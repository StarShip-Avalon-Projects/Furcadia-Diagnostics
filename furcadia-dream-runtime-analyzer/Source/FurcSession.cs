/*** FurcSession.cs
 * 
 * Furcadia Online Session Class (c) 2009 by IceDragon of QuickFox.org
 * 
 * <icedragon@quickfox.org>
 * http://www.icerealm.org
 * 
 * This module handles an asynchroneous connection to Furcadia and data I/O.
 * 
 * Requirements:
 *   - Furcadia.Character for login information management
 * 
 * ChangeLog:
 *   20090909 - Initial Release.
 * 
 * Furcadia is (c) 1996-Present Day by Dragon's Eye Productions
 */

using System;
using System.Timers;
using System.Net;
using System.Net.Sockets;
using System.Collections.Generic;
using System.Text;

namespace Furcadia
{
    class FurcSession
    {
        /*
         *** Constants
         */
        // Default info that we will use unless otherwise specified.
        public const string DEFAULT_ADDRESS = "lightbringer.furcadia.com";
        public const ushort DEFAULT_PORT = 6500;
        public const double DEFAULT_KEEPALIVE = 30000.0; // (ms) 5 minutes

        // Status text we will use to notify of certain events.
        public const string TEXT_LOGIN_SUCCESS = "Login successful!";
        public const string TEXT_LOGIN_FAIL = "Login failed - aborting!";
        public const string TEXT_DISCONNECTED = "Disconnected.";
        public const string TEXT_CONNECTION_LOST = "Connection to remote server terminated.";
        
        public const string TEXT_KEEPALIVE = "iamhere"; // Keepalive string

        /*
         *** Data Members
         */
        private string sHostname = DEFAULT_ADDRESS;
        private ushort nPort = DEFAULT_PORT;

        private bool bLoginSuccessful = false;
        private Character chrFurcCharacter; // Furcadia character info.
        private Socket sock;
        private Timer tKeepAlive;

        protected Queue<string> qProgressLog = new Queue<string>(); // I/O pipe for async status.
        protected Queue<string> qPendingInstructions = new Queue<string>();

        /*
         *** Properties
         */
        /// <summary>
        /// Get the next available status message as a string or NULL if not
        /// available. Once retrieved, this message will no longer be available
        /// and it will be replaced by the next message waiting in line!
        /// </summary>
        public string NextStatus
        {
            get { return HasNextStatus ? qProgressLog.Dequeue() : null; }
        }
        /// <summary>
        /// TRUE if there are pending status messages. The message itself can
        /// be retrieved with the NextStatus property.
        /// </summary>
        public bool HasNextStatus
        {
            get { return (qProgressLog.Count > 0); }
        }
        /// <summary>
        /// Get the next available raw server instruction as a string or NULL
        /// if not available. Once retrieved, this instruction will no longer
        /// be available and it will be replaced by the next instruction
        /// waiting in line!
        /// </summary>
        public string NextInstruction
        {
            get { return HasNextInstruction ? qPendingInstructions.Dequeue() : null; }
        }
        /// <summary>
        /// TRUE if there are pending server instructions. The data itself can
        /// be retrieved with the NextInstruction property.
        /// </summary>
        public bool HasNextInstruction
        {
            get { return (qPendingInstructions.Count > 0); }
        }
        /// <summary>
        /// TRUE if the session has successfully logged in.
        /// </summary>
        public bool IsLoginSuccessful
        {
            get { return bLoginSuccessful; }
        }
        /// <summary>
        /// Get or set the Furcadia server address to see or change where does
        /// the session connect to.
        /// </summary>
        public string Address
        {
            get { return sHostname; }
            set { SetAddress(value); }
        }
        /// <summary>
        /// Get or set the Furcadia server port to see or change where does the
        /// session connect to.
        /// </summary>
        public ushort Port
        {
            get { return nPort; }
            set { SetPort(value); }
        }
        /// <summary>
        /// TRUE if the session can attempt to connect. If the session is not
        /// ready to beconnected, FALSE is returned. One of the reasons is
        /// lack of character login information which has to be specified.
        /// </summary>
        public bool CanConnect
        {
            get { return IsReady(); }
        }
        /// <summary>
        /// TRUE if the session is currently connected to the remote server.
        /// </summary>
        public bool Connected
        {
            get { return (sock != null) ? sock.Connected : false; }
        }


        /*
         *** Constructors
         */
        public FurcSession()
        {
        }
        public FurcSession(Character chr)
            : this(DEFAULT_ADDRESS, DEFAULT_PORT, chr)
        {
        }
        public FurcSession(string hostname, ushort port, Character chr)
        {
            chrFurcCharacter = chr;
            sHostname = hostname;
            nPort = port;
        }


