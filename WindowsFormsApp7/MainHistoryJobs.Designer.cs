namespace WindowsFormsApp7
{
    partial class MainHistoryJobs
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
            this.buttonDeleteJobs = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonEditMode = new System.Windows.Forms.Button();
            this.labelLastUpdateSQUEUE = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panelBorderStyle = new System.Windows.Forms.Panel();
            this.labelFormName = new System.Windows.Forms.Label();
            this.button_ = new System.Windows.Forms.Button();
            this.buttonX = new System.Windows.Forms.Button();
            this.buttonM = new System.Windows.Forms.Button();
            this.buttonResize = new System.Windows.Forms.Button();
            this.buttonCancelJobs = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panelBorderStyle.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonDeleteJobs
            // 
            this.buttonDeleteJobs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonDeleteJobs.Location = new System.Drawing.Point(869, 350);
            this.buttonDeleteJobs.Name = "buttonDeleteJobs";
            this.buttonDeleteJobs.Size = new System.Drawing.Size(115, 23);
            this.buttonDeleteJobs.TabIndex = 67;
            this.buttonDeleteJobs.Text = "Delete Jobs";
            this.buttonDeleteJobs.UseVisualStyleBackColor = true;
            this.buttonDeleteJobs.Click += new System.EventHandler(this.buttonCancelJobs_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 376);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 65;
            this.label1.Text = "label1";
            // 
            // buttonEditMode
            // 
            this.buttonEditMode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonEditMode.Location = new System.Drawing.Point(869, 68);
            this.buttonEditMode.Name = "buttonEditMode";
            this.buttonEditMode.Size = new System.Drawing.Size(115, 23);
            this.buttonEditMode.TabIndex = 64;
            this.buttonEditMode.Text = "Edit Mode OFF";
            this.buttonEditMode.UseVisualStyleBackColor = true;
            this.buttonEditMode.Click += new System.EventHandler(this.buttonEditMode_Click);
            // 
            // labelLastUpdateSQUEUE
            // 
            this.labelLastUpdateSQUEUE.AutoSize = true;
            this.labelLastUpdateSQUEUE.Location = new System.Drawing.Point(9, 35);
            this.labelLastUpdateSQUEUE.Name = "labelLastUpdateSQUEUE";
            this.labelLastUpdateSQUEUE.Size = new System.Drawing.Size(35, 13);
            this.labelLastUpdateSQUEUE.TabIndex = 63;
            this.labelLastUpdateSQUEUE.Text = "label6";
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
            this.dataGridView1.Location = new System.Drawing.Point(12, 51);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridView1.Size = new System.Drawing.Size(830, 322);
            this.dataGridView1.TabIndex = 62;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_ColumnHeaderMouseClick_1);
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
            this.panelBorderStyle.Size = new System.Drawing.Size(1007, 26);
            this.panelBorderStyle.TabIndex = 83;
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
            this.button_.Location = new System.Drawing.Point(924, 1);
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
            this.buttonX.Location = new System.Drawing.Point(980, 1);
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
            this.buttonM.Location = new System.Drawing.Point(952, 1);
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
            this.buttonResize.Location = new System.Drawing.Point(991, 401);
            this.buttonResize.Name = "buttonResize";
            this.buttonResize.Size = new System.Drawing.Size(75, 23);
            this.buttonResize.TabIndex = 84;
            this.buttonResize.Text = "button1";
            this.buttonResize.UseVisualStyleBackColor = true;
            this.buttonResize.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonResize_MouseDown);
            this.buttonResize.MouseMove += new System.Windows.Forms.MouseEventHandler(this.buttonResize_MouseMove);
            this.buttonResize.MouseUp += new System.Windows.Forms.MouseEventHandler(this.buttonResize_MouseUp);
            // 
            // buttonCancelJobs
            // 
            this.buttonCancelJobs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancelJobs.Location = new System.Drawing.Point(869, 321);
            this.buttonCancelJobs.Name = "buttonCancelJobs";
            this.buttonCancelJobs.Size = new System.Drawing.Size(115, 23);
            this.buttonCancelJobs.TabIndex = 85;
            this.buttonCancelJobs.Text = "Stop Jobs";
            this.buttonCancelJobs.UseVisualStyleBackColor = true;
            this.buttonCancelJobs.Click += new System.EventHandler(this.buttonCancelJobs_Click_1);
            // 
            // MainHistoryJobs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1006, 411);
            this.Controls.Add(this.buttonCancelJobs);
            this.Controls.Add(this.buttonResize);
            this.Controls.Add(this.panelBorderStyle);
            this.Controls.Add(this.buttonDeleteJobs);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonEditMode);
            this.Controls.Add(this.labelLastUpdateSQUEUE);
            this.Controls.Add(this.dataGridView1);
            this.Name = "MainHistoryJobs";
            this.Text = "MainHistoryJobs";
            this.Load += new System.EventHandler(this.MainHistoryJobs_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panelBorderStyle.ResumeLayout(false);
            this.panelBorderStyle.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonDeleteJobs;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonEditMode;
        public System.Windows.Forms.Label labelLastUpdateSQUEUE;
        public System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panelBorderStyle;
        private System.Windows.Forms.Label labelFormName;
        private System.Windows.Forms.Button button_;
        private System.Windows.Forms.Button buttonX;
        private System.Windows.Forms.Button buttonM;
        private System.Windows.Forms.Button buttonResize;
        private System.Windows.Forms.Button buttonCancelJobs;
    }
}