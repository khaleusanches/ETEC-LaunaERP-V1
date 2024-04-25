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
        int[] lista;
        public TelaPrincipalCaixa(Caixa caixa) 
        {
            lb_Cod_prod = new LabelPerso(100, 25, 135, 20, "Código do produto", this);
            lb_Nome_prod = new LabelPerso(100, 25, 170, 20, "Nome do Produto", this);
            lb_Quantidade = new LabelPerso(100, 25, 205, 20, "Quantidade", this);
            lb_Total = new LabelPerso(100, 25, 240, 20, "Total a pagar", this);
            labelPersos = new LabelPerso[] {lb_Cod_prod, lb_Cod_prod, lb_Quantidade, lb_Total}; 

            tb_cod_prod = new TextBoxPerso(150, 25, 135, 150, "", 100, this);
            tb_nome_prod = new TextBoxPerso(150, 25, 170, 150, "", 100, this);
            tb_quantidade = new TextBoxPerso(150, 25, 205, 150, "", 100, this);
            tb_total =  new TextBoxPerso(150, 25, 240, 150, "", 100, this);
            textBoxPersos = new TextBoxPerso[] {tb_cod_prod, tb_nome_prod, tb_quantidade, tb_total};

            adicionarProd = new BtnImage(true, 150, 50, 405, 105, null, null, "Adicionar Produto", this);
            adicionarProd.btn.Click += new EventHandler(adicionarProd_Click);
            lista = new int[] { 11,13,5,14 };
            dtv_prod = new DataGridView();
            dtv_prod.BackColor = Color.DimGray;
            dtv_prod.DataSource = caixa.exibirCaixa(lista);
            dtv_prod.Width = 500;
            dtv_prod.Height = 400;
            dtv_prod.Top = 135;
            dtv_prod.Left = 350;
            Controls.Add(dtv_prod);
        }

        private void adicionarProd_Click(object sender, EventArgs e)
        {
            
        }
    }
}
