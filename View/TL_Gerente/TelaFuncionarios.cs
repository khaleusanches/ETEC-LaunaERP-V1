using CaixaFerramentas;
using Funcionarios;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TL_Gerente
{
    public class TelaFuncionarios
    {
        LabelPerso titulo;
        BtnImage adicionarFuncionario;
        BtnImage demitirFuncionario;
        BtnImage atualizarDadosFuncionario;
        TextBoxPerso tb_nome_Funcionario;
        TextBoxPerso tb_senha_Funcionario;
        TextBoxPerso tb_setor;
        TextBoxPerso tb_cargo;
        Gerente gerente;
        TelaGerente tela;
        LabelPerso[] labelPersos;
        TextBoxPerso[] textBoxPersos;
        DataGridView dtw_Funcionarios;
        public TelaFuncionarios(TelaGerente tela, Gerente gerente)
        {
            this.tela = tela;
            this.gerente = gerente;
            titulo = new LabelPerso(140, 35, 100, 20, "Funcionarios", tela);
            titulo.txt.Font = new Font("Arial", 16);
            LabelPerso lb_nome_Funcionario = new LabelPerso(100, 25, 135, 20, "Nome do Funcionario:", tela);
            LabelPerso lb_senha_Funcionario = new LabelPerso(100, 25, 180, 20, "Senha do Funcionario:", tela);
            LabelPerso lb_setor = new LabelPerso(100, 25, 215, 20, "Setor:", tela);
            LabelPerso lb_cargo = new LabelPerso(100, 25, 250, 20, "Cargo:", tela);
            tb_nome_Funcionario = new TextBoxPerso(150, 25, 135, 150, "", 100, tela);
            tb_senha_Funcionario = new TextBoxPerso(150, 25, 180, 150, "", 100, tela);
            tb_setor = new TextBoxPerso(150, 25, 215, 150, "", 100, tela);
            tb_cargo = new TextBoxPerso(150, 25, 250, 150, "", 100, tela);
            labelPersos = new LabelPerso[] {lb_nome_Funcionario, lb_senha_Funcionario, lb_setor, lb_cargo};
            textBoxPersos = new TextBoxPerso[] {tb_nome_Funcionario, tb_senha_Funcionario, tb_setor, tb_cargo};

            adicionarFuncionario = new BtnImage(true, 150, 50, 315, 20, null, null, "Adicionar lote", tela);
            adicionarFuncionario.btn.Click += new EventHandler(adicionarFuncionario_Click);
            demitirFuncionario = new BtnImage(true, 150, 50, 315, 190, null, null, "Excluir lote", tela);
            demitirFuncionario.btn.Click += new EventHandler(demitirFuncionario_Click);
            atualizarDadosFuncionario = new BtnImage(true, 150, 50, 405, 105, null, null, "Atualizar lote", tela);
            atualizarDadosFuncionario.btn.Click += new EventHandler(atualizarDados_Click);

            dtw_Funcionarios = new DataGridView();
            dtw_Funcionarios.DataSource = gerente.exibirFuncionarios();
            dtw_Funcionarios.BackColor = Color.DimGray;
            dtw_Funcionarios.Width = 500;
            dtw_Funcionarios.Height = 400;
            dtw_Funcionarios.Top = 135;
            dtw_Funcionarios.Left = 350;
            dtw_Funcionarios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            tela.Controls.Add(dtw_Funcionarios);


        }

        private void adicionarFuncionario_Click(object sender, EventArgs e)
        {
            gerente.adicionarFuncionario(textBoxPersos[0].tb.Text, textBoxPersos[1].tb.Text, textBoxPersos[2].tb.Text);
            dtw_Funcionarios.DataSource = gerente.exibirFuncionarios();
        }

        private void demitirFuncionario_Click(object sender, EventArgs e)
        {
           if(dtw_Funcionarios.SelectedRows.Count > 0 && dtw_Funcionarios.SelectedCells[0].Value != null)
            {
                int i = int.Parse(dtw_Funcionarios.SelectedCells[0].Value.ToString());
                gerente.demitirFuncionario(i);
                dtw_Funcionarios.DataSource = gerente.exibirFuncionarios();
            }
        }

        private void atualizarDados_Click(object sender, EventArgs e)
        {
            if(dtw_Funcionarios.SelectedRows.Count > 0 && dtw_Funcionarios.SelectedCells[0].Value != null)
            {
                int i = int.Parse(dtw_Funcionarios.SelectedCells[0].Value.ToString());
                gerente.atualizarFuncionario(i, textBoxPersos[0].tb.Text, textBoxPersos[1].tb.Text, textBoxPersos[2].tb.Text);
                dtw_Funcionarios.DataSource = gerente.exibirFuncionarios();
            }
        }

        public void fechar()
        {
            tela.Controls.Remove(titulo.txt);
            for (int i = 0; i < labelPersos.Length; i++)
            {
                tela.Controls.Remove(labelPersos[i].txt);
                tela.Controls.Remove(textBoxPersos[i].tb);
            }
            gerente.fechar();
            tela.Controls.Remove(adicionarFuncionario.btn);
            tela.Controls.Remove(demitirFuncionario.btn);
            tela.Controls.Remove(atualizarDadosFuncionario.btn);
            tela.Controls.Remove(dtw_Funcionarios);
        }
    }
}
