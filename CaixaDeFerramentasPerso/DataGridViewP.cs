using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
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
                BackgroundColor = Color.White;
                BorderStyle = BorderStyle.None;
                DataGridViewCellStyle a = new DataGridViewCellStyle();
                a.BackColor = Color.FromArgb(99, 133, 199);
                a.ForeColor = Color.Black;
                a.SelectionBackColor = Color.FromArgb(99, 133, 199);
                a.Alignment = DataGridViewContentAlignment.MiddleCenter;
                a.Font = new Font("Arial", 10, FontStyle.Bold);
                ColumnHeadersDefaultCellStyle = a;
                ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
                ColumnHeadersHeight = 35;
                ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
                EnableHeadersVisualStyles = false;
                CellBorderStyle = DataGridViewCellBorderStyle.None;
                AllowUserToResizeColumns = false;
                AllowUserToResizeRows = false;
                MultiSelect = false;
                RowHeadersVisible = false;
                RowHeadersWidth = 25;
                RowHeadersWidth = 25;
                DefaultCellStyle = new DataGridViewCellStyle();
                DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                foreach (DataGridViewColumn column in Columns)
                {
                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    column.FillWeight = 150;
                }
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
