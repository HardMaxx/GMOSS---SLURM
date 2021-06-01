namespace WindowsFormsApp7
{
    partial class AddJobForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxTimeLimit = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxPartition = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxTasksPerNode = new System.Windows.Forms.TextBox();
            this.textBoxMemory = new System.Windows.Forms.TextBox();
            this.labelMemory = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.labelJobName = new System.Windows.Forms.Label();
            this.labelDescription = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.labelTool = new System.Windows.Forms.Label();
            this.buttonNext = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.comboBoxType = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.buttonPrevious = new System.Windows.Forms.Button();
            this.buttonCreateDirectory = new System.Windows.Forms.Button();
            this.buttonAddFiles = new System.Windows.Forms.Button();
            this.comboBoxDirectory = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBoxQuery = new System.Windows.Forms.ComboBox();
            this.comboBoxDatabase = new System.Windows.Forms.ComboBox();
            this.comboBoxDirectoryQuery = new System.Windows.Forms.ComboBox();
            this.comboBoxDirectoryDatabase = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.comboBoxDirectoryType = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.checkBoxSplitJob = new System.Windows.Forms.CheckBox();
            this.buttonSplitOption = new System.Windows.Forms.Button();
            this.labelInfoAboutSplit = new System.Windows.Forms.Label();
            this.panelBorderStyle = new System.Windows.Forms.Panel();
            this.labelFormName = new System.Windows.Forms.Label();
            this.buttonX = new System.Windows.Forms.Button();
            this.buttonClosewindow = new System.Windows.Forms.Button();
            this.panelBorderStyle.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(113, 153);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Time Limit";
            // 
            // textBoxTimeLimit
            // 
            this.textBoxTimeLimit.Location = new System.Drawing.Point(116, 169);
            this.textBoxTimeLimit.Name = "textBoxTimeLimit";
            this.textBoxTimeLimit.Size = new System.Drawing.Size(121, 20);
            this.textBoxTimeLimit.TabIndex = 2;
            this.textBoxTimeLimit.Click += new System.EventHandler(this.textBoxTimeLimit_Click);
            this.textBoxTimeLimit.TextChanged += new System.EventHandler(this.textBoxTimeLimit_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(113, 113);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Partition";
            // 
            // comboBoxPartition
            // 
            this.comboBoxPartition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPartition.FormattingEnabled = true;
            this.comboBoxPartition.Location = new System.Drawing.Point(116, 129);
            this.comboBoxPartition.Name = "comboBoxPartition";
            this.comboBoxPartition.Size = new System.Drawing.Size(121, 21);
            this.comboBoxPartition.TabIndex = 4;
            this.comboBoxPartition.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(8, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Job Name";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(113, 197);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Tasks per node";
            // 
            // textBoxTasksPerNode
            // 
            this.textBoxTasksPerNode.Location = new System.Drawing.Point(116, 213);
            this.textBoxTasksPerNode.Name = "textBoxTasksPerNode";
            this.textBoxTasksPerNode.Size = new System.Drawing.Size(121, 20);
            this.textBoxTasksPerNode.TabIndex = 13;
            this.textBoxTasksPerNode.TextChanged += new System.EventHandler(this.textBoxTasksPerNode_TextChanged);
            this.textBoxTasksPerNode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxTasksPerNode_KeyPress);
            // 
            // textBoxMemory
            // 
            this.textBoxMemory.Location = new System.Drawing.Point(116, 252);
            this.textBoxMemory.Name = "textBoxMemory";
            this.textBoxMemory.Size = new System.Drawing.Size(121, 20);
            this.textBoxMemory.TabIndex = 14;
            this.textBoxMemory.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxMemory_KeyPress);
            // 
            // labelMemory
            // 
            this.labelMemory.AutoSize = true;
            this.labelMemory.Location = new System.Drawing.Point(113, 236);
            this.labelMemory.Name = "labelMemory";
            this.labelMemory.Size = new System.Drawing.Size(44, 13);
            this.labelMemory.TabIndex = 15;
            this.labelMemory.Text = "Memory";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label6.Location = new System.Drawing.Point(245, 151);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "d-hh:mm:ss";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label9.Location = new System.Drawing.Point(8, 82);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(71, 13);
            this.label9.TabIndex = 22;
            this.label9.Text = "Description";
            // 
            // labelJobName
            // 
            this.labelJobName.AutoSize = true;
            this.labelJobName.Location = new System.Drawing.Point(29, 48);
            this.labelJobName.Name = "labelJobName";
            this.labelJobName.Size = new System.Drawing.Size(41, 13);
            this.labelJobName.TabIndex = 23;
            this.labelJobName.Text = "label10";
            // 
            // labelDescription
            // 
            this.labelDescription.AutoSize = true;
            this.labelDescription.Location = new System.Drawing.Point(32, 95);
            this.labelDescription.Name = "labelDescription";
            this.labelDescription.Size = new System.Drawing.Size(41, 13);
            this.labelDescription.TabIndex = 24;
            this.labelDescription.Text = "label11";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label10.Location = new System.Drawing.Point(8, 116);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(32, 13);
            this.label10.TabIndex = 25;
            this.label10.Text = "Tool";
            // 
            // labelTool
            // 
            this.labelTool.AutoSize = true;
            this.labelTool.Location = new System.Drawing.Point(32, 129);
            this.labelTool.Name = "labelTool";
            this.labelTool.Size = new System.Drawing.Size(41, 13);
            this.labelTool.TabIndex = 26;
            this.labelTool.Text = "label11";
            // 
            // buttonNext
            // 
            this.buttonNext.Enabled = false;
            this.buttonNext.Location = new System.Drawing.Point(629, 280);
            this.buttonNext.Name = "buttonNext";
            this.buttonNext.Size = new System.Drawing.Size(75, 23);
            this.buttonNext.TabIndex = 27;
            this.buttonNext.Text = "Next";
            this.buttonNext.UseVisualStyleBackColor = true;
            this.buttonNext.Click += new System.EventHandler(this.buttonNext_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(453, 113);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(31, 13);
            this.label11.TabIndex = 28;
            this.label11.Text = "Type";
            // 
            // comboBoxType
            // 
            this.comboBoxType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxType.FormattingEnabled = true;
            this.comboBoxType.Location = new System.Drawing.Point(452, 129);
            this.comboBoxType.Name = "comboBoxType";
            this.comboBoxType.Size = new System.Drawing.Size(121, 21);
            this.comboBoxType.TabIndex = 29;
            this.comboBoxType.SelectedIndexChanged += new System.EventHandler(this.comboBoxType_SelectedIndexChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(453, 153);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(35, 13);
            this.label12.TabIndex = 30;
            this.label12.Text = "Query";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(453, 195);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(53, 13);
            this.label13.TabIndex = 32;
            this.label13.Text = "Database";
            // 
            // buttonPrevious
            // 
            this.buttonPrevious.Location = new System.Drawing.Point(15, 280);
            this.buttonPrevious.Name = "buttonPrevious";
            this.buttonPrevious.Size = new System.Drawing.Size(75, 23);
            this.buttonPrevious.TabIndex = 34;
            this.buttonPrevious.Text = "Previous";
            this.buttonPrevious.UseVisualStyleBackColor = true;
            this.buttonPrevious.Click += new System.EventHandler(this.buttonPrevious_Click_1);
            // 
            // buttonCreateDirectory
            // 
            this.buttonCreateDirectory.Location = new System.Drawing.Point(396, 46);
            this.buttonCreateDirectory.Name = "buttonCreateDirectory";
            this.buttonCreateDirectory.Size = new System.Drawing.Size(106, 23);
            this.buttonCreateDirectory.TabIndex = 65;
            this.buttonCreateDirectory.Text = "Create Directory";
            this.buttonCreateDirectory.UseVisualStyleBackColor = true;
            this.buttonCreateDirectory.Click += new System.EventHandler(this.buttonCreateDirectory_Click);
            // 
            // buttonAddFiles
            // 
            this.buttonAddFiles.Location = new System.Drawing.Point(508, 46);
            this.buttonAddFiles.Name = "buttonAddFiles";
            this.buttonAddFiles.Size = new System.Drawing.Size(75, 23);
            this.buttonAddFiles.TabIndex = 64;
            this.buttonAddFiles.Text = "Add files";
            this.buttonAddFiles.UseVisualStyleBackColor = true;
            this.buttonAddFiles.Click += new System.EventHandler(this.buttonAddFiles_Click);
            // 
            // comboBoxDirectory
            // 
            this.comboBoxDirectory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDirectory.FormattingEnabled = true;
            this.comboBoxDirectory.Location = new System.Drawing.Point(592, 48);
            this.comboBoxDirectory.Name = "comboBoxDirectory";
            this.comboBoxDirectory.Size = new System.Drawing.Size(121, 21);
            this.comboBoxDirectory.TabIndex = 63;
            this.comboBoxDirectory.SelectedIndexChanged += new System.EventHandler(this.comboBoxDirectory_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(589, 32);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 13);
            this.label4.TabIndex = 62;
            this.label4.Text = "Directory Name";
            // 
            // comboBoxQuery
            // 
            this.comboBoxQuery.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxQuery.FormattingEnabled = true;
            this.comboBoxQuery.Location = new System.Drawing.Point(452, 169);
            this.comboBoxQuery.Name = "comboBoxQuery";
            this.comboBoxQuery.Size = new System.Drawing.Size(121, 21);
            this.comboBoxQuery.TabIndex = 66;
            this.comboBoxQuery.SelectedIndexChanged += new System.EventHandler(this.comboBoxQuery_SelectedIndexChanged);
            // 
            // comboBoxDatabase
            // 
            this.comboBoxDatabase.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDatabase.FormattingEnabled = true;
            this.comboBoxDatabase.Location = new System.Drawing.Point(452, 211);
            this.comboBoxDatabase.Name = "comboBoxDatabase";
            this.comboBoxDatabase.Size = new System.Drawing.Size(121, 21);
            this.comboBoxDatabase.TabIndex = 67;
            this.comboBoxDatabase.SelectedIndexChanged += new System.EventHandler(this.comboBoxDatabase_SelectedIndexChanged);
            // 
            // comboBoxDirectoryQuery
            // 
            this.comboBoxDirectoryQuery.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDirectoryQuery.FormattingEnabled = true;
            this.comboBoxDirectoryQuery.Location = new System.Drawing.Point(325, 169);
            this.comboBoxDirectoryQuery.Name = "comboBoxDirectoryQuery";
            this.comboBoxDirectoryQuery.Size = new System.Drawing.Size(121, 21);
            this.comboBoxDirectoryQuery.TabIndex = 68;
            this.comboBoxDirectoryQuery.SelectedIndexChanged += new System.EventHandler(this.comboBoxDirectoryQuery_SelectedIndexChanged);
            // 
            // comboBoxDirectoryDatabase
            // 
            this.comboBoxDirectoryDatabase.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDirectoryDatabase.FormattingEnabled = true;
            this.comboBoxDirectoryDatabase.Location = new System.Drawing.Point(325, 211);
            this.comboBoxDirectoryDatabase.Name = "comboBoxDirectoryDatabase";
            this.comboBoxDirectoryDatabase.Size = new System.Drawing.Size(121, 21);
            this.comboBoxDirectoryDatabase.TabIndex = 69;
            this.comboBoxDirectoryDatabase.SelectedIndexChanged += new System.EventHandler(this.comboBoxDirectoryDatabase_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(325, 153);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 13);
            this.label7.TabIndex = 70;
            this.label7.Text = "Directory";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(325, 197);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(49, 13);
            this.label8.TabIndex = 71;
            this.label8.Text = "Directory";
            // 
            // comboBoxDirectoryType
            // 
            this.comboBoxDirectoryType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDirectoryType.FormattingEnabled = true;
            this.comboBoxDirectoryType.Location = new System.Drawing.Point(325, 129);
            this.comboBoxDirectoryType.Name = "comboBoxDirectoryType";
            this.comboBoxDirectoryType.Size = new System.Drawing.Size(121, 21);
            this.comboBoxDirectoryType.TabIndex = 72;
            this.comboBoxDirectoryType.SelectedIndexChanged += new System.EventHandler(this.comboBoxDirectoryType_SelectedIndexChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(325, 113);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(49, 13);
            this.label14.TabIndex = 73;
            this.label14.Text = "Directory";
            // 
            // checkBoxSplitJob
            // 
            this.checkBoxSplitJob.AutoSize = true;
            this.checkBoxSplitJob.Location = new System.Drawing.Point(325, 242);
            this.checkBoxSplitJob.Name = "checkBoxSplitJob";
            this.checkBoxSplitJob.Size = new System.Drawing.Size(66, 17);
            this.checkBoxSplitJob.TabIndex = 74;
            this.checkBoxSplitJob.Text = "Split Job";
            this.checkBoxSplitJob.UseVisualStyleBackColor = true;
            this.checkBoxSplitJob.CheckedChanged += new System.EventHandler(this.checkBoxSplitJob_CheckedChanged);
            // 
            // buttonSplitOption
            // 
            this.buttonSplitOption.Location = new System.Drawing.Point(452, 238);
            this.buttonSplitOption.Name = "buttonSplitOption";
            this.buttonSplitOption.Size = new System.Drawing.Size(122, 23);
            this.buttonSplitOption.TabIndex = 75;
            this.buttonSplitOption.Text = "Split options";
            this.buttonSplitOption.UseVisualStyleBackColor = true;
            this.buttonSplitOption.Click += new System.EventHandler(this.buttonSplitOption_Click);
            // 
            // labelInfoAboutSplit
            // 
            this.labelInfoAboutSplit.AutoSize = true;
            this.labelInfoAboutSplit.Location = new System.Drawing.Point(325, 262);
            this.labelInfoAboutSplit.Name = "labelInfoAboutSplit";
            this.labelInfoAboutSplit.Size = new System.Drawing.Size(41, 13);
            this.labelInfoAboutSplit.TabIndex = 76;
            this.labelInfoAboutSplit.Text = "label15";
            // 
            // panelBorderStyle
            // 
            this.panelBorderStyle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelBorderStyle.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panelBorderStyle.Controls.Add(this.labelFormName);
            this.panelBorderStyle.Controls.Add(this.buttonX);
            this.panelBorderStyle.Location = new System.Drawing.Point(0, 0);
            this.panelBorderStyle.Margin = new System.Windows.Forms.Padding(0);
            this.panelBorderStyle.Name = "panelBorderStyle";
            this.panelBorderStyle.Size = new System.Drawing.Size(726, 26);
            this.panelBorderStyle.TabIndex = 83;
            this.panelBorderStyle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelBorderStyle_MouseDown);
            this.panelBorderStyle.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelBorderStyle_MouseMove);
            this.panelBorderStyle.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panelBorderStyle_MouseUp);
            // 
            // labelFormName
            // 
            this.labelFormName.AutoSize = true;
            this.labelFormName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.labelFormName.Location = new System.Drawing.Point(12, 4);
            this.labelFormName.Name = "labelFormName";
            this.labelFormName.Size = new System.Drawing.Size(49, 16);
            this.labelFormName.TabIndex = 78;
            this.labelFormName.Text = "Home";
            // 
            // buttonX
            // 
            this.buttonX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonX.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.buttonX.Location = new System.Drawing.Point(699, 1);
            this.buttonX.Margin = new System.Windows.Forms.Padding(1);
            this.buttonX.Name = "buttonX";
            this.buttonX.Size = new System.Drawing.Size(26, 22);
            this.buttonX.TabIndex = 77;
            this.buttonX.Text = "X";
            this.buttonX.UseVisualStyleBackColor = true;
            this.buttonX.Click += new System.EventHandler(this.buttonX_Click_1);
            // 
            // buttonClosewindow
            // 
            this.buttonClosewindow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonClosewindow.Location = new System.Drawing.Point(605, 0);
            this.buttonClosewindow.Name = "buttonClosewindow";
            this.buttonClosewindow.Size = new System.Drawing.Size(121, 23);
            this.buttonClosewindow.TabIndex = 85;
            this.buttonClosewindow.Text = "Close window";
            this.buttonClosewindow.UseVisualStyleBackColor = true;
            this.buttonClosewindow.Click += new System.EventHandler(this.buttonClosewindow_Click);
            // 
            // AddJobForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(725, 345);
            this.ControlBox = false;
            this.Controls.Add(this.buttonClosewindow);
            this.Controls.Add(this.panelBorderStyle);
            this.Controls.Add(this.labelInfoAboutSplit);
            this.Controls.Add(this.buttonSplitOption);
            this.Controls.Add(this.checkBoxSplitJob);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.comboBoxDirectoryType);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.comboBoxDirectoryDatabase);
            this.Controls.Add(this.comboBoxDirectoryQuery);
            this.Controls.Add(this.comboBoxDatabase);
            this.Controls.Add(this.comboBoxQuery);
            this.Controls.Add(this.buttonCreateDirectory);
            this.Controls.Add(this.buttonAddFiles);
            this.Controls.Add(this.comboBoxDirectory);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.buttonPrevious);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.comboBoxType);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.buttonNext);
            this.Controls.Add(this.labelTool);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.labelDescription);
            this.Controls.Add(this.labelJobName);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.labelMemory);
            this.Controls.Add(this.textBoxMemory);
            this.Controls.Add(this.textBoxTasksPerNode);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBoxPartition);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxTimeLimit);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddJobForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add Job Form";
            this.Load += new System.EventHandler(this.NewJob_Load);
            this.panelBorderStyle.ResumeLayout(false);
            this.panelBorderStyle.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxTimeLimit;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxPartition;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxTasksPerNode;
        private System.Windows.Forms.TextBox textBoxMemory;
        private System.Windows.Forms.Label labelMemory;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label labelJobName;
        private System.Windows.Forms.Label labelDescription;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label labelTool;
        private System.Windows.Forms.Button buttonNext;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox comboBoxType;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button buttonPrevious;
        private System.Windows.Forms.Button buttonCreateDirectory;
        private System.Windows.Forms.Button buttonAddFiles;
        private System.Windows.Forms.ComboBox comboBoxDirectory;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBoxQuery;
        private System.Windows.Forms.ComboBox comboBoxDatabase;
        private System.Windows.Forms.ComboBox comboBoxDirectoryQuery;
        private System.Windows.Forms.ComboBox comboBoxDirectoryDatabase;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox comboBoxDirectoryType;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.CheckBox checkBoxSplitJob;
        private System.Windows.Forms.Button buttonSplitOption;
        private System.Windows.Forms.Label labelInfoAboutSplit;
        private System.Windows.Forms.Panel panelBorderStyle;
        private System.Windows.Forms.Label labelFormName;
        private System.Windows.Forms.Button buttonX;
        private System.Windows.Forms.Button buttonClosewindow;
    }
}