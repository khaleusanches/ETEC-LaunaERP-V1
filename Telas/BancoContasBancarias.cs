using CaixaDeFerramentasPerso;
using Logica;
using System.Drawing;
using System;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Telas
{
    public class BancoContasBancarias : InterfacesBanco
    {
        LabelP[] labelPs = new LabelP[10];
        int incrementoTop = 40;
        private TextBoxP[] textBoxPs = new TextBoxP[9];

        private DataGridViewP dgv;
        private DAO dao = new DAO();
        private ButtonP btnAdd;
        private ButtonP btnRemove;
        private PanelP container;

        public override void exibir(TelaPadrao tela)
        {
            int top = 165;
            int left = 35;
            container = new PanelP(340, 430, 100, 25, Color.White, tela);
            labelPs[9] = new LabelP(100, 20, 125, 35, "CONTAS NOS BANCOS", tela);
            labelPs[9].Font = new Font("Arial", 12, FontStyle.Bold);
            labelPs[0] = new LabelP(150, 20, top, left, "ID da Conta Bancária:", tela);
            textBoxPs[0] = new TextBoxP(50, 20, top, left + 160, "", 10, tela);
            textBoxPs[0].ReadOnly = true;
            top += incrementoTop;

            labelPs[1] = new LabelP(120, 20, top, left, "Nome do Banco:", tela);
            textBoxPs[1] = new TextBoxP(150, 20, top, left + 160, "", 50, tela);
            top += incrementoTop;

            labelPs[2] = new LabelP(140, 20, top, left, "Número da Agência:", tela);
            textBoxPs[2] = new TextBoxP(150, 20, top, left + 160, "", 14, tela, isQuant:true);
            top += incrementoTop;

            labelPs[3] = new LabelP(140, 20, top, left, "Número da Conta:", tela);
            textBoxPs[3] = new TextBoxP(150, 20, top, left + 160, "", 20, tela, isQuant:true);
            top += incrementoTop;

            labelPs[4] = new LabelP(150, 20, top, left, "Tipo de Conta:", tela);
            textBoxPs[4] = new TextBoxP(150, 20, top, left + 160, "", 20, tela);
            top += incrementoTop;

            labelPs[5] = new LabelP(120, 20, top, left, "Nome do Titular:", tela);
            textBoxPs[5] = new TextBoxP(150, 20, top, left + 160, "", 100, tela); 
            top += incrementoTop;

            labelPs[6] = new LabelP(160, 20, top, left, "CPF/CNPJ do Titular:", tela);
            textBoxPs[6] = new TextBoxP(150, 20, top, left + 160, "", 14, tela, isQuant:true); 
            top += incrementoTop;

            labelPs[7] = new LabelP(160, 20, top, left, "Telefone do Banco:", tela);
            textBoxPs[7] = new TextBoxP(150, 20, top, left + 160, "", 15, tela, isQuant:true); 
            top += incrementoTop;

            labelPs[8] = new LabelP(160, 20, top, left, "E-mail de Contato:", tela);
            textBoxPs[8] = new TextBoxP(150, 20, top, left + 160, "", 50, tela);
            top += incrementoTop + 25;

            foreach (TextBoxP tbps in textBoxPs)
            {
                tbps.TextChanged += new EventHandler(BancoContasBancarias_TextChanged);
            }
            btnAdd = new ButtonP(true, 120, 50, top, left, "Cadastrar Conta", tela);
            btnAdd.Enabled = false;
            btnAdd.Click += new EventHandler(Btn_add_Click);
            btnRemove = new ButtonP(true, 150, 50, top, left+125, "Remover Conta", tela);
            btnRemove.Click += new EventHandler(BtnRemove_Click);

            dgv = new DataGridViewP(800, 500, 100, 375, dao.lerTabela("select * from ContasBancarias"), tela);
            dgv.SelectionChanged += Dgv_SelectionChanged;

        }

        private void BtnRemove_Click(object sender, EventArgs e)
        {
            if (dgv.Rows.Count > 1 && dgv.SelectedCells.Count > 0 && dgv.SelectedRows[0].Index < dgv.Rows.Count - 1)
            {
                int i = int.Parse(dgv.SelectedCells[0].Value.ToString());
                dao.updateInsertDelete($"DELETE from ContasBancarias where id={i}");
                dgv.DataSource = dao.lerTabela("select * from ContasBancarias");
            }
        }

        private void Dgv_SelectionChanged(object sender, EventArgs e)
        {
            if (dgv.Rows.Count > 1 && dgv.SelectedCells.Count > 0)
            {
                int i = dgv.SelectedRows[0].Index;
                for (int j = 0; j < textBoxPs.Length; j++)
                {
                    textBoxPs[j].Text = dgv[j, i].Value.ToString();
                }
            }
        }

        private void Btn_add_Click(object sender, EventArgs e)
        {
            string sql = "insert into ContasBancarias (NomeBanco, NumeroAgencia, NumeroConta, TipoConta, NomeTitular, CNPJ, TelefoneBanco, EmailContato) values(";
            for(int i = 1;  i < textBoxPs.Length-1; i++)
            {
                sql = sql + $"'{textBoxPs[i].Text}',";
            }
            sql = sql + $"'{textBoxPs[8].Text}');";
            MessageBox.Show(sql);
            dao.updateInsertDelete(sql);
            dgv.DataSource = dao.lerTabela("select * from ContasBancarias");
        }

        private void BancoContasBancarias_TextChanged(object sender, EventArgs e)
        {
            int cont = 0;
            for (int i = 1; i < textBoxPs.Length; i++)
            {
                if (textBoxPs[i].Text == "") { cont++; }
            }
            if (cont == 0) { btnAdd.Enabled = true; }
            else { btnAdd.Enabled = false; }
        }

        public override void fechar(TelaPadrao tela)
        {
            foreach (TextBoxP tbp in textBoxPs)
            {
                tela.Controls.Remove(tbp);
            }
            foreach (LabelP labelP in labelPs)
            {
                tela.Controls.Remove(labelP);
            }
            tela.Controls.Remove(dgv);
            tela.Controls.Remove(btnAdd);
            tela.Controls.Remove(container);
            tela.Controls.Remove(btnRemove);
        }
    }
}