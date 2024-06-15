using CaixaDeFerramentasPerso;
using Logica;
using System;
using System.Data;
using System.Windows.Forms;

namespace Telas
{
    public class BancoCatalogoProdutos : InterfacesBanco
    {
        LabelP[] labelPs = new LabelP[6];
        TextBoxP[] textBoxPs = new TextBoxP[5];
        DataTable dt;
        DAO dao = new DAO();
        DataGridViewP dgv;
        ComboBoxP cbDisponibilidade;
        string[] disponibilidade = new string[2] {"s", "n"};
        ButtonP btnAdd;
        ButtonP btnUpdate;
        private ButtonP btnRemove;

        public override void exibir(TelaPadrao tela)
        {
            labelPs[0] = new LabelP(30, 20, 125, 25, "ID:", tela);
            labelPs[1] = new LabelP(100, 20, 125, 90, "Nome:", tela);
            labelPs[2] = new LabelP(100, 20, 180, 25, "Valor:", tela);
            labelPs[3] = new LabelP(100, 20, 235, 25, "Estoque:", tela);
            labelPs[4] = new LabelP(100, 20, 290, 25, "Descrição:", tela);
            labelPs[5] = new LabelP(100, 20, 370, 25, "Disponivel:", tela);

            textBoxPs[0] = new TextBoxP(30, 25, 145, 25, "", 9, tela);
            textBoxPs[0].Enabled = false;
            textBoxPs[1] = new TextBoxP(50, 25, 145, 90, "", 9, tela);
            textBoxPs[2] = new TextBoxP(150, 25, 200, 25, "", 9, tela);
            textBoxPs[3] = new TextBoxP(150, 25, 255, 25, "", 9, tela);
            textBoxPs[4] = new TextBoxP(150, 50, 310, 25, "", 100, tela);
            textBoxPs[4].Multiline = true;
            cbDisponibilidade = new ComboBoxP(100, 25, 390, 25, disponibilidade, tela);
            foreach (TextBoxP t in textBoxPs)
            {
                t.TextChanged += new EventHandler(BancoUsuarios_TextChanged);
            }

            btnAdd = new ButtonP(true, 100, 50, 450, 25, "Cadastrar", tela);
            btnAdd.Enabled = false;
            btnAdd.Click += new EventHandler(Btn_add_Click);

            btnRemove = new ButtonP(true, 120, 50, 450, 150, "Remover", tela);
            btnRemove.Click += new EventHandler(BtnRemove_Click);


            dgv = new DataGridViewP(680, 500, 125, 285, dao.lerTabela("select"+" nome as 'Produto', id as 'ID', valor as 'Valor unitário (R$)', estoque as 'Quantidade em estoque',"
                +" descricao as 'Descrição',"
                +" disponivel as 'A venda'"
                +" from produtos"), tela);
            dgv.SelectionChanged += Dgv_SelectionChanged;


        }

        private void BtnRemove_Click(object sender, EventArgs e)
        {
            if (dgv.Rows.Count > 1 && dgv.SelectedCells.Count > 0 && dgv.SelectedRows[0].Index < dgv.Rows.Count - 1)
            {
                int i = int.Parse(dgv.SelectedCells[0].Value.ToString());
                dao.updateInsertDelete($"DELETE from produtos where id={i}");
                dgv.DataSource = "select" + " nome as 'Produto', id as 'ID', valor as 'Valor unitário (R$)', estoque as 'Quantidade em estoque'," + " descricao as 'Descrição'," + " disponivel as 'A venda' from produtos";
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
            string sql = $"insert into produtos (nome, valor, estoque, descricao, disponivel) values ('{textBoxPs[1].Text}', '{textBoxPs[2].Text}', '{textBoxPs[3].Text}', '{textBoxPs[4].Text}', '{cbDisponibilidade.Text}');";
            MessageBox.Show(sql);
            dao.updateInsertDelete(sql);
            dgv.DataSource = dao.lerTabela("select" + " nome as 'Produto', id as 'ID', valor as 'Valor unitário (R$)', estoque as 'Quantidade em estoque',"
                + " descricao as 'Descrição',"
                + " disponivel as 'A venda'"
                + " from produtos");
        }

        private void BancoUsuarios_TextChanged(object sender, EventArgs e)
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
            foreach (LabelP labelP in labelPs)
            {
                tela.Controls.Remove(labelP);
            }
            foreach (TextBoxP textBoxP in textBoxPs)
            {
                tela.Controls.Remove(textBoxP);
            }
            tela.Controls.Remove(dgv);
            tela.Controls.Remove(btnAdd);
            tela.Controls.Remove(btnRemove);
            tela.Controls.Remove(cbDisponibilidade);
        }
    }
}