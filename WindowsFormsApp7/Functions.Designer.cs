using System.Windows.Forms;

namespace WindowsFormsApp7
{
    partial class Functions
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Functions));
            this.buttonLogOut = new System.Windows.Forms.Button();
            this.labelLastUpdateSQUEUE = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.labelConfigureJobsU = new System.Windows.Forms.Label();
            this.labelCompleteJobsU = new System.Windows.Forms.Label();
            this.labelTotalJobsU = new System.Windows.Forms.Label();
            this.labelRunningJobsU = new System.Windows.Forms.Label();
            this.labelPendingJobsU = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.buttonUserMyData = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.buttonSystemSum = new System.Windows.Forms.Button();
            this.buttonSqueueList = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.buttonSettings = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBoxNodeList = new System.Windows.Forms.CheckBox();
            this.checkBoxNodes = new System.Windows.Forms.CheckBox();
            this.checkBoxTimeLimit = new System.Windows.Forms.CheckBox();
            this.checkBoxTime = new System.Windows.Forms.CheckBox();
            this.checkBoxState = new System.Windows.Forms.CheckBox();
            this.checkBoxUser = new System.Windows.Forms.CheckBox();
            this.checkBoxJob = new System.Windows.Forms.CheckBox();
            this.checkBoxName = new System.Windows.Forms.CheckBox();
            this.checkBoxPartition = new System.Windows.Forms.CheckBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.buttonNewJob = new System.Windows.Forms.Button();
            this.buttonHistory = new System.Windows.Forms.Button();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.panelControlLocation = new System.Windows.Forms.Panel();
            this.buttonCancelMode = new System.Windows.Forms.Button();
            this.buttonStopJobs = new System.Windows.Forms.Button();
            this.buttonResize = new System.Windows.Forms.Button();
            this.panelBorderStyle = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.button_ = new System.Windows.Forms.Button();
            this.buttonX = new System.Windows.Forms.Button();
            this.buttonM = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            this.panelControlLocation.SuspendLayout();
            this.panelBorderStyle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonLogOut
            // 
            this.buttonLogOut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonLogOut.Location = new System.Drawing.Point(1104, 0);
            this.buttonLogOut.Name = "buttonLogOut";
            this.buttonLogOut.Size = new System.Drawing.Size(75, 23);
            this.buttonLogOut.TabIndex = 5;
            this.buttonLogOut.Text = "Log out";
            this.buttonLogOut.UseVisualStyleBackColor = true;
            this.buttonLogOut.Click += new System.EventHandler(this.buttonLogOut_Click);
            // 
            // labelLastUpdateSQUEUE
            // 
            this.labelLastUpdateSQUEUE.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelLastUpdateSQUEUE.AutoSize = true;
            this.labelLastUpdateSQUEUE.Location = new System.Drawing.Point(703, 28);
            this.labelLastUpdateSQUEUE.Name = "labelLastUpdateSQUEUE";
            this.labelLastUpdateSQUEUE.Size = new System.Drawing.Size(35, 13);
            this.labelLastUpdateSQUEUE.TabIndex = 41;
            this.labelLastUpdateSQUEUE.Text = "label6";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(1055, 80);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 16);
            this.label6.TabIndex = 56;
            this.label6.Text = "Statistics";
            // 
            // panel2
            // 
            this.panel2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.labelConfigureJobsU);
            this.panel2.Controls.Add(this.labelCompleteJobsU);
            this.panel2.Controls.Add(this.labelTotalJobsU);
            this.panel2.Controls.Add(this.labelRunningJobsU);
            this.panel2.Controls.Add(this.labelPendingJobsU);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Location = new System.Drawing.Point(1058, 100);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(130, 144);
            this.panel2.TabIndex = 57;
            // 
            // labelConfigureJobsU
            // 
            this.labelConfigureJobsU.AutoSize = true;
            this.labelConfigureJobsU.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelConfigureJobsU.Location = new System.Drawing.Point(4, 72);
            this.labelConfigureJobsU.Margin = new System.Windows.Forms.Padding(2);
            this.labelConfigureJobsU.Name = "labelConfigureJobsU";
            this.labelConfigureJobsU.Size = new System.Drawing.Size(95, 13);
            this.labelConfigureJobsU.TabIndex = 9;
            this.labelConfigureJobsU.Text = "Configure Jobs:";
            // 
            // labelCompleteJobsU
            // 
            this.labelCompleteJobsU.AutoSize = true;
            this.labelCompleteJobsU.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelCompleteJobsU.Location = new System.Drawing.Point(4, 55);
            this.labelCompleteJobsU.Margin = new System.Windows.Forms.Padding(2);
            this.labelCompleteJobsU.Name = "labelCompleteJobsU";
            this.labelCompleteJobsU.Size = new System.Drawing.Size(93, 13);
            this.labelCompleteJobsU.TabIndex = 8;
            this.labelCompleteJobsU.Text = "Complete Jobs:";
            // 
            // labelTotalJobsU
            // 
            this.labelTotalJobsU.AutoSize = true;
            this.labelTotalJobsU.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelTotalJobsU.Location = new System.Drawing.Point(4, 4);
            this.labelTotalJobsU.Margin = new System.Windows.Forms.Padding(2);
            this.labelTotalJobsU.Name = "labelTotalJobsU";
            this.labelTotalJobsU.Size = new System.Drawing.Size(70, 13);
            this.labelTotalJobsU.TabIndex = 7;
            this.labelTotalJobsU.Text = "Total Jobs:";
            // 
            // labelRunningJobsU
            // 
            this.labelRunningJobsU.AutoSize = true;
            this.labelRunningJobsU.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelRunningJobsU.Location = new System.Drawing.Point(4, 38);
            this.labelRunningJobsU.Margin = new System.Windows.Forms.Padding(2);
            this.labelRunningJobsU.Name = "labelRunningJobsU";
            this.labelRunningJobsU.Size = new System.Drawing.Size(88, 13);
            this.labelRunningJobsU.TabIndex = 6;
            this.labelRunningJobsU.Text = "Running Jobs:";
            // 
            // labelPendingJobsU
            // 
            this.labelPendingJobsU.AutoSize = true;
            this.labelPendingJobsU.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelPendingJobsU.Location = new System.Drawing.Point(4, 21);
            this.labelPendingJobsU.Margin = new System.Windows.Forms.Padding(2);
            this.labelPendingJobsU.Name = "labelPendingJobsU";
            this.labelPendingJobsU.Size = new System.Drawing.Size(91, 13);
            this.labelPendingJobsU.TabIndex = 5;
            this.labelPendingJobsU.Text = "Pending Jobs: ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(4, 82);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(0, 13);
            this.label7.TabIndex = 4;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(4, 60);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(0, 13);
            this.label8.TabIndex = 3;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(4, 38);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(0, 13);
            this.label9.TabIndex = 2;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(4, 21);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(0, 13);
            this.label10.TabIndex = 1;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(4, 4);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(0, 13);
            this.label11.TabIndex = 0;
            // 
            // buttonUserMyData
            // 
            this.buttonUserMyData.AutoSize = true;
            this.buttonUserMyData.Location = new System.Drawing.Point(12, 18);
            this.buttonUserMyData.Name = "buttonUserMyData";
            this.buttonUserMyData.Size = new System.Drawing.Size(75, 23);
            this.buttonUserMyData.TabIndex = 55;
            this.buttonUserMyData.Text = "My data";
            this.buttonUserMyData.UseVisualStyleBackColor = true;
            this.buttonUserMyData.Click += new System.EventHandler(this.buttonUserMyData_Click);
            // 
            // label12
            // 
            this.label12.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(402, 5);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(108, 13);
            this.label12.TabIndex = 54;
            this.label12.Text = "List of available users";
            // 
            // comboBox1
            // 
            this.comboBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.comboBox1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBox1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.RecentlyUsedList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(405, 21);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 53;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // dataGridView3
            // 
            this.dataGridView3.AllowUserToAddRows = false;
            this.dataGridView3.AllowUserToDeleteRows = false;
            this.dataGridView3.AllowUserToResizeRows = false;
            this.dataGridView3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView3.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView3.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView3.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView3.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.dataGridView3.Location = new System.Drawing.Point(15, 75);
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.ReadOnly = true;
            this.dataGridView3.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridView3.RowTemplate.Height = 20;
            this.dataGridView3.Size = new System.Drawing.Size(1034, 387);
            this.dataGridView3.TabIndex = 52;
            this.dataGridView3.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView3_CellClick);
            this.dataGridView3.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView3_CellContentClick);
            this.dataGridView3.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gridView_ColumnHeaderMouseClick);
            // 
            // buttonSystemSum
            // 
            this.buttonSystemSum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSystemSum.Location = new System.Drawing.Point(699, 0);
            this.buttonSystemSum.Name = "buttonSystemSum";
            this.buttonSystemSum.Size = new System.Drawing.Size(75, 23);
            this.buttonSystemSum.TabIndex = 58;
            this.buttonSystemSum.Text = "System";
            this.buttonSystemSum.UseVisualStyleBackColor = true;
            this.buttonSystemSum.Click += new System.EventHandler(this.buttonSystemSum_Click);
            // 
            // buttonSqueueList
            // 
            this.buttonSqueueList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSqueueList.Location = new System.Drawing.Point(942, 0);
            this.buttonSqueueList.Name = "buttonSqueueList";
            this.buttonSqueueList.Size = new System.Drawing.Size(75, 23);
            this.buttonSqueueList.TabIndex = 59;
            this.buttonSqueueList.Text = "Squeue List";
            this.buttonSqueueList.UseVisualStyleBackColor = true;
            this.buttonSqueueList.Click += new System.EventHandler(this.buttonSqueueList_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // buttonSettings
            // 
            this.buttonSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSettings.Location = new System.Drawing.Point(1023, 0);
            this.buttonSettings.Name = "buttonSettings";
            this.buttonSettings.Size = new System.Drawing.Size(75, 23);
            this.buttonSettings.TabIndex = 60;
            this.buttonSettings.Text = "Settings";
            this.buttonSettings.UseVisualStyleBackColor = true;
            this.buttonSettings.Click += new System.EventHandler(this.buttonSettings_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(1055, 274);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 16);
            this.label1.TabIndex = 70;
            this.label1.Text = "View Control";
            // 
            // checkBoxNodeList
            // 
            this.checkBoxNodeList.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.checkBoxNodeList.AutoSize = true;
            this.checkBoxNodeList.Location = new System.Drawing.Point(1058, 454);
            this.checkBoxNodeList.Name = "checkBoxNodeList";
            this.checkBoxNodeList.Size = new System.Drawing.Size(68, 17);
            this.checkBoxNodeList.TabIndex = 69;
            this.checkBoxNodeList.Text = "NodeList";
            this.checkBoxNodeList.UseVisualStyleBackColor = true;
            this.checkBoxNodeList.CheckedChanged += new System.EventHandler(this.checkBoxNodeList_CheckedChanged);
            // 
            // checkBoxNodes
            // 
            this.checkBoxNodes.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.checkBoxNodes.AutoSize = true;
            this.checkBoxNodes.Location = new System.Drawing.Point(1058, 431);
            this.checkBoxNodes.Name = "checkBoxNodes";
            this.checkBoxNodes.Size = new System.Drawing.Size(57, 17);
            this.checkBoxNodes.TabIndex = 68;
            this.checkBoxNodes.Text = "Nodes";
            this.checkBoxNodes.UseVisualStyleBackColor = true;
            this.checkBoxNodes.CheckedChanged += new System.EventHandler(this.checkBoxNodes_CheckedChanged);
            // 
            // checkBoxTimeLimit
            // 
            this.checkBoxTimeLimit.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.checkBoxTimeLimit.AutoSize = true;
            this.checkBoxTimeLimit.Location = new System.Drawing.Point(1058, 408);
            this.checkBoxTimeLimit.Name = "checkBoxTimeLimit";
            this.checkBoxTimeLimit.Size = new System.Drawing.Size(70, 17);
            this.checkBoxTimeLimit.TabIndex = 67;
            this.checkBoxTimeLimit.Text = "TimeLimit";
            this.checkBoxTimeLimit.UseVisualStyleBackColor = true;
            this.checkBoxTimeLimit.CheckedChanged += new System.EventHandler(this.checkBoxTimeLimit_CheckedChanged);
            // 
            // checkBoxTime
            // 
            this.checkBoxTime.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.checkBoxTime.AutoSize = true;
            this.checkBoxTime.Location = new System.Drawing.Point(1058, 385);
            this.checkBoxTime.Name = "checkBoxTime";
            this.checkBoxTime.Size = new System.Drawing.Size(49, 17);
            this.checkBoxTime.TabIndex = 66;
            this.checkBoxTime.Text = "Time";
            this.checkBoxTime.UseVisualStyleBackColor = true;
            this.checkBoxTime.CheckedChanged += new System.EventHandler(this.checkBoxTime_CheckedChanged);
            // 
            // checkBoxState
            // 
            this.checkBoxState.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.checkBoxState.AutoSize = true;
            this.checkBoxState.Location = new System.Drawing.Point(1058, 362);
            this.checkBoxState.Name = "checkBoxState";
            this.checkBoxState.Size = new System.Drawing.Size(51, 17);
            this.checkBoxState.TabIndex = 65;
            this.checkBoxState.Text = "State";
            this.checkBoxState.UseVisualStyleBackColor = true;
            this.checkBoxState.CheckedChanged += new System.EventHandler(this.checkBoxState_CheckedChanged);
            // 
            // checkBoxUser
            // 
            this.checkBoxUser.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.checkBoxUser.AutoSize = true;
            this.checkBoxUser.Location = new System.Drawing.Point(1058, 339);
            this.checkBoxUser.Name = "checkBoxUser";
            this.checkBoxUser.Size = new System.Drawing.Size(48, 17);
            this.checkBoxUser.TabIndex = 64;
            this.checkBoxUser.Text = "User";
            this.checkBoxUser.UseVisualStyleBackColor = true;
            this.checkBoxUser.CheckedChanged += new System.EventHandler(this.checkBoxUser_CheckedChanged);
            // 
            // checkBoxJob
            // 
            this.checkBoxJob.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.checkBoxJob.AutoSize = true;
            this.checkBoxJob.Location = new System.Drawing.Point(1058, 316);
            this.checkBoxJob.Name = "checkBoxJob";
            this.checkBoxJob.Size = new System.Drawing.Size(43, 17);
            this.checkBoxJob.TabIndex = 63;
            this.checkBoxJob.Text = "Job";
            this.checkBoxJob.UseVisualStyleBackColor = true;
            this.checkBoxJob.CheckedChanged += new System.EventHandler(this.checkBoxName_CheckedChanged);
            // 
            // checkBoxName
            // 
            this.checkBoxName.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.checkBoxName.AutoSize = true;
            this.checkBoxName.Enabled = false;
            this.checkBoxName.Location = new System.Drawing.Point(1058, 293);
            this.checkBoxName.Name = "checkBoxName";
            this.checkBoxName.Size = new System.Drawing.Size(54, 17);
            this.checkBoxName.TabIndex = 61;
            this.checkBoxName.Text = "Name";
            this.checkBoxName.UseVisualStyleBackColor = true;
            this.checkBoxName.CheckedChanged += new System.EventHandler(this.checkBoxJob_CheckedChanged);
            // 
            // checkBoxPartition
            // 
            this.checkBoxPartition.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.checkBoxPartition.AutoSize = true;
            this.checkBoxPartition.Location = new System.Drawing.Point(1058, 477);
            this.checkBoxPartition.Name = "checkBoxPartition";
            this.checkBoxPartition.Size = new System.Drawing.Size(64, 17);
            this.checkBoxPartition.TabIndex = 62;
            this.checkBoxPartition.Text = "Partition";
            this.checkBoxPartition.UseVisualStyleBackColor = true;
            this.checkBoxPartition.CheckedChanged += new System.EventHandler(this.checkBoxPartition_CheckedChanged);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // buttonNewJob
            // 
            this.buttonNewJob.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonNewJob.Location = new System.Drawing.Point(861, 0);
            this.buttonNewJob.Name = "buttonNewJob";
            this.buttonNewJob.Size = new System.Drawing.Size(75, 23);
            this.buttonNewJob.TabIndex = 72;
            this.buttonNewJob.Text = "New Job";
            this.buttonNewJob.UseVisualStyleBackColor = true;
            this.buttonNewJob.Click += new System.EventHandler(this.buttonNewJob_Click);
            // 
            // buttonHistory
            // 
            this.buttonHistory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonHistory.Location = new System.Drawing.Point(780, 0);
            this.buttonHistory.Name = "buttonHistory";
            this.buttonHistory.Size = new System.Drawing.Size(75, 23);
            this.buttonHistory.TabIndex = 73;
            this.buttonHistory.Text = "History";
            this.buttonHistory.UseVisualStyleBackColor = true;
            this.buttonHistory.Click += new System.EventHandler(this.buttonHistory_Click);
            // 
            // backgroundWorker2
            // 
            this.backgroundWorker2.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker2_DoWork);
            this.backgroundWorker2.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker2_RunWorkerCompleted);
            // 
            // panelControlLocation
            // 
            this.panelControlLocation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelControlLocation.Controls.Add(this.buttonCancelMode);
            this.panelControlLocation.Controls.Add(this.buttonStopJobs);
            this.panelControlLocation.Controls.Add(this.buttonHistory);
            this.panelControlLocation.Controls.Add(this.buttonNewJob);
            this.panelControlLocation.Controls.Add(this.buttonSettings);
            this.panelControlLocation.Controls.Add(this.buttonSqueueList);
            this.panelControlLocation.Controls.Add(this.buttonSystemSum);
            this.panelControlLocation.Controls.Add(this.labelLastUpdateSQUEUE);
            this.panelControlLocation.Controls.Add(this.label12);
            this.panelControlLocation.Controls.Add(this.comboBox1);
            this.panelControlLocation.Controls.Add(this.buttonLogOut);
            this.panelControlLocation.Controls.Add(this.buttonUserMyData);
            this.panelControlLocation.Location = new System.Drawing.Point(0, 25);
            this.panelControlLocation.Margin = new System.Windows.Forms.Padding(0);
            this.panelControlLocation.Name = "panelControlLocation";
            this.panelControlLocation.Size = new System.Drawing.Size(1187, 46);
            this.panelControlLocation.TabIndex = 77;
            this.panelControlLocation.Paint += new System.Windows.Forms.PaintEventHandler(this.panelControlLocation_Paint);
            // 
            // buttonCancelMode
            // 
            this.buttonCancelMode.Location = new System.Drawing.Point(156, 20);
            this.buttonCancelMode.Name = "buttonCancelMode";
            this.buttonCancelMode.Size = new System.Drawing.Size(130, 23);
            this.buttonCancelMode.TabIndex = 75;
            this.buttonCancelMode.Text = "Cancel Mode";
            this.buttonCancelMode.UseVisualStyleBackColor = true;
            this.buttonCancelMode.Click += new System.EventHandler(this.buttonCancelMode_Click);
            // 
            // buttonStopJobs
            // 
            this.buttonStopJobs.Location = new System.Drawing.Point(292, 21);
            this.buttonStopJobs.Name = "buttonStopJobs";
            this.buttonStopJobs.Size = new System.Drawing.Size(75, 23);
            this.buttonStopJobs.TabIndex = 74;
            this.buttonStopJobs.Text = "Stop Jobs";
            this.buttonStopJobs.UseVisualStyleBackColor = true;
            this.buttonStopJobs.Click += new System.EventHandler(this.buttonStopJobs_Click);
            // 
            // buttonResize
            // 
            this.buttonResize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonResize.Location = new System.Drawing.Point(1172, 549);
            this.buttonResize.Name = "buttonResize";
            this.buttonResize.Size = new System.Drawing.Size(75, 23);
            this.buttonResize.TabIndex = 78;
            this.buttonResize.Text = "button1";
            this.buttonResize.UseVisualStyleBackColor = true;
            this.buttonResize.MouseDown += new System.Windows.Forms.MouseEventHandler(this.button1_MouseDown);
            this.buttonResize.MouseMove += new System.Windows.Forms.MouseEventHandler(this.button1_MouseMove);
            this.buttonResize.MouseUp += new System.Windows.Forms.MouseEventHandler(this.button1_MouseUp);
            // 
            // panelBorderStyle
            // 
            this.panelBorderStyle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelBorderStyle.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panelBorderStyle.Controls.Add(this.label2);
            this.panelBorderStyle.Controls.Add(this.button_);
            this.panelBorderStyle.Controls.Add(this.buttonX);
            this.panelBorderStyle.Controls.Add(this.buttonM);
            this.panelBorderStyle.Location = new System.Drawing.Point(0, -1);
            this.panelBorderStyle.Margin = new System.Windows.Forms.Padding(0);
            this.panelBorderStyle.Name = "panelBorderStyle";
            this.panelBorderStyle.Size = new System.Drawing.Size(1189, 26);
            this.panelBorderStyle.TabIndex = 76;
            this.panelBorderStyle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelBorderStyle_MouseDown);
            this.panelBorderStyle.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelBorderStyle_MouseMove);
            this.panelBorderStyle.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panelBorderStyle_MouseUp);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(12, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 16);
            this.label2.TabIndex = 78;
            this.label2.Text = "Home";
            // 
            // button_
            // 
            this.button_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.button_.Location = new System.Drawing.Point(1106, 1);
            this.button_.Margin = new System.Windows.Forms.Padding(1);
            this.button_.Name = "button_";
            this.button_.Size = new System.Drawing.Size(26, 22);
            this.button_.TabIndex = 77;
            this.button_.Text = "_";
            this.button_.UseVisualStyleBackColor = true;
            this.button_.Click += new System.EventHandler(this.button__Click);
            // 
            // buttonX
            // 
            this.buttonX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonX.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.buttonX.Location = new System.Drawing.Point(1162, 1);
            this.buttonX.Margin = new System.Windows.Forms.Padding(1);
            this.buttonX.Name = "buttonX";
            this.buttonX.Size = new System.Drawing.Size(26, 22);
            this.buttonX.TabIndex = 77;
            this.buttonX.Text = "X";
            this.buttonX.UseVisualStyleBackColor = true;
            this.buttonX.Click += new System.EventHandler(this.buttonX_Click);
            // 
            // buttonM
            // 
            this.buttonM.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonM.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.buttonM.Location = new System.Drawing.Point(1134, 1);
            this.buttonM.Margin = new System.Windows.Forms.Padding(1);
            this.buttonM.Name = "buttonM";
            this.buttonM.Size = new System.Drawing.Size(26, 22);
            this.buttonM.TabIndex = 75;
            this.buttonM.Text = "[]";
            this.buttonM.UseVisualStyleBackColor = true;
            this.buttonM.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(27, 468);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(972, 54);
            this.pictureBox1.TabIndex = 71;
            this.pictureBox1.TabStop = false;
            // 
            // Functions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1189, 560);
            this.Controls.Add(this.buttonResize);
            this.Controls.Add(this.panelControlLocation);
            this.Controls.Add(this.panelBorderStyle);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.checkBoxNodeList);
            this.Controls.Add(this.checkBoxNodes);
            this.Controls.Add(this.checkBoxTimeLimit);
            this.Controls.Add(this.checkBoxTime);
            this.Controls.Add(this.checkBoxState);
            this.Controls.Add(this.checkBoxUser);
            this.Controls.Add(this.checkBoxJob);
            this.Controls.Add(this.checkBoxPartition);
            this.Controls.Add(this.checkBoxName);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.dataGridView3);
            this.Name = "Functions";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Server";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Functions_FormClosing);
            this.Load += new System.EventHandler(this.Functions_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            this.panelControlLocation.ResumeLayout(false);
            this.panelControlLocation.PerformLayout();
            this.panelBorderStyle.ResumeLayout(false);
            this.panelBorderStyle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonLogOut;
        private System.Windows.Forms.Label labelLastUpdateSQUEUE;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button buttonUserMyData;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label labelCompleteJobsU;
        private System.Windows.Forms.Label labelTotalJobsU;
        private System.Windows.Forms.Label labelRunningJobsU;
        private System.Windows.Forms.Label labelPendingJobsU;
        private System.Windows.Forms.Label labelConfigureJobsU;
        private System.Windows.Forms.Button buttonSystemSum;
        private System.Windows.Forms.Button buttonSqueueList;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button buttonSettings;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBoxNodeList;
        private System.Windows.Forms.CheckBox checkBoxNodes;
        private System.Windows.Forms.CheckBox checkBoxTimeLimit;
        private System.Windows.Forms.CheckBox checkBoxTime;
        private System.Windows.Forms.CheckBox checkBoxState;
        private System.Windows.Forms.CheckBox checkBoxUser;
        private System.Windows.Forms.CheckBox checkBoxJob;
        private System.Windows.Forms.CheckBox checkBoxName;
        private System.Windows.Forms.CheckBox checkBoxPartition;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private PictureBox pictureBox1;
        private Button buttonNewJob;
        private Button buttonHistory;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
        private DataGridView dataGridView3;
        private Button buttonM;
        private Panel panelBorderStyle;
        private Label label2;
        private Button button_;
        private Button buttonX;
        private Panel panelControlLocation;
        private Button buttonResize;
        private Button buttonStopJobs;
        private Button buttonCancelMode;
    }
}