using CaixaFerramentas;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TL_Estoque;

namespace TL_RecursosHumanos
{
        public class teste : TelaPrincipalRH
        {
            TelaPrincipalRH tela;
            BtnImage cadastrar;
            BtnImage deletar;
            BtnImage atualizar;
            public DataGridView dtw_fornecedores;

            List<LabelPerso> labels = new List<LabelPerso>();
            List<TextBoxPerso> textsboxs = new List<TextBoxPerso>();
            public teste(TelaPrincipalRH tela)
            {
                this.tela = tela;
                tela.panel.Visible = false;

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
                cadastrar.btn.Visible = false;
                atualizar.btn.Visible = false;
                deletar.btn.Visible = false;

                this.dtw_fornecedores = new DataGridView();
                dtw_fornecedores.DataSource = tela.gerente.exibirFornecedores();
                dtw_fornecedores.BackColor = Color.DimGray;
                dtw_fornecedores.Width = 500;
                dtw_fornecedores.Height = 400;
                dtw_fornecedores.Top = 0;
                dtw_fornecedores.Left = 0;
                dtw_fornecedores.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                tela.Controls.Add(dtw_fornecedores);
                dtw_fornecedores.SelectionChanged += panel_SelectionChanged;
                dtw_fornecedores.ReadOnly = true;
            }

            private void cadastrar_Click(object sender, EventArgs e)
            {
                tela.gerente.cadastrarFornecedores(textsboxs[0].tb.Text, textsboxs[1].tb.Text, textsboxs[2].tb.Text, textsboxs[3].tb.Text);
                dtw_fornecedores.DataSource = tela.gerente.exibirFornecedores();
            }
            private void deletar_Click(object sender, EventArgs e)
            {
                if (dtw_fornecedores.Rows.Count > 1 && dtw_fornecedores.SelectedCells.Count > 0)
                {
                    int i = int.Parse(dtw_fornecedores.SelectedCells[0].Value.ToString());
                    tela.gerente.deletarFornecedor(i);

                    dtw_fornecedores.DataSource = tela.gerente.exibirFornecedores();
                    dtw_fornecedores.Refresh();
                }
            }
            private void atualizar_Click(object sender, EventArgs e)
            {
                if (dtw_fornecedores.Rows.Count > 1 && dtw_fornecedores.SelectedCells.Count > 0 && dtw_fornecedores.SelectedRows[0].Index < dtw_fornecedores.Rows.Count - 1)
                {
                    int i = int.Parse(dtw_fornecedores.SelectedCells[0].Value.ToString());
                    tela.gerente.atualizarFornecedor(i, textsboxs[0].tb.Text, textsboxs[1].tb.Text, textsboxs[2].tb.Text, textsboxs[3].tb.Text);

                    dtw_fornecedores.DataSource = tela.gerente.exibirFornecedores();
                    dtw_fornecedores.Refresh();
                }
            }
            private void panel_SelectionChanged(object sender, EventArgs e)
            {
                if (dtw_fornecedores.Rows.Count > 1 && dtw_fornecedores.SelectedCells.Count > 0)
                {
                    int i = dtw_fornecedores.SelectedRows[0].Index;
                    textsboxs[0].tb.Text = dtw_fornecedores[1, i].Value.ToString();
                    textsboxs[1].tb.Text = dtw_fornecedores[2, i].Value.ToString();
                    textsboxs[2].tb.Text = dtw_fornecedores[3, i].Value.ToString();
                    textsboxs[3].tb.Text = dtw_fornecedores[4, i].Value.ToString();
                }
            }
            public void fechar()
            {
                for (int i = 0; i < 4; i++)
                {
                    tela.Controls.Remove(labels[i].txt);
                    tela.Controls.Remove(textsboxs[i].tb);
                }

                tela.Controls.Remove(cadastrar.btn);
                tela.Controls.Remove(deletar.btn);
                tela.Controls.Remove(atualizar.btn);
            }
        }
}
