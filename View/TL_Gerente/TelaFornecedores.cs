using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Funcionarios;
using System.Windows.Forms;
using CaixaFerramentas;
using System.Data;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using TL_Estoque;

namespace TL_Gerente
{
    public class TelaFornecedores : Form
    {
        TelaAcessoEstoque tela;
        BtnImage cadastrar;
        BtnImage deletar;
        BtnImage atualizar;
        DataGridView panel;

        List<LabelPerso> labels = new List<LabelPerso>();
        List<TextBoxPerso> textsboxs = new List<TextBoxPerso>();
        public TelaFornecedores(TelaAcessoEstoque tela)
        {
            this.tela = tela;

            LabelPerso LB_nome_Fornecedor = new LabelPerso(100, 25, 135, 20, "Nome do Fornecedor:", tela);
            TextBoxPerso TB_nome_Fornecedor = new TextBoxPerso(150, 25, 135, 150, "", 100, tela);

            LabelPerso LB_categoria_Fornecedor = new LabelPerso(100, 25, 175, 20, "Categoria do Fornecedor", tela);
            TextBoxPerso TB_categoria_Fornecedor = new TextBoxPerso(150, 25, 175, 150, "", 100, tela);

            LabelPerso LB_telefone = new LabelPerso(100, 25, 210, 20, "Telefone:", tela);
            TextBoxPerso TB_telefone = new TextBoxPerso(150, 25, 210, 150, "", 100, tela);

            LabelPerso LB_descricao = new LabelPerso(100, 25, 245, 20, "Descrição", tela);
            TextBoxPerso TB_descricao = new TextBoxPerso(150, 25, 245, 150, "", 100, tela);

            labels.Add(LB_nome_Fornecedor);
            labels.Add(LB_categoria_Fornecedor);
            labels.Add(LB_telefone);
            labels.Add(LB_descricao);
            textsboxs.Add(TB_nome_Fornecedor);
            textsboxs.Add(TB_categoria_Fornecedor);
            textsboxs.Add(TB_telefone);
            textsboxs.Add(TB_descricao);

            this.cadastrar = new BtnImage(true, 150, 50, 315, 20, null, null, "Cadastrar", tela);
            this.deletar = new BtnImage(true, 150, 50, 315, 190, null, null, "Deletar", tela);
            this.atualizar = new BtnImage(true, 150, 50, 405, 105, null, null, "Atualizar", tela);
            cadastrar.btn.Click += new EventHandler(cadastrar_Click);
            deletar.btn.Click += new EventHandler(deletar_Click);
            atualizar.btn.Click += new EventHandler(atualizar_Click);

            this.panel = new DataGridView();
            panel.DataSource = tela.gerente.exibirFornecedores();
            panel.BackColor = Color.DimGray;
            panel.Width = 500;
            panel.Height = 400;
            panel.Top = 135;
            panel.Left = 350;
            panel.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            tela.Controls.Add(panel);
            panel.SelectionChanged += panel_SelectionChanged;
            panel.ReadOnly = true;
        }

        private void cadastrar_Click(object sender, EventArgs e)
        {
            tela.gerente.cadastrarFornecedores(textsboxs[0].tb.Text, textsboxs[1].tb.Text, textsboxs[2].tb.Text, textsboxs[3].tb.Text);
            panel.DataSource = tela.gerente.exibirFornecedores();
        }
        private void deletar_Click(object sender, EventArgs e)
        {
            if (panel.Rows.Count > 1 && panel.SelectedCells.Count > 0)
            {
                int i = int.Parse(panel.SelectedCells[0].Value.ToString());
                tela.gerente.deletarFornecedor(i);

                panel.DataSource = tela.gerente.exibirFornecedores();
                panel.Refresh();
            }
        }
        private void atualizar_Click(object sender, EventArgs e)
        {
            if (panel.Rows.Count > 1 && panel.SelectedCells.Count > 0 && panel.SelectedRows[0].Index < panel.Rows.Count - 1)
            {
                int i = int.Parse(panel.SelectedCells[0].Value.ToString());
                tela.gerente.atualizarFornecedor(i, textsboxs[0].tb.Text, textsboxs[1].tb.Text, textsboxs[2].tb.Text, textsboxs[3].tb.Text);

                panel.DataSource = tela.gerente.exibirFornecedores();
                panel.Refresh();
            }
        }
        private void panel_SelectionChanged(object sender, EventArgs e)
        {
            if (panel.Rows.Count > 1 && panel.SelectedCells.Count > 0)
            {
                int i = panel.SelectedRows[0].Index;
                textsboxs[0].tb.Text = panel[1, i].Value.ToString();
                textsboxs[1].tb.Text = panel[2, i].Value.ToString();
                textsboxs[2].tb.Text = panel[3, i].Value.ToString();
                textsboxs[3].tb.Text = panel[4, i].Value.ToString();
            }
        }
        public void fechar()
        {
            for (int i = 0; i < 4; i++)
            {
                tela.Controls.Remove(labels[i].txt);
                tela.Controls.Remove(textsboxs[i].tb);
            }
            tela.gerente.fechar();
            tela.Controls.Remove(cadastrar.btn);
            tela.Controls.Remove(deletar.btn);
            tela.Controls.Remove(panel);
            tela.Controls.Remove(atualizar.btn);
        }
    }
}
