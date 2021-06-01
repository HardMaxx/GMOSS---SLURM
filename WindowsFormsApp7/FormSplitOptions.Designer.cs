namespace WindowsFormsApp7
{
    partial class FormSplitOptions
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
            this.checkBoxSequencePerFile = new System.Windows.Forms.CheckBox();
            this.checkBoxNumberOfFiles = new System.Windows.Forms.CheckBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.labelCheckDependent = new System.Windows.Forms.Label();
            this.buttonAccept = new System.Windows.Forms.Button();
            this.panelBorderStyle = new System.Windows.Forms.Panel();
            this.labelFormName = new System.Windows.Forms.Label();
            this.buttonX = new System.Windows.Forms.Button();
            this.panelBorderStyle.SuspendLayout();
            this.SuspendLayout();
            // 
            // checkBoxSequencePerFile
            // 
            this.checkBoxSequencePerFile.AutoSize = true;
            this.checkBoxSequencePerFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.checkBoxSequencePerFile.Location = new System.Drawing.Point(37, 78);
            this.checkBoxSequencePerFile.Name = "checkBoxSequencePerFile";
            this.checkBoxSequencePerFile.Size = new System.Drawing.Size(187, 19);
            this.checkBoxSequencePerFile.TabIndex = 0;
            this.checkBoxSequencePerFile.Text = "Number of sequences per file";
            this.checkBoxSequencePerFile.UseVisualStyleBackColor = true;
            this.checkBoxSequencePerFile.CheckedChanged += new System.EventHandler(this.checkBoxSequencePerFile_CheckedChanged);
            // 
            // checkBoxNumberOfFiles
            // 
            this.checkBoxNumberOfFiles.AutoSize = true;
            this.checkBoxNumberOfFiles.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.checkBoxNumberOfFiles.Location = new System.Drawing.Point(37, 118);
            this.checkBoxNumberOfFiles.Name = "checkBoxNumberOfFiles";
            this.checkBoxNumberOfFiles.Size = new System.Drawing.Size(113, 19);
            this.checkBoxNumberOfFiles.TabIndex = 1;
            this.checkBoxNumberOfFiles.Text = "Number of Files";
            this.checkBoxNumberOfFiles.UseVisualStyleBackColor = true;
            this.checkBoxNumberOfFiles.CheckedChanged += new System.EventHandler(this.checkBoxNumberOfFiles_CheckedChanged);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(37, 165);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 2;
            this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(34, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(151, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "File splitting options:";
            // 
            // labelCheckDependent
            // 
            this.labelCheckDependent.AutoSize = true;
            this.labelCheckDependent.Location = new System.Drawing.Point(144, 171);
            this.labelCheckDependent.Name = "labelCheckDependent";
            this.labelCheckDependent.Size = new System.Drawing.Size(35, 13);
            this.labelCheckDependent.TabIndex = 4;
            this.labelCheckDependent.Text = "label2";
            // 
            // buttonAccept
            // 
            this.buttonAccept.Location = new System.Drawing.Point(246, 161);
            this.buttonAccept.Name = "buttonAccept";
            this.buttonAccept.Size = new System.Drawing.Size(75, 23);
            this.buttonAccept.TabIndex = 5;
            this.buttonAccept.Text = "Accept";
            this.buttonAccept.UseVisualStyleBackColor = true;
            this.buttonAccept.Click += new System.EventHandler(this.buttonAccept_Click);
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
            this.panelBorderStyle.Size = new System.Drawing.Size(356, 26);
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
            // buttonX
            // 
            this.buttonX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonX.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonX.Location = new System.Drawing.Point(329, 1);
            this.buttonX.Margin = new System.Windows.Forms.Padding(1);
            this.buttonX.Name = "buttonX";
            this.buttonX.Size = new System.Drawing.Size(26, 22);
            this.buttonX.TabIndex = 77;
            this.buttonX.Text = "X";
            this.buttonX.UseVisualStyleBackColor = true;
            this.buttonX.Click += new System.EventHandler(this.buttonX_Click);
            // 
            // FormSplitOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(355, 220);
            this.Controls.Add(this.panelBorderStyle);
            this.Controls.Add(this.buttonAccept);
            this.Controls.Add(this.labelCheckDependent);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.checkBoxNumberOfFiles);
            this.Controls.Add(this.checkBoxSequencePerFile);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormSplitOptions";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormSplitOptions";
            this.Load += new System.EventHandler(this.FormSplitOptions_Load);
            this.panelBorderStyle.ResumeLayout(false);
            this.panelBorderStyle.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBoxSequencePerFile;
        private System.Windows.Forms.CheckBox checkBoxNumberOfFiles;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelCheckDependent;
        private System.Windows.Forms.Button buttonAccept;
        private System.Windows.Forms.Panel panelBorderStyle;
        private System.Windows.Forms.Label labelFormName;
        private System.Windows.Forms.Button buttonX;
    }
}