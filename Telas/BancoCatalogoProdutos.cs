using CaixaDeFerramentasPerso;
using Logica;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Telas
{
    public class BancoCatalogoProdutos : InterfacesBanco
    {
        LabelP[] labelPs = new LabelP[7];
        TextBoxP[] textBoxPs = new TextBoxP[5];
        DataTable dt;
        DAO dao = new DAO();
        DataGridViewP dgv;
        ComboBoxP cbDisponibilidade;
        string[] disponibilidade = new string[2] {"sim", "nao"};
        ButtonP btnAdd;
        ButtonP btnUpdate;
        private ButtonP btnRemove;
        private PanelP container, container2;

        public override void exibir(TelaPadrao tela)
        {
            container = new PanelP(275, 350, 85, 20, Color.White, tela);
            labelPs[0] = new LabelP(150, 20, 100, 35, "Catalogo Produtos:", tela);
            labelPs[0].Font = new Font("Arial", 12, FontStyle.Bold);
            labelPs[1] = new LabelP(30, 20, 125, 35, "ID:", tela);
            labelPs[2] = new LabelP(100, 20, 125, 100, "Nome:", tela);
            labelPs[3] = new LabelP(100, 20, 180, 35, "Valor:", tela);
            labelPs[4] = new LabelP(100, 20, 235, 35, "Estoque:", tela);
            labelPs[5] = new LabelP(100, 20, 290, 35, "Descrição:", tela);
            labelPs[6] = new LabelP(100, 20, 370, 35, "Disponivel:", tela);

            textBoxPs[0] = new TextBoxP(30, 25, 145, 35, "", 9, tela);
            textBoxPs[0].Enabled = false;
            textBoxPs[1] = new TextBoxP(50, 25, 145, 100, "", 9, tela);
            textBoxPs[2] = new TextBoxP(150, 25, 200, 35, "", 9, tela, true);
            textBoxPs[3] = new TextBoxP(150, 25, 255, 35, "", 9, tela, true);
            textBoxPs[4] = new TextBoxP(150, 50, 310, 35, "", 100, tela);
            textBoxPs[4].Multiline = true;
            cbDisponibilidade = new ComboBoxP(100, 25, 390, 35, disponibilidade, tela);
            foreach (TextBoxP t in textBoxPs)
            {
                t.TextChanged += new EventHandler(BancoUsuarios_TextChanged);
            }

            btnAdd = new ButtonP(true, 100, 50, 450, 25, "Cadastrar", tela);
            btnAdd.Enabled = false;
            btnAdd.Click += new EventHandler(Btn_add_Click);

            btnRemove = new ButtonP(true, 120, 50, 450, 150, "Remover", tela);
            btnRemove.Click += new EventHandler(BtnAtualizar_Click);


            dgv = new DataGridViewP(600, 500, 85, 350, dao.lerTabela("select"+" nome as 'Produto', id as 'ID', valor as 'Valor unitário (R$)', estoque as 'Quantidade em estoque',"
                +" descricao as 'Descrição',"
                +" disponivel as 'A venda'"
                +" from produtos"), tela);
            dgv.SelectionChanged += Dgv_SelectionChanged;
            container2 = new PanelP(620, 520, 85, 340, Color.FromArgb(99, 133, 199), tela);

            dgv.ClearSelection();
        }

        private void BtnAtualizar_Click(object sender, EventArgs e)
        {
            if (dgv.Rows.Count > 1 && dgv.SelectedCells.Count > 0 && dgv.SelectedRows[0].Index < dgv.Rows.Count - 1)
            {
                int i = int.Parse(dgv.SelectedCells[1].Value.ToString());
                dao.updateInsertDelete($"UPDATE produtos set valor = {textBoxPs[2].Text}, estoque = {textBoxPs[3].Text}, descricao = '{textBoxPs[4].Text}', disponivel = '{cbDisponibilidade.Text}' where id={i}");
                dgv.DataSource = dao.lerTabela("select" + " nome as 'Produto', id as 'ID', valor as 'Valor unitário (R$)', estoque as 'Quantidade em estoque'," + " descricao as 'Descrição'," + " disponivel as 'A venda' from produtos");
            }
            dgv.ClearSelection();
        }

        private void Dgv_SelectionChanged(object sender, EventArgs e)
        {
            if (dgv.Rows.Count > 1 && dgv.SelectedCells.Count > 0 && dgv.SelectedRows[0].Index < dgv.Rows.Count - 1)
            {
                int i = dgv.SelectedRows[0].Index;
                for (int j = 0; j < textBoxPs.Length; j++)
                {
                    textBoxPs[j].Text = dgv[j, i].Value.ToString();
                }
                textBoxPs[0].Text = dgv.SelectedCells[1].Value.ToString();
                textBoxPs[1].Text = dgv.SelectedCells[0].Value.ToString();
                textBoxPs[2].Text = dgv.SelectedCells[2].Value.ToString().Replace(",", ".");
                textBoxPs[3].Text = dgv.SelectedCells[3].Value.ToString();
                textBoxPs[4].Text = dgv.SelectedCells[4].Value.ToString();
            }
        }
        private void Btn_add_Click(object sender, EventArgs e)
        {
            string sql = $"insert into produtos (nome, valor, estoque, descricao, disponivel) values ('{textBoxPs[1].Text}', '{textBoxPs[2].Text}', '{textBoxPs[3].Text}', '{textBoxPs[4].Text}', '{cbDisponibilidade.Text}');";
            dao.updateInsertDelete(sql);
            dgv.DataSource = dao.lerTabela("select" + " nome as 'Produto', id as 'ID', valor as 'Valor unitário (R$)', estoque as 'Quantidade em estoque',"
                + " descricao as 'Descrição',"
                + " disponivel as 'A venda'"
                + " from produtos");
            dgv.ClearSelection();
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
            tela.Controls.Remove(container);
            tela.Controls.Remove(container2);
            tela.Controls.Remove(cbDisponibilidade);
        }
    }
}