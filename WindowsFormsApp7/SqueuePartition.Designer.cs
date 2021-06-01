namespace WindowsFormsApp7
{
    partial class SqueuePartition
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SqueuePartition));
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
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.labelLastUpdateSQUEUE = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBoxNodeList = new System.Windows.Forms.CheckBox();
            this.checkBoxNodes = new System.Windows.Forms.CheckBox();
            this.checkBoxTimeLimit = new System.Windows.Forms.CheckBox();
            this.checkBoxTime = new System.Windows.Forms.CheckBox();
            this.checkBoxState = new System.Windows.Forms.CheckBox();
            this.checkBoxUser = new System.Windows.Forms.CheckBox();
            this.checkBoxJob = new System.Windows.Forms.CheckBox();
            this.checkBoxPartition = new System.Windows.Forms.CheckBox();
            this.checkBoxName = new System.Windows.Forms.CheckBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panelBorderStyle = new System.Windows.Forms.Panel();
            this.labelFormName = new System.Windows.Forms.Label();
            this.button_ = new System.Windows.Forms.Button();
            this.buttonX = new System.Windows.Forms.Button();
            this.buttonM = new System.Windows.Forms.Button();
            this.buttonResize = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panelBorderStyle.SuspendLayout();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(1016, 44);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 16);
            this.label6.TabIndex = 69;
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
            this.panel2.Location = new System.Drawing.Point(1019, 63);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(130, 144);
            this.panel2.TabIndex = 70;
            // 
            // labelConfigureJobsU
            // 
            this.labelConfigureJobsU.AutoSize = true;
            this.labelConfigureJobsU.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
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
            this.labelCompleteJobsU.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
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
            this.labelTotalJobsU.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelTotalJobsU.Location = new System.Drawing.Point(3, 4);
            this.labelTotalJobsU.Margin = new System.Windows.Forms.Padding(2);
            this.labelTotalJobsU.Name = "labelTotalJobsU";
            this.labelTotalJobsU.Size = new System.Drawing.Size(70, 13);
            this.labelTotalJobsU.TabIndex = 7;
            this.labelTotalJobsU.Text = "Total Jobs:";
            // 
            // labelRunningJobsU
            // 
            this.labelRunningJobsU.AutoSize = true;
            this.labelRunningJobsU.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
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
            this.labelPendingJobsU.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
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
            this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dataGridView3.Location = new System.Drawing.Point(12, 43);
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.ReadOnly = true;
            this.dataGridView3.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridView3.Size = new System.Drawing.Size(1001, 422);
            this.dataGridView3.TabIndex = 68;
            this.dataGridView3.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView3_CellClick);
            this.dataGridView3.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView3_CellContentClick);
            this.dataGridView3.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView3_ColumnHeaderMouseClick);
            this.dataGridView3.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView3_RowHeaderMouseClick);
            // 
            // labelLastUpdateSQUEUE
            // 
            this.labelLastUpdateSQUEUE.AutoSize = true;
            this.labelLastUpdateSQUEUE.Location = new System.Drawing.Point(9, 27);
            this.labelLastUpdateSQUEUE.Name = "labelLastUpdateSQUEUE";
            this.labelLastUpdateSQUEUE.Size = new System.Drawing.Size(35, 13);
            this.labelLastUpdateSQUEUE.TabIndex = 72;
            this.labelLastUpdateSQUEUE.Text = "label6";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(1016, 219);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 16);
            this.label1.TabIndex = 82;
            this.label1.Text = "View Control";
            // 
            // checkBoxNodeList
            // 
            this.checkBoxNodeList.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.checkBoxNodeList.AutoSize = true;
            this.checkBoxNodeList.Location = new System.Drawing.Point(1019, 399);
            this.checkBoxNodeList.Name = "checkBoxNodeList";
            this.checkBoxNodeList.Size = new System.Drawing.Size(68, 17);
            this.checkBoxNodeList.TabIndex = 81;
            this.checkBoxNodeList.Text = "NodeList";
            this.checkBoxNodeList.UseVisualStyleBackColor = true;
            this.checkBoxNodeList.CheckedChanged += new System.EventHandler(this.checkBoxNodeList_CheckedChanged);
            // 
            // checkBoxNodes
            // 
            this.checkBoxNodes.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.checkBoxNodes.AutoSize = true;
            this.checkBoxNodes.Location = new System.Drawing.Point(1019, 376);
            this.checkBoxNodes.Name = "checkBoxNodes";
            this.checkBoxNodes.Size = new System.Drawing.Size(57, 17);
            this.checkBoxNodes.TabIndex = 80;
            this.checkBoxNodes.Text = "Nodes";
            this.checkBoxNodes.UseVisualStyleBackColor = true;
            this.checkBoxNodes.CheckedChanged += new System.EventHandler(this.checkBoxNodes_CheckedChanged);
            // 
            // checkBoxTimeLimit
            // 
            this.checkBoxTimeLimit.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.checkBoxTimeLimit.AutoSize = true;
            this.checkBoxTimeLimit.Location = new System.Drawing.Point(1019, 353);
            this.checkBoxTimeLimit.Name = "checkBoxTimeLimit";
            this.checkBoxTimeLimit.Size = new System.Drawing.Size(70, 17);
            this.checkBoxTimeLimit.TabIndex = 79;
            this.checkBoxTimeLimit.Text = "TimeLimit";
            this.checkBoxTimeLimit.UseVisualStyleBackColor = true;
            this.checkBoxTimeLimit.CheckedChanged += new System.EventHandler(this.checkBoxTimeLimit_CheckedChanged);
            // 
            // checkBoxTime
            // 
            this.checkBoxTime.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.checkBoxTime.AutoSize = true;
            this.checkBoxTime.Location = new System.Drawing.Point(1019, 330);
            this.checkBoxTime.Name = "checkBoxTime";
            this.checkBoxTime.Size = new System.Drawing.Size(49, 17);
            this.checkBoxTime.TabIndex = 78;
            this.checkBoxTime.Text = "Time";
            this.checkBoxTime.UseVisualStyleBackColor = true;
            this.checkBoxTime.CheckedChanged += new System.EventHandler(this.checkBoxTime_CheckedChanged);
            // 
            // checkBoxState
            // 
            this.checkBoxState.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.checkBoxState.AutoSize = true;
            this.checkBoxState.Location = new System.Drawing.Point(1019, 307);
            this.checkBoxState.Name = "checkBoxState";
            this.checkBoxState.Size = new System.Drawing.Size(51, 17);
            this.checkBoxState.TabIndex = 77;
            this.checkBoxState.Text = "State";
            this.checkBoxState.UseVisualStyleBackColor = true;
            this.checkBoxState.CheckedChanged += new System.EventHandler(this.checkBoxState_CheckedChanged);
            // 
            // checkBoxUser
            // 
            this.checkBoxUser.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.checkBoxUser.AutoSize = true;
            this.checkBoxUser.Location = new System.Drawing.Point(1019, 284);
            this.checkBoxUser.Name = "checkBoxUser";
            this.checkBoxUser.Size = new System.Drawing.Size(48, 17);
            this.checkBoxUser.TabIndex = 76;
            this.checkBoxUser.Text = "User";
            this.checkBoxUser.UseVisualStyleBackColor = true;
            this.checkBoxUser.CheckedChanged += new System.EventHandler(this.checkBoxUser_CheckedChanged);
            // 
            // checkBoxJob
            // 
            this.checkBoxJob.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.checkBoxJob.AutoSize = true;
            this.checkBoxJob.Location = new System.Drawing.Point(1019, 261);
            this.checkBoxJob.Name = "checkBoxJob";
            this.checkBoxJob.Size = new System.Drawing.Size(43, 17);
            this.checkBoxJob.TabIndex = 75;
            this.checkBoxJob.Text = "Job";
            this.checkBoxJob.UseVisualStyleBackColor = true;
            this.checkBoxJob.CheckedChanged += new System.EventHandler(this.checkBoxName_CheckedChanged);
            // 
            // checkBoxPartition
            // 
            this.checkBoxPartition.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.checkBoxPartition.AutoSize = true;
            this.checkBoxPartition.Location = new System.Drawing.Point(1019, 422);
            this.checkBoxPartition.Name = "checkBoxPartition";
            this.checkBoxPartition.Size = new System.Drawing.Size(64, 17);
            this.checkBoxPartition.TabIndex = 74;
            this.checkBoxPartition.Text = "Partition";
            this.checkBoxPartition.UseVisualStyleBackColor = true;
            this.checkBoxPartition.CheckedChanged += new System.EventHandler(this.checkBoxPartition_CheckedChanged);
            // 
            // checkBoxName
            // 
            this.checkBoxName.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.checkBoxName.AutoSize = true;
            this.checkBoxName.Enabled = false;
            this.checkBoxName.Location = new System.Drawing.Point(1019, 238);
            this.checkBoxName.Name = "checkBoxName";
            this.checkBoxName.Size = new System.Drawing.Size(54, 17);
            this.checkBoxName.TabIndex = 73;
            this.checkBoxName.Text = "Name";
            this.checkBoxName.UseVisualStyleBackColor = true;
            this.checkBoxName.CheckedChanged += new System.EventHandler(this.checkBoxJob_CheckedChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 479);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(844, 62);
            this.pictureBox1.TabIndex = 83;
            this.pictureBox1.TabStop = false;
            // 
            // panelBorderStyle
            // 
            this.panelBorderStyle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelBorderStyle.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panelBorderStyle.Controls.Add(this.labelFormName);
            this.panelBorderStyle.Controls.Add(this.button_);
            this.panelBorderStyle.Controls.Add(this.buttonX);
            this.panelBorderStyle.Controls.Add(this.buttonM);
            this.panelBorderStyle.Location = new System.Drawing.Point(0, 0);
            this.panelBorderStyle.Margin = new System.Windows.Forms.Padding(0);
            this.panelBorderStyle.Name = "panelBorderStyle";
            this.panelBorderStyle.Size = new System.Drawing.Size(1156, 26);
            this.panelBorderStyle.TabIndex = 84;
            this.panelBorderStyle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelBorderStyle_MouseDown);
            this.panelBorderStyle.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelBorderStyle_MouseMove);
            this.panelBorderStyle.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panelBorderStyle_MouseUp);
            // 
            // labelFormName
            // 
            this.labelFormName.AutoSize = true;
            this.labelFormName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelFormName.Location = new System.Drawing.Point(12, 4);
            this.labelFormName.Name = "labelFormName";
            this.labelFormName.Size = new System.Drawing.Size(49, 16);
            this.labelFormName.TabIndex = 78;
            this.labelFormName.Text = "Home";
            // 
            // button_
            // 
            this.button_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button_.Location = new System.Drawing.Point(1073, 1);
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
            this.buttonX.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonX.Location = new System.Drawing.Point(1129, 1);
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
            this.buttonM.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonM.Location = new System.Drawing.Point(1101, 1);
            this.buttonM.Margin = new System.Windows.Forms.Padding(1);
            this.buttonM.Name = "buttonM";
            this.buttonM.Size = new System.Drawing.Size(26, 22);
            this.buttonM.TabIndex = 75;
            this.buttonM.Text = "[]";
            this.buttonM.UseVisualStyleBackColor = true;
            this.buttonM.Click += new System.EventHandler(this.buttonM_Click);
            // 
            // buttonResize
            // 
            this.buttonResize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonResize.Location = new System.Drawing.Point(1140, 541);
            this.buttonResize.Name = "buttonResize";
            this.buttonResize.Size = new System.Drawing.Size(75, 23);
            this.buttonResize.TabIndex = 85;
            this.buttonResize.Text = "button1";
            this.buttonResize.UseVisualStyleBackColor = true;
            this.buttonResize.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonResize_MouseDown);
            this.buttonResize.MouseMove += new System.Windows.Forms.MouseEventHandler(this.buttonResize_MouseMove);
            this.buttonResize.MouseUp += new System.Windows.Forms.MouseEventHandler(this.buttonResize_MouseUp);
            // 
            // SqueuePartition
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1156, 553);
            this.Controls.Add(this.buttonResize);
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
            this.Controls.Add(this.labelLastUpdateSQUEUE);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.dataGridView3);
            this.Name = "SqueuePartition";
            this.Text = "Squeue Partition";
            this.Load += new System.EventHandler(this.queuePartitionSqueue_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panelBorderStyle.ResumeLayout(false);
            this.panelBorderStyle.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBoxNodeList;
        private System.Windows.Forms.CheckBox checkBoxNodes;
        private System.Windows.Forms.CheckBox checkBoxTimeLimit;
        private System.Windows.Forms.CheckBox checkBoxTime;
        private System.Windows.Forms.CheckBox checkBoxState;
        private System.Windows.Forms.CheckBox checkBoxUser;
        private System.Windows.Forms.CheckBox checkBoxJob;
        private System.Windows.Forms.CheckBox checkBoxPartition;
        private System.Windows.Forms.CheckBox checkBoxName;
        private System.Windows.Forms.PictureBox pictureBox1;
        public System.Windows.Forms.Label labelConfigureJobsU;
        public System.Windows.Forms.Label labelCompleteJobsU;
        public System.Windows.Forms.Label labelTotalJobsU;
        public System.Windows.Forms.Label labelRunningJobsU;
        public System.Windows.Forms.Label labelPendingJobsU;
        public System.Windows.Forms.DataGridView dataGridView3;
        private System.Windows.Forms.Label labelLastUpdateSQUEUE;
        private System.Windows.Forms.Panel panelBorderStyle;
        private System.Windows.Forms.Label labelFormName;
        private System.Windows.Forms.Button button_;
        private System.Windows.Forms.Button buttonX;
        private System.Windows.Forms.Button buttonM;
        private System.Windows.Forms.Button buttonResize;
    }
}