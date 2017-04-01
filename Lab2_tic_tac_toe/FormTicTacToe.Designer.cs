namespace Lab2_tic_tac_toe
{
    partial class FormTicTacToe
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // FormTicTacToe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(481, 438);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(499, 485);
            this.MinimumSize = new System.Drawing.Size(499, 485);
            this.Name = "FormTicTacToe";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Крестики-нолики";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FormTicTacToe_Paint);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.FormTicTacToe_MouseClick);
            this.ResumeLayout(false);

        }

        #endregion
    }
}

