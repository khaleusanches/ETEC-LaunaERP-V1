using CaixaDeFerramentasPerso;
using Logica;
using System.Data;
using System;
using System.Windows.Forms;
using System.Reflection.Emit;
using System.ComponentModel;
using System.Drawing;

namespace Telas
{
    public class BancoPagarContas : InterfacesBanco
    {
        LabelP[] labelPs = new LabelP[7];
        TextBoxP[] textBoxPs = new TextBoxP[2];
        DateTimePickerP dtPagamento;
        ComboBoxP[] comboBoxPs = new ComboBoxP[4];
        DataTable dt;
        DAO dao = new DAO();
        string[] lista = new string[1] {""};
        DataGridViewP dgv;
        ButtonP btnAdd;
        ButtonP btnAddListaSalarioPende;
        DateTime dataAtual = new DateTime(2024, 09, 12);
        DateTime data;
        private TelaPadrao tela;
        private PanelP container;

        public override void exibir(TelaPadrao tela)
        {
            int top = 100;
            int left = 85;
            this.tela = tela;
            int incrementoTop = 40;
            container = new PanelP(340, 290, 85, 75, Color.White, tela);
            labelPs[0] = new LabelP(200, 20, top, left, "REALIZAR PAGAMENTOS", tela);
            labelPs[0].Font = new Font("Arial", 12, FontStyle.Bold);
            top += incrementoTop;
            labelPs[1] = new LabelP(150, 20, top, left, "ID:", tela);
            textBoxPs[0] = new TextBoxP(25, 20, top, left + 160, "", 10, tela);
            textBoxPs[0].Enabled = false;
            top += incrementoTop;

            labelPs[2] = new LabelP(150, 20, top, left, "Sálarios ID:", tela);
            comboBoxPs[0] = new ComboBoxP(50, 20, top, left + 160, pegaID("id", "pagamentosSalario", "statusPagamento = 'Pendente'"), tela);
            btnAddListaSalarioPende = new ButtonP(true, 50, 20, top, left+220, "Atualizar", tela);
            top += incrementoTop;

            labelPs[3] = new LabelP(150, 20, top, left, "Empréstimos", tela);
            comboBoxPs[1] = new ComboBoxP(50, 20, top, left + 160, pegaID("id", "emprestimos", "valor_emprestimo > valor_pago"), tela);
            top += incrementoTop;

            labelPs[4] = new LabelP(150, 20, top, left, "Gastos Váriados", tela);
            comboBoxPs[2] = new ComboBoxP(50, 20, top, left + 160, pegaID("id","despesasVariadas","status_pagamento = 'Pendente'"), tela);
            top += incrementoTop;

            labelPs[5] = new LabelP(150, 20, top, left, "Valor a ser pago", tela);
            textBoxPs[1] = new TextBoxP(150, 20, top, left + 160, "", 20, tela, true);
            top += incrementoTop;

            labelPs[6] = new LabelP(150, 20, top, left, "Data do Pagamento:", tela);
            dtPagamento = new DateTimePickerP(150, 20, top, left + 160, tela);
            top += incrementoTop + 30;

            btnAdd = new ButtonP(true, 120, 50, top, left, "Cadastrar Pagamento", tela);
            btnAdd.Enabled = false;
            btnAdd.Click += new EventHandler(Btn_add_Click);

            btnAddListaSalarioPende.Enabled = false;
            btnAddListaSalarioPende.Click += new EventHandler(Btn_Lista_Salario_Click);
            btnAddListaSalarioPende.BackColor = Color.FromArgb(99, 133, 199);
            atualizarListaSalarios();

            textBoxPs[1].TextChanged += new EventHandler(BancoPagar_TextChanged);
            comboBoxPs[0].SelectedIndexChanged += new EventHandler(BancoPagar_TextChanged);
            comboBoxPs[1].SelectedIndexChanged += new EventHandler(BancoPagar_TextChanged);
            comboBoxPs[2].SelectedIndexChanged += new EventHandler(BancoPagar_TextChanged);

            dgv = new DataGridViewP(575, 500, 85, 430, null, tela);
        }
        private void atualizarListaSalarios()
        {
            dt = dao.lerTabela($"select dataPagamentoSal from pagamentosSalario where statusPagamento = 'Realizado' order by dataPagamentoSal DESC;");
            if (dt.Rows.Count != 0) 
            {
                data = (DateTime)dt.Rows[0].ItemArray[0];
                if (dataAtual.Month > data.Month)
                {
                    dt = dao.lerTabela($"select dataVencimento from pagamentosSalario where statusPagamento = 'Pendente' order by dataVencimento DESC;");
                    if (dt.Rows.Count != 0)
                    {
                        data = (DateTime)dt.Rows[0].ItemArray[0];
                        if (dataAtual.Month > data.Month)
                        {
                            btnAddListaSalarioPende.Enabled = true;
                        }
                    }
                    else
                    {
                        btnAddListaSalarioPende.Enabled = true;
                    }
                }
            }
            else
            {
                dt = dao.lerTabela($"select dataVencimento from pagamentosSalario where statusPagamento = 'Pendente' order by dataVencimento DESC;");
                if (dt.Rows.Count != 0)
                {
                    data = (DateTime)dt.Rows[0].ItemArray[0];
                    if (dataAtual.Month > data.Month)
                    {
                        btnAddListaSalarioPende.Enabled = true;
                    }
                }
                else
                {
                    btnAddListaSalarioPende.Enabled = true;
                }
            }
        }
        private void Btn_Lista_Salario_Click(object sender, EventArgs e)
        {
            dt = dao.lerTabela($"select id from funcionarios");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dao.updateInsertDelete($"insert into pagamentosSalario(idfuncionariofk, valorPagamentoSal, dataVencimento) values('{dt.Rows[i].ItemArray[0]}', (select funcionarios.salario from funcionarios where funcionarios.id = '{dt.Rows[i].ItemArray[0]}'), '{dataAtual.Year}/{dataAtual.Month}/{28}');");
            }
            fechar(tela);
            exibir(tela);
        }

