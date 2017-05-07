/*** Analyzer.cs
 * 
 * Furcadia Data Analyzer Class (c) 2009 by IceDragon of QuickFox.org
 * 
 * <icedragon@quickfox.org>
 * http://www.icerealm.org
 * 
 * This module handles data analysis of passed to it Furcadia protocol
 * data.
 * 
 * Requirements:
 *   - Furcadia.Numeric for base95 conversion
 * 
 * ChangeLog:
 *   20090909 - Initial Release.
 * 
 * Furcadia is (c) 1996-Present Day by Dragon's Eye Productions
 */

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

using Furcadia;

namespace Dream_Runtime_Analyzer
{
    /// <summary>
    /// Furcadia Data Analyzer Class
    /// </summary>
    public class Analyzer
    {
        // Constantly incrementing capture IDs for visual purposes (naming).
        private static int dcid = 0;

        /*
         *** Data Members
         */
        // Tells whether a capture was started.
        private bool bStarted = false;

        // Tells whether the data is timestamped:
        // TSCF == TimeStamped Capture File
        private bool bIsTSCF = false;

        // Capture title - commonly contains the filepath or a simple title.
        private string sTitle;

        // Timestamp of the first and last processed line.
        private DateTime dtStart;
        private DateTime dtLast;

        // Size of the longest instruction.
        private ushort nLongestInstructionLength = 0;

        // Average line-per-instruction spread.
        private float nAvgLinePerInstruction = 0.0F;

        // Amount of bytes captured in DS-related instructions + instruction count.
        private ulong nDsBytes = 0;
        private uint nDsCount = 0;

        // Amount of bytes captured for avatar manipulation + instruction count.
        // Instructions: < A B C D / )
        private ulong nAvatarBytes = 0;
        private uint nAvatarCount = 0;

        // The rest of the bandwidth captured.
        // Initialized to 1 to avoid DivByZero errors with bandwidth calculation.
        private ulong nOtherBytes = 1;

        // Sorted storage of DS Line and Instruction frequencies.
        private SortedDictionary<ushort, uint> lnFrequency = new SortedDictionary<ushort, uint>();
        private SortedDictionary<char, uint> instrFrequency = new SortedDictionary<char, uint>();


        /*
         *** Properties
         */
        /// <summary>
        /// Get or set the title of the Analyzer instance.
        /// </summary>
        public string Title
        {
            get { return sTitle; }
            set { sTitle = value; }
        }

        //--- Instruction Counters
        /// <summary>
        /// Gets the amount of Avatar-related instructions received so far.
        /// </summary>
        public uint AvatarCount
        {
            get { return nAvatarCount; }
        }
        /// <summary>
        /// Gets the amount of DragonSpeak-related instructions received so far.
        /// </summary>
        public uint DsCount
        {
            get { return nDsCount; }
        }
        /// <summary>
        /// Gets the amount of 6/7 instructions (SixTrigger and SevenTrigger)
        /// received so far. These instructions have the same syntax (except
        /// for the first byte) and are responsible for DS line execution
        /// requests.
        /// </summary>
        public uint SixSevenTriggerCount
        {
            get { return GetInstructionFrequency('6') + GetInstructionFrequency('7'); }
        }
        /// <summary>
        /// Get the amount of empty instructions received so far. Empty
        /// instructions (empty lines) contain nothing in them but the NewLine
        /// (\n) character.
        /// </summary>
        public uint EmptyInstructionCount { get { return GetInstructionFrequency('\0'); } }

        //--- Bandwidth Counters
        public ulong DsBytes { get { return nDsBytes; } }
        public ulong AvatarBytes { get { return nAvatarBytes; } }
        public ulong OtherBytes { get { return nOtherBytes; } }
        public ulong TotalBytes { get { return AvatarBytes + DsBytes + OtherBytes; } }

