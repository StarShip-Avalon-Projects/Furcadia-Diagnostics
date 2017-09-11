using static Furcadia.AccountLogin;

namespace AccountTest
{
    /// <summary>
    /// Summary description for SimpleHttpWebRequest.
    /// </summary>
    public class SimpleHttpWebRequest : System.Windows.Forms.Form

    {
        #region Private Fields

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button cmdGo;

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtBoxApiKey;
        private System.Windows.Forms.TextBox txtBoxPassword;
        private System.Windows.Forms.TextBox txtBoxUser;
        private System.Windows.Forms.TextBox txtHTML;
        private System.Windows.Forms.TextBox txtUrl;

        #endregion Private Fields

        #region Public Constructors

        public SimpleHttpWebRequest()
        {
            // Required for Windows Form Designer support
            InitializeComponent();
            txtUrl.Text = "https://charon.furcadia.com/accounts/clogin.php";
            txtBoxApiKey.Text = "SecretAPIKey";
            // TODO: Add any constructor code after InitializeComponent call
        }

        #endregion Public Constructors

        #region Protected Methods

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #endregion Protected Methods

        #region Private Methods

        private void cmdGo_Click(object sender, System.EventArgs e)
        {
            this.txtHTML.Text = getFurcadiaCharacters(txtBoxUser.Text, txtBoxPassword.Text, txtBoxApiKey.Text, txtUrl.Text);
        }

        /// <summary>
        /// Required method for Designer support - do not modify the
        /// contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtUrl = new System.Windows.Forms.TextBox();
            this.txtHTML = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cmdGo = new System.Windows.Forms.Button();
            this.txtBoxPassword = new System.Windows.Forms.TextBox();
            this.txtBoxUser = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtBoxApiKey = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtUrl
            // 
            this.txtUrl.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUrl.Location = new System.Drawing.Point(62, 6);
            this.txtUrl.Name = "txtUrl";
            this.txtUrl.Size = new System.Drawing.Size(602, 27);
            this.txtUrl.TabIndex = 1;
            // 
            // txtHTML
            // 
            this.txtHTML.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtHTML.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHTML.Location = new System.Drawing.Point(0, 145);
            this.txtHTML.Multiline = true;
            this.txtHTML.Name = "txtHTML";
            this.txtHTML.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtHTML.Size = new System.Drawing.Size(718, 155);
            this.txtHTML.TabIndex = 6;
            this.txtHTML.WordWrap = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1078, 453);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(5, 3);
            this.button1.TabIndex = 8;
            this.button1.Text = "button1";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(19, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 22);
            this.label1.TabIndex = 9;
            this.label1.Text = "Url:";
            // 
            // cmdGo
            // 
            this.cmdGo.Location = new System.Drawing.Point(677, 6);
            this.cmdGo.Name = "cmdGo";
            this.cmdGo.Size = new System.Drawing.Size(110, 32);
            this.cmdGo.TabIndex = 2;
            this.cmdGo.Text = "&Go";
            this.cmdGo.Click += new System.EventHandler(this.cmdGo_Click);
            // 
            // txtBoxPassword
            // 
            this.txtBoxPassword.Location = new System.Drawing.Point(720, 56);
            this.txtBoxPassword.Name = "txtBoxPassword";
            this.txtBoxPassword.Size = new System.Drawing.Size(306, 26);
            this.txtBoxPassword.TabIndex = 4;
            // 
            // txtBoxUser
            // 
            this.txtBoxUser.Location = new System.Drawing.Point(221, 56);
            this.txtBoxUser.Name = "txtBoxUser";
            this.txtBoxUser.Size = new System.Drawing.Size(345, 26);
            this.txtBoxUser.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(179, 20);
            this.label2.TabIndex = 13;
            this.label2.Text = "Account E-Mail Address";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(608, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 20);
            this.label3.TabIndex = 14;
            this.label3.Text = "Password";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 111);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 20);
            this.label4.TabIndex = 16;
            this.label4.Text = "Api Key";
            // 
            // txtBoxApiKey
            // 
            this.txtBoxApiKey.Location = new System.Drawing.Point(98, 107);
            this.txtBoxApiKey.Name = "txtBoxApiKey";
            this.txtBoxApiKey.Size = new System.Drawing.Size(468, 26);
            this.txtBoxApiKey.TabIndex = 5;
            // 
            // SimpleHttpWebRequest
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(8, 19);
            this.ClientSize = new System.Drawing.Size(713, 300);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtBoxApiKey);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtBoxUser);
            this.Controls.Add(this.txtBoxPassword);
            this.Controls.Add(this.cmdGo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtUrl);
            this.Controls.Add(this.txtHTML);
            this.Name = "SimpleHttpWebRequest";
            this.Text = "SimpleHTTPWebRequest";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion Private Methods
    }
}