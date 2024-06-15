using CaixaDeFerramentasPerso;

namespace Telas
{
    partial class atualizarFuncionarios
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
        private void InitializeComponent(string[] listCargo, string[] listSetores)
        {
            this.lbID = new System.Windows.Forms.Label();
            this.lbEmail = new System.Windows.Forms.Label();
            this.lbTelefone = new System.Windows.Forms.Label();
            this.lbEndereco = new System.Windows.Forms.Label();
            this.lbSalario = new System.Windows.Forms.Label();
            this.lbCargo = new System.Windows.Forms.Label();
            this.lbSetor = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbID
            // 
            this.lbID.AutoSize = true;
            this.lbID.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbID.Location = new System.Drawing.Point(24, 8);
            this.lbID.Name = "lbID";
            this.lbID.Size = new System.Drawing.Size(52, 20);
            this.lbID.TabIndex = 0;
            this.lbID.Text = "ID:";
            // 
            // lbEmail
            // 
            this.lbEmail.AutoSize = true;
            this.lbEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbEmail.Location = new System.Drawing.Point(24, 38);
            this.lbEmail.Name = "lbEmail";
            this.lbEmail.Size = new System.Drawing.Size(52, 20);
            this.lbEmail.TabIndex = 0;
            this.lbEmail.Text = "Email:";
            // 
            // label2
            // 
            this.lbTelefone.AutoSize = true;
            this.lbTelefone.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTelefone.Location = new System.Drawing.Point(24, 170);
            this.lbTelefone.Name = "lbSalario";
            this.lbTelefone.Size = new System.Drawing.Size(62, 20);
            this.lbTelefone.TabIndex = 1;
            this.lbTelefone.Text = "Salário:";
            // 
            // label3
            // 
            this.lbEndereco.AutoSize = true;
            this.lbEndereco.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbEndereco.Location = new System.Drawing.Point(24, 79);
            this.lbEndereco.Name = "lbTelefone";
            this.lbEndereco.Size = new System.Drawing.Size(75, 20);
            this.lbEndereco.TabIndex = 2;
            this.lbEndereco.Text = "Telefone:";
            // 
            // label4
            // 
            this.lbSalario.AutoSize = true;
            this.lbSalario.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSalario.Location = new System.Drawing.Point(24, 124);
            this.lbSalario.Name = "lbEndereco";
            this.lbSalario.Size = new System.Drawing.Size(82, 20);
            this.lbSalario.TabIndex = 3;
            this.lbSalario.Text = "Endereço:";
            // 
            // label5
            // 
            this.lbCargo.AutoSize = true;
            this.lbCargo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCargo.Location = new System.Drawing.Point(24, 203);
            this.lbCargo.Name = "lbCargo";
            this.lbCargo.Size = new System.Drawing.Size(56, 20);
            this.lbCargo.TabIndex = 4;
            this.lbCargo.Text = "Cargo:";
            // 
            // label6
            // 
            this.lbSetor.AutoSize = true;
            this.lbSetor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSetor.Location = new System.Drawing.Point(24, 233);
            this.lbSetor.Name = "lbSetor";
            this.lbSetor.Size = new System.Drawing.Size(52, 20);
            this.lbSetor.TabIndex = 5;
            this.lbSetor.Text = "Setor:";
            //
            // TextBox
            //
            textBoxPs[0] = new TextBoxP(100, 20, 8, 154, "", 55, this);
            textBoxPs[0].Enabled = false;
            textBoxPs[1] = new TextBoxP(100, 20, 38, 154, "", 55, this);
            textBoxPs[2] = new TextBoxP(100, 20, 79, 154, "", 55, this);
            textBoxPs[3] = new TextBoxP(100, 20, 124, 154, "", 55, this);
            textBoxPs[4] = new TextBoxP(100, 20, 170, 154, "", 55, this);
            cargos = new ComboBoxP(100, 25, 203, 154, listCargo, this);
            setores = new ComboBoxP(130, 25, 233, 140, listSetores, this);
            //
            // CONCLUIR
            //
            btnConcluir = new ButtonP(true, 100, 25, 265, 999, "Concluir", this);
            btnConcluir.Click += new System.EventHandler(BtnConcluir_Click);
            // 
            // atualizarFuncionarios
            // 
            this.ClientSize = new System.Drawing.Size(384, 361);
            this.Controls.Add(this.lbID);
            this.Controls.Add(this.lbSetor);
            this.Controls.Add(this.lbCargo);
            this.Controls.Add(this.lbSalario);
            this.Controls.Add(this.lbEndereco);
            this.Controls.Add(this.lbTelefone);
            this.Controls.Add(this.lbEmail);
            this.Name = "atualizarFuncionarios";
            this.Text = "atualizarFuncionarios";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lbID;
        private System.Windows.Forms.Label lbEmail;
        private System.Windows.Forms.Label lbTelefone;
        private System.Windows.Forms.Label lbEndereco;
        private System.Windows.Forms.Label lbSalario;
        private System.Windows.Forms.Label lbCargo;
        private System.Windows.Forms.Label lbSetor;
        private ComboBoxP cargos;
        private ComboBoxP setores;
        private ButtonP btnConcluir;
        private TextBoxP[] textBoxPs = new TextBoxP[5];
    }
}