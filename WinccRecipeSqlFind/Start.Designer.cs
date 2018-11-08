namespace WinccRecipeSqlFind
{
    partial class Start
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.findBtn = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.配方操作ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setBtn = new System.Windows.Forms.Button();
            this.serverNameCbx = new System.Windows.Forms.ComboBox();
            this.sqlDataCbx = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // findBtn
            // 
            this.findBtn.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.findBtn.Location = new System.Drawing.Point(125, 128);
            this.findBtn.Name = "findBtn";
            this.findBtn.Size = new System.Drawing.Size(84, 30);
            this.findBtn.TabIndex = 1;
            this.findBtn.Text = "查找";
            this.findBtn.UseVisualStyleBackColor = true;
            this.findBtn.Click += new System.EventHandler(this.findBtn_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.配方操作ToolStripMenuItem,
            this.帮助ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(388, 25);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 配方操作ToolStripMenuItem
            // 
            this.配方操作ToolStripMenuItem.Name = "配方操作ToolStripMenuItem";
            this.配方操作ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.配方操作ToolStripMenuItem.Text = "配方操作";
            this.配方操作ToolStripMenuItem.Click += new System.EventHandler(this.配方操作ToolStripMenuItem_Click);
            // 
            // 帮助ToolStripMenuItem
            // 
            this.帮助ToolStripMenuItem.Name = "帮助ToolStripMenuItem";
            this.帮助ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.帮助ToolStripMenuItem.Text = "帮助";
            // 
            // setBtn
            // 
            this.setBtn.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.setBtn.Location = new System.Drawing.Point(241, 128);
            this.setBtn.Name = "setBtn";
            this.setBtn.Size = new System.Drawing.Size(84, 30);
            this.setBtn.TabIndex = 3;
            this.setBtn.Text = "设置";
            this.setBtn.UseVisualStyleBackColor = true;
            this.setBtn.Click += new System.EventHandler(this.setBtn_Click);
            // 
            // serverNameCbx
            // 
            this.serverNameCbx.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.serverNameCbx.FormattingEnabled = true;
            this.serverNameCbx.Location = new System.Drawing.Point(82, 48);
            this.serverNameCbx.Name = "serverNameCbx";
            this.serverNameCbx.Size = new System.Drawing.Size(294, 22);
            this.serverNameCbx.TabIndex = 4;
            this.serverNameCbx.SelectedIndexChanged += new System.EventHandler(this.serverNameCbx_SelectedIndexChanged);
            // 
            // sqlDataCbx
            // 
            this.sqlDataCbx.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.sqlDataCbx.FormattingEnabled = true;
            this.sqlDataCbx.Location = new System.Drawing.Point(82, 91);
            this.sqlDataCbx.Name = "sqlDataCbx";
            this.sqlDataCbx.Size = new System.Drawing.Size(294, 22);
            this.sqlDataCbx.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(9, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "服务器选择:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(9, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 12);
            this.label2.TabIndex = 7;
            this.label2.Text = "数据库选择:";
            // 
            // Start
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(388, 178);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.sqlDataCbx);
            this.Controls.Add(this.serverNameCbx);
            this.Controls.Add(this.setBtn);
            this.Controls.Add(this.findBtn);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Start";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Wincc配方数据库查找";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button findBtn;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 配方操作ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 帮助ToolStripMenuItem;
        private System.Windows.Forms.Button setBtn;
        private System.Windows.Forms.ComboBox serverNameCbx;
        private System.Windows.Forms.ComboBox sqlDataCbx;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

