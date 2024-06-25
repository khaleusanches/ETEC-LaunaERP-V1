using CaixaDeFerramentasPerso;
using Logica;
using System.Data;
using System;
using System.Windows.Forms;
using System.Reflection.Emit;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Drawing;

namespace Telas
{
    internal class BancoLotes : InterfacesBanco
    {
        LabelP[] labelPs = new LabelP[12];
        TextBoxP[] textBoxP = new TextBoxP[4];
        ComboBoxP[] comboBoxPs = new ComboBoxP[3];
        DataTable dt;
        DAO dao = new DAO();
        DataGridViewP dgv;
        ButtonP btnAdd;
        PanelP container, container2;
        ButtonP btnUpdate;
        DateTimePickerP[] dateTimePickerPs = new DateTimePickerP[4];
        DateTime dataatual = DateTime.Now;
        string sqlTabela = "select lotes.id as 'Lote ID', lotes.notafiscal as 'Nota Fiscal', fornecedores.nome as 'Fornecedor Nome', produtos.nome as 'Produto', lotes.quantidade as 'Quantidade', lotes.valor as 'Valor', lotes.recebido as 'Recebidos', lotes.dataRecebimento as 'DT Recebimento', lotes.fabricacao as 'DT Fabricação', lotes.validade as 'DT Validade' from lotes inner join fornecedores on lotes.idfornecedorfk = fornecedores.id\r\ninner join produtos on lotes.idprodutofk = produtos.id;";
        string[] lista;
        private string sql;

        public override void exibir(TelaPadrao tela)
        {
            container = new PanelP(275, 500, 85, 20, Color.White, tela);
            labelPs[0] = new LabelP(100, 20, 100, 35, "LOTES", tela);
            labelPs[0].Font = new Font("Arial", 12, FontStyle.Bold);
            labelPs[1] = new LabelP(30, 20, 125, 35, "ID:", tela);
            labelPs[2] = new LabelP(100, 20, 125, 100, "ID Produto:", tela);
            labelPs[3] = new LabelP(235, 20, 180, 35, "ID Fornecedor:", tela);
            labelPs[4] = new LabelP(100, 20, 235, 35, "Quantidade:", tela);
            labelPs[11] = new LabelP(100, 20, 235, 170, "Valor:", tela);
            labelPs[5] = new LabelP(235, 20, 290, 35, "Data da Compra:", tela);
            labelPs[6] = new LabelP(100, 20, 345, 35, "Nota Fiscal:", tela);
            labelPs[7] = new LabelP(100, 20, 345, 170, "Recebido:", tela);
            labelPs[8] = new LabelP(235, 20, 400, 35, "Data de Recebimento:", tela);
            labelPs[9] = new LabelP(235, 20, 465, 35, "Data de Fabricação:", tela);
            labelPs[10] = new LabelP(235, 20, 520, 35, "Data de Validade:", tela);

            textBoxP[0] = new TextBoxP(30, 25, 145, 35, "", 9, tela);
            textBoxP[0].Enabled = false;
            textBoxP[1] = new TextBoxP(100, 25, 255, 35, "", 9, tela, isQuant:true);
            textBoxP[2] = new TextBoxP(100, 25, 255, 170, "", 9, tela, true);
            textBoxP[3] = new TextBoxP(100, 25, 365, 35, "", 9, tela, isQuant: true);
            

            comboBoxPs[0] = new ComboBoxP(50, 25, 145, 100, pegaID("produtos"), tela);
            comboBoxPs[1] = new ComboBoxP(150, 25, 200, 35, pegaID("fornecedores"), tela);
            comboBoxPs[2] = new ComboBoxP(100, 25, 365, 170, new string[2] { "sim", "nao" }, tela);
            comboBoxPs[2].SelectedIndex = 1;

            dateTimePickerPs[0] = new DateTimePickerP(235, 25, 310, 35, tela);
            dateTimePickerPs[1] = new DateTimePickerP(235, 25, 420, 35, tela);
            dateTimePickerPs[2] = new DateTimePickerP(235, 25, 485, 35, tela);
            dateTimePickerPs[3] = new DateTimePickerP(235, 25, 550, 35, tela);
            dateTimePickerPs[0].MaxDate = dataatual;
            dateTimePickerPs[3].MinDate = dataatual;

            btnAdd = new ButtonP(true, 100, 50, 600, 25, "Cadastrar Lote", tela);
            btnAdd.Enabled = false;
            btnAdd.Click += new EventHandler(Btn_add_Click);
            btnUpdate = new ButtonP(true, 100, 50, 600, 150, "Atualizar Lote", tela);
            btnUpdate.Click += new EventHandler(Btn_Update_Click);
            btnUpdate.Enabled = false;

            foreach (TextBoxP t in textBoxP)
            {
                t.TextChanged += new EventHandler(BancoLote_TextChanged);
            }
            foreach(ComboBoxP comboBoxP in comboBoxPs)
            {
                comboBoxP.SelectedIndexChanged += new EventHandler(BancoLote_TextChanged);
            }
            for (int i = 0; i < dateTimePickerPs.Length; i++)
            {
                dateTimePickerPs[i].Enabled = false;
                dateTimePickerPs[i].ValueChanged += new EventHandler(BancoLote_TextChanged);
            }
            dateTimePickerPs[0].Enabled = true;
            
            dgv = new DataGridViewP(680, 500, 85, 350, dao.lerTabela(sqlTabela), tela);
            dgv.SelectionChanged += Dgv_SelectionChanged;
            container2 = new PanelP(620, 500, 85, 340, Color.FromArgb(99, 133, 199), tela);
        }

