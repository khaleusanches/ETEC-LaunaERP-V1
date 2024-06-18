using CaixaDeFerramentasPerso;
using Logica;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Telas
{
    public class BancoUsuarios : InterfacesBanco
    {
        LabelP[] labelPs = new LabelP[5];
        TextBoxP[] textBoxPs = new TextBoxP[3];
        ComboBoxP listUsers;
        DataTable dt;
        
        DAO dao = new DAO();
        private ButtonP btnAdd;
        private DataGridViewP dgv;
        private ButtonP btnRemove;
        private PanelP[] container = new PanelP[3];
        public override void exibir(TelaPadrao tela)
        {
            tela.Width = 625;
            container[0] = new PanelP(210, 210, 85, 25, Color.White, tela);
            labelPs[4] = new LabelP(100, 20, 100, 45, "USUÁRIOS", tela);
            labelPs[4].Font = new Font("Arial", 12, FontStyle.Bold);
            labelPs[0] = new LabelP(30, 20, 125, 45, "ID:", tela);
            labelPs[1] = new LabelP(120, 20, 125, 90, "ID Funcionario:", tela);
            labelPs[2] = new LabelP(100, 20, 180, 45, "Login:", tela);
            labelPs[3] = new LabelP(100, 20, 235, 45, "Senha:", tela);

            textBoxPs[0] = new TextBoxP(30, 25, 145, 45, "", 9, tela);
            textBoxPs[0].Enabled = false;
            listUsers = new ComboBoxP(100, 25, 145, 90, teste(), tela);
            textBoxPs[1] = new TextBoxP(150, 25, 200, 45, "", 64, tela);
            textBoxPs[2] = new TextBoxP(150, 25, 255, 45, "", 64, tela);

            foreach (TextBoxP t in textBoxPs)
            {
                t.TextChanged += new EventHandler(BancoUsuarios_TextChanged);
            }
            listUsers.SelectedIndexChanged += new EventHandler(BancoUsuarios_TextChanged);

            btnAdd = new ButtonP(true, 100, 40, 320, 25, "Cadastrar usuário", tela);
            btnAdd.Enabled = false;
            btnAdd.Click += new EventHandler(Btn_add_Click);

            btnRemove = new ButtonP(true, 100, 40, 320, 140, "Remover usuário", tela);
            btnRemove.Click += new EventHandler(BtnRemove_Click);

            dgv = new DataGridViewP(300, 400, 85, 300, dao.lerTabela("select id, id_func, login from usuarios"), tela);
        }

        private void BtnRemove_Click(object sender, EventArgs e)
        {
            if (dgv.Rows.Count > 1 && dgv.SelectedCells.Count > 0 && dgv.SelectedRows[0].Index < dgv.Rows.Count - 1)
            {
                int i = int.Parse(dgv.SelectedCells[0].Value.ToString());
                dao.updateInsertDelete($"DELETE from usuarios where id={i}");
                dgv.DataSource = dao.lerTabela("select * from usuarios");
            }
        }

        private void BancoUsuarios_TextChanged(object sender, EventArgs e)
        {
            int cont = 0;
            for (int i = 1; i < textBoxPs.Length; i++)
            {
                if (textBoxPs[i].Text == "") { cont++; }
            }
            if (listUsers.SelectedIndex == -1) { cont++; };
            if (cont == 0) { btnAdd.Enabled = true; }
            else { btnAdd.Enabled = false; }
        }

        private void Btn_add_Click(object sender, EventArgs e)
        {
            string sql = $"insert into usuarios (login, senha, id_func) values ('{textBoxPs[1].Text}', '{textBoxPs[2].Text}', '{listUsers.SelectedIndex + 1}')";
            dao.updateInsertDelete(sql);
            dgv.DataSource = dao.lerTabela("select id, id_func, login from usuarios");
        }

        public string[] teste()
        {
            string sql = "select id from funcionarios";
            dt = dao.lerTabela(sql);
            string[] listaUsuarios = new string[dt.Rows.Count];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                listaUsuarios[i] = dt.Rows[i].ItemArray[0].ToString();
            }
            return listaUsuarios;
        }

        public override void fechar(TelaPadrao tela)
        {
            foreach (LabelP labelP in labelPs)
            {
                tela.Controls.Remove(labelP);
            }
            foreach (TextBoxP textBoxP in textBoxPs)
            {
                tela.Controls.Remove(textBoxP);
            }
            tela.Controls.Remove(dgv);
            tela.Controls.Remove(btnAdd);
            tela.Controls.Remove(btnRemove);
            tela.Controls.Remove(listUsers);
        }
    }
}
