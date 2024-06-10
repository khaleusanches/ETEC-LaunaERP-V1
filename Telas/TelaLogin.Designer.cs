using CaixaDeFerramentasPerso;
using System;
using System.Windows.Forms;

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
            this.Width = 1000;
            this.Height = 720;
            this.SuspendLayout();
            // 
            // lbUsername
            // 
            lbUsername = new LabelP(150, 25, 125, 999, "Nome de Usuário:", this);
            // 
            // lbPassword
            // 
            lbSenha = new LabelP(150, 25, 200, 999, "Senha:", this);
            // 
            // tbUsername
            // 
            tbUsername = new TextBoxP(150, 50, 150, 999, "", 50, this);
            tbUsername.TextChanged += new System.EventHandler(tbUsername_tbSenha_TextChanged);
            // 
            // tbSenha
            // 
            tbSenha = new TextBoxP(150, 50, 225, 999, "", 50, this);
            tbSenha.TextChanged += new System.EventHandler(tbUsername_tbSenha_TextChanged);
            tbSenha.PasswordChar = '*';
            // 
            // btnLogar
            // 
            btnLogar = new ButtonP(true, 150, 35, 275, 999, "Logar", this);
            btnLogar.Click += new System.EventHandler(btnLogar_Click);
            btnLogar.Enabled = false;
            // 
            // TelaLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.ClientSize = new System.Drawing.Size(800, 450);
           
            this.MaximizeBox = false;
            this.Controls.Add(this.lbUsername);
            this.Controls.Add(this.lbSenha);
            this.Controls.Add(this.tbUsername);
            this.Controls.Add(this.tbSenha);
            this.Controls.Add(this.btnLogar);
            this.Name = "TelaLogin";
            this.Text = "TelaLogin";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private LabelP lbUsername;
        private LabelP lbSenha;
        private TextBoxP tbUsername;
        private TextBoxP tbSenha;
        private ButtonP btnLogar;
    }
}