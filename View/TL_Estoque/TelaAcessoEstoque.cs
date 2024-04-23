using CaixaFerramentas;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TL_Estoque
{
    public class TelaAcessoEstoque : Form
    {
        LabelPerso Lote;
        BtnImage adicionarProduto;
        BtnImage excluirProduto;
        BtnImage atualizarProduto;
        BtnImage ListaFornecedores;
        LabelPerso lb_nome_produto;
        LabelPerso lb_quantidade;
        LabelPerso lb_fornecedor;
        LabelPerso lb_preco;
        TextBoxPerso tb_nome_produto;
        TextBoxPerso tb_quantidade;
        TextBoxPerso tb_fornecedor;
        TextBoxPerso tb_preco;
        DataGridView dtw_produtos;
        public TelaAcessoEstoque(TelaPrincipalEstoque tela) 
        {
            Lote = new LabelPerso(300, 35, 100, 20, "Lote do produto", tela);
            Lote.txt.Font = new Font("Arial", 16);
            lb_nome_produto = new LabelPerso(100, 25, 135, 20, "Nome do Produto do Lote", tela);
            tb_nome_produto = new TextBoxPerso(150, 25, 135, 150, "", 100, tela);
            lb_quantidade = new LabelPerso(100, 25, 170, 20, "Quantidade do Produto", tela);
            tb_quantidade = new TextBoxPerso(150, 25, 170, 150, "", 100, tela);

            lb_fornecedor = new LabelPerso(100, 25, 205, 20, "Fornecedor", tela);
            tb_fornecedor = new TextBoxPerso(150, 25, 205, 150, "", 100, tela);

            lb_preco = new LabelPerso(100, 25, 240, 20, "Preço", tela);
            tb_preco = new TextBoxPerso(150, 25, 240, 150, "", 100, tela);

            ListaFornecedores = new BtnImage(true, 10, 10, 170, 125, null, null, "Lista", tela);
            adicionarProduto = new BtnImage(true, 150, 50, 315, 20, null, null, "Adicionar lote", tela);
            excluirProduto = new BtnImage(true, 150, 50, 315, 190, null, null, "Excluir lote", tela);
            atualizarProduto = new BtnImage(true, 150, 50, 405, 105, null, null, "Atualizar lote", tela);

            dtw_produtos = new DataGridView();
            dtw_produtos.DataSource = tela.gerente.exibirProdutos();
            dtw_produtos.BackColor = Color.DimGray;
            dtw_produtos.Width = 500;
            dtw_produtos.Height = 400;
            dtw_produtos.Top = 135;
            dtw_produtos.Left = 350;
            tela.Controls.Add(dtw_produtos);
        }
    }
}
