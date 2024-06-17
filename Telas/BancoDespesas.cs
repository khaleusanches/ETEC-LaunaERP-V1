using CaixaDeFerramentasPerso;
using Logica;
using System.Data;
using System;

namespace Telas
{
    internal class BancoDespesas : InterfacesBanco
    {
        LabelP[] labelPs = new LabelP[6];
        TextBoxP[] textBoxPs = new TextBoxP[3];
        DateTimePickerP dtVencimento, dtPagamento;
        ComboBoxP cbStatus;
        DataTable dt;
        DAO dao = new DAO();
        string[] lista;
        string sql;
        DataGridViewP dgv;
        ButtonP btnAdd;

        public override void exibir(TelaPadrao tela)
        {
            int top = 165;
            int left = 25;
            int incrementoTop = 40;

            labelPs[0] = new LabelP(150, 20, top, left, "ID:", tela);
            textBoxPs[0] = new TextBoxP(25, 20, top, left + 160, "", 10, tela);
            textBoxPs[0].Enabled = false;
            top += incrementoTop;

            labelPs[1] = new LabelP(150, 20, top, left, "Status do Pagamento", tela);
            cbStatus = new ComboBoxP(50, 20, top, left + 160, new string[2]{"Realizado","Pendente"}, tela);
            top += incrementoTop;

            labelPs[2] = new LabelP(150, 20, top, left, "Valor da Despesa:", tela);
            textBoxPs[1] = new TextBoxP(150, 20, top, left + 160, "", 20, tela);
            top += incrementoTop;

            
            labelPs[3] = new LabelP(150, 20, top, left, "Data do Vencimento:", tela);
            dtVencimento = new DateTimePickerP(150, 20, top, left + 160, tela);
            top += incrementoTop;

            labelPs[4] = new LabelP(150, 20, top, left, "Data do Pagamento:", tela);
            dtPagamento = new DateTimePickerP(150, 20, top, left + 160, tela);
            top += incrementoTop;
            dtPagamento.Enabled = false;

            labelPs[5] = new LabelP(150, 20, top, left, "Descrição:", tela);
            textBoxPs[2] = new TextBoxP(150, 20, top, left + 160, "", 20, tela);
            top += incrementoTop;


            btnAdd = new ButtonP(true, 120, 50, top, left, "Cadastrar empréstimo", tela);
            btnAdd.Enabled = false;
            btnAdd.Click += new EventHandler(Btn_add_Click);

            for (int i = 1; i < textBoxPs.Length; i++)
            {
                textBoxPs[i].TextChanged += new EventHandler(BancoDespesas_TextChanged);
            }
            cbStatus.SelectedIndexChanged += new EventHandler(BancoDespesas_TextChanged);

            dgv = new DataGridViewP(575, 500, 125, 375, dao.lerTabela("select * from despesasVariadas"), tela);
        }

        private void BancoDespesas_TextChanged(object sender, EventArgs e)
        {
            int cont = 0;
            for (int i = 1; i < textBoxPs.Length; i++)
            {
                if (textBoxPs[i].Text == "") { cont++; }
            }
            if (cbStatus.SelectedIndex == -1) { cont++; }
            if (cbStatus.Text == "Realizado") { dtPagamento.Enabled = true; }
            if (cont == 0) { btnAdd.Enabled = true; }
            else { btnAdd.Enabled = false; }
        }

        private void Btn_add_Click(object sender, EventArgs e)
        {
            if (cbStatus.Text == "Realizado") 
            { 
                sql = $"insert into despesasvariadas(valorDespesa, descricaoDespesa, status_pagamento, data_vencimento, dataPagamento) values('{textBoxPs[1].Text}', " +
                $"'{textBoxPs[2].Text}', '{cbStatus.Text}', '{dtVencimento.pegarData()}', '{dtPagamento.pegarData()}');";
            }
            else
            {
                sql = $"insert into despesasvariadas(valorDespesa, descricaoDespesa, status_pagamento, data_vencimento) values('{textBoxPs[1].Text}', " +
                $"'{textBoxPs[2].Text}', '{cbStatus.Text}', '{dtVencimento.pegarData()}');";
            }
            dao.updateInsertDelete(sql);
            dgv.DataSource = dao.lerTabela("select * from despesasVariadas");
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
            tela.Controls.Remove(btnAdd);
            tela.Controls.Remove(dtPagamento);
            tela.Controls.Remove(dtVencimento);
            tela.Controls.Remove(cbStatus);
            tela.Controls.Remove(dgv);
        }
    }
}