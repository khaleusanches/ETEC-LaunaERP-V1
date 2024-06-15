using CaixaDeFerramentasPerso;
using Logica;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.LinkLabel;

namespace Telas
{
    public class TelaPrincipalCaixa : TelaPadrao
    {
        LabelP lb_Cod_prod;
        LabelP lb_Nome_prod;
        LabelP lb_Quantidade;
        LabelP lb_Total;
        TextBoxP tb_cod_prod;
        TextBoxP tb_nome_prod;
        TextBoxP tb_quantidade;
        TextBoxP tb_total;
        DataGridView dtv_prod;
        DataTable dt;
        DAO dao = new DAO();
        string sql;

        LabelP[] labelPersos;
        TextBoxP[] textBoxPersos;

        ButtonP adicionarProd;
        ButtonP deletarProd;
        ButtonP finalizarCompra;
        List<int> lista = new List<int>();
        double total;
        public TelaPrincipalCaixa(Funcionario funcionario) : base(funcionario)
        {
            lb_Cod_prod = new LabelP(150, 25, 135, 20, "Código do produto", this);
            lb_Nome_prod = new LabelP(120, 25, 170, 20, "Nome do Produto", this);
            lb_Quantidade = new LabelP(120, 25, 205, 20, "Quantidade", this);
            lb_Total = new LabelP(120, 25, 240, 20, "Total a pagar", this);
            labelPersos = new LabelP[] { lb_Cod_prod, lb_Cod_prod, lb_Quantidade, lb_Total };

            tb_cod_prod = new TextBoxP(150, 25, 135, 190, "", 100, this);
            tb_nome_prod = new TextBoxP(150, 25, 170, 190, "", 100, this);
            tb_quantidade = new TextBoxP(150, 25, 205, 190, "1", 100, this);
            tb_total = new TextBoxP(150, 25, 240, 190, "", 100, this);
            textBoxPersos = new TextBoxP[] { tb_cod_prod, tb_nome_prod, tb_quantidade, tb_total };
            tb_nome_prod.ReadOnly = true;
            tb_total.ReadOnly = true;
            tb_quantidade.KeyPress += quantidade_IsNumero;

            adicionarProd = new ButtonP(true, 150, 50, 405, 105, "Adicionar Produto", this);
            adicionarProd.Click += new EventHandler(adicionarProd_Click);
            deletarProd = new ButtonP(true, 150, 50, 460, 105, "Deletar Produto", this);
            deletarProd.Click += new EventHandler(deletarProd_Click);
            finalizarCompra = new ButtonP(true, 150, 50, 515, 105, "Finalizar Compra", this);
            finalizarCompra.Click += new EventHandler(finalizarCompra_Click);

            this.funcionario = funcionario;

            dtv_prod = new DataGridView();
            dtv_prod.BackColor = Color.DimGray;
            dtv_prod.Width = 500;
            dtv_prod.Height = 400;
            dtv_prod.Top = 135;
            dtv_prod.Left = 350;
            dtv_prod.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtv_prod.SelectionChanged += new EventHandler(Dtv_prod_SelectionChanged);
            dtv_prod.ReadOnly = true;
            Controls.Add(dtv_prod);
        }

        private void Dtv_prod_SelectionChanged(object sender, EventArgs e)
        {
            if (dtv_prod.SelectedRows.Count > 0 && dtv_prod.SelectedCells[0].Value != null && dtv_prod.SelectedRows[0].Index < dtv_prod.Rows.Count - 1)
            {
                int linha = dtv_prod.SelectedRows[0].Index;
                textBoxPersos[0].Text = lista[linha].ToString();
                textBoxPersos[1].Text = dtv_prod.SelectedCells[0].Value.ToString();
            }
        }

        private void quantidade_IsNumero(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void adicionarProd_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < int.Parse(textBoxPersos[2].Text); i++)
                {
                    lista.Add(int.Parse(textBoxPersos[0].Text));
                }
                dtv_prod.DataSource = exibirCaixa(lista);
                atualizarTotal();
            }
            catch
            {
            }
        }
        private DataTable exibirCaixa(List<int> id)
        {
            dt = new DataTable();
            dt.Clear();
            foreach (int idItem in id)
            {
                dt.Merge(dao.lerTabela("select nome, valor from produtos where id =" + idItem + ";"), false, MissingSchemaAction.Add);
            }
            return dt;
        }
        private void deletarProd_Click(object sender, EventArgs args)
        {
            if (dtv_prod.Rows.Count > 1 && dtv_prod.SelectedCells[0].Value != null)
            {
                int linha = dtv_prod.SelectedRows[0].Index;
                lista.RemoveAt(linha);
                dtv_prod.DataSource = exibirCaixa(lista);
                atualizarTotal();
            }
        }
        private void finalizar(List<int> id)
        {
            string dataehora = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            sql = $"insert into operacoes(idfuncionariofk, total, dataehora) values('{funcionario.id}', '{double.Parse(textBoxPersos[3].Text)}', '{dataehora}')";
            dao.updateInsertDelete(sql);
            dt = dao.lerTabela("select id from operacoes");
            int idoperacao = dt.Rows.Count;
            foreach (int idItem in id)
            {
                sql = $"UPDATE produtos set estoque = estoque -1 where id = '{idItem}'";
                dao.updateInsertDelete(sql);
                sql = $"insert into vendas(idoperacaofk, idprodutofk) values('{idoperacao}', '{idItem}')";
                dao.updateInsertDelete(sql);
            }
            lista.Clear();
            dtv_prod.DataSource = exibirCaixa(lista);
            atualizarTotal();
            textBoxPersos[0].Text = "";
            textBoxPersos[1].Text = "";
        }

        private void finalizarCompra_Click(object sender, EventArgs args)
        {
            if (dtv_prod.Rows.Count > 1)
            {
                finalizar(lista);
            }
        }
        private void atualizarTotal()
        {
            total = 0;
            for (int i = 0; i < dtv_prod.Rows.Count - 1; i++)
            {
                total += double.Parse(dtv_prod.Rows[i].Cells[1].Value.ToString());
            }
            textBoxPersos[3].Text = total.ToString();
        }
    }
}
