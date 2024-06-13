using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CaixaDeFerramentasPerso;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Telas
{
    public class BancoCargosSetores
    {
        private LabelP[] labelPs = new LabelP[4];
        private TextBoxP[] textBoxPs = new TextBoxP[3];

        public void exibir(Form tela)
        {
            labelPs[0] = new LabelP(100, 20, 125, 25, "CARGOS", tela);
            labelPs[0].Font = new Font("Arial", 14);
            labelPs[1] = new LabelP(30, 20, 165, 25, "ID:", tela);
            labelPs[2] = new LabelP(50, 20, 165, 115, "Nome:", tela);
            labelPs[3] = new LabelP(75, 20, 165, 250, "Descrição:", tela);

            textBoxPs[0] = new TextBoxP(50, 25, 160, 60, "", 9, tela);
            textBoxPs[1] = new TextBoxP(75, 25, 160, 165, "", 9, tela);
            textBoxPs[2] = new TextBoxP(150, 100, 160, 330, "", 300, tela);
            textBoxPs[2].Multiline = true;
        }
        public void fechar(Form tela)
        {
            foreach (LabelP labelP in labelPs)
            {
                tela.Controls.Remove(labelP);
            }
        }
    }
}
