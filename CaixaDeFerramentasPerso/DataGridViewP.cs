using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CaixaDeFerramentasPerso
{
    public class DataGridViewP : DataGridView
    {
        public DataGridViewP(int width, int height, int top, int left, DataTable source, Form tela)
        {
            if (tela != null)
            {
                SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                this.DataSource = source;
                Width = width;
                Height = height;
                Top = top;
                ReadOnly = true;
                Left = left;
                if (left == 999)
                {
                    this.Left = (tela.Width / 2) - width - 25;
                }
                tela.Controls.Add(this);
            }
        }
    }
}
