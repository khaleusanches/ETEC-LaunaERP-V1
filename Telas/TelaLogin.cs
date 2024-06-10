using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Telas
{
    public partial class TelaLogin : Form
    {
        public TelaLogin()
        {
            InitializeComponent();
        }

        private void lbUsername_Click(object sender, EventArgs e)
        {
        }

        private void tbUsername_tbSenha_TextChanged(object sender, EventArgs e)
        {
            if(tbUsername.Text != "" && tbSenha.Text != "")
            {
                btnLogar.Enabled = true;
            }
            else 
            {
                btnLogar.Enabled = false;
            }
        }
        private void btnLogar_Click(object sender, EventArgs e)
        {
            this.Hide();
            new TelaSetorRH().ShowDialog();
        }
    }
}