        public string[] pegaID(string dado, string tabela, string where)
        {
            string sql = $"select {dado} from {tabela} where {where}";
            dt = dao.lerTabela(sql);
            if (dt.Rows.Count >= 1) {
                lista = new string[dt.Rows.Count + 1];
                lista[0] = "";
                int j = 0;
                for (int i = 1; i < dt.Rows.Count + 1; i++, j++)
                {
                    lista[i] = dt.Rows[j].ItemArray[0].ToString();
                }
            }
            else
            {
                lista = new string[1] { "" };
            }
            return lista;
        }

        private void BancoPagar_TextChanged(object sender, EventArgs e)
        {
            int cont = 0;
            
            if(comboBoxPs[0].SelectedIndex > 0)
            {
                comboBoxPs[1].Enabled = false;
                comboBoxPs[2].Enabled = false;
                dgv.DataSource = dao.lerTabela("select pagamentosSalario.id, idfuncionariofk, funcionarios.nome, valorPagamentoSal, dataPagamentoSal, statusPagamento from pagamentosSalario\r\ninner join funcionarios on pagamentosSalario.idfuncionariofk = funcionarios.id;");
                dt = dao.lerTabela($"select valorPagamentoSal from pagamentosSalario where id = '{comboBoxPs[0].Text}'");
                textBoxPs[1].Text = dt.Rows[0].ItemArray[0].ToString().Replace(",", ".");
            }
            else if (comboBoxPs[1].SelectedIndex > 0)
            {
                comboBoxPs[0].Enabled = false;
                comboBoxPs[2].Enabled = false;
                dgv.DataSource = dao.lerTabela("select * from Emprestimos where valor_emprestimo > valor_pago");
                dt = dao.lerTabela($"select valor_emprestimo from emprestimos where id = '{comboBoxPs[1].Text}'");
                if (textBoxPs[1].Text == "")
                {
                    textBoxPs[1].Text = dt.Rows[0].ItemArray[0].ToString().Replace(",", ".");
                }
            }
            else if (comboBoxPs[2].SelectedIndex > 0)
            {
                comboBoxPs[0].Enabled = false;
                comboBoxPs[1].Enabled = false;
                dgv.DataSource = dao.lerTabela("select * from despesasVariadas where status_pagamento = 'Pendente';");
                dt = dao.lerTabela($"select valorDespesa from despesasVariadas where id = '{comboBoxPs[2].Text}';");
                textBoxPs[1].Text = dt.Rows[0].ItemArray[0].ToString().Replace(",", ".");
            }
            else 
            { 
                cont++;
                comboBoxPs[0].Enabled = true;
                comboBoxPs[1].Enabled = true;
                comboBoxPs[2].Enabled = true;
            }
            for (int i = 1; i < textBoxPs.Length; i++)
            {
                if (textBoxPs[i].Text == "") { cont++; }
            }
            if (cont == 0) { btnAdd.Enabled = true; }
            else { btnAdd.Enabled = false; }
        }

