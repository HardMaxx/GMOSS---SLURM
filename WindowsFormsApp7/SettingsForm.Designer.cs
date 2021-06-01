namespace WindowsFormsApp7
{
    partial class SettingsForm
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
            this.TextBoxRefreshingTime = new System.Windows.Forms.TextBox();
            this.buttonConfirmRefresh = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.TextBoxRefreshingTimeHistory = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panelBorderStyle = new System.Windows.Forms.Panel();
            this.labelFormName = new System.Windows.Forms.Label();
            this.buttonX = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxLimitMBProgram = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panelBorderStyle.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Refreshing time";
            // 
            // TextBoxRefreshingTime
            // 
            this.TextBoxRefreshingTime.Location = new System.Drawing.Point(28, 54);
            this.TextBoxRefreshingTime.Name = "TextBoxRefreshingTime";
            this.TextBoxRefreshingTime.Size = new System.Drawing.Size(100, 20);
            this.TextBoxRefreshingTime.TabIndex = 1;
            this.TextBoxRefreshingTime.TextChanged += new System.EventHandler(this.TextBoxRefreshingTime_TextChanged);
            // 
            // buttonConfirmRefresh
            // 
            this.buttonConfirmRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonConfirmRefresh.Location = new System.Drawing.Point(290, 161);
            this.buttonConfirmRefresh.Name = "buttonConfirmRefresh";
            this.buttonConfirmRefresh.Size = new System.Drawing.Size(75, 23);
            this.buttonConfirmRefresh.TabIndex = 2;
            this.buttonConfirmRefresh.Text = "Confirm";
            this.buttonConfirmRefresh.UseVisualStyleBackColor = true;
            this.buttonConfirmRefresh.Click += new System.EventHandler(this.buttonConfirmRefresh_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(134, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "seconds";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(134, 112);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "seconds";
            // 
            // TextBoxRefreshingTimeHistory
            // 
            this.TextBoxRefreshingTimeHistory.Location = new System.Drawing.Point(28, 109);
            this.TextBoxRefreshingTimeHistory.Name = "TextBoxRefreshingTimeHistory";
            this.TextBoxRefreshingTimeHistory.Size = new System.Drawing.Size(100, 20);
            this.TextBoxRefreshingTimeHistory.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(25, 93);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(113, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Refreshing time history";
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
            this.panelBorderStyle.Size = new System.Drawing.Size(419, 26);
            this.panelBorderStyle.TabIndex = 85;
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
            this.buttonX.Location = new System.Drawing.Point(392, 1);
            this.buttonX.Margin = new System.Windows.Forms.Padding(1);
            this.buttonX.Name = "buttonX";
            this.buttonX.Size = new System.Drawing.Size(26, 22);
            this.buttonX.TabIndex = 77;
            this.buttonX.Text = "X";
            this.buttonX.UseVisualStyleBackColor = true;
            this.buttonX.Click += new System.EventHandler(this.buttonX_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(134, 166);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(21, 13);
            this.label5.TabIndex = 88;
            this.label5.Text = "mb";
            this.label5.Visible = false;
            // 
            // textBoxLimitMBProgram
            // 
            this.textBoxLimitMBProgram.Location = new System.Drawing.Point(28, 163);
            this.textBoxLimitMBProgram.Name = "textBoxLimitMBProgram";
            this.textBoxLimitMBProgram.Size = new System.Drawing.Size(100, 20);
            this.textBoxLimitMBProgram.TabIndex = 87;
            this.textBoxLimitMBProgram.Visible = false;
            this.textBoxLimitMBProgram.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxLimitMBProgram_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(25, 147);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(141, 13);
            this.label6.TabIndex = 86;
            this.label6.Text = "Limit memory for the program";
            this.label6.Visible = false;
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(419, 222);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBoxLimitMBProgram);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.panelBorderStyle);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TextBoxRefreshingTimeHistory);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonConfirmRefresh);
            this.Controls.Add(this.TextBoxRefreshingTime);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SettingsForm";
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            this.panelBorderStyle.ResumeLayout(false);
            this.panelBorderStyle.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TextBoxRefreshingTime;
        private System.Windows.Forms.Button buttonConfirmRefresh;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TextBoxRefreshingTimeHistory;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panelBorderStyle;
        private System.Windows.Forms.Label labelFormName;
        private System.Windows.Forms.Button buttonX;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxLimitMBProgram;
        private System.Windows.Forms.Label label6;
    }
}