using CaixaDeFerramentasPerso;
using Logica;
using System;
using System.Data;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace Telas
{
    internal class BancoFornecedores : InterfacesBanco
    {
        LabelP[] labelPs = new LabelP[5];
        TextBoxP[] textBoxP = new TextBoxP[5];
        DataTable dt;
        DAO dao = new DAO();
        DataGridViewP dgv;
        ButtonP btnAdd;
        ButtonP btnUpdate;
        Funcionario funcionario;

        ButtonP btnRemove;

        public override void exibir(TelaPadrao tela)
        {
            labelPs[0] = new LabelP(30, 20, 125, 25, "ID:", tela);
            labelPs[1] = new LabelP(100, 20, 125, 90, "Nome:", tela);
            labelPs[2] = new LabelP(100, 20, 180, 25, "CNPJ:", tela);
            labelPs[3] = new LabelP(100, 20, 235, 25, "Endereco:", tela);
            labelPs[4] = new LabelP(100, 20, 290, 25, "Email:", tela);

            textBoxP[0] = new TextBoxP(30, 25, 145, 25, "", 9, tela);
            textBoxP[0].Enabled = false;
            textBoxP[1] = new TextBoxP(50, 25, 145, 90, "", 64, tela);
            textBoxP[2] = new TextBoxP(150, 25, 200, 25, "", 18, tela);
            textBoxP[3] = new TextBoxP(150, 25, 255, 25, "", 200, tela);
            textBoxP[4] = new TextBoxP(150, 25, 310, 25, "", 80, tela);

            
            btnAdd = new ButtonP(true, 100, 50, 360, 25, "Cadastrar Fornecedor", tela);
            btnAdd.Enabled = false;
            btnAdd.Click += new EventHandler(Btn_add_Click);
            btnRemove = new ButtonP(true, 120, 50, 360, 150, "Remover Fornecedor", tela);
            btnRemove.Enabled = false;
            btnRemove.Click += new EventHandler(Btn_Remove_Click);
            btnUpdate = new ButtonP(true, 100, 25, 435, 87, "Atualizar Fornecedor", tela);
            btnUpdate.Click += new EventHandler(Btn_Update_Click);
            btnUpdate.Enabled = false;

            foreach (TextBoxP t in textBoxP)
            {
                t.TextChanged += new EventHandler(BancoFornecedores_TextChanged);
            }


            dgv = new DataGridViewP(680, 500, 125, 285, dao.lerTabela("select * from Fornecedores"), tela);
            dgv.SelectionChanged += Dgv_SelectionChanged;
        }

        private void Btn_Update_Click(object sender, EventArgs e)
        {
            string sql = $"UPDATE fornecedores set nome = '{textBoxP[1].Text}', cnpj = '{textBoxP[2].Text}', endereco = '{textBoxP[3].Text}', email = '{textBoxP[4].Text}' where id = '{textBoxP[0].Text}';";
            dao.updateInsertDelete(sql);
            dgv.DataSource = dao.lerTabela("select * from fornecedores");
        }

        private void BancoFornecedores_TextChanged(object sender, EventArgs e)
        {
            int cont = 0;
            for (int i = 1; i < textBoxP.Length; i++)
            {
                if (textBoxP[i].Text == "") { cont++; }
            }
            if (cont == 0) { btnAdd.Enabled = true; }
            else { btnAdd.Enabled = false; }
        }

        private void Btn_add_Click(object sender, EventArgs e)
        {
            int i = dgv.SelectedRows[0].Index;
            string sql = $"insert into fornecedores (nome, cnpj, endereco, email) values ('{textBoxP[1].Text}', '{textBoxP[2].Text}', '{textBoxP[3].Text}', '{textBoxP[4].Text}')";
            if (textBoxP[1].Text != dgv[0, i].Value.ToString() && textBoxP[2].Text != dgv[2, i].Value.ToString() && textBoxP[4].Text != dgv[4, i].Value.ToString())
            {
                dao.updateInsertDelete(sql);
            }
            else
            {
                MessageBox.Show("ja esta inserido na tabela");
            }
            dgv.DataSource = dao.lerTabela("select * from fornecedores");
        }

        private void Btn_Remove_Click(object sender, EventArgs e)
        {
            if (dgv.Rows.Count > 1 && dgv.SelectedCells.Count > 0 && dgv.SelectedRows[0].Index < dgv.Rows.Count - 1)
            {
                int i = int.Parse(dgv.SelectedCells[0].Value.ToString());
                dao.updateInsertDelete($"DELETE from fornecedores where id={i}");
                dgv.DataSource = dao.lerTabela("select * from fornecedores");
            }
        }
        private void Dgv_SelectionChanged(object sender, EventArgs e)
        {
            if (dgv.Rows.Count > 1 && dgv.SelectedCells.Count > 0)
            {
                int i = dgv.SelectedRows[0].Index;
                for (int j = 0; j < textBoxP.Length; j++)
                {
                    textBoxP[j].Text = dgv[j, i].Value.ToString();
                }
                btnRemove.Enabled = true;
                btnUpdate.Enabled = true;
            }
        }



        public override void fechar(TelaPadrao tela)
        {
            foreach (TextBoxP tbp in textBoxP)
            {
                tela.Controls.Remove(tbp);
            }
            foreach (LabelP labelP in labelPs)
            {
                tela.Controls.Remove(labelP);
            }
            tela.Controls.Remove(dgv);
            tela.Controls.Remove(btnAdd);
            tela.Controls.Remove(btnUpdate);
            tela.Controls.Remove(btnRemove);
        }
    }
}