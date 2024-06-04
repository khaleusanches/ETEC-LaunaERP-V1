using CaixaDeFerramentasPerso;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace View
{
    public class Tl_Login : Tl_Padrao
    {
        public Tl_Login() 
        {
            LabelP lb_username = new LabelP(150, 25, 125, 999, "Nome:", this);
            TextBoxP tb_username = new TextBoxP(150, 50, 150, 999, "", 50, this);
            LabelP lb_senha = new LabelP(150, 25, 200, 999, "Senha:", this);
            TextBoxP tb_senha = new TextBoxP(150, 50, 225, 999, "", 50, this);
            tb_senha.PasswordChar = '*';
            ButtonP btn_logar = new ButtonP(true, 150, 35, 275, 999, "Logar", this);
        }
    }
}
