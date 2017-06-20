using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;

namespace Heimdall_Tester
{
    public enum Phase
    {
        Init,
        Connecting,
        MOTD,
        Auth,
        Connected,
        Disconnected
    }

    public class HeimdallCheck
    {
        #region Public Fields

        public const int MAX_CHARNAME_LENGTH = 40;
        public const int MAX_PASSWORD_LENGTH = 32;
        public const int MAX_QUEUE_LENGTH = 1000;
        public const int RECV_BUFFER_LENGTH = 4096;
        // Lines

        /** Members **/

        // Connectivity/Login Settings
        public string Address = "lightbringer.furcadia.com";

        public ushort Port = 6665;

        #endregion Public Fields

        #region Private Fields

        // Check results (everything is considered down by default)
        private bool bHeimdall = false;

        private bool bHorton = false;
        private bool bIsRunning = false;
        private bool bPingSent = false;
        private bool bShouldDisconnect = false;
        private bool bTestComplete = false;
        private bool bTribble = false;
        private byte[] buffer = new byte[RECV_BUFFER_LENGTH];
        private DateTime dtWhichRequestTime = DateTime.MinValue;
        private ushort nHeimdallId = 0;
        private ushort nHeimdallQTEMP = 0;
        private ushort nHortonQTEMP = 0;
        private int nTaken = 0;
        private ushort nTribbleQTEMP = 0;
        private Phase phase = Phase.Init;

        // Check status
        private Queue<string> qIO = new Queue<string>();

        private string sErrorMessage = null;

        // Connection/Login Data
        private Socket sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        private string sPassword = "Unknown";
        private string sUsername = "Unknown";

        #endregion Private Fields

        /** Properties **/

        #region Public Constructors

        public HeimdallCheck()
        {
        }

        #endregion Public Constructors

        #region Public Properties

        public bool Complete { get { return bTestComplete; } }
        public Phase ConnectionPhase { get { return phase; } }
        public bool Error { get { return (sErrorMessage != null); } }
        public string ErrorMessage { get { return sErrorMessage; } }
        public bool HasEverything { get { return bHeimdall && bHorton && bTribble; } }
        public bool HasHeimdall { get { return bHeimdall; } }
        public bool HasHorton { get { return bHorton; } }
        public bool HasTribble { get { return bTribble; } }
        public int HeimdallNumber { get { return nHeimdallId; } }
        public int HeimdallQTEMP { get { return nHeimdallQTEMP; } }
        public int HortonQTEMP { get { return nHortonQTEMP; } }
        public string Name { get { return sUsername; } }

        public string NextLine
        {
            get { return (qIO.Count > 0) ? qIO.Dequeue() : null; }
        }

        public bool Running { get { return bIsRunning; } }
        public int TribbleQTEMP { get { return nTribbleQTEMP; } }

        #endregion Public Properties

        /** Constructor **/
        /** Methods **/

        #region Public Methods

        public void ConnectCallback(IAsyncResult ar)
        {
            if (sock.Connected)
            {
                phase = Phase.MOTD;
                sock.NoDelay = true;
                BeginReceive();
            }
            else
            {
                sErrorMessage = "Unable to connect";
                Disconnect();
            }
        }

        public void ReceiveCallback(IAsyncResult ar)
        {
            string line;
            int size;

            // If the socket was already disposed of, get out of here.
            try
            {
                size = sock.EndReceive(ar);
            }
            catch
            {
                return;
            }

            if (size > 0)
            {
                nTaken += size;
                do
                {
                    line = GetLineFromBuffer(false);
                    if (line != null)
                        HandleLine(line);
                } while (line != null);

                // This one will throw an exception if the socket is already
                // gone. We don't really care if it is, it should be in a
                // Disconnected phase by then.
                try
                {
                    BeginReceive();
                }
                catch
                {
                    // Do nothing
                }
            }
            else
            {
                if (nTaken > 0)
                    HandleLine(GetLineFromBuffer(true)); // Forced operation
                Disconnect();
                bTestComplete = true;
            }
        }

        public void SetAddress(string address, ushort port)
        {
            // Sanity check
            if (port == 0)
                throw new System.ArgumentOutOfRangeException("Port is out of range");
            Address = address;
            Port = port;
        }

        public void SetLogin(string charName, string charPassword)
        {
            // Make sure the values are in range.
            if (charName.Length > MAX_CHARNAME_LENGTH)
                throw new Exception("Character name is too long");
            if (charPassword.Length > MAX_PASSWORD_LENGTH)
                charPassword = charPassword.Substring(0, MAX_PASSWORD_LENGTH);

            // Set the values in the members.
            sUsername = charName.Replace(' ', '|');
            sPassword = charPassword.Replace(' ', '_');
        }

        /// <summary>
        /// Start the check procedure.
        /// </summary>
        public void Start()
        {
            // If this one was already started, we can't start it again -
            // most of the data is screwed up!
            if (phase != Phase.Init)
                throw new Exception("Cannot restart an already used instance");

            bIsRunning = true;

            // Begin a connection attempt.
            phase = Phase.Connecting;
            sock.BeginConnect(Address, Port, new AsyncCallback(ConnectCallback), null);
        }

        /// <summary>
        /// Stop the check procedure prematurely.
        /// NOTE: Start()ing it again is NOT advised!
        /// </summary>
        public void Stop()
        {
            Disconnect();
            sErrorMessage = "Check stopped";
        }

        #endregion Public Methods

        /** Helper Methods (PRIVATE) **/

        #region Private Methods

