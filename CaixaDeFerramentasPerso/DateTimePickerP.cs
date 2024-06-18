using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CaixaDeFerramentasPerso
{
    public class DateTimePickerP : DateTimePicker
    {
        public DateTimePickerP(int width, int height, int top, int left, Form tela) 
        {
            if(tela != null)
            {
                this.Width = width;
                this.Height = height;
                this.Top = top;
                this.Left = left;
                tela.Controls.Add(this);
                BringToFront();
            }
        }
        public string pegarData()
        {
            string data = $"{Value.Year}/{Value.Month}/{Value.Day}";
            return data;
        }
    }
}
