namespace WindowsFormsApp7
{
    partial class SinfoPartition
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SinfoPartition));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.labelAvailableNodes = new System.Windows.Forms.Label();
            this.labelUnavailableNodes = new System.Windows.Forms.Label();
            this.labelAvailableSoonNodes = new System.Windows.Forms.Label();
            this.labelLastUpdateSQUEUE = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip2 = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip3 = new System.Windows.Forms.ToolTip(this.components);
            this.checkBoxAvail = new System.Windows.Forms.CheckBox();
            this.checkBoxNodeList = new System.Windows.Forms.CheckBox();
            this.checkBoxPartition = new System.Windows.Forms.CheckBox();
            this.checkBoxTimeLimit = new System.Windows.Forms.CheckBox();
            this.checkJobSize = new System.Windows.Forms.CheckBox();
            this.checkBoxState = new System.Windows.Forms.CheckBox();
            this.checkBoxNode = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panelBorderStyle = new System.Windows.Forms.Panel();
            this.labelFormName = new System.Windows.Forms.Label();
            this.button_ = new System.Windows.Forms.Button();
            this.buttonX = new System.Windows.Forms.Button();
            this.buttonM = new System.Windows.Forms.Button();
            this.buttonResize = new System.Windows.Forms.Button();
            this.labelPartitionName = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panelBorderStyle.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.GridColor = System.Drawing.Color.Black;
            this.dataGridView1.Location = new System.Drawing.Point(20, 58);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1041, 325);
            this.dataGridView1.TabIndex = 37;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_ColumnHeaderMouseClick);
            this.dataGridView1.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_RowHeaderMouseClick);
            // 
            // labelAvailableNodes
            // 
            this.labelAvailableNodes.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelAvailableNodes.AutoSize = true;
            this.labelAvailableNodes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelAvailableNodes.Location = new System.Drawing.Point(1065, 87);
            this.labelAvailableNodes.Margin = new System.Windows.Forms.Padding(2);
            this.labelAvailableNodes.Name = "labelAvailableNodes";
            this.labelAvailableNodes.Size = new System.Drawing.Size(112, 15);
            this.labelAvailableNodes.TabIndex = 52;
            this.labelAvailableNodes.Text = "Available nodes:";
            this.toolTip1.SetToolTip(this.labelAvailableNodes, resources.GetString("labelAvailableNodes.ToolTip"));
            // 
            // labelUnavailableNodes
            // 
            this.labelUnavailableNodes.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelUnavailableNodes.AutoSize = true;
            this.labelUnavailableNodes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelUnavailableNodes.Location = new System.Drawing.Point(1065, 106);
            this.labelUnavailableNodes.Margin = new System.Windows.Forms.Padding(2);
            this.labelUnavailableNodes.Name = "labelUnavailableNodes";
            this.labelUnavailableNodes.Size = new System.Drawing.Size(130, 15);
            this.labelUnavailableNodes.TabIndex = 55;
            this.labelUnavailableNodes.Text = "Unavailable nodes:";
            this.toolTip2.SetToolTip(this.labelUnavailableNodes, resources.GetString("labelUnavailableNodes.ToolTip"));
            // 
            // labelAvailableSoonNodes
            // 
            this.labelAvailableSoonNodes.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelAvailableSoonNodes.AutoSize = true;
            this.labelAvailableSoonNodes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelAvailableSoonNodes.Location = new System.Drawing.Point(1065, 125);
            this.labelAvailableSoonNodes.Margin = new System.Windows.Forms.Padding(2);
            this.labelAvailableSoonNodes.Name = "labelAvailableSoonNodes";
            this.labelAvailableSoonNodes.Size = new System.Drawing.Size(104, 15);
            this.labelAvailableSoonNodes.TabIndex = 56;
            this.labelAvailableSoonNodes.Text = "Available soon:";
            this.toolTip3.SetToolTip(this.labelAvailableSoonNodes, resources.GetString("labelAvailableSoonNodes.ToolTip"));
            // 
            // labelLastUpdateSQUEUE
            // 
            this.labelLastUpdateSQUEUE.AutoSize = true;
            this.labelLastUpdateSQUEUE.Location = new System.Drawing.Point(12, 30);
            this.labelLastUpdateSQUEUE.Name = "labelLastUpdateSQUEUE";
            this.labelLastUpdateSQUEUE.Size = new System.Drawing.Size(35, 13);
            this.labelLastUpdateSQUEUE.TabIndex = 58;
            this.labelLastUpdateSQUEUE.Text = "label6";
            this.labelLastUpdateSQUEUE.Click += new System.EventHandler(this.labelLastUpdateSQUEUE_Click);
            // 
            // checkBoxAvail
            // 
            this.checkBoxAvail.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.checkBoxAvail.AutoSize = true;
            this.checkBoxAvail.Enabled = false;
            this.checkBoxAvail.Location = new System.Drawing.Point(1068, 199);
            this.checkBoxAvail.Name = "checkBoxAvail";
            this.checkBoxAvail.Size = new System.Drawing.Size(49, 17);
            this.checkBoxAvail.TabIndex = 62;
            this.checkBoxAvail.Text = "Avail";
            this.checkBoxAvail.UseVisualStyleBackColor = true;
            this.checkBoxAvail.CheckedChanged += new System.EventHandler(this.checkBoxAvail_CheckedChanged);
            // 
            // checkBoxNodeList
            // 
            this.checkBoxNodeList.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.checkBoxNodeList.AutoSize = true;
            this.checkBoxNodeList.Location = new System.Drawing.Point(1068, 337);
            this.checkBoxNodeList.Name = "checkBoxNodeList";
            this.checkBoxNodeList.Size = new System.Drawing.Size(68, 17);
            this.checkBoxNodeList.TabIndex = 61;
            this.checkBoxNodeList.Text = "NodeList";
            this.checkBoxNodeList.UseVisualStyleBackColor = true;
            this.checkBoxNodeList.CheckedChanged += new System.EventHandler(this.checkBoxPartition_CheckedChanged);
            // 
            // checkBoxPartition
            // 
            this.checkBoxPartition.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.checkBoxPartition.AutoSize = true;
            this.checkBoxPartition.Location = new System.Drawing.Point(1068, 222);
            this.checkBoxPartition.Name = "checkBoxPartition";
            this.checkBoxPartition.Size = new System.Drawing.Size(64, 17);
            this.checkBoxPartition.TabIndex = 63;
            this.checkBoxPartition.Text = "Partition";
            this.checkBoxPartition.UseVisualStyleBackColor = true;
            this.checkBoxPartition.CheckedChanged += new System.EventHandler(this.checkBoxTimeLimit_CheckedChanged);
            // 
            // checkBoxTimeLimit
            // 
            this.checkBoxTimeLimit.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.checkBoxTimeLimit.AutoSize = true;
            this.checkBoxTimeLimit.Location = new System.Drawing.Point(1068, 245);
            this.checkBoxTimeLimit.Name = "checkBoxTimeLimit";
            this.checkBoxTimeLimit.Size = new System.Drawing.Size(70, 17);
            this.checkBoxTimeLimit.TabIndex = 64;
            this.checkBoxTimeLimit.Text = "TimeLimit";
            this.checkBoxTimeLimit.UseVisualStyleBackColor = true;
            this.checkBoxTimeLimit.CheckedChanged += new System.EventHandler(this.checkBoxJobSize_CheckedChanged);
            // 
            // checkJobSize
            // 
            this.checkJobSize.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.checkJobSize.AutoSize = true;
            this.checkJobSize.Location = new System.Drawing.Point(1068, 268);
            this.checkJobSize.Name = "checkJobSize";
            this.checkJobSize.Size = new System.Drawing.Size(63, 17);
            this.checkJobSize.TabIndex = 65;
            this.checkJobSize.Text = "JobSize";
            this.checkJobSize.UseVisualStyleBackColor = true;
            this.checkJobSize.CheckedChanged += new System.EventHandler(this.checkBoxNodes_CheckedChanged);
            // 
            // checkBoxState
            // 
            this.checkBoxState.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.checkBoxState.AutoSize = true;
            this.checkBoxState.Location = new System.Drawing.Point(1068, 291);
            this.checkBoxState.Name = "checkBoxState";
            this.checkBoxState.Size = new System.Drawing.Size(51, 17);
            this.checkBoxState.TabIndex = 66;
            this.checkBoxState.Text = "State";
            this.checkBoxState.UseVisualStyleBackColor = true;
            this.checkBoxState.CheckedChanged += new System.EventHandler(this.checkBoxState_CheckedChanged);
            // 
            // checkBoxNode
            // 
            this.checkBoxNode.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.checkBoxNode.AutoSize = true;
            this.checkBoxNode.Location = new System.Drawing.Point(1068, 314);
            this.checkBoxNode.Name = "checkBoxNode";
            this.checkBoxNode.Size = new System.Drawing.Size(52, 17);
            this.checkBoxNode.TabIndex = 69;
            this.checkBoxNode.Text = "Node";
            this.checkBoxNode.UseVisualStyleBackColor = true;
            this.checkBoxNode.CheckedChanged += new System.EventHandler(this.checkBoxNodeList_CheckedChanged);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(1065, 171);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 16);
            this.label1.TabIndex = 70;
            this.label1.Text = "View Control";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(20, 388);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(900, 49);
            this.pictureBox1.TabIndex = 72;
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
            this.panelBorderStyle.Size = new System.Drawing.Size(1230, 26);
            this.panelBorderStyle.TabIndex = 82;
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
            this.button_.Location = new System.Drawing.Point(1147, 1);
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
            this.buttonX.Location = new System.Drawing.Point(1203, 1);
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
            this.buttonM.Location = new System.Drawing.Point(1175, 1);
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
            this.buttonResize.Location = new System.Drawing.Point(1216, 429);
            this.buttonResize.Name = "buttonResize";
            this.buttonResize.Size = new System.Drawing.Size(75, 23);
            this.buttonResize.TabIndex = 83;
            this.buttonResize.Text = "button1";
            this.buttonResize.UseVisualStyleBackColor = true;
            this.buttonResize.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonResize_MouseDown);
            this.buttonResize.MouseMove += new System.Windows.Forms.MouseEventHandler(this.buttonResize_MouseMove);
            this.buttonResize.MouseUp += new System.Windows.Forms.MouseEventHandler(this.buttonResize_MouseUp);
            // 
            // labelPartitionName
            // 
            this.labelPartitionName.AutoSize = true;
            this.labelPartitionName.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelPartitionName.Location = new System.Drawing.Point(300, 26);
            this.labelPartitionName.Name = "labelPartitionName";
            this.labelPartitionName.Size = new System.Drawing.Size(76, 25);
            this.labelPartitionName.TabIndex = 84;
            this.labelPartitionName.Text = "label2";
            // 
            // SinfoPartition
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1230, 440);
            this.Controls.Add(this.labelPartitionName);
            this.Controls.Add(this.buttonResize);
            this.Controls.Add(this.panelBorderStyle);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelLastUpdateSQUEUE);
            this.Controls.Add(this.checkBoxNode);
            this.Controls.Add(this.labelAvailableSoonNodes);
            this.Controls.Add(this.labelUnavailableNodes);
            this.Controls.Add(this.labelAvailableNodes);
            this.Controls.Add(this.checkBoxState);
            this.Controls.Add(this.checkJobSize);
            this.Controls.Add(this.checkBoxTimeLimit);
            this.Controls.Add(this.checkBoxPartition);
            this.Controls.Add(this.checkBoxAvail);
            this.Controls.Add(this.checkBoxNodeList);
            this.Controls.Add(this.dataGridView1);
            this.Name = "SinfoPartition";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Sinfo Partition";
            this.Load += new System.EventHandler(this.SinfoPartition_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panelBorderStyle.ResumeLayout(false);
            this.panelBorderStyle.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ToolTip toolTip2;
        private System.Windows.Forms.ToolTip toolTip3;
        private System.Windows.Forms.CheckBox checkBoxAvail;
        private System.Windows.Forms.CheckBox checkBoxNodeList;
        private System.Windows.Forms.CheckBox checkBoxPartition;
        private System.Windows.Forms.CheckBox checkBoxTimeLimit;
        private System.Windows.Forms.CheckBox checkJobSize;
        private System.Windows.Forms.CheckBox checkBoxState;
        private System.Windows.Forms.CheckBox checkBoxNode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        public System.Windows.Forms.DataGridView dataGridView1;
        public System.Windows.Forms.Label labelAvailableNodes;
        public System.Windows.Forms.Label labelUnavailableNodes;
        public System.Windows.Forms.Label labelAvailableSoonNodes;
        public System.Windows.Forms.Label labelLastUpdateSQUEUE;
        private System.Windows.Forms.Panel panelBorderStyle;
        private System.Windows.Forms.Label labelFormName;
        private System.Windows.Forms.Button button_;
        private System.Windows.Forms.Button buttonX;
        private System.Windows.Forms.Button buttonM;
        private System.Windows.Forms.Button buttonResize;
        private System.Windows.Forms.Label labelPartitionName;
    }
}