        /*
         *** Data Manipulation Methods
         */
        /// <summary>
        /// Sets/changes the current Character object used to log in.
        /// </summary>
        /// <param name="ch">Character object</param>
        public void SetCharacter(Character ch)
        {
            chrFurcCharacter = ch;
        }
        /// <summary>
        /// Sets a new Furcadia character name, used for login.
        /// </summary>
        /// <param name="newName">New character name</param>
        public void SetCharacterName(string newName)
        {
            HasCharacterInstance(true); // Ensure we have a Character object available
            chrFurcCharacter.LongName = newName;
        }
        /// <summary>
        /// Sets a new Furcadia character password, used for login.
        /// </summary>
        /// <param name="newPass">New character password</param>
        public void SetCharacterPassword(string newPass)
        {
            HasCharacterInstance(true); // Ensure we have a Character object available
            chrFurcCharacter.Password = newPass;
        }
        /// <summary>
        /// Sets a new address to connect to instead of the default one.
        /// </summary>
        /// <param name="newAddress">New address to connect to</param>
        public void SetAddress(string newAddress)
        {
            sHostname = newAddress;
        }
        /// <summary>
        /// Sets a new port number to connect to instead of the default one.
        /// 
        /// NOTE: If you specify the port number 0, this function will throw an
        ///       exception.
        /// </summary>
        /// <param name="port">New port number between 1 and 65535 (inclusive)</param>
        public void SetPort(ushort port)
        {
            if (port == 0)
                throw new Exception("FurcSession::SetPort(): Illegal port (0) specified");

            nPort = port;
        }


        /*
         *** Miscellaneous Methods
         */
        /// <summary>
        /// Check if this object is ready to connect to Furcadia.
        /// </summary>
        /// <returns>TRUE if we can connect now or FALSE if something is missing.</returns>
        public bool IsReady()
        {
            // If we're already connect, we can't be ready.
            if (Connected)
                return false;

            // If they didn't specify the character data, we're not ready.
            if (chrFurcCharacter == null ||
                chrFurcCharacter.ShortName == "" ||
                chrFurcCharacter.Password == "")
                return false;

            // Ready to go!
            return true;
        }
        /// <summary>
        /// Connect to Furcadia and begin asynchroneous session. The method
        /// returns as soon as the connection phase is complete and may throw
        /// an exception if something went wrong.
        /// </summary>
        public void Connect()
        {
            bLoginSuccessful = false;

            // Check if we're ready or throw - they should've ensure this!
            if (!CanConnect)
                throw new Exception("FurcSession::Connect(): Attempted to connect when not ready");

            sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            // Result hostname.
            AddStatus("Resolving hostname " + sHostname);
            IPAddress[] ipAddresses = Dns.GetHostAddresses(sHostname);

            // Create an endpoint and connect.
            qProgressLog.Enqueue("Connecting to Furcadia game server...");
            IPEndPoint ep = new IPEndPoint(ipAddresses[0], nPort);
            sock.Connect(ep);
            if (!sock.Connected)
                new Exception("Unable to connect to remote server");

            // Begin Async operation
            AddStatus("Awaiting server introduction...");
            BeginAsyncOperation();
        }
        /// <summary>
        /// Disconnect from Furcadia and end the session.
        /// </summary>
        public void Disconnect()
        {
            // Clear keepalive timer.
            ClearKeepaliveTimer();

            // Shut off the socket.
            if (sock != null)
                sock.Disconnect(false);

            // Clear pending instruction queue.
            ClearInstructionQueue();
            AddStatus(TEXT_DISCONNECTED);
        }
        /// <summary>
        /// Dispatch a data string that came from the server. Until the session
        /// logs in, all data from the server is automatically passed to this
        /// method. Afterwards, it is up to the program using this session to
        /// pass data into here if it wants the data to be handled.
        /// </summary>
        /// <param name="data">Data string (without the \n)</param>
        /// <returns>TRUE if the data was handled by this function, FALSE if it was ignored.</returns>
        public bool Dispatch(string data)
        {
            // If it's a blank string, just don't do anything about it.
            if (data.Length == 0)
                return false;

            // Incoming chatbox text
            if (data.StartsWith("("))
            {
                AddStatus("*** TEXT: " + data.Substring(1));
                return true;
            }

            // Incoming request to download and confirm a dream package
            if (data.StartsWith("]q"))
            {
                SendLine("vascodagama");
                return true;
            }

            // Incoming popup dialog - might be for ACCESS DENIED
            if (data.StartsWith("]#"))
            {
                AddStatus("*** POPUP: " + data.Substring(2));
                return true;
            }

            // These are only relevant when logging in.
            if (!bLoginSuccessful)
            {
                // Incoming Dragonroar (request to authenticate).
                if (data == "Dragonroar")
                {
                    AddStatus("Received challenge - logging in...");
                    SendLine("connect " + chrFurcCharacter.LongName + " " + chrFurcCharacter.Password);
                    return true;
                }

                // Incoming ACCESS GRANTED notification
                if (data.StartsWith("&&&&&&&"))
                {
                    bLoginSuccessful = true;
                    AddStatus(TEXT_LOGIN_SUCCESS);
                    SendLine("color " + chrFurcCharacter.ColorString);
                    SendLine("desc " + chrFurcCharacter.Description);
                    SetKeepaliveTimer();

                    // Return 
                    return true;
                }

                // Incoming ACCESS DENIED instruction
                if (data.StartsWith("]]"))
                {
                    bLoginSuccessful = false;
                    AddStatus(TEXT_LOGIN_FAIL);
                    return true;
                }
            }

            return false;
        }


