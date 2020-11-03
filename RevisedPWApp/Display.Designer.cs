namespace RevisedPWApp
{
    partial class Display
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnLogin = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.lblName = new System.Windows.Forms.Label();
            this.AppPath = new System.Windows.Forms.Label();
            this.Username = new System.Windows.Forms.Label();
            this.Password = new System.Windows.Forms.Label();
            this.DateCreated = new System.Windows.Forms.Label();
            this.SelectAction = new System.Windows.Forms.Label();
            this.Description = new System.Windows.Forms.Label();
            this.SpecialNotes = new System.Windows.Forms.Label();
            this.DateModified = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtDateCreated = new System.Windows.Forms.TextBox();
            this.txtAppPath = new System.Windows.Forms.TextBox();
            this.txtDesc = new System.Windows.Forms.TextBox();
            this.txtSpecialNotes = new System.Windows.Forms.TextBox();
            this.txtDateModified = new System.Windows.Forms.TextBox();
            this.txtSearchList = new System.Windows.Forms.TextBox();
            this.cboSelectAction = new System.Windows.Forms.ComboBox();
            this.grpPassword = new System.Windows.Forms.GroupBox();
            this.gpFifteen = new System.Windows.Forms.RadioButton();
            this.gpTen = new System.Windows.Forms.RadioButton();
            this.gpEight = new System.Windows.Forms.RadioButton();
            this.chkUnmask = new System.Windows.Forms.CheckBox();
            this.dv = new System.Windows.Forms.DataGridView();
            this.lblRetrieveFile = new System.Windows.Forms.Label();
            this.lblPushFile = new System.Windows.Forms.Label();
            this.txtPushFile = new System.Windows.Forms.TextBox();
            this.btnGetFile = new System.Windows.Forms.Button();
            this.btnPushFile = new System.Windows.Forms.Button();
            this.pbAvatar = new System.Windows.Forms.PictureBox();
            this.btnPhoto = new System.Windows.Forms.Button();
            this.chkCopy = new System.Windows.Forms.CheckBox();
            this.grpPassword.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAvatar)).BeginInit();
            this.SuspendLayout();
            // 
            // btnLogin
            // 
            this.btnLogin.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnLogin.BackColor = System.Drawing.Color.Green;
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnLogin.Location = new System.Drawing.Point(752, 30);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(110, 34);
            this.btnLogin.TabIndex = 0;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnLogout.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnLogout.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogout.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnLogout.Location = new System.Drawing.Point(752, 90);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(110, 34);
            this.btnLogout.TabIndex = 21;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnClear
            // 
            this.btnClear.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnClear.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Location = new System.Drawing.Point(752, 155);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(110, 34);
            this.btnClear.TabIndex = 20;
            this.btnClear.Text = "Clear Form";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnExit.BackColor = System.Drawing.Color.DarkRed;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnExit.Location = new System.Drawing.Point(752, 220);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(110, 34);
            this.btnExit.TabIndex = 22;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // lblName
            // 
            this.lblName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblName.AutoSize = true;
            this.lblName.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(12, 30);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(52, 18);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "Name:";
            // 
            // AppPath
            // 
            this.AppPath.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.AppPath.AutoSize = true;
            this.AppPath.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.AppPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AppPath.Location = new System.Drawing.Point(12, 162);
            this.AppPath.Name = "AppPath";
            this.AppPath.Size = new System.Drawing.Size(117, 18);
            this.AppPath.TabIndex = 1;
            this.AppPath.Text = "Application Path:";
            // 
            // Username
            // 
            this.Username.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Username.AutoSize = true;
            this.Username.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Username.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Username.Location = new System.Drawing.Point(12, 82);
            this.Username.Name = "Username";
            this.Username.Size = new System.Drawing.Size(81, 18);
            this.Username.TabIndex = 1;
            this.Username.Text = "Username:";
            // 
            // Password
            // 
            this.Password.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Password.AutoSize = true;
            this.Password.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Password.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Password.Location = new System.Drawing.Point(12, 122);
            this.Password.Name = "Password";
            this.Password.Size = new System.Drawing.Size(79, 18);
            this.Password.TabIndex = 1;
            this.Password.Text = "Password:";
            // 
            // DateCreated
            // 
            this.DateCreated.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.DateCreated.AutoSize = true;
            this.DateCreated.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.DateCreated.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DateCreated.Location = new System.Drawing.Point(12, 331);
            this.DateCreated.Name = "DateCreated";
            this.DateCreated.Size = new System.Drawing.Size(99, 18);
            this.DateCreated.TabIndex = 1;
            this.DateCreated.Text = "Date Created:";
            this.DateCreated.Click += new System.EventHandler(this.DateCreated_Click);
            // 
            // SelectAction
            // 
            this.SelectAction.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.SelectAction.AutoSize = true;
            this.SelectAction.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.SelectAction.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SelectAction.Location = new System.Drawing.Point(12, 410);
            this.SelectAction.Name = "SelectAction";
            this.SelectAction.Size = new System.Drawing.Size(98, 18);
            this.SelectAction.TabIndex = 1;
            this.SelectAction.Text = "Select Action:";
            this.SelectAction.Click += new System.EventHandler(this.SelectAction_Click);
            // 
            // Description
            // 
            this.Description.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Description.AutoSize = true;
            this.Description.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Description.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Description.Location = new System.Drawing.Point(12, 215);
            this.Description.Name = "Description";
            this.Description.Size = new System.Drawing.Size(87, 18);
            this.Description.TabIndex = 1;
            this.Description.Text = "Description:";
            // 
            // SpecialNotes
            // 
            this.SpecialNotes.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.SpecialNotes.AutoSize = true;
            this.SpecialNotes.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.SpecialNotes.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SpecialNotes.Location = new System.Drawing.Point(12, 272);
            this.SpecialNotes.Name = "SpecialNotes";
            this.SpecialNotes.Size = new System.Drawing.Size(104, 18);
            this.SpecialNotes.TabIndex = 1;
            this.SpecialNotes.Text = "Special Notes:";
            // 
            // DateModified
            // 
            this.DateModified.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.DateModified.AutoSize = true;
            this.DateModified.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.DateModified.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DateModified.Location = new System.Drawing.Point(12, 371);
            this.DateModified.Name = "DateModified";
            this.DateModified.Size = new System.Drawing.Size(103, 18);
            this.DateModified.TabIndex = 1;
            this.DateModified.Text = "Date Modified:";
            this.DateModified.Click += new System.EventHandler(this.DateModified_Click);
            // 
            // txtName
            // 
            this.txtName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.Location = new System.Drawing.Point(141, 29);
            this.txtName.Multiline = true;
            this.txtName.Name = "txtName";
            this.txtName.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtName.Size = new System.Drawing.Size(213, 44);
            this.txtName.TabIndex = 1;
            // 
            // txtUsername
            // 
            this.txtUsername.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsername.Location = new System.Drawing.Point(141, 83);
            this.txtUsername.Multiline = true;
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(213, 32);
            this.txtUsername.TabIndex = 2;
            // 
            // txtPassword
            // 
            this.txtPassword.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.Location = new System.Drawing.Point(141, 122);
            this.txtPassword.Multiline = true;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(213, 32);
            this.txtPassword.TabIndex = 3;
            // 
            // txtDateCreated
            // 
            this.txtDateCreated.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtDateCreated.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDateCreated.Location = new System.Drawing.Point(141, 331);
            this.txtDateCreated.Multiline = true;
            this.txtDateCreated.Name = "txtDateCreated";
            this.txtDateCreated.Size = new System.Drawing.Size(213, 32);
            this.txtDateCreated.TabIndex = 8;
            this.txtDateCreated.TextChanged += new System.EventHandler(this.txtDateCreated_TextChanged);
            // 
            // txtAppPath
            // 
            this.txtAppPath.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtAppPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAppPath.Location = new System.Drawing.Point(141, 162);
            this.txtAppPath.Multiline = true;
            this.txtAppPath.Name = "txtAppPath";
            this.txtAppPath.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtAppPath.Size = new System.Drawing.Size(213, 43);
            this.txtAppPath.TabIndex = 5;
            // 
            // txtDesc
            // 
            this.txtDesc.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDesc.Location = new System.Drawing.Point(141, 215);
            this.txtDesc.Multiline = true;
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDesc.Size = new System.Drawing.Size(213, 52);
            this.txtDesc.TabIndex = 6;
            // 
            // txtSpecialNotes
            // 
            this.txtSpecialNotes.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtSpecialNotes.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSpecialNotes.Location = new System.Drawing.Point(141, 273);
            this.txtSpecialNotes.Multiline = true;
            this.txtSpecialNotes.Name = "txtSpecialNotes";
            this.txtSpecialNotes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtSpecialNotes.Size = new System.Drawing.Size(213, 48);
            this.txtSpecialNotes.TabIndex = 7;
            // 
            // txtDateModified
            // 
            this.txtDateModified.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtDateModified.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDateModified.Location = new System.Drawing.Point(140, 371);
            this.txtDateModified.Multiline = true;
            this.txtDateModified.Name = "txtDateModified";
            this.txtDateModified.Size = new System.Drawing.Size(213, 32);
            this.txtDateModified.TabIndex = 9;
            this.txtDateModified.TextChanged += new System.EventHandler(this.txtDateModified_TextChanged);
            // 
            // txtSearchList
            // 
            this.txtSearchList.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtSearchList.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchList.Location = new System.Drawing.Point(428, 346);
            this.txtSearchList.Multiline = true;
            this.txtSearchList.Name = "txtSearchList";
            this.txtSearchList.Size = new System.Drawing.Size(86, 31);
            this.txtSearchList.TabIndex = 18;
            this.txtSearchList.Text = "Search";
            this.txtSearchList.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtSearchList.TextChanged += new System.EventHandler(this.txtSearchList_TextChanged);
            this.txtSearchList.Enter += new System.EventHandler(this.txtSearchList_Enter);
            // 
            // cboSelectAction
            // 
            this.cboSelectAction.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cboSelectAction.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboSelectAction.FormattingEnabled = true;
            this.cboSelectAction.Items.AddRange(new object[] {
            "Add New",
            "Edit Items",
            "Delete Items"});
            this.cboSelectAction.Location = new System.Drawing.Point(140, 411);
            this.cboSelectAction.Name = "cboSelectAction";
            this.cboSelectAction.Size = new System.Drawing.Size(212, 26);
            this.cboSelectAction.TabIndex = 10;
            this.cboSelectAction.SelectedIndexChanged += new System.EventHandler(this.cboSelectAction_SelectedIndexChanged);
            this.cboSelectAction.SelectionChangeCommitted += new System.EventHandler(this.cboSelectAction_SelectionChangeCommitted);
            // 
            // grpPassword
            // 
            this.grpPassword.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.grpPassword.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.grpPassword.Controls.Add(this.gpFifteen);
            this.grpPassword.Controls.Add(this.gpTen);
            this.grpPassword.Controls.Add(this.gpEight);
            this.grpPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpPassword.Location = new System.Drawing.Point(360, 24);
            this.grpPassword.Name = "grpPassword";
            this.grpPassword.Size = new System.Drawing.Size(210, 72);
            this.grpPassword.TabIndex = 4;
            this.grpPassword.TabStop = false;
            this.grpPassword.Text = "Generate Password";
            // 
            // gpFifteen
            // 
            this.gpFifteen.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.gpFifteen.AutoSize = true;
            this.gpFifteen.Location = new System.Drawing.Point(97, 33);
            this.gpFifteen.Name = "gpFifteen";
            this.gpFifteen.Size = new System.Drawing.Size(82, 19);
            this.gpFifteen.TabIndex = 2;
            this.gpFifteen.TabStop = true;
            this.gpFifteen.Text = "15 Digits";
            this.gpFifteen.UseVisualStyleBackColor = true;
            this.gpFifteen.Click += new System.EventHandler(this.gpFifteen_Click);
            // 
            // gpTen
            // 
            this.gpTen.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.gpTen.AutoSize = true;
            this.gpTen.Location = new System.Drawing.Point(50, 33);
            this.gpTen.Name = "gpTen";
            this.gpTen.Size = new System.Drawing.Size(41, 19);
            this.gpTen.TabIndex = 1;
            this.gpTen.TabStop = true;
            this.gpTen.Text = "10";
            this.gpTen.UseVisualStyleBackColor = true;
            this.gpTen.Click += new System.EventHandler(this.gpTen_Click);
            // 
            // gpEight
            // 
            this.gpEight.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.gpEight.AutoSize = true;
            this.gpEight.Location = new System.Drawing.Point(11, 33);
            this.gpEight.Name = "gpEight";
            this.gpEight.Size = new System.Drawing.Size(33, 19);
            this.gpEight.TabIndex = 0;
            this.gpEight.TabStop = true;
            this.gpEight.Text = "8";
            this.gpEight.UseVisualStyleBackColor = true;
            this.gpEight.Click += new System.EventHandler(this.gpEight_Click);
            // 
            // chkUnmask
            // 
            this.chkUnmask.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.chkUnmask.AutoSize = true;
            this.chkUnmask.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.chkUnmask.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkUnmask.Location = new System.Drawing.Point(360, 122);
            this.chkUnmask.Name = "chkUnmask";
            this.chkUnmask.Size = new System.Drawing.Size(83, 22);
            this.chkUnmask.TabIndex = 17;
            this.chkUnmask.Text = "Unmask";
            this.chkUnmask.UseVisualStyleBackColor = false;
            this.chkUnmask.CheckedChanged += new System.EventHandler(this.chkUnmask_CheckedChanged);
            // 
            // dv
            // 
            this.dv.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dv.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dv.Location = new System.Drawing.Point(428, 395);
            this.dv.Name = "dv";
            this.dv.Size = new System.Drawing.Size(434, 147);
            this.dv.TabIndex = 19;
            this.dv.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dv_CellClick);
            // 
            // lblRetrieveFile
            // 
            this.lblRetrieveFile.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblRetrieveFile.AutoSize = true;
            this.lblRetrieveFile.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblRetrieveFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRetrieveFile.Location = new System.Drawing.Point(12, 446);
            this.lblRetrieveFile.Name = "lblRetrieveFile";
            this.lblRetrieveFile.Size = new System.Drawing.Size(106, 18);
            this.lblRetrieveFile.TabIndex = 1;
            this.lblRetrieveFile.Text = "Add File to DB:";
            // 
            // lblPushFile
            // 
            this.lblPushFile.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblPushFile.AutoSize = true;
            this.lblPushFile.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblPushFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPushFile.Location = new System.Drawing.Point(12, 488);
            this.lblPushFile.Name = "lblPushFile";
            this.lblPushFile.Size = new System.Drawing.Size(127, 18);
            this.lblPushFile.TabIndex = 1;
            this.lblPushFile.Text = "Extract DB to File:";
            // 
            // txtPushFile
            // 
            this.txtPushFile.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtPushFile.BackColor = System.Drawing.SystemColors.ControlDark;
            this.txtPushFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPushFile.Location = new System.Drawing.Point(140, 489);
            this.txtPushFile.Multiline = true;
            this.txtPushFile.Name = "txtPushFile";
            this.txtPushFile.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtPushFile.Size = new System.Drawing.Size(213, 53);
            this.txtPushFile.TabIndex = 15;
            this.txtPushFile.TabStop = false;
            // 
            // btnGetFile
            // 
            this.btnGetFile.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnGetFile.BackgroundImage = global::RevisedPWApp.Properties.Resources.downloadFile;
            this.btnGetFile.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnGetFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGetFile.Location = new System.Drawing.Point(140, 445);
            this.btnGetFile.Name = "btnGetFile";
            this.btnGetFile.Size = new System.Drawing.Size(90, 35);
            this.btnGetFile.TabIndex = 12;
            this.btnGetFile.UseVisualStyleBackColor = true;
            this.btnGetFile.Click += new System.EventHandler(this.btnGetFile_Click);
            // 
            // btnPushFile
            // 
            this.btnPushFile.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnPushFile.BackgroundImage = global::RevisedPWApp.Properties.Resources.uploadFile;
            this.btnPushFile.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPushFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPushFile.Location = new System.Drawing.Point(359, 489);
            this.btnPushFile.Name = "btnPushFile";
            this.btnPushFile.Size = new System.Drawing.Size(53, 53);
            this.btnPushFile.TabIndex = 16;
            this.btnPushFile.UseVisualStyleBackColor = true;
            this.btnPushFile.Click += new System.EventHandler(this.btnPushFile_Click);
            // 
            // pbAvatar
            // 
            this.pbAvatar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pbAvatar.BackgroundImage = global::RevisedPWApp.Properties.Resources.avatar;
            this.pbAvatar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbAvatar.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pbAvatar.Location = new System.Drawing.Point(576, 30);
            this.pbAvatar.Name = "pbAvatar";
            this.pbAvatar.Size = new System.Drawing.Size(170, 174);
            this.pbAvatar.TabIndex = 23;
            this.pbAvatar.TabStop = false;
            // 
            // btnPhoto
            // 
            this.btnPhoto.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnPhoto.BackColor = System.Drawing.Color.PeachPuff;
            this.btnPhoto.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPhoto.Location = new System.Drawing.Point(576, 210);
            this.btnPhoto.Name = "btnPhoto";
            this.btnPhoto.Size = new System.Drawing.Size(170, 44);
            this.btnPhoto.TabIndex = 23;
            this.btnPhoto.Text = "Select Image";
            this.btnPhoto.UseVisualStyleBackColor = false;
            this.btnPhoto.Click += new System.EventHandler(this.btnPhoto_Click);
            // 
            // chkCopy
            // 
            this.chkCopy.AutoSize = true;
            this.chkCopy.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.chkCopy.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkCopy.Location = new System.Drawing.Point(508, 122);
            this.chkCopy.Name = "chkCopy";
            this.chkCopy.Size = new System.Drawing.Size(62, 22);
            this.chkCopy.TabIndex = 24;
            this.chkCopy.Text = "Copy";
            this.chkCopy.UseVisualStyleBackColor = false;
            this.chkCopy.CheckedChanged += new System.EventHandler(this.chkCopy_CheckedChanged);
            // 
            // Display
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::RevisedPWApp.Properties.Resources.passwordKey;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(873, 587);
            this.Controls.Add(this.chkCopy);
            this.Controls.Add(this.btnPhoto);
            this.Controls.Add(this.pbAvatar);
            this.Controls.Add(this.btnPushFile);
            this.Controls.Add(this.btnGetFile);
            this.Controls.Add(this.dv);
            this.Controls.Add(this.chkUnmask);
            this.Controls.Add(this.grpPassword);
            this.Controls.Add(this.cboSelectAction);
            this.Controls.Add(this.txtSearchList);
            this.Controls.Add(this.txtDateModified);
            this.Controls.Add(this.txtSpecialNotes);
            this.Controls.Add(this.txtPushFile);
            this.Controls.Add(this.txtDesc);
            this.Controls.Add(this.txtAppPath);
            this.Controls.Add(this.txtDateCreated);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblPushFile);
            this.Controls.Add(this.DateModified);
            this.Controls.Add(this.lblRetrieveFile);
            this.Controls.Add(this.SpecialNotes);
            this.Controls.Add(this.Description);
            this.Controls.Add(this.AppPath);
            this.Controls.Add(this.SelectAction);
            this.Controls.Add(this.DateCreated);
            this.Controls.Add(this.Password);
            this.Controls.Add(this.Username);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnLogin);
            this.Name = "Display";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Display Passwords";
            this.grpPassword.ResumeLayout(false);
            this.grpPassword.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAvatar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label AppPath;
        private System.Windows.Forms.Label Username;
        private System.Windows.Forms.Label Password;
        private System.Windows.Forms.Label DateCreated;
        private System.Windows.Forms.Label SelectAction;
        private System.Windows.Forms.Label Description;
        private System.Windows.Forms.Label SpecialNotes;
        private System.Windows.Forms.Label DateModified;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtDateCreated;
        private System.Windows.Forms.TextBox txtAppPath;
        private System.Windows.Forms.TextBox txtDesc;
        private System.Windows.Forms.TextBox txtSpecialNotes;
        private System.Windows.Forms.TextBox txtDateModified;
        private System.Windows.Forms.TextBox txtSearchList;
        private System.Windows.Forms.ComboBox cboSelectAction;
        private System.Windows.Forms.GroupBox grpPassword;
        private System.Windows.Forms.RadioButton gpFifteen;
        private System.Windows.Forms.RadioButton gpTen;
        private System.Windows.Forms.RadioButton gpEight;
        private System.Windows.Forms.CheckBox chkUnmask;
        private System.Windows.Forms.DataGridView dv;
        private System.Windows.Forms.Label lblRetrieveFile;
        private System.Windows.Forms.Label lblPushFile;
        private System.Windows.Forms.TextBox txtPushFile;
        private System.Windows.Forms.Button btnGetFile;
        private System.Windows.Forms.Button btnPushFile;
        private System.Windows.Forms.PictureBox pbAvatar;
        private System.Windows.Forms.Button btnPhoto;
        private System.Windows.Forms.CheckBox chkCopy;
    }
}