namespace WinccRecipeSqlFind
{
    partial class RecipeSet
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
            this.winccRecipe1 = new WinccRecipeLib.WinccRecipe();
            this.SuspendLayout();
            // 
            // winccRecipe1
            // 
            this.winccRecipe1.BackColor = System.Drawing.Color.Cyan;
            this.winccRecipe1.Location = new System.Drawing.Point(36, 66);
            this.winccRecipe1.Name = "winccRecipe1";
            this.winccRecipe1.Size = new System.Drawing.Size(548, 162);
            this.winccRecipe1.TabIndex = 0;
            // 
            // RecipeSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(619, 328);
            this.Controls.Add(this.winccRecipe1);
            this.Name = "RecipeSet";
            this.Text = "WINCC配方操作";
            this.ResumeLayout(false);

        }

        #endregion

        private WinccRecipeLib.WinccRecipe winccRecipe1;
    }
}