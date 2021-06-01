namespace WindowsFormsApp7
{
    partial class SinfoListPartition
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SinfoListPartition));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.labelLastUpdateSQUEUE = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBoxNode = new System.Windows.Forms.CheckBox();
            this.checkBoxState = new System.Windows.Forms.CheckBox();
            this.checkBoxJobSize = new System.Windows.Forms.CheckBox();
            this.checkBoxTimeLimit = new System.Windows.Forms.CheckBox();
            this.checkBoxPartition = new System.Windows.Forms.CheckBox();
            this.checkBoxAvail = new System.Windows.Forms.CheckBox();
            this.checkBoxNodeList = new System.Windows.Forms.CheckBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panelBorderStyle = new System.Windows.Forms.Panel();
            this.labelFormName = new System.Windows.Forms.Label();
            this.button_ = new System.Windows.Forms.Button();
            this.buttonX = new System.Windows.Forms.Button();
            this.buttonM = new System.Windows.Forms.Button();
            this.buttonResize = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panelBorderStyle.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.GridColor = System.Drawing.Color.Black;
            this.dataGridView1.Location = new System.Drawing.Point(11, 47);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1230, 416);
            this.dataGridView1.TabIndex = 47;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_ColumnHeaderMouseClick);
            this.dataGridView1.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_RowHeaderMouseClick);
            // 
            // labelLastUpdateSQUEUE
            // 
            this.labelLastUpdateSQUEUE.AutoSize = true;
            this.labelLastUpdateSQUEUE.Location = new System.Drawing.Point(8, 32);
            this.labelLastUpdateSQUEUE.Name = "labelLastUpdateSQUEUE";
            this.labelLastUpdateSQUEUE.Size = new System.Drawing.Size(35, 13);
            this.labelLastUpdateSQUEUE.TabIndex = 56;
            this.labelLastUpdateSQUEUE.Text = "label6";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(1246, 120);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 16);
            this.label1.TabIndex = 78;
            this.label1.Text = "View Control";
            // 
            // checkBoxNode
            // 
            this.checkBoxNode.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.checkBoxNode.AutoSize = true;
            this.checkBoxNode.Location = new System.Drawing.Point(1249, 262);
            this.checkBoxNode.Name = "checkBoxNode";
            this.checkBoxNode.Size = new System.Drawing.Size(52, 17);
            this.checkBoxNode.TabIndex = 77;
            this.checkBoxNode.Text = "Node";
            this.checkBoxNode.UseVisualStyleBackColor = true;
            this.checkBoxNode.CheckedChanged += new System.EventHandler(this.checkBoxNodeList_CheckedChanged);
            // 
            // checkBoxState
            // 
            this.checkBoxState.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.checkBoxState.AutoSize = true;
            this.checkBoxState.Location = new System.Drawing.Point(1249, 239);
            this.checkBoxState.Name = "checkBoxState";
            this.checkBoxState.Size = new System.Drawing.Size(51, 17);
            this.checkBoxState.TabIndex = 76;
            this.checkBoxState.Text = "State";
            this.checkBoxState.UseVisualStyleBackColor = true;
            this.checkBoxState.CheckedChanged += new System.EventHandler(this.checkBoxState_CheckedChanged);
            // 
            // checkBoxJobSize
            // 
            this.checkBoxJobSize.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.checkBoxJobSize.AutoSize = true;
            this.checkBoxJobSize.Location = new System.Drawing.Point(1249, 215);
            this.checkBoxJobSize.Name = "checkBoxJobSize";
            this.checkBoxJobSize.Size = new System.Drawing.Size(63, 17);
            this.checkBoxJobSize.TabIndex = 75;
            this.checkBoxJobSize.Text = "JobSize";
            this.checkBoxJobSize.UseVisualStyleBackColor = true;
            this.checkBoxJobSize.CheckedChanged += new System.EventHandler(this.checkBoxNodes_CheckedChanged);
            // 
            // checkBoxTimeLimit
            // 
            this.checkBoxTimeLimit.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.checkBoxTimeLimit.AutoSize = true;
            this.checkBoxTimeLimit.Location = new System.Drawing.Point(1249, 192);
            this.checkBoxTimeLimit.Name = "checkBoxTimeLimit";
            this.checkBoxTimeLimit.Size = new System.Drawing.Size(70, 17);
            this.checkBoxTimeLimit.TabIndex = 74;
            this.checkBoxTimeLimit.Text = "TimeLimit";
            this.checkBoxTimeLimit.UseVisualStyleBackColor = true;
            this.checkBoxTimeLimit.CheckedChanged += new System.EventHandler(this.checkBoxJobSize_CheckedChanged);
            // 
            // checkBoxPartition
            // 
            this.checkBoxPartition.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.checkBoxPartition.AutoSize = true;
            this.checkBoxPartition.Location = new System.Drawing.Point(1249, 166);
            this.checkBoxPartition.Name = "checkBoxPartition";
            this.checkBoxPartition.Size = new System.Drawing.Size(64, 17);
            this.checkBoxPartition.TabIndex = 73;
            this.checkBoxPartition.Text = "Partition";
            this.checkBoxPartition.UseVisualStyleBackColor = true;
            this.checkBoxPartition.CheckedChanged += new System.EventHandler(this.checkBoxTimeLimit_CheckedChanged);
            // 
            // checkBoxAvail
            // 
            this.checkBoxAvail.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.checkBoxAvail.AutoSize = true;
            this.checkBoxAvail.Enabled = false;
            this.checkBoxAvail.Location = new System.Drawing.Point(1249, 143);
            this.checkBoxAvail.Name = "checkBoxAvail";
            this.checkBoxAvail.Size = new System.Drawing.Size(49, 17);
            this.checkBoxAvail.TabIndex = 72;
            this.checkBoxAvail.Text = "Avail";
            this.checkBoxAvail.UseVisualStyleBackColor = true;
            this.checkBoxAvail.CheckedChanged += new System.EventHandler(this.checkBoxAvail_CheckedChanged);
            // 
            // checkBoxNodeList
            // 
            this.checkBoxNodeList.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.checkBoxNodeList.AutoSize = true;
            this.checkBoxNodeList.Location = new System.Drawing.Point(1249, 285);
            this.checkBoxNodeList.Name = "checkBoxNodeList";
            this.checkBoxNodeList.Size = new System.Drawing.Size(68, 17);
            this.checkBoxNodeList.TabIndex = 71;
            this.checkBoxNodeList.Text = "NodeList";
            this.checkBoxNodeList.UseVisualStyleBackColor = true;
            this.checkBoxNodeList.CheckedChanged += new System.EventHandler(this.checkBoxPartition_CheckedChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(11, 468);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(900, 55);
            this.pictureBox1.TabIndex = 79;
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
            this.panelBorderStyle.Size = new System.Drawing.Size(1353, 26);
            this.panelBorderStyle.TabIndex = 81;
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
            this.button_.Location = new System.Drawing.Point(1270, 1);
            this.button_.Margin = new System.Windows.Forms.Padding(1);
            this.button_.Name = "button_";
            this.button_.Size = new System.Drawing.Size(26, 22);
            this.button_.TabIndex = 77;
            this.button_.Text = "_";
            this.button_.UseVisualStyleBackColor = true;
            this.button_.Click += new System.EventHandler(this.button__Click_1);
            // 
            // buttonX
            // 
            this.buttonX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonX.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonX.Location = new System.Drawing.Point(1326, 1);
            this.buttonX.Margin = new System.Windows.Forms.Padding(1);
            this.buttonX.Name = "buttonX";
            this.buttonX.Size = new System.Drawing.Size(26, 22);
            this.buttonX.TabIndex = 77;
            this.buttonX.Text = "X";
            this.buttonX.UseVisualStyleBackColor = true;
            this.buttonX.Click += new System.EventHandler(this.buttonX_Click_1);
            // 
            // buttonM
            // 
            this.buttonM.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonM.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonM.Location = new System.Drawing.Point(1298, 1);
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
            this.buttonResize.Location = new System.Drawing.Point(1337, 517);
            this.buttonResize.Name = "buttonResize";
            this.buttonResize.Size = new System.Drawing.Size(75, 23);
            this.buttonResize.TabIndex = 82;
            this.buttonResize.Text = "button1";
            this.buttonResize.UseVisualStyleBackColor = true;
            this.buttonResize.MouseDown += new System.Windows.Forms.MouseEventHandler(this.button1_MouseDown_1);
            this.buttonResize.MouseMove += new System.Windows.Forms.MouseEventHandler(this.button1_MouseMove_1);
            this.buttonResize.MouseUp += new System.Windows.Forms.MouseEventHandler(this.button1_MouseUp_1);
            // 
            // SinfoListPartition
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1352, 528);
            this.Controls.Add(this.buttonResize);
            this.Controls.Add(this.panelBorderStyle);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.checkBoxNode);
            this.Controls.Add(this.checkBoxState);
            this.Controls.Add(this.checkBoxJobSize);
            this.Controls.Add(this.checkBoxTimeLimit);
            this.Controls.Add(this.checkBoxPartition);
            this.Controls.Add(this.checkBoxAvail);
            this.Controls.Add(this.checkBoxNodeList);
            this.Controls.Add(this.labelLastUpdateSQUEUE);
            this.Controls.Add(this.dataGridView1);
            this.Name = "SinfoListPartition";
            this.Text = "Sinfo List Partition";
            this.Load += new System.EventHandler(this.SinfoListPartition_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panelBorderStyle.ResumeLayout(false);
            this.panelBorderStyle.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBoxNode;
        private System.Windows.Forms.CheckBox checkBoxState;
        private System.Windows.Forms.CheckBox checkBoxJobSize;
        private System.Windows.Forms.CheckBox checkBoxTimeLimit;
        private System.Windows.Forms.CheckBox checkBoxPartition;
        private System.Windows.Forms.CheckBox checkBoxAvail;
        private System.Windows.Forms.CheckBox checkBoxNodeList;
        private System.Windows.Forms.PictureBox pictureBox1;
        public System.Windows.Forms.DataGridView dataGridView1;
        public System.Windows.Forms.Label labelLastUpdateSQUEUE;
        private System.Windows.Forms.Panel panelBorderStyle;
        private System.Windows.Forms.Label labelFormName;
        private System.Windows.Forms.Button button_;
        private System.Windows.Forms.Button buttonX;
        private System.Windows.Forms.Button buttonM;
        private System.Windows.Forms.Button buttonResize;
    }
}