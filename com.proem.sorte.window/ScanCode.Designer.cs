namespace sorteSystem.com.proem.sorte.window
{
    partial class ScanCode
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle61 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle62 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle65 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle63 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle64 = new System.Windows.Forms.DataGridViewCellStyle();
            this.sorteGoodListPanel = new System.Windows.Forms.Panel();
            this.logoPanel = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.logoLabel = new System.Windows.Forms.Label();
            this.timePanel = new System.Windows.Forms.Panel();
            this.branchIdLabel = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.goodTableGroupBox = new System.Windows.Forms.GroupBox();
            this.topPanel = new System.Windows.Forms.Panel();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.calculateButton = new System.Windows.Forms.Button();
            this.numberTextBox = new System.Windows.Forms.TextBox();
            this.Timebutton = new System.Windows.Forms.Button();
            this.goodTablePanel = new System.Windows.Forms.Panel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.goodDataGridView = new System.Windows.Forms.DataGridView();
            this.serialNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.workcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nums = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sorteNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.goodsfile_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pTimer = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.sorteGoodListPanel.SuspendLayout();
            this.logoPanel.SuspendLayout();
            this.goodTableGroupBox.SuspendLayout();
            this.topPanel.SuspendLayout();
            this.goodTablePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.goodDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // sorteGoodListPanel
            // 
            this.sorteGoodListPanel.BackgroundImage = global::sorteSystem.Properties.Resources.login_bg_0;
            this.sorteGoodListPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.sorteGoodListPanel.Controls.Add(this.logoPanel);
            this.sorteGoodListPanel.Controls.Add(this.goodTableGroupBox);
            this.sorteGoodListPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sorteGoodListPanel.Location = new System.Drawing.Point(0, 0);
            this.sorteGoodListPanel.Name = "sorteGoodListPanel";
            this.sorteGoodListPanel.Size = new System.Drawing.Size(1008, 729);
            this.sorteGoodListPanel.TabIndex = 1;
            // 
            // logoPanel
            // 
            this.logoPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.logoPanel.BackgroundImage = global::sorteSystem.Properties.Resources.login_bg_2;
            this.logoPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.logoPanel.Controls.Add(this.button1);
            this.logoPanel.Controls.Add(this.panel4);
            this.logoPanel.Controls.Add(this.logoLabel);
            this.logoPanel.Controls.Add(this.timePanel);
            this.logoPanel.Controls.Add(this.branchIdLabel);
            this.logoPanel.Controls.Add(this.textBox1);
            this.logoPanel.Location = new System.Drawing.Point(0, 0);
            this.logoPanel.Name = "logoPanel";
            this.logoPanel.Size = new System.Drawing.Size(1008, 75);
            this.logoPanel.TabIndex = 29;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(67)))), ((int)(((byte)(65)))));
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("宋体", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(898, 10);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 40);
            this.button1.TabIndex = 1;
            this.button1.Text = "退出";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.panel4.BackgroundImage = global::sorteSystem.Properties.Resources.logo;
            this.panel4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel4.Location = new System.Drawing.Point(20, 10);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(200, 55);
            this.panel4.TabIndex = 28;
            // 
            // logoLabel
            // 
            this.logoLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.logoLabel.AutoSize = true;
            this.logoLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.logoLabel.Font = new System.Drawing.Font("宋体", 32F);
            this.logoLabel.Location = new System.Drawing.Point(220, 16);
            this.logoLabel.Name = "logoLabel";
            this.logoLabel.Size = new System.Drawing.Size(191, 43);
            this.logoLabel.TabIndex = 27;
            this.logoLabel.Text = "分拣系统";
            // 
            // timePanel
            // 
            this.timePanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.timePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.timePanel.Location = new System.Drawing.Point(758, 15);
            this.timePanel.Name = "timePanel";
            this.timePanel.Size = new System.Drawing.Size(119, 32);
            this.timePanel.TabIndex = 25;
            // 
            // branchIdLabel
            // 
            this.branchIdLabel.AutoSize = true;
            this.branchIdLabel.Font = new System.Drawing.Font("宋体", 16F);
            this.branchIdLabel.Location = new System.Drawing.Point(460, 30);
            this.branchIdLabel.Name = "branchIdLabel";
            this.branchIdLabel.Size = new System.Drawing.Size(120, 22);
            this.branchIdLabel.TabIndex = 37;
            this.branchIdLabel.Text = "当前分店：";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("宋体", 16F);
            this.textBox1.Location = new System.Drawing.Point(580, 25);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(150, 32);
            this.textBox1.TabIndex = 39;
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // goodTableGroupBox
            // 
            this.goodTableGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.goodTableGroupBox.Controls.Add(this.topPanel);
            this.goodTableGroupBox.Controls.Add(this.goodTablePanel);
            this.goodTableGroupBox.Location = new System.Drawing.Point(0, 75);
            this.goodTableGroupBox.Name = "goodTableGroupBox";
            this.goodTableGroupBox.Size = new System.Drawing.Size(1008, 654);
            this.goodTableGroupBox.TabIndex = 0;
            this.goodTableGroupBox.TabStop = false;
            this.goodTableGroupBox.Text = "商品列表";
            // 
            // topPanel
            // 
            this.topPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.topPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(234)))), ((int)(((byte)(243)))));
            this.topPanel.Controls.Add(this.label1);
            this.topPanel.Controls.Add(this.textBox2);
            this.topPanel.Controls.Add(this.calculateButton);
            this.topPanel.Controls.Add(this.numberTextBox);
            this.topPanel.Controls.Add(this.Timebutton);
            this.topPanel.Location = new System.Drawing.Point(3, 17);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(1002, 150);
            this.topPanel.TabIndex = 1;
            // 
            // textBox2
            // 
            this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Font = new System.Drawing.Font("宋体", 20F);
            this.textBox2.Location = new System.Drawing.Point(65, 54);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox2.Size = new System.Drawing.Size(900, 88);
            this.textBox2.TabIndex = 73;
            // 
            // calculateButton
            // 
            this.calculateButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.calculateButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(67)))), ((int)(((byte)(65)))));
            this.calculateButton.FlatAppearance.BorderSize = 0;
            this.calculateButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.calculateButton.Font = new System.Drawing.Font("宋体", 12F);
            this.calculateButton.ForeColor = System.Drawing.Color.White;
            this.calculateButton.Location = new System.Drawing.Point(20, 10);
            this.calculateButton.Name = "calculateButton";
            this.calculateButton.Size = new System.Drawing.Size(80, 38);
            this.calculateButton.TabIndex = 72;
            this.calculateButton.Text = "加(F1)";
            this.calculateButton.UseVisualStyleBackColor = false;
            this.calculateButton.Click += new System.EventHandler(this.calculateButton_Click);
            // 
            // numberTextBox
            // 
            this.numberTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.numberTextBox.Font = new System.Drawing.Font("宋体", 20F);
            this.numberTextBox.Location = new System.Drawing.Point(120, 10);
            this.numberTextBox.Name = "numberTextBox";
            this.numberTextBox.Size = new System.Drawing.Size(300, 38);
            this.numberTextBox.TabIndex = 70;
            // 
            // Timebutton
            // 
            this.Timebutton.Location = new System.Drawing.Point(400, 6);
            this.Timebutton.Name = "Timebutton";
            this.Timebutton.Size = new System.Drawing.Size(75, 23);
            this.Timebutton.TabIndex = 47;
            this.Timebutton.Text = "button1";
            this.Timebutton.UseVisualStyleBackColor = true;
            this.Timebutton.Visible = false;
            // 
            // goodTablePanel
            // 
            this.goodTablePanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.goodTablePanel.Controls.Add(this.statusStrip1);
            this.goodTablePanel.Controls.Add(this.goodDataGridView);
            this.goodTablePanel.Location = new System.Drawing.Point(4, 167);
            this.goodTablePanel.Name = "goodTablePanel";
            this.goodTablePanel.Size = new System.Drawing.Size(1000, 533);
            this.goodTablePanel.TabIndex = 0;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 511);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1000, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // goodDataGridView
            // 
            this.goodDataGridView.AllowUserToAddRows = false;
            this.goodDataGridView.AllowUserToDeleteRows = false;
            this.goodDataGridView.AllowUserToResizeColumns = false;
            this.goodDataGridView.AllowUserToResizeRows = false;
            dataGridViewCellStyle61.BackColor = System.Drawing.Color.White;
            this.goodDataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle61;
            this.goodDataGridView.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.goodDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.goodDataGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.goodDataGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle62.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle62.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(247)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle62.Font = new System.Drawing.Font("宋体", 19F);
            dataGridViewCellStyle62.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle62.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle62.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle62.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.goodDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle62;
            this.goodDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.goodDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.serialNumber,
            this.workcode,
            this.name,
            this.nums,
            this.sorteNum,
            this.goodsfile_id});
            dataGridViewCellStyle65.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle65.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle65.Font = new System.Drawing.Font("宋体", 19F);
            dataGridViewCellStyle65.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle65.SelectionBackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle65.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle65.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.goodDataGridView.DefaultCellStyle = dataGridViewCellStyle65;
            this.goodDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.goodDataGridView.EnableHeadersVisualStyles = false;
            this.goodDataGridView.Location = new System.Drawing.Point(0, 0);
            this.goodDataGridView.Name = "goodDataGridView";
            this.goodDataGridView.ReadOnly = true;
            this.goodDataGridView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.goodDataGridView.RowTemplate.Height = 35;
            this.goodDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.goodDataGridView.Size = new System.Drawing.Size(1000, 533);
            this.goodDataGridView.TabIndex = 0;
            // 
            // serialNumber
            // 
            this.serialNumber.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.serialNumber.DataPropertyName = "serialNumber";
            this.serialNumber.FillWeight = 0.2F;
            this.serialNumber.HeaderText = "货号";
            this.serialNumber.Name = "serialNumber";
            this.serialNumber.ReadOnly = true;
            this.serialNumber.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // workcode
            // 
            this.workcode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.workcode.DataPropertyName = "workname";
            this.workcode.FillWeight = 0.2F;
            this.workcode.HeaderText = "工位";
            this.workcode.Name = "workcode";
            this.workcode.ReadOnly = true;
            this.workcode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // name
            // 
            this.name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.name.DataPropertyName = "name";
            this.name.FillWeight = 0.3F;
            this.name.HeaderText = "商品名";
            this.name.Name = "name";
            this.name.ReadOnly = true;
            this.name.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // nums
            // 
            this.nums.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.nums.DataPropertyName = "nums";
            dataGridViewCellStyle63.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.nums.DefaultCellStyle = dataGridViewCellStyle63;
            this.nums.FillWeight = 0.15F;
            this.nums.HeaderText = "订单数量";
            this.nums.Name = "nums";
            this.nums.ReadOnly = true;
            this.nums.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // sorteNum
            // 
            this.sorteNum.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.sorteNum.DataPropertyName = "sorteNum";
            dataGridViewCellStyle64.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.sorteNum.DefaultCellStyle = dataGridViewCellStyle64;
            this.sorteNum.FillWeight = 0.15F;
            this.sorteNum.HeaderText = "分拣数量";
            this.sorteNum.Name = "sorteNum";
            this.sorteNum.ReadOnly = true;
            this.sorteNum.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // goodsfile_id
            // 
            this.goodsfile_id.DataPropertyName = "goodsfile_id";
            this.goodsfile_id.HeaderText = "goodsfile_id";
            this.goodsfile_id.Name = "goodsfile_id";
            this.goodsfile_id.ReadOnly = true;
            this.goodsfile_id.Visible = false;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F);
            this.label1.Location = new System.Drawing.Point(3, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 16);
            this.label1.TabIndex = 74;
            this.label1.Text = "备注：";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ScanCode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 729);
            this.Controls.Add(this.sorteGoodListPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ScanCode";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ScanCode";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.ScanCode_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ScanCode_KeyDown);
            this.sorteGoodListPanel.ResumeLayout(false);
            this.logoPanel.ResumeLayout(false);
            this.logoPanel.PerformLayout();
            this.goodTableGroupBox.ResumeLayout(false);
            this.topPanel.ResumeLayout(false);
            this.topPanel.PerformLayout();
            this.goodTablePanel.ResumeLayout(false);
            this.goodTablePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.goodDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel sorteGoodListPanel;
        private System.Windows.Forms.Panel logoPanel;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label logoLabel;
        private System.Windows.Forms.Panel timePanel;
        private System.Windows.Forms.Label branchIdLabel;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.GroupBox goodTableGroupBox;
        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.Button calculateButton;
        private System.Windows.Forms.TextBox numberTextBox;
        private System.Windows.Forms.Button Timebutton;
        private System.Windows.Forms.Panel goodTablePanel;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.DataGridView goodDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn serialNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn workcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn nums;
        private System.Windows.Forms.DataGridViewTextBoxColumn sorteNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn goodsfile_id;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Timer pTimer;
        private System.Windows.Forms.Label label1;
    }
}