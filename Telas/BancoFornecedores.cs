using CaixaDeFerramentasPerso;
using Logica;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace Telas
{
    internal class BancoFornecedores : InterfacesBanco
    {
        LabelP[] labelPs = new LabelP[7];
        TextBoxP[] textBoxP = new TextBoxP[6];
        DataTable dt;
        DAO dao = new DAO();
        DataGridViewP dgv;
        ButtonP btnAdd;
        ButtonP btnUpdate;
        Funcionario funcionario;
        PanelP container;
        PanelP container2;
        ButtonP btnRemove;

        public override void exibir(TelaPadrao tela)
        {
            container = new PanelP(300, 325, 85, 20, Color.White, tela);
            labelPs[0] = new LabelP(150, 20, 100, 35, "FORNECEDORES", tela);
            labelPs[0].Font = new Font("Arial", 12, FontStyle.Bold);
            labelPs[1] = new LabelP(30, 20, 135, 35, "ID:", tela);
            labelPs[2] = new LabelP(100, 20, 135, 100, "Nome:", tela);
            labelPs[3] = new LabelP(100, 20, 190, 35, "Razão Social:", tela);
            labelPs[4] = new LabelP(100, 20, 245, 35, "CNPJ:", tela);
            labelPs[5] = new LabelP(100, 20, 300, 35, "Endereco:", tela);
            labelPs[6] = new LabelP(100, 20, 355, 35, "Email:", tela);

            textBoxP[0] = new TextBoxP(30, 25, 155, 35, "", 9, tela, true);
            textBoxP[0].Enabled = false;
            textBoxP[1] = new TextBoxP(150, 25, 155, 100, "", 90, tela);
            textBoxP[2] = new TextBoxP(150, 25, 210, 35, "", 255, tela);
            textBoxP[3] = new TextBoxP(150, 25, 265, 35, "", 14, tela, true);
            textBoxP[4] = new TextBoxP(150, 25, 320, 35, "", 255, tela);
            textBoxP[5] = new TextBoxP(150, 25, 375, 35, "", 80, tela);

            
            btnAdd = new ButtonP(true, 100, 50, 420, 45, "Cadastrar Fornecedor", tela);
            btnAdd.Enabled = false;
            btnAdd.Click += new EventHandler(Btn_add_Click);
            btnRemove = new ButtonP(true, 120, 50, 420, 170, "Remover Fornecedor", tela);
            btnRemove.Enabled = false;
            btnRemove.Click += new EventHandler(Btn_Remove_Click);
            btnUpdate = new ButtonP(true, 100, 25, 495, 107, "Atualizar Fornecedor", tela);
            btnUpdate.Click += new EventHandler(Btn_Update_Click);
            btnUpdate.Enabled = false;

            foreach (TextBoxP t in textBoxP)
            {
                t.TextChanged += new EventHandler(BancoFornecedores_TextChanged);
            }


            dgv = new DataGridViewP(590, 500, 85, 400, dao.lerTabela("select * from Fornecedores"), tela);
            dgv.SelectionChanged += Dgv_SelectionChanged;
            container2 = new PanelP(610, 520, 85, 390, Color.FromArgb(99, 133, 199), tela);
        }

        private void Btn_Update_Click(object sender, EventArgs e)
        {
            string sql = $"UPDATE fornecedores set nome = '{textBoxP[1].Text}', razaosocial = '{textBoxP[2].Text}', cnpj = '{textBoxP[3].Text}', endereco = '{textBoxP[4].Text}', email = '{textBoxP[5].Text}' where id = '{textBoxP[0].Text}';";
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
            string sql = $"insert into fornecedores (nome, razaosocial, cnpj, endereco, email) values ('{textBoxP[1].Text}', '{textBoxP[2].Text}', '{textBoxP[3].Text}', '{textBoxP[4].Text}', '{textBoxP[5].Text}')";
            dao.updateInsertDelete(sql);
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
            if (dgv.Rows.Count > 1 && dgv.SelectedCells.Count > 0 && dgv.SelectedRows[0].Index < dgv.Rows.Count-1)
            {
                int i = dgv.SelectedRows[0].Index;
                for (int j = 0; j < textBoxP.Length; j++)
                {
                    textBoxP[j].Text = dgv[j, i].Value.ToString();
                }
                btnRemove.Enabled = true;
                btnUpdate.Enabled = true;
            }
            else
            {
                btnRemove.Enabled = false;
                btnUpdate.Enabled = false;
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
            tela.Controls.Remove(container);
            tela.Controls.Remove(container2);
        }
    }
}