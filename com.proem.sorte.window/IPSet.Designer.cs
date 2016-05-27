namespace sorteSystem.com.proem.sorte.window
{
    partial class IPSet
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
            this.iPSetPanel = new System.Windows.Forms.Panel();
            this.leaveButton = new System.Windows.Forms.Button();
            this.sureButton = new System.Windows.Forms.Button();
            this.twoTextBox = new System.Windows.Forms.TextBox();
            this.twoLabel = new System.Windows.Forms.Label();
            this.oneTextBox = new System.Windows.Forms.TextBox();
            this.oneLabel = new System.Windows.Forms.Label();
            this.iPSetPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // iPSetPanel
            // 
            this.iPSetPanel.BackgroundImage = global::sorteSystem.Properties.Resources.login_bg_0;
            this.iPSetPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.iPSetPanel.Controls.Add(this.leaveButton);
            this.iPSetPanel.Controls.Add(this.sureButton);
            this.iPSetPanel.Controls.Add(this.twoTextBox);
            this.iPSetPanel.Controls.Add(this.twoLabel);
            this.iPSetPanel.Controls.Add(this.oneTextBox);
            this.iPSetPanel.Controls.Add(this.oneLabel);
            this.iPSetPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.iPSetPanel.Location = new System.Drawing.Point(0, 0);
            this.iPSetPanel.Margin = new System.Windows.Forms.Padding(5);
            this.iPSetPanel.Name = "iPSetPanel";
            this.iPSetPanel.Size = new System.Drawing.Size(484, 311);
            this.iPSetPanel.TabIndex = 0;
            // 
            // leaveButton
            // 
            this.leaveButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(173)))), ((int)(((byte)(173)))), ((int)(((byte)(173)))));
            this.leaveButton.FlatAppearance.BorderSize = 0;
            this.leaveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.leaveButton.ForeColor = System.Drawing.Color.White;
            this.leaveButton.Location = new System.Drawing.Point(263, 220);
            this.leaveButton.Margin = new System.Windows.Forms.Padding(5);
            this.leaveButton.Name = "leaveButton";
            this.leaveButton.Size = new System.Drawing.Size(100, 45);
            this.leaveButton.TabIndex = 11;
            this.leaveButton.Text = "取消";
            this.leaveButton.UseVisualStyleBackColor = false;
            this.leaveButton.Click += new System.EventHandler(this.leaveButton_Click);
            // 
            // sureButton
            // 
            this.sureButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(67)))), ((int)(((byte)(65)))));
            this.sureButton.FlatAppearance.BorderSize = 0;
            this.sureButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sureButton.ForeColor = System.Drawing.Color.White;
            this.sureButton.Location = new System.Drawing.Point(122, 220);
            this.sureButton.Margin = new System.Windows.Forms.Padding(5);
            this.sureButton.Name = "sureButton";
            this.sureButton.Size = new System.Drawing.Size(100, 45);
            this.sureButton.TabIndex = 10;
            this.sureButton.Text = "确定";
            this.sureButton.UseVisualStyleBackColor = false;
            this.sureButton.Click += new System.EventHandler(this.sureButton_Click);
            // 
            // twoTextBox
            // 
            this.twoTextBox.Location = new System.Drawing.Point(140, 155);
            this.twoTextBox.Margin = new System.Windows.Forms.Padding(5);
            this.twoTextBox.Name = "twoTextBox";
            this.twoTextBox.Size = new System.Drawing.Size(282, 29);
            this.twoTextBox.TabIndex = 9;
            // 
            // twoLabel
            // 
            this.twoLabel.AutoSize = true;
            this.twoLabel.Location = new System.Drawing.Point(54, 159);
            this.twoLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.twoLabel.Name = "twoLabel";
            this.twoLabel.Size = new System.Drawing.Size(76, 19);
            this.twoLabel.TabIndex = 8;
            this.twoLabel.Text = "工位2：";
            // 
            // oneTextBox
            // 
            this.oneTextBox.Location = new System.Drawing.Point(140, 91);
            this.oneTextBox.Margin = new System.Windows.Forms.Padding(5);
            this.oneTextBox.Name = "oneTextBox";
            this.oneTextBox.Size = new System.Drawing.Size(282, 29);
            this.oneTextBox.TabIndex = 7;
            // 
            // oneLabel
            // 
            this.oneLabel.AutoSize = true;
            this.oneLabel.Location = new System.Drawing.Point(54, 95);
            this.oneLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.oneLabel.Name = "oneLabel";
            this.oneLabel.Size = new System.Drawing.Size(76, 19);
            this.oneLabel.TabIndex = 6;
            this.oneLabel.Text = "工位1：";
            // 
            // IPSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 311);
            this.Controls.Add(this.iPSetPanel);
            this.Font = new System.Drawing.Font("宋体", 14F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "IPSet";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "IP设置";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.IPSet_Load);
            this.iPSetPanel.ResumeLayout(false);
            this.iPSetPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel iPSetPanel;
        private System.Windows.Forms.TextBox twoTextBox;
        private System.Windows.Forms.Label twoLabel;
        private System.Windows.Forms.TextBox oneTextBox;
        private System.Windows.Forms.Label oneLabel;
        private System.Windows.Forms.Button leaveButton;
        private System.Windows.Forms.Button sureButton;
    }
}