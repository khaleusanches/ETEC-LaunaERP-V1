using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace CaixaDeFerramentasPerso
{
    public class ComboBoxP : ComboBox
    {
        public ComboBoxP(int width, int height, int top, int left, string[] opcoes, Form tela)
        {
            if (tela != null)
            {
                this.Font = new Font("Arial", 10);
                foreach (var item in opcoes)
                {
                    this.Items.Add(item);
                }
                Width = width;
                Height = height;
                Top = top;
                Left = left;
                if (left == 999)
                {
                    this.Left = (tela.Width / 2) - width - 25;
                }
                this.DropDownStyle = ComboBoxStyle.DropDownList;
                tela.Controls.Add(this);
            }
            
        }
    }
}
