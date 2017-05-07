using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Dream_Runtime_Analyzer
{
    public partial class DsDialog : Form
    {
        // Private
        private Analyzer DataAnalyzer;
        private string DsFilename; // Keep track of the DS filename.

        /*
         *** Constructor
         */
        /// <summary>
        /// Create a DS Inspector dialog instance, priming it with an Analyzer
        /// object and a filename of the DS file we should use to match against
        /// the data.
        /// </summary>
        /// <param name="da">DataAnalyzer with ready capture data</param>
        /// <param name="filename">DragonSpeak filename to process</param>
        public DsDialog(Analyzer da, string filename)
        {
            if (da == null)
                throw new Exception("DS Inspector dialog launched with no Data Analyzer reference");

            if (!File.Exists(filename))
                throw new Exception("DragonSpeak file does not exist");

            DataAnalyzer = da;

            InitializeComponent();

            // Initialization of the tables
            PopulateLineTable();
            LoadDsFile(filename);
        }


        /*
         *** UI Control Functions
         */
        /// <summary>
        /// Populate the DS frequency table from the data in DataAnalyzer.
        /// </summary>
        private void PopulateLineTable()
        {
            dgvDsbLines.Rows.Clear();

            SortedDictionary<uint, List<ushort>> lineTable = DataAnalyzer.GetLineTableByFrequency();

            foreach (uint freq in lineTable.Keys)
            {
                foreach (ushort line in lineTable[freq])
                {
                    int n = dgvDsbLines.Rows.Add();

                    dgvDsbLines.Rows[n].Cells[0].Value = freq.ToString();
                    dgvDsbLines.Rows[n].Cells[1].Value = line.ToString();
                }
            }
        }
        /// <summary>
        /// Focuses on a specific line within the DS file and shows it to the
        /// user. Used to focus on a triggering line when clicked on one of
        /// the DS lines in the left table.
        /// </summary>
        /// <param name="line">Regular DS file line to focus on</param>
        private void GoToLine(int line)
        {
            if (dgvDragonSpeak.Rows.Count <= line || line < 0)
                return;

            dgvDragonSpeak.ClearSelection();
            dgvDragonSpeak.Rows[line].Selected = true;
            dgvDragonSpeak.FirstDisplayedScrollingRowIndex = line;

            ShowLineInfo(line, Convert.ToUInt16(dgvDragonSpeak.Rows[line].Cells[1].Value));
        }
        /// <summary>
        /// Display DS and DSB line numbers in the appropriate labels.
        /// </summary>
        /// <param name="line">DS line number to show</param>
        /// <param name="dsbLine">DSB line number to show</param>
        private void ShowLineInfo(int line, int dsbLine)
        {
            string sLine = (line >= 0) ? line.ToString() : "N/A";
            string sDsbLine = (dsbLine > 0) ? dsbLine.ToString() : "N/A";

            txtLineNumber.Text = sLine;
            txtDsbLineNumber.Text = sDsbLine;
        }


        /*
         *** DragonSpeak Parsing Functions
         */
        /// <summary>
        /// Load a specific DragonSpeak file into the DS display table.
        /// </summary>
        /// <param name="filename">DS filename we should load data from</param>
        private void LoadDsFile(string filename)
        {
            StreamReader sr = new StreamReader(filename, Encoding.ASCII);

            uint nDsbLine = 1;

            while (!sr.EndOfStream)
            {
                string buffer = sr.ReadLine();
                if (buffer == null)
                    break;

                buffer.TrimEnd('\n');

                int n = dgvDragonSpeak.Rows.Add();

                dgvDragonSpeak.Rows[n].Cells[0].Value = buffer;

                // If it's the header or footer, ignore them.
                bool isDsLine = (n == 0 && buffer.StartsWith("DSPK")) ? false : IsDsLine(buffer);
                if (isDsLine)
                {
                    dgvDragonSpeak.Rows[n].Cells[1].ValueType = typeof(int);
                    dgvDragonSpeak.Rows[n].Cells[1].Value = nDsbLine++;
                }
                else
                {
                    dgvDragonSpeak.Rows[n].Cells[1].ValueType = typeof(int);
                    dgvDragonSpeak.Rows[n].Cells[1].Value = -1;
                }
            }

            sr.Close();
            DsFilename = filename;
        }
        /// <summary>
        /// Determine if a specific line is considered a valid DragonSpeak line
        /// or is it a line that would be otherwise ignored?
        /// </summary>
        /// <param name="buffer">Line from the DS file</param>
        /// <returns>TRUE if this is considered a DragonSpeak line</returns>
        private bool IsDsLine(string buffer)
        {
            if (buffer == "")
                return false;

            // Check for comments.
            if (buffer[0] == '*' || buffer.StartsWith("//"))
                return false;

            // If it's a footer, it isn't a line.
            if (buffer.StartsWith("*Endtriggers*"))
                return false;

            // Try to find a lonesome 0, 1, 2, 3, 4 or 5.
            // If we do find it, we have a line.
            bool flag = false;

            for (int i = 0; i < buffer.Length; i++)
            {
                if (buffer[i] >= '0' && buffer[i] <= '5')
                {
                    if (flag)
                        flag = false;
                    else
                        flag = true;
                }
                else
                {
                    if (flag)
                        return true; // Found a lonesome digit!
                }
            }

            return false; // The last number in the line can't be right - it's too dirty.
        }


        /*
         *** DSB<->DS Conversion Functions
         */
        /// <summary>
        /// Get a regular DS file line number from a specific DSB line that the
        /// server gives.
        /// </summary>
        /// <param name="dsbLine">DSB line number</param>
        /// <returns>Corresponding DS line number or -1 if none was found</returns>
        private int GetLineFromDsbLine(ushort dsbLine)
        {
            for (int i = 0; i < dgvDragonSpeak.Rows.Count; i++)
            {
                int val = Convert.ToInt32(dgvDragonSpeak.Rows[i].Cells[1].Value);
                if (val == dsbLine)
                    return i;
            }

            return -1;
        }
        /// <summary>
        /// Get a DSB line number from a regular DS file line number.
        /// </summary>
        /// <param name="line">DS file line number</param>
        /// <returns>Corresponding DSB line or -1 if none was found</returns>
        private int GetDsbLineFromLine(uint line)
        {
            // Bounds checking
            if (dgvDragonSpeak.Rows.Count <= line)
                return -1;

            return Convert.ToInt32(dgvDragonSpeak.Rows[(int)line].Cells[1].Value);
        }



        /*
         *** Event Functions
         */
        // Open DS File button clicked (launch DS editor if associated)
        private void btnOpenDsFile_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(DsFilename);
        }

        // DS line frequency table row clicked (focus on a specific DSB line)
        private void dgvDsbLines_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;

            if (i >= 0)
            {
                ushort dsbLine = Convert.ToUInt16(dgvDsbLines.Rows[i].Cells[1].Value);
                GoToLine(GetLineFromDsbLine(dsbLine));
            }
        }

        // DS file row clicked (display DS and DSB for the row)
        private void dgvDragonSpeak_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            int line = e.RowIndex + 1;
            int dsbLine = GetDsbLineFromLine((uint)e.RowIndex);
            ShowLineInfo(e.RowIndex + 1, dsbLine);
        }
    }
}
