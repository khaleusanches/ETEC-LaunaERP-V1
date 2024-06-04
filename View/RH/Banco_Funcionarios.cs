using CaixaDeFerramentasPerso;
using Sistema.Cargos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace View.RH
{
    public class Banco_Funcionarios 
    {
        LabelP[] labelPs = new LabelP[13];
        TextBoxP[] textBoxP = new TextBoxP[13];
        DataTable dt;
        DataGridView dgv = new DataGridView();
        AuxiliarRH auxiliar;
        public Banco_Funcionarios(AuxiliarRH auxiliar)
        {
            this.auxiliar = auxiliar;  
        }
        public void exibir(Form tela)
        {
            labelPs[0] = new LabelP(30, 20, 125, 25, "ID:", tela);
            labelPs[1] = new LabelP(100, 20, 125, 90, "Nome:", tela);
            labelPs[2] = new LabelP(100, 20, 180, 25, "Email:", tela);
            labelPs[3] = new LabelP(100, 20, 235, 25, "Tel:", tela);
            labelPs[4] = new LabelP(100, 20, 290, 25, "CEP:", tela);
            labelPs[5] = new LabelP(100, 20, 345, 25, "RG:", tela);
            labelPs[6] = new LabelP(100, 20, 345, 160, "CPF:", tela);
            labelPs[7] = new LabelP(100, 20, 400, 25, "Nascimento:", tela);
            labelPs[8] = new LabelP(100, 20, 400, 160, "Admissão:", tela);
            labelPs[9] = new LabelP(100, 20, 465, 25, "PIS:", tela);
            labelPs[10] = new LabelP(100, 20, 465, 160, "Salario:", tela);
            labelPs[11] = new LabelP(100, 20, 525, 25, "Login:", tela);
            labelPs[12] = new LabelP(100, 20, 525, 160, "Password:", tela);

            textBoxP[0] = new TextBoxP(30, 25, 145, 25, "", 9, tela);
            textBoxP[1] = new TextBoxP(50, 25, 145, 90, "", 9, tela);
            textBoxP[2] = new TextBoxP(150, 25, 200, 25, "", 9, tela);
            textBoxP[3] = new TextBoxP(150, 25, 255, 25, "", 9, tela);
            textBoxP[4] = new TextBoxP(150, 25, 310, 25, "", 9, tela);
            textBoxP[5] = new TextBoxP(100, 25, 365, 25, "", 9, tela);
            textBoxP[6] = new TextBoxP(100, 25, 365, 160, "", 9, tela);
            textBoxP[7] = new TextBoxP(100, 25, 420, 25, "", 9, tela);
            textBoxP[8] = new TextBoxP(100, 25, 420, 160, "", 9, tela);
            textBoxP[9] = new TextBoxP(130, 25, 485, 25, "", 9, tela);
            textBoxP[10] = new TextBoxP(100, 25, 485, 160, "", 9, tela);
            textBoxP[11] = new TextBoxP(100, 25, 545, 25, "", 9, tela);
            textBoxP[12] = new TextBoxP(100, 25, 545, 160, "", 9, tela);

            auxiliar.btn_add = new ButtonP(true, 100, 25, 580, 25, "teste", tela);
            auxiliar.btn_add.Click += (sender, EventArgs) => auxiliar.Btn_add_Click(textBoxP);

            dgv.DataSource = auxiliar.verTabela(this);
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.Width = 680;
            dgv.Height = 500;
            dgv.Top = 125;
            dgv.Left = 285;
            tela.Controls.Add(dgv);
        }
        public void refresh()
        {
            dgv.DataSource = auxiliar.verTabela(this);
        }
        public void fechar(Form tela)
        {
            for (int i = 0; i < textBoxP.Count(); i++)
            {
                tela.Controls.Remove(labelPs[i]);
                tela.Controls.Remove(textBoxP[i]);
            }
            tela.Controls.Remove(dgv);
        }
    }
}
