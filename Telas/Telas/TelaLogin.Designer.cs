using CaixaDeFerramentasPerso;

namespace Telas
{
    partial class TelaLogin
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
            this.SuspendLayout();
            // 
            // lbUsername
            // 
            this.lbUsername.Font = new System.Drawing.Font("Arial", 10F);
            this.lbUsername.Location = new System.Drawing.Point(300, 0);
            this.lbUsername.Name = "lbUsername";
            this.lbUsername.Size = new System.Drawing.Size(250, 100);
            this.lbUsername.TabIndex = 0;
            this.lbUsername.Text = "Nome de Usuário:";
            this.lbUsername.Click += new System.EventHandler(this.lbUsername_Click);
            // 
            // lbPassword
            // 
            this.lbPassword.Font = new System.Drawing.Font("Arial", 10F);
            this.lbPassword.Location = new System.Drawing.Point(300, 200);
            this.lbPassword.Name = "lbPassword";
            this.lbPassword.Size = new System.Drawing.Size(100, 100);
            this.lbPassword.TabIndex = 1;
            this.lbPassword.Text = "Senha:";
            // 
            // tbUsername
            // 
            this.tbUsername.Font = new System.Drawing.Font("Arial", 10F);
            this.tbUsername.Location = new System.Drawing.Point(300, 120);
            this.tbUsername.MaxLength = 55;
            this.tbUsername.Name = "tbUsername";
            this.tbUsername.Size = new System.Drawing.Size(100, 23);
            this.tbUsername.TabIndex = 2;
            // 
            // TelaLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lbUsername);
            this.Controls.Add(this.lbPassword);
            this.Controls.Add(this.tbUsername);
            this.Name = "TelaLogin";
            this.Text = "TelaLogin";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private LabelP lbUsername;
        private LabelP lbPassword;
        private TextBoxP tbUsername;
    }
}