        /*
         *** Data I/O Methods
         */
        /// <summary>
        /// Transmits a string to the server as a single line. If an error
        /// occurs, an exception is thrown.
        /// </summary>
        /// <param name="line">Data string</param>
        public void SendLine(string line)
        {
            SendLine(line, true);
        }
        /// <summary>
        /// Transmits a string to the server as a single line. If an error
        /// occurs and the throwOnError parameter is set, an exception is
        /// thrown. The error is ignored otherwise.
        /// </summary>
        /// <param name="line">Data string</param>
        /// <param name="throwOnError">TRUE if the function should throw on error (TRUE by default)</param>
        public void SendLine(string line, bool throwOnError)
        {
            Send(line + "\n", throwOnError);
        }
        /// <summary>
        /// Transmits a string to the server without line termination character
        /// at the end. If an error occurs, an exception is thrown.
        /// </summary>
        /// <param name="line">Data string</param>
        public void Send(string line)
        {
            Send(line, true);
        }
        /// <summary>
        /// Transmits a string to the server without line termination character
        /// at the end. If an error occurs and the throwOnError parameter is
        /// set, an exception is thrown. The error is ignored otherwise.
        /// </summary>
        /// <param name="line">Data string</param>
        /// <param name="throwOnError">TRUE if the function should throw on error (TRUE by default)</param>
        public void Send(string line, bool throwOnError)
        {
            if (sock != null && sock.Connected)
            {
                byte[] buffer = Encoding.ASCII.GetBytes(line.ToCharArray());
                try
                {
                    sock.Send(buffer);
                }
                catch (Exception e)
                {
                    if (throwOnError)
                        throw e;
                }

                return;
            }

            if (throwOnError)
                throw new Exception("FurcSession::Send(): Socket not found or disconnected");
        }


        /*
         *** Helper Methods (PRIVATE)
         */
        private bool HasCharacterInstance()
        {
            return HasCharacterInstance(false); // FALSE by default
        }
        private bool HasCharacterInstance(bool createIfNotExists)
        {
            if (chrFurcCharacter != null)
                return true;

            if (createIfNotExists)
                chrFurcCharacter = new Character();

            return false;
        }

        private void ClearInstructionQueue()
        {
            qPendingInstructions.Clear();
        }
        private void AddInstruction(string newInstr)
        {
            qPendingInstructions.Enqueue(newInstr);
        }
        private void AddStatus(string newStatus)
        {
            qProgressLog.Enqueue(newStatus);
        }

        private void SetKeepaliveTimer()
        {
            ClearKeepaliveTimer();

            tKeepAlive = new Timer(DEFAULT_KEEPALIVE);
            tKeepAlive.AutoReset = true;
            tKeepAlive.Elapsed += new ElapsedEventHandler(tKeepAlive_Elapsed);
            tKeepAlive.Start();
        }
        private void ClearKeepaliveTimer()
        {
            if (tKeepAlive != null)
            {
                tKeepAlive.Stop();
                tKeepAlive.Close();
                tKeepAlive = null;
            }
        }
        private void tKeepAlive_Elapsed(object sender, ElapsedEventArgs e)
        {
            SendLine(TEXT_KEEPALIVE, false);
        }

        private void BeginAsyncOperation()
        {
            StateObject so = new StateObject();
            sock.BeginReceive(so.buffer, 0, StateObject.BUFFER_SIZE, SocketFlags.None, this.HandleIncomingData, so);
        }
        private void HandleIncomingData(IAsyncResult ar)
        {
            StateObject so = (StateObject)ar.AsyncState;

            int rx = sock.EndReceive(ar);

            if (rx > 0)
            {
                so.sb.Append(Encoding.ASCII.GetString(so.buffer, 0, rx));
                string tmpString = so.sb.ToString();
                if (tmpString.Contains("\n"))
                {
                    string[] lines = tmpString.Split('\n');

                    // Doing this like that because I don't want to do if()
                    // every loop cycle. Should be faster.
                    if (bLoginSuccessful)
                    {
                        for (int i = 0; i < lines.Length - 1; i++)
                            AddInstruction(lines[i]);
                    }
                    else
                    {
                        for (int i = 0; i < lines.Length - 1; i++)
                            Dispatch(lines[i]);
                    }

                    so.sb.Remove(0, so.sb.Length);
                    so.sb.Append(lines[lines.Length - 1]);
                    BeginAsyncOperation();
                }
            }
            else
            {
                AddStatus(TEXT_CONNECTION_LOST);
                Disconnect();
                sock = null;
            }
        }
    }

    class StateObject
    {
        public const int BUFFER_SIZE = 4096;
        public byte[] buffer = new byte[BUFFER_SIZE];
        public StringBuilder sb = new StringBuilder("");
    }
}