        private void Btn_add_Click(object sender, EventArgs e)
        {
            if (comboBoxPs[0].Enabled == true)
            {
                string sql = $"update pagamentosSalario set statusPagamento = 'Realizado', dataPagamentoSal = '{dataAtual.Year}/{dataAtual.Month}/{dataAtual.Day}' where id = '{comboBoxPs[0].Text}';";
                dao.updateInsertDelete(sql);
                fechar(tela);
                exibir(tela);
                dgv.DataSource = dao.lerTabela("select pagamentosSalario.id, idfuncionariofk, funcionarios.nome, valorPagamentoSal, dataPagamentoSal, statusPagamento from pagamentosSalario inner join funcionarios on pagamentosSalario.idfuncionariofk = funcionarios.id;");
            }
            else if (comboBoxPs[1].Enabled == true)
            {
                string sql = $"insert into pagamentoEmprestimos(idemprestimofk, valorPagamentoEmprestimo, dataPagamentoEmprestimo) values('{comboBoxPs[1].Text}', REPLACE(REPLACE('{textBoxPs[1].Text}', '.' ,''), ',', '.'), '{dataAtual.Year}/{dataAtual.Month}/{dataAtual.Day}');";
                dao.updateInsertDelete(sql);
                dao.updateInsertDelete($"update emprestimos set valor_pago = valor_pago + REPLACE(REPLACE('{textBoxPs[1].Text}', '.' ,''), ',', '.') where id = '{comboBoxPs[1].Text}';");
                fechar(tela);
                exibir(tela);
                dgv.DataSource = dao.lerTabela("select * from Emprestimos where valor_emprestimo > valor_pago");
                textBoxPs[1].Text = "";
            }
            else if (comboBoxPs[2].Enabled == true)
            {
                string sql = $"update despesasVariadas set status_pagamento = 'Realizado', dataPagamento = '{dataAtual.Year}/{dataAtual.Month}/{dataAtual.Day}' where id = '{comboBoxPs[2].Text}';";
                dao.updateInsertDelete(sql);
                fechar(tela);
                exibir(tela);
                dgv.DataSource = dao.lerTabela("select * from despesasVariadas where status_pagamento = 'Pendente';");
            }

        }

        public override void fechar(TelaPadrao tela)
        {
            foreach (TextBoxP tbp in textBoxPs)
            {
                tela.Controls.Remove(tbp);
            }
            foreach (LabelP labelP in labelPs)
            {
                tela.Controls.Remove(labelP);
            }
            foreach(ComboBoxP comboBoxP in comboBoxPs)
            {
                tela.Controls.Remove(comboBoxP);
            }
            tela.Controls.Remove(btnAdd);
            tela.Controls.Remove(dtPagamento);
            tela.Controls.Remove(container);
            tela.Controls.Remove(dgv);
            tela.Controls.Remove(btnAddListaSalarioPende);
        }
    }
}