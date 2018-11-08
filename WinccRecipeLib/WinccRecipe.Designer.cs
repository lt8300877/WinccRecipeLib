namespace WinccRecipeLib
{
    partial class WinccRecipe
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

        #region 组件设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.recipeNameCbx = new System.Windows.Forms.ComboBox();
            this.recipeidTbx = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.newBtn = new System.Windows.Forms.Button();
            this.delBtn = new System.Windows.Forms.Button();
            this.saveBtn = new System.Windows.Forms.Button();
            this.downBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // recipeNameCbx
            // 
            this.recipeNameCbx.DropDownHeight = 120;
            this.recipeNameCbx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.recipeNameCbx.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.recipeNameCbx.FormattingEnabled = true;
            this.recipeNameCbx.IntegralHeight = false;
            this.recipeNameCbx.Location = new System.Drawing.Point(66, 31);
            this.recipeNameCbx.Name = "recipeNameCbx";
            this.recipeNameCbx.Size = new System.Drawing.Size(476, 32);
            this.recipeNameCbx.TabIndex = 0;
            this.recipeNameCbx.SelectedIndexChanged += new System.EventHandler(this.recipeNameCbx_SelectedIndexChanged);
            this.recipeNameCbx.Click += new System.EventHandler(this.recipeNameCbx_Click);
            // 
            // recipeidTbx
            // 
            this.recipeidTbx.BackColor = System.Drawing.Color.WhiteSmoke;
            this.recipeidTbx.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.recipeidTbx.Location = new System.Drawing.Point(6, 31);
            this.recipeidTbx.Multiline = true;
            this.recipeidTbx.Name = "recipeidTbx";
            this.recipeidTbx.ReadOnly = true;
            this.recipeidTbx.Size = new System.Drawing.Size(54, 32);
            this.recipeidTbx.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(6, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 21);
            this.label1.TabIndex = 2;
            this.label1.Text = "ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(66, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 21);
            this.label2.TabIndex = 3;
            this.label2.Text = "工件名称";
            // 
            // newBtn
            // 
            this.newBtn.BackColor = System.Drawing.Color.Khaki;
            this.newBtn.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.newBtn.Location = new System.Drawing.Point(68, 69);
            this.newBtn.Name = "newBtn";
            this.newBtn.Size = new System.Drawing.Size(76, 45);
            this.newBtn.TabIndex = 4;
            this.newBtn.Text = "新建";
            this.newBtn.UseVisualStyleBackColor = false;
            this.newBtn.Click += new System.EventHandler(this.newBtn_Click);
            // 
            // delBtn
            // 
            this.delBtn.BackColor = System.Drawing.Color.Khaki;
            this.delBtn.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.delBtn.Location = new System.Drawing.Point(200, 69);
            this.delBtn.Name = "delBtn";
            this.delBtn.Size = new System.Drawing.Size(76, 45);
            this.delBtn.TabIndex = 5;
            this.delBtn.Text = "删除";
            this.delBtn.UseVisualStyleBackColor = false;
            this.delBtn.Click += new System.EventHandler(this.delBtn_Click);
            // 
            // saveBtn
            // 
            this.saveBtn.BackColor = System.Drawing.Color.Khaki;
            this.saveBtn.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.saveBtn.Location = new System.Drawing.Point(332, 69);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(76, 45);
            this.saveBtn.TabIndex = 6;
            this.saveBtn.Text = "保存";
            this.saveBtn.UseVisualStyleBackColor = false;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // downBtn
            // 
            this.downBtn.BackColor = System.Drawing.Color.Khaki;
            this.downBtn.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.downBtn.Location = new System.Drawing.Point(464, 69);
            this.downBtn.Name = "downBtn";
            this.downBtn.Size = new System.Drawing.Size(76, 45);
            this.downBtn.TabIndex = 7;
            this.downBtn.Text = "下载";
            this.downBtn.UseVisualStyleBackColor = false;
            this.downBtn.Click += new System.EventHandler(this.downBtn_Click);
            // 
            // WinccRecipe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(204)))), ((int)(((byte)(255)))));
            this.Controls.Add(this.downBtn);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.delBtn);
            this.Controls.Add(this.newBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.recipeidTbx);
            this.Controls.Add(this.recipeNameCbx);
            this.Name = "WinccRecipe";
            this.Size = new System.Drawing.Size(548, 124);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox recipeNameCbx;
        private System.Windows.Forms.TextBox recipeidTbx;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button newBtn;
        private System.Windows.Forms.Button delBtn;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.Button downBtn;
    }
}