        //--- Bandwidth Percentage
        public double DsPercentage { get { return ((double)DsBytes / TotalBytes) * 100; } }
        public double AvatarPercentage { get { return ((double)AvatarBytes / TotalBytes) * 100; } }
        public double OtherPercentage { get { return ((double)OtherBytes / TotalBytes) * 100; } }

        //--- Data Access
        public SortedDictionary<uint, List<ushort>> LinesByFrequency
        {
            get { return GetLineTableByFrequency(); }
        }
        public SortedDictionary<uint, List<char>> InstructionsByFrequency
        {
            get { return GetInstructionTableByFrequency(); }
        }
        public SortedDictionary<ushort, uint> Lines
        {
            get { return GetLineTableByLine(); }
        }
        public SortedDictionary<char, uint> Instructions
        {
            get { return GetInstructionTableByInstruction(); }
        }

        //--- Time-dependent Data
        /// <summary>
        /// TRUE if data timestamping is available during capture, or the file
        /// loaded was a timestamped file. This does not necessarily mean that
        /// there is timed information available yet (which you check with the
        /// IsTimeAvailable property), it just mean that the format or code
        /// that gathers information uses timestamping.
        /// </summary>
        public bool IsTimeStamped
        {
            get { return bIsTSCF; }
        }
        /// <summary>
        /// TRUE if time-dependent information such as the average speed is
        /// available. If the capture loaded does not support timestamping
        /// (IsTimeStamped being FALSE), this will be FALSE as long as that
        /// condition exists.
        /// </summary>
        public bool IsTimeAvailable
        {
            get { return (bStarted && RunTimeSeconds > 0); }
        }
        /// <summary>
        /// Gets the TimeSpan class that represents how long the data capture
        /// has been running. This value gets updated each time new data got
        /// processed!
        /// 
        /// NOTE: If the IsTimeAvailable property is FALSE, this information
        ///       should be considered unavailable!
        /// </summary>
        public TimeSpan RunTime
        {
            get { return dtLast.Subtract(dtStart); }
        }
        /// <summary>
        /// Gets the amount of seconds for how long the data capture has been
        /// running. This value gets updated each time new data got processed!
        /// 
        /// NOTE: If the IsTimeAvailable property is FALSE, this information
        ///       should be considered unavailable!
        /// </summary>
        public uint RunTimeSeconds
        {
            get { return (uint)RunTime.TotalSeconds; }
        }
        /// <summary>
        /// Gets the average speed (in KB/sec, where KB=1024 bytes) the
        /// information was received in. The value relies on the speed that
        /// data was fed into the Analyzer object! If is was readen from a
        /// file that does not support timestamps, and was timestamped as it
        /// was read, this information can be incorrect - it will correspond
        /// to the reading speed rather than the speed it was captured in!
        ///
        /// NOTE: If the IsTimeAvailable property is FALSE, this information
        ///       should be considered unavailable!
        /// </summary>
        public double AvgSpeed
        {
            get { return GetAvgSpeed(); }
        }

        //--- Miscellaneous
        /// <summary>
        /// Gets the length in bytes of the longest instruction known.
        /// </summary>
        public ulong LongestInstructionLength { get { return nLongestInstructionLength; } }
        /// <summary>
        /// Gets the average DragonSpeak line spread across a single Six/Seven
        /// Trigger.
        /// </summary>
        public float AvgLineSpread { get { return nAvgLinePerInstruction; } }

        
        /*
         *** Constructors
         */
        public Analyzer() : this(false)
        {
        }
        /// <summary>
        /// Initialize the Analyzer object while specifying whether timestamping
        /// support is intended.
        /// 
        /// NOTE: The isTimestamped setting loses its effect when a file is
        ///       loaded from disk. It is re-evaluated when that happens!
        /// </summary>
        /// <param name="isTimestamped">TRUE if timestamping will be supported</param>
        public Analyzer(bool isTimestamped)
        {
            sTitle = String.Format("<Data Capture {0}>", dcid++);
            bIsTSCF = true;
        }
        /// <summary>
        /// Initialize the Analyzer object and load a specific data file.
        /// 
        /// NOTE: An exception may be thrown if the loading operation fails!
        /// </summary>
        /// <param name="filename"></param>
        public Analyzer(string filename)
        {
            // To save time, don't reset twice - we know it's already initialized
            // so it will concatenate to nothing.
            Load(filename,true);
        }


