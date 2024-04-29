using CaixaFerramentas;
using Funcionarios;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TL_Principal;

namespace TL_Caixa
{
    public class TelaPrincipalCaixa : TelaPrincipal
    {
        Caixa caixa;
        LabelPerso lb_Cod_prod;
        LabelPerso lb_Nome_prod;
        LabelPerso lb_Quantidade;
        LabelPerso lb_Total;
        TextBoxPerso tb_cod_prod;
        TextBoxPerso tb_nome_prod;
        TextBoxPerso tb_quantidade;
        TextBoxPerso tb_total;
        DataGridView dtv_prod;

        LabelPerso[] labelPersos;
        TextBoxPerso[] textBoxPersos;

        BtnImage adicionarProd;
        BtnImage deletarProd;
        BtnImage finalizarCompra;
        List<int> lista = new List<int>();
        double total;
        public TelaPrincipalCaixa(Caixa caixa) 
        {
            this.caixa = caixa;
            lb_Cod_prod = new LabelPerso(100, 25, 135, 20, "Código do produto", this);
            lb_Nome_prod = new LabelPerso(100, 25, 170, 20, "Nome do Produto", this);
            lb_Quantidade = new LabelPerso(100, 25, 205, 20, "Quantidade", this);
            lb_Total = new LabelPerso(100, 25, 240, 20, "Total a pagar", this);
            labelPersos = new LabelPerso[] {lb_Cod_prod, lb_Cod_prod, lb_Quantidade, lb_Total}; 

            tb_cod_prod = new TextBoxPerso(150, 25, 135, 150, "", 100, this);
            tb_nome_prod = new TextBoxPerso(150, 25, 170, 150, "", 100, this);
            tb_quantidade = new TextBoxPerso(150, 25, 205, 150, "1", 100, this);
            tb_total =  new TextBoxPerso(150, 25, 240, 150, "", 100, this);
            textBoxPersos = new TextBoxPerso[] {tb_cod_prod, tb_nome_prod, tb_quantidade, tb_total};
            tb_nome_prod.tb.ReadOnly = true;
            tb_total.tb.ReadOnly = true;
            tb_quantidade.tb.KeyPress += quantidade_IsNumero;

            adicionarProd = new BtnImage(true, 150, 50, 405, 105, null, null, "Adicionar Produto", this);
            adicionarProd.btn.Click += new EventHandler(adicionarProd_Click);
            deletarProd = new BtnImage(true, 150, 50, 460, 105, null, null, "Deletar Produto", this);
            deletarProd.btn.Click += new EventHandler(deletarProd_Click);
            finalizarCompra = new BtnImage(true, 150, 50, 515, 105, null, null, "Finalizar Compra", this);
            finalizarCompra.btn.Click += new EventHandler(finalizarCompra_Click);


            dtv_prod = new DataGridView();
            dtv_prod.BackColor = Color.DimGray;
            dtv_prod.DataSource = caixa.exibirCaixa(lista);
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
            if (dtv_prod.SelectedRows.Count > 0 && dtv_prod.SelectedCells[0].Value != null && dtv_prod.SelectedRows[0].Index < dtv_prod.Rows.Count-1)
            {
                int linha = dtv_prod.SelectedRows[0].Index;
                textBoxPersos[0].tb.Text = lista[linha].ToString();
                textBoxPersos[1].tb.Text = dtv_prod.SelectedCells[0].Value.ToString();
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
                int.Parse(textBoxPersos[0].tb.Text);
                for (int i = 0; i < int.Parse(textBoxPersos[2].tb.Text); i++)
                {
                    lista.Add(int.Parse(textBoxPersos[0].tb.Text));
                }
                dtv_prod.DataSource = caixa.exibirCaixa(lista);
                atualizarTotal();
            }
            catch
            {
            }           
        }
        private void deletarProd_Click(object sender, EventArgs args)
        {
            if (dtv_prod.Rows.Count > 1 && dtv_prod.SelectedCells[0].Value != null) { 
                int linha = dtv_prod.SelectedRows[0].Index;
                lista.RemoveAt(linha);
                dtv_prod.DataSource = caixa.exibirCaixa(lista);
                atualizarTotal();
            }
        }

        private void finalizarCompra_Click(object sender, EventArgs args)
        {
            if (dtv_prod.Rows.Count > 1)
            {
                
            }
        }
        private void atualizarTotal()
        {
            total = 0;
            for (int i = 0; i < dtv_prod.Rows.Count - 1; i++)
            {
                total += double.Parse(dtv_prod.Rows[i].Cells[1].Value.ToString());
            }
            textBoxPersos[3].tb.Text = total.ToString();
        }
    }
}
