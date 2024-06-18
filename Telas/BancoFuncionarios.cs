using CaixaDeFerramentasPerso;
using Logica;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Telas
{
    public class BancoFuncionarios : InterfacesBanco
    {
        int verificaID;
        LabelP[] labelPs = new LabelP[14];
        TextBoxP[] textBoxP = new TextBoxP[8];
        DataTable dt;
        DAO dao = new DAO();
        DataGridViewP dgv;
        ButtonP btnAdd;
        ButtonP btnUpdate;
        ComboBoxP cbCargos;
        ComboBoxP cbSetores;
        Funcionario funcionario;

        DateTimePickerP dtNascimento, dtAdmissao;

        PanelP[] container = new PanelP[2];
        PanelP teste;
        string[] lista = new string[1] {""};
        public override void exibir(TelaPadrao tela)
        {
            tela.Width = 1200;
            container[0] = new PanelP(490, 165, 85, 20, Color.White, tela);
            labelPs[12] = new LabelP(250, 20, 100, 35, "DADOS PESSOAIS", tela);
            labelPs[12].Font = new Font("Arial", 12, FontStyle.Bold);
            labelPs[0] = new LabelP(30, 20, 130, 35, "ID:", tela);
            labelPs[1] = new LabelP(100, 20, 130, 75, "Nome:", tela);
            labelPs[2] = new LabelP(100, 20, 130, 175, "Email:", tela);
            labelPs[3] = new LabelP(100, 20, 130, 335, "Tel:", tela);
            labelPs[4] = new LabelP(100, 20, 195, 35, "CEP:", tela);
            labelPs[5] = new LabelP(100, 20, 195, 210, "RG:", tela);
            labelPs[6] = new LabelP(100, 20, 195, 375, "Nascimento:", tela);

            textBoxP[0] = new TextBoxP(30, 25, 150, 35, "", 9, tela);
            textBoxP[0].Enabled = false;
            textBoxP[1] = new TextBoxP(90, 25, 150, 75, "", 64, tela);
            textBoxP[2] = new TextBoxP(150, 25, 150, 175, "", 100, tela);
            textBoxP[3] = new TextBoxP(150, 25, 150, 335, "", 11, tela);
            textBoxP[4] = new TextBoxP(150, 25, 215, 35, "", 200, tela);
            textBoxP[5] = new TextBoxP(150, 25, 215, 210, "", 8, tela);
            dtNascimento = new DateTimePickerP(100, 20, 215, 375, tela);


            container[1] = new PanelP(490, 165, 315, 20, Color.White, tela);
            labelPs[13] = new LabelP(250, 20, 330, 35, "OUTROS DADOS", tela);
            labelPs[13].Font = new Font("Arial", 12, FontStyle.Bold);
            labelPs[7] = new LabelP(100, 20, 360, 35, "Admissão:", tela);
            labelPs[8] = new LabelP(100, 20, 360, 160, "PIS:", tela);
            labelPs[9] = new LabelP(100, 20, 360, 325, "Salario:", tela);
            labelPs[10] = new LabelP(100, 20, 425, 35, "Cargo:", tela);
            labelPs[11] = new LabelP(100, 20, 425, 160, "Setores:", tela);


            dtAdmissao = new DateTimePickerP(100, 20, 380, 35, tela);
            textBoxP[6] = new TextBoxP(130, 25, 380, 160, "", 9, tela);
            textBoxP[7] = new TextBoxP(100, 25, 380, 325, "", 9, tela);
            cbCargos = new ComboBoxP(100, 25, 445, 35, pegaIDLista("nome", "cargos", ""), tela);
            cbSetores = new ComboBoxP(130, 25, 445, 160, pegaIDLista("nome", "setores", ""), tela);
            cbCargos.SelectedIndexChanged += new EventHandler(BancoFuncionarios_TextChanged);
            cbSetores.SelectedIndexChanged += new EventHandler(BancoFuncionarios_TextChanged);
            foreach (TextBoxP t in textBoxP)
            {
                t.TextChanged += new EventHandler(BancoFuncionarios_TextChanged);
            }

            btnAdd = new ButtonP(true, 100, 45, 500, 150, "CADASTRAR FUNCIONÁRIO", tela);
            btnAdd.Enabled = false;
            btnAdd.Click += new EventHandler(Btn_add_Click);

            this.funcionario = tela.funcionario;
            if (funcionario.cargo == "Gerente")
            {
                btnUpdate = new ButtonP(true, 100, 45, 500, 260, "ATUALIZAR DADOS", tela);
                btnUpdate.Click += new EventHandler(Btn_Update_Click);
                btnUpdate.Enabled = false;
            }
            
            dgv = new DataGridViewP(900, 500, 85, 555, dao.lerTabela("select"
                +" funcionarios.nome as 'Nome',"
                +" funcionarios.id as 'ID',"
                +" cargos.nome as 'Cargo',"
                +" setores.nome as 'Setor',"
                +" email as 'Email',"
                +" tel as 'Telefone', endereco as 'CEP', pis as 'PIS',"
                +" admissao as 'Data de admissão',"
                +" salario as 'Salário'"
            +" from funcionarios"
            +" inner join cargos on idcargofk = cargos.id"
            +" inner join setores on idsetorfk = setores.id"
            +" order by funcionarios.nome"), tela);
            dgv.SelectionChanged += Dgv_SelectionChanged;
            teste = new PanelP(920, 540, 85, 540, Color.FromArgb(99, 133, 199), tela);
        }

        public string[] pegaIDLista(string dado, string tabela, string where)
        {
            string sql = $"select {dado} from {tabela} {where}";
            dt = dao.lerTabela(sql);
            if (dt.Rows.Count >= 1)
            {
                lista = new string[dt.Rows.Count];
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    lista[i] = dt.Rows[i].ItemArray[0].ToString();
                }
            }
            else
            {
                lista = new string[1] { "" };
            }
            return lista;
        }
        public string pegaID(string dado, string tabela, string where)
        {
            string sql = $"select {dado} from {tabela} {where}";
            
            dt = dao.lerTabela(sql);
            string id;
            if (dt.Rows.Count >= 1)
            {
                id = dt.Rows[0].ItemArray[0].ToString();
            }
            else
            {
                id = "0";
            }
            return id;
        }
        private void Dgv_SelectionChanged(object sender, EventArgs e)
        {
            if (dgv.Rows.Count > 1 && dgv.SelectedCells.Count > 0 )
            {
                verificaID = dgv.SelectedRows[0].Index;
                if (funcionario.cargo == "Gerente")
                {
                    btnUpdate.Enabled = true;
                }
            }
            else { }
        }
        private void Btn_Update_Click(object sender, EventArgs e)
        {
            string[] text = new string[6] 
            {
                dgv.Rows[verificaID].Cells[1].Value.ToString(),
                dgv.Rows[verificaID].Cells[0].Value.ToString(),
                dgv.Rows[verificaID].Cells[4].Value.ToString(),
                dgv.Rows[verificaID].Cells[5].Value.ToString(),
                dgv.Rows[verificaID].Cells[6].Value.ToString(),
                dgv.Rows[verificaID].Cells[9].Value.ToString(),
            };
            new atualizarFuncionarios(text, pegaIDLista("nome", "cargos", ""), pegaIDLista("nome", "setores", ""), funcionario).ShowDialog();
        }

        public override void fechar(TelaPadrao tela)
        {
            foreach (TextBoxP tbp in textBoxP)
            {
                tela.Controls.Remove(tbp);
            }
            foreach(LabelP labelP in labelPs)
            {
                tela.Controls.Remove(labelP);
            }
            tela.Controls.Remove(dgv);
            tela.Controls.Remove(cbCargos);
            tela.Controls.Remove(cbSetores);
            tela.Controls.Remove(btnAdd);
            tela.Controls.Remove(teste);
            tela.Controls.Remove(dtNascimento);
            tela.Controls.Remove(dtAdmissao);
            tela.Controls.Remove(container[0]);
            tela.Controls.Remove(container[1]);
            if (funcionario.cargo == "Gerente")
            {
                tela.Controls.Remove(btnUpdate);
            }
        }

        private void Btn_add_Click(object sender, EventArgs e)
        {
            string sql = $"insert into funcionarios (nome, email, tel, endereco, rg, nascimento, admissao, pis, salario, idsetorfk, idcargofk) values ('{textBoxP[1].Text}', '{textBoxP[2].Text}', '{textBoxP[3].Text}', '{textBoxP[4].Text}', '{textBoxP[5].Text}', '{dtNascimento.pegarData()}', '{dtNascimento.pegarData()}', '{textBoxP[6].Text}', '{textBoxP[7].Text}', {pegaID("id", "cargos", $"where nome = '{cbCargos.Text}';")}, {pegaID("id", "cargos", $"where nome = '{cbCargos.Text}';")})";
            dao.updateInsertDelete(sql);
            dgv.DataSource = dao.lerTabela("select"
                + " funcionarios.nome as 'Nome',"
                + " funcionarios.id as 'ID',"
                + " cargos.nome as 'Cargo',"
                + " setores.nome as 'Setor',"
                + " email as 'Email',"
                + " tel as 'Telefone', pis as 'PIS',"
                + " admissao as 'Data de admissão',"
                + " salario as 'Salário'"
            + " from funcionarios"
            + " inner join cargos on idcargofk = cargos.id"
            + " inner join setores on idsetorfk = setores.id"
            + " order by funcionarios.nome");
        }

        private void BancoFuncionarios_TextChanged(object sender, EventArgs e)
        {
            int cont = 0;
            for (int i = 1; i < textBoxP.Length; i++)
            {
                if (textBoxP[i].Text == ""){ cont++; }
            }
            if(cbCargos.SelectedIndex == -1 || cbSetores.SelectedIndex == -1) { cont++; };
            if(cont== 0) { btnAdd.Enabled = true; }
            else { btnAdd.Enabled = false; }
        }

         
    }

}