        /*
         *** Internal Data Maintenance Methods
         */
        /// <summary>
        /// Reset the data stored in this object and prepare it for a new
        /// capture session.
        /// </summary>
        public void Reset()
        {
            lnFrequency.Clear();
            instrFrequency.Clear();
            nLongestInstructionLength = 0;
            nAvgLinePerInstruction = 0;
            nDsBytes = 0;
            nDsCount = 0;
            nAvatarBytes = 0;
            nAvatarCount = 0;
            nOtherBytes = 0;
            bStarted = false;
            bIsTSCF = false;
            sTitle = String.Format("<Data Capture {0}>", dcid++);
        }


        /*
         *** File I/O Methods
         */
        /// <summary>
        /// Load raw data from a file.
        /// </summary>
        /// <param name="filename">Filename to load the data from</param>
        public void Load(string filename)
        {
            // Don't concatenate by default.
            Load(filename, false);
        }
        /// <summary>
        /// Load raw data from a file and optionally concatenate it to the
        /// data already present so far.
        /// </summary>
        /// <param name="filename">Filename to load the data from</param>
        /// <param name="concat">TRUE if we should add the data to the current one (FALSE by default)</param>
        public void Load(string filename, bool concat)
        {
            // Reset the values if concatenation is not desired.
            if( !concat )
                Reset();

            using (TextReader tr = new StreamReader(filename, Encoding.ASCII))
            {
                Title = filename;
                bIsTSCF = false;
                string buffer = tr.ReadLine();

                if (buffer == null)
                    return;

                if (buffer.StartsWith("TSCF"))
                {
                    bIsTSCF = true;
                    while (true)
                    {
                        buffer = tr.ReadLine();
                        if (buffer == null)
                            break;

                        ProcessTimestamped(buffer.TrimEnd('\n'));
                    }
                }
                else
                {
                    while (true)
                    {
                        Process(buffer.TrimEnd('\n'));

                        buffer = tr.ReadLine();
                        if (buffer == null)
                            break;
                    }
                }
            }
        }


        /*
         *** Data Processing Methods
         */
        /// <summary>
        /// Process a raw Furcadia instruction with a timestamp of its occurence.
        /// 
        /// NOTE: Supply the instruction WITHOUT the trailing \n character!
        /// </summary>
        /// <param name="data">Instruction data (with the trailing \n stripped)</param>
        /// <param name="timestamp">Timestamp of the data being received</param>
        public void Process(string data, DateTime timestamp)
        {
            uint len = (uint)data.Length;

            // If this is the first instruction we receive, write down the
            // start time.
            if (!bStarted)
            {
                bStarted = true;
                dtStart = timestamp;
            }

            dtLast = timestamp;

            // If the string is empty, just count it and return.
            if( len == 0 )
            {
                nOtherBytes++; // The \n takes one byte
                AddInstruction('\0'); // We'll use NUL to count empty ones.
                return;
            }

            // See if this is bigger than maximal.
            if (len >= nLongestInstructionLength)
                nLongestInstructionLength = (ushort)(len + 1);

            // Add instruction to the counter.
            char instr = data[0];
            AddInstruction(instr);

            // Is it an avatar instruction?
            if (IsAvatarInstruction(instr))
            {
                nAvatarCount++;
                nAvatarBytes += 1 + len;
                return;
            }

            // Is it a DS instruction?
            if (IsDsInstruction(instr))
            {
                nDsCount++;
                nDsBytes += 1 + len;

                // If it's 6 or 7, parse it.
                if (instr == '6' || instr == '7')
                    ParseDsTrigger(data);

                return;
            }

            // All the rest are just counted up.
            nOtherBytes += 1 + len;
        }
        /// <summary>
        /// Process a raw Furcadia instruction.
        /// 
        /// NOTE: Supply the instruction WITHOUT the trailing \n character!
        /// NOTE: In a timestamped environment, a lack of the timestamp parameter
        ///       after 'data' places the current timestamp by default!
        /// </summary>
        /// <param name="data">Instruction data (with the trailing \n stripped)</param>
        public void Process(string data)
        {
            Process(data, DateTime.Now);
        }
        /// <summary>
        /// Process a formatted data string with a UNIX timestamp at the
        /// beginning.
        /// </summary>
        /// <param name="data">Timestamped raw data from a TSCF file.</param>
        public void ProcessTimestamped(string data)
        {
            string[] sep = { " " };
            string[] param = data.Split(sep, 2, StringSplitOptions.None);

            DateTime ts = new DateTime(1970, 1, 1, 0, 0, 0).AddSeconds(Convert.ToUInt32(param[0]));
            Process(param[1], ts);
        }