        private void Dgv_SelectionChanged(object sender, EventArgs e)
        {
            if (dgv.Rows.Count > 1 && dgv.SelectedCells.Count > 0)
            {
                int i = dgv.SelectedRows[0].Index;
                textBoxP[0].Text = dgv[0,i].Value.ToString();
                int cont = 0;
                for (int j = 1; j < textBoxP.Length; j++)
                {
                    if (textBoxP[j].Text == "") { cont++; }
                }
                if (comboBoxPs[0].SelectedIndex == -1 || comboBoxPs[1].SelectedIndex == -1) { cont++; }
                if (cont == 0) {btnUpdate.Enabled = true; }
                else
                {
                    btnUpdate.Enabled = false;
                }
            }
        }

        public string[] pegaID(string tabela)
        {
            string sql = $"select id from {tabela}";
            dt = dao.lerTabela(sql);
            lista = new string[dt.Rows.Count];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                lista[i] = dt.Rows[i].ItemArray[0].ToString();
            }
            return lista;
        }
        private void BancoLote_TextChanged(object sender, EventArgs e)
        {
            int cont = 0;
            for (int i = 1; i < textBoxP.Length; i++)
            {
                if (textBoxP[i].Text == "") { cont++; }
            }
            if (comboBoxPs[0].SelectedIndex == -1 || comboBoxPs[1].SelectedIndex == -1){ cont++; }
            if (cont == 0) { btnAdd.Enabled = true; btnUpdate.Enabled = true; }
            else
            {
                btnAdd.Enabled = false;
            }
            if (comboBoxPs[2].Text == "sim")
            {
                for(int i = 1; i < dateTimePickerPs.Length; i++)
                {
                    dateTimePickerPs[i].Enabled = true;
                }
            }
            else
            {
                for (int i = 1; i < dateTimePickerPs.Length; i++)
                {
                    dateTimePickerPs[i].Enabled = false;
                }
            }

            dateTimePickerPs[1].MinDate = dateTimePickerPs[0].Value;
            dateTimePickerPs[2].MaxDate = dateTimePickerPs[0].Value;
            dateTimePickerPs[3].MinDate = dateTimePickerPs[2].Value;
        }
        private void Btn_add_Click(object sender, EventArgs e)
        {
            if (comboBoxPs[2].Text == "nao")
            {
                sql = $"insert into lotes (idprodutofk, quantidade, idfornecedorfk, dataCompra, notafiscal, recebido, valor) values('{comboBoxPs[0].Text}', '{textBoxP[1].Text}', '{comboBoxPs[1].Text}', '{dateTimePickerPs[0].pegarData()}', '{textBoxP[3].Text}', '{comboBoxPs[2].Text}', '{textBoxP[2].Text}');";
            }
            else
            {
                sql = $"insert into lotes (idprodutofk, quantidade, idfornecedorfk, dataCompra, notafiscal, recebido, valor, dataRecebimento, fabricacao, validade)" +
                    $"values('{comboBoxPs[0].Text}', '{textBoxP[1].Text}', '{comboBoxPs[1].Text}', '{dateTimePickerPs[0].pegarData()}', '{textBoxP[3].Text}', '{comboBoxPs[2].Text}', '{textBoxP[2].Text}', " +
                    $"'{dateTimePickerPs[1].pegarData()}', '{dateTimePickerPs[2].pegarData()}', '{dateTimePickerPs[3].pegarData()}');";
                dao.updateInsertDelete($"UPDATE produtos set estoque = estoque + {textBoxP[1].Text} where id = '{comboBoxPs[0].Text}'");
            }
            dao.updateInsertDelete(sql);
            dgv.DataSource = dao.lerTabela(sqlTabela);
        }
        private void Btn_Update_Click(object sender, EventArgs e)
        {
            string sql = $"UPDATE lotes set idprodutofk = '{comboBoxPs[0].Text}', quantidade = '{textBoxP[1].Text}', idfornecedorfk = '{comboBoxPs[1].Text}', " +
                $"dataCompra = '{dateTimePickerPs[0].pegarData()}', notafiscal = '{textBoxP[3].Text}', recebido = '{comboBoxPs[2].Text}', valor = '{textBoxP[2].Text}', " +
                $"dataRecebimento = '{dateTimePickerPs[1].pegarData()}', fabricacao = '{dateTimePickerPs[2].pegarData()}', validade = '{dateTimePickerPs[3].pegarData()}' " +
                $"where id = '{textBoxP[0].Text}';";
            dao.updateInsertDelete(sql);
            dao.updateInsertDelete($"UPDATE produtos set estoque = estoque + {textBoxP[1].Text} where id = '{comboBoxPs[0].Text}'");
            dgv.DataSource = dao.lerTabela(sqlTabela);
        }

        public override void fechar(TelaPadrao tela)
        {
            foreach (TextBoxP tbp in textBoxP)
            {
                tela.Controls.Remove(tbp);
            }
            foreach (LabelP labelP in labelPs)
            {
                tela.Controls.Remove(labelP);
            }
            foreach (ComboBoxP comboBoxP in comboBoxPs)
            {
                tela.Controls.Remove(comboBoxP);
            }
            foreach(DateTimePickerP dateTimePickerP in dateTimePickerPs)
            {
                tela.Controls.Remove(dateTimePickerP);
            }
            tela.Controls.Remove(dgv);
            tela.Controls.Remove(btnAdd);
            tela.Controls.Remove(btnUpdate);
            tela.Controls.Remove(container);
            tela.Controls.Remove(container2);
        }
    }
}