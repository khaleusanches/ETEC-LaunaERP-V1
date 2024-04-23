﻿using CaixaFerramentas;
using Funcionarios;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TL_Gerente;
using TL_RecursosHumanos;

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
        List<LabelPerso> labelPersos = new List<LabelPerso>();
        List<TextBoxPerso> textBoxPersos = new List<TextBoxPerso>();

        TelaPrincipalEstoque tela;
        public Gerente gerente = new Gerente();
        public TelaAcessoEstoque(TelaPrincipalEstoque tela) 
        {
            this.tela = tela;
            this.gerente = tela.gerente;
            Lote = new LabelPerso(300, 35, 100, 20, "Lote do produto", tela);
            Lote.txt.Font = new Font("Arial", 16);
            labelPersos.Add(Lote);

            lb_nome_produto = new LabelPerso(100, 25, 135, 20, "Nome do Produto do Lote", tela);
            tb_nome_produto = new TextBoxPerso(150, 25, 135, 150, "", 100, tela);
            labelPersos.Add(lb_nome_produto);
            textBoxPersos.Add(tb_nome_produto);

            lb_quantidade = new LabelPerso(100, 25, 170, 20, "Quantidade do Produto", tela);
            tb_quantidade = new TextBoxPerso(150, 25, 170, 150, "", 100, tela);
            labelPersos.Add(lb_quantidade);
            textBoxPersos.Add(tb_quantidade);

            lb_fornecedor = new LabelPerso(100, 25, 205, 20, "Fornecedor", tela);
            tb_fornecedor = new TextBoxPerso(150, 25, 205, 150, "", 100, tela);
            labelPersos.Add(lb_fornecedor);
            textBoxPersos.Add(tb_fornecedor);

            lb_preco = new LabelPerso(100, 25, 240, 20, "Preço", tela);
            tb_preco = new TextBoxPerso(150, 25, 240, 150, "", 100, tela);
            labelPersos.Add(lb_preco);
            textBoxPersos.Add(tb_preco);


            ListaFornecedores = new BtnImage(true, 10, 10, 170, 125, null, null, "Lista", tela);
            ListaFornecedores.btn.Click += new EventHandler(listaFornecedores_Click);
            adicionarProduto = new BtnImage(true, 150, 50, 315, 20, null, null, "Adicionar lote", tela);
            adicionarProduto.btn.Click += new EventHandler(adicionarProduto_Click);
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

        private void adicionarProduto_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void listaFornecedores_Click(object sender, EventArgs e)
        {
            TelaPrincipalRH testeRH = new TelaPrincipalRH();
            testeRH.Show();
            testeRH.Width = 510;
            testeRH.Height = 300;
            teste tl1 = new teste(testeRH);
            tl1.fechar();
            tl1.dtw_fornecedores.Width = 500;
            tl1.dtw_fornecedores.Height = 250;
            tl1.Top = 0;
            tl1.Left = 0;
        }

        public void fechar()
        {
            foreach (LabelPerso i in labelPersos)
            {
                tela.Controls.Remove(i.txt);
            }
            foreach (TextBoxPerso i in textBoxPersos)
            {
                tela.Controls.Remove(i.tb);
            }
            tela.Controls.Remove(ListaFornecedores.btn);
            tela.Controls.Remove(adicionarProduto.btn);
            tela.Controls.Remove(excluirProduto.btn);
            tela.Controls.Remove(atualizarProduto.btn);
            tela.gerente.fechar();
            tela.Controls.Remove(dtw_produtos);
        }
    }
}