        private void AddLine(string line)
        {
            if (qIO.Count >= MAX_QUEUE_LENGTH)
                qIO.Dequeue();
            qIO.Enqueue(line);
        }

        private void BeginReceive()
        {
            sock.BeginReceive(buffer, nTaken, RECV_BUFFER_LENGTH - nTaken, SocketFlags.None, new AsyncCallback(ReceiveCallback), null);
        }

        private void Disconnect()
        {
            if (sock.Connected)
                sock.Close();
            phase = Phase.Disconnected;
            bIsRunning = false;
        }

        private ushort GetHeimdallId(string line)
        {
            int iNumStart = line.IndexOf(':') + 1;
            int iCloseBrace = line.IndexOf(']', iNumStart);
            return Convert.ToUInt16(line.Substring(iNumStart, iCloseBrace - iNumStart));
        }

        private string GetLineFromBuffer(bool forced)
        {
            string line = null;

            if (nTaken > 0)
            {
                // Find a line break character.
                int i = 0;
                for (; i < nTaken; i++)
                {
                    if (buffer[i] == '\n')
                    {
                        line = Encoding.ASCII.GetString(buffer, 0, i);
                        break;
                    }
                }

                // If we took out a line, collapse the buffer.
                if (line != null)
                {
                    int j = 0;
                    i++; // Skip the \n

                    while (i < nTaken)
                        buffer[j++] = buffer[i++];

                    nTaken = j;
                    return line;
                }

                // If we don't have a line and it's a forced request, give
                // them what's left in the buffer.
                if (forced)
                {
                    nTaken = 0;
                    return Encoding.ASCII.GetString(buffer, 0, nTaken);
                }
            }

            return null;
        }

        private ushort GetQTEMP(string line)
        {
            int iNumStart = line.IndexOf("(QTEMP") + 7;
            int iCloseBrace = line.IndexOf(')', iNumStart);
            return Convert.ToUInt16(line.Substring(iNumStart, iCloseBrace - iNumStart));
        }

        //--- Even Handlers (Callback Functions)
        private void HandleLine(string line)
        {
            //AddLine("DEBUG: " + line);
            switch (phase)
            {
                case Phase.MOTD:
                    if (line.Contains("Dragonroar"))
                    {
                        phase = Phase.Auth;
                        Send(String.Format("connect {0} {1}\n", sUsername, sPassword));
                    }
                    break;

                case Phase.Auth:
                    if (line.StartsWith("]#"))
                    {
                        char[] sep = { ' ' };
                        string[] tokens = line.Split(sep, 3);
                        sErrorMessage = tokens[2];
                    }
                    else if (line.StartsWith("]]"))
                    {
                        Disconnect();
                        bIsRunning = false;
                    }
                    else if (line.StartsWith("&&&&&"))
                    {
                        phase = Phase.Connected;

                        // Send a `which now!
                        Send("which\n");
                        dtWhichRequestTime = DateTime.Now;
                    }
                    break;

                case Phase.Connected:
                    // If we should disconnect, do it.
                    if (bShouldDisconnect)
                    {
                        Disconnect();
                        bShouldDisconnect = false;
                    }

                    // If we didn't send a ping yet, do it, but not before
                    // the "safe distance" in time from the `which request
                    // or the "(Pong." response will arrive too soon!
                    if (!bPingSent && ((DateTime.Now - dtWhichRequestTime).TotalMilliseconds >= 1000))
                    {
                        Send("ping\n");
                        bPingSent = true;
                    }

                    // Remove any markup tags they may have shoved in there.
                    string line_clean = RemoveTags(line);

                    // Check for heimdall message.
                    if (line_clean.StartsWith("( You are connected to Heimdall"))
                    {
                        // This will be 0 if we can't extract the data.
                        nHeimdallId = GetHeimdallId(line_clean);
                        nHeimdallQTEMP = GetQTEMP(line_clean);
                        bHeimdall = true;
                    }
                    else if (line_clean.StartsWith("( You are connected to Horton"))
                    {
                        bHorton = true;
                        nHortonQTEMP = GetQTEMP(line_clean);
                    }
                    else if (line_clean.StartsWith("( You are connected to tribble"))
                    {
                        bTribble = true;
                        nTribbleQTEMP = GetQTEMP(line_clean);
                    }
                    else if (line_clean.StartsWith("(Pong"))
                    {
                        // Time to disconnect!
                        bShouldDisconnect = true;
                        Send("quit\n");
                    }

                    // Override the (Pong waiting if we have all the three online.
                    if (!bShouldDisconnect && HasEverything)
                    {
                        // Time to disconnect!
                        bShouldDisconnect = true;
                        Send("quit\n");
                    }

                    break;

                case Phase.Disconnected:
                    // Do nothing - we're disconnected...
                    break;

                default:
                    throw new Exception("Unidentified connection phase");
            }
        }

        private string RemoveTags(string data)
        {
            StringBuilder sb = new StringBuilder();
            bool ignoring = false;
            for (int i = 0; i < data.Length; i++)
            {
                if (ignoring)
                {
                    if (data[i] == '>')
                    {
                        ignoring = false;
                    }
                }
                else if (data[i] == '<')
                {
                    ignoring = true;
                }
                else
                {
                    sb.Append(data[i]);
                }
            }
            return sb.ToString();
        }

        private void Send(string data)
        {
            // If the socket was already disposed, we don't care.
            try
            {
                sock.Send(Encoding.ASCII.GetBytes(data));
            }
            catch
            {
                // Do nothing
            }
        }

        #endregion Private Methods
    }
}