        /*
         *** Frequency Table Retrieval Methods
         */
        /// <summary>
        /// Returns a sorted dictionary for DragonSpeak lines, sorted by the
        /// frequency of each line in a descending order (from most frequent to
        /// the least frequent).
        /// </summary>
        /// <returns>
        /// A SortedDictionary which uses the line execution frequency as the
        /// key and a list of DS line numbers as the value.
        /// </returns>
        public SortedDictionary<uint, List<ushort>> GetLineTableByFrequency()
        {
            SortedDictionary<uint, List<ushort>> dsLineTable = new SortedDictionary<uint, List<ushort>>(new ReverseComparer<uint>());

            foreach (ushort ln in lnFrequency.Keys)
            {
                uint freq = lnFrequency[ln];
                if (!dsLineTable.ContainsKey(freq))
                    dsLineTable[freq] = new List<ushort>();
                dsLineTable[freq].Add(ln);
            }

            return dsLineTable;
        }
        /// <summary>
        /// Returns a sorted dictionary for DragonSpeak lines, sorted by the
        /// line number in an ascending order (from the first line to the last).
        /// </summary>
        /// <returns>
        /// A SortedDictionary which uses the line number as the key and its
        /// execution frequency as the value.
        /// </returns>
        public SortedDictionary<ushort, uint> GetLineTableByLine()
        {
            return lnFrequency;
        }
        /// <summary>
        /// Returns a sorted dictionary for server instructions, sorted by the
        /// frequency of each instruction in a descending order (from most
        /// frequent to the least frequent).
        /// </summary>
        /// <returns>
        /// A SortedDictionary which uses the instruction frequency as the key
        /// and a list of instruction bytes as the value.
        /// </returns>
        public SortedDictionary<uint, List<char>> GetInstructionTableByFrequency()
        {
            SortedDictionary<uint, List<char>> instrTable = new SortedDictionary<uint, List<char>>(new ReverseComparer<uint>());

            foreach (char instr in instrFrequency.Keys)
            {
                uint freq = instrFrequency[instr];
                if (!instrTable.ContainsKey(freq))
                    instrTable[freq] = new List<char>();
                instrTable[freq].Add(instr);
            }

            return instrTable;
        }
        /// <summary>
        /// Returns a sorted dictionary for server instructions, sorted by the
        /// instruction bytes in an ascending order (from the lowest character
        /// to the highest).
        /// </summary>
        /// <returns>
        /// A SortedDictionary which uses the instruction byte as the key and
        /// its frequency as the value.
        /// </returns>
        public SortedDictionary<char, uint> GetInstructionTableByInstruction()
        {
            return instrFrequency;
        }


        /*
         *** Data Element Retrieval Methods
         */
        /// <summary>
        /// Get the amount of times a specific server instruction was
        /// received.
        /// </summary>
        /// <param name="instr">Server instruction byte</param>
        /// <returns>Amount of times the instruction was received</returns>
        public uint GetInstructionFrequency(char instr)
        {
            uint freq;
            if (instrFrequency.TryGetValue(instr, out freq))
                return freq;
            return 0;
        }
        /// <summary>
        /// Get the amount of times a specific DragonSpeak line was requested
        /// by the server.
        /// </summary>
        /// <param name="instr">DragonSpeak Binary line number</param>
        /// <returns>Amount of times the DSB line was received</returns>
        public uint GetDsLineFrequency(ushort nLine)
        {
            uint freq;
            if (lnFrequency.TryGetValue(nLine, out freq))
                return freq;
            return 0;
        }

        /// <summary>
        /// Gets the average speed (in KB/sec, where KB=1024 bytes) the
        /// information was received in. The value relies on the speed that
        /// data was fed into the Analyzer object! If is was readen from a
        /// file that does not support timestamps, and was timestamped as it
        /// was read, this information can be incorrect - it will correspond
        /// to the reading speed rather than the speed it was captured in!
        ///
        /// NOTE: If the IsTimeAvailable property is FALSE, this information
        ///       should be considered unavailable!
        /// </summary>
        /// <returns>Average speed in KB/sec</returns>
        public double GetAvgSpeed()
        {
            uint rts = RunTimeSeconds;

            if (rts > 0)
                return ((double)TotalBytes / 1024 / rts);
            return 0.0;
        }

        /// <summary>
        /// Get a string representation of the Analyzer object.
        /// </summary>
        /// <returns>String representation of the Analyzer object</returns>
        public override string ToString()
        {
            return "[Analyzer Object <\"" + Title + "\">]";
        }


        /*
         *** Helper Methods (PRIVATE)
         */
        private void AddInstruction(char instr)
        {
            if (instrFrequency.ContainsKey(instr))
                instrFrequency[instr]++;
            else
                instrFrequency[instr] = 1;
        }
        private void AddDsLine(ushort nLine)
        {
            if (lnFrequency.ContainsKey(nLine))
                lnFrequency[nLine]++;
            else
                lnFrequency[nLine] = 1;
        }
        private bool IsAvatarInstruction(char instr)
        {
            return (
                instr == '/' ||
                instr == '<' ||
                instr == ')' ||
                (instr >= 'A' && instr <= 'D')
                   );
        }
        private bool IsDsInstruction(char instr)
        {
            return (instr == '3' || (instr >= '6' && instr <= '8'));
        }
        private void ParseDsTrigger(string data)
        {
            int nLines = 0;
            ushort ln;

            for (int i = 9; i < data.Length; i += 6)
            {
                nLines++;
                ln = (ushort)Base95.ConvertFromBase95(data.Substring(i, 2));

                // If the line is above 8000, we have a slightly different syntax since 0.28.
                // We have an extra pair of bytes to tell us the thousands.
                if (ln > 8000)
                {
                    i += 2;
                    ushort lnThousands = (ushort)Base95.ConvertFromBase95(data.Substring(i, 2));
                    ln = (ushort)(ln - 8000 + (lnThousands * 1000));
                }
                AddDsLine(ln);
            }

            // Update the average
            uint sst = SixSevenTriggerCount; // Constantly requesting the original is more costly.
            nAvgLinePerInstruction = ((nAvgLinePerInstruction * (sst-1) + nLines) / sst);
        }
    }

    /// <summary>
    /// Helper class to adjust the SortedDirectory sorting order to descending.
    /// </summary>
    /// <typeparam name="T">Comparable parameter</typeparam>
    class ReverseComparer<T> : IComparer<T> where T : IComparable<T>
    {
        #region IComparer<T> Members

        public int Compare(T x, T y)
        {
            // Reverse comparison
            return y.CompareTo(x);
        }

        #endregion
    }
}
