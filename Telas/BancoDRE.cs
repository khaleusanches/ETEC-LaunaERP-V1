using CaixaDeFerramentasPerso;
using Logica;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Telas
{
    public class BancoDRE : InterfacesBanco
    {
        LabelP[] labelPs = new LabelP[17];
        Panel barra, barra2;
        DataTable dt;
        DAO dao = new DAO();
        DateTime dataAtual = DateTime.Now;
        double dinheiro = 0;
        double resultado = 0;

        double caixa, fornecedores, contasVariadas, salarios, emprestimos;
        public override void exibir(TelaPadrao tela)
        {
            int top = 165;
            int left = 45;
            caixa = pegaID("total", "operacoes", $"MONTH(dataehora)='{dataAtual.Month}'");
            fornecedores = 0 - pegaID("valor", "lotes", $"MONTH(dataCompra)='{dataAtual.Month}'");
            contasVariadas = 0 - pegaID("valorDespesa", "despesasVariadas", $"MONTH(dataPagamento)='{dataAtual.Month}'");
            salarios = 0 - pegaID("valorPagamentoSal", "pagamentosSalario", $"MONTH(dataPagamentoSal)='{dataAtual.Month}'");
            emprestimos = 0 - pegaID("valorPagamentoEmprestimo", "pagamentoEmprestimos", $"MONTH(dataPagamentoEmprestimo)='{dataAtual.Month}'");

           

            resultado += caixa;
            labelPs[0] = new LabelP(300, 20, top, left, $"Faturamento : {resultado}", tela);
            labelPs[0].Font = new System.Drawing.Font("Arial", 12);
            top += 30;

            labelPs[1] = new LabelP(185, 20, top, left + 25, "Venda de Produtos | Caixa:", tela);
            labelPs[2] = new LabelP(110, 20, top, left + 225, $"R$: {caixa}", tela);

            top += 60;
            resultado += fornecedores;
            labelPs[3] = new LabelP(300, 20, top, left, $"Receita Liquida : R$ {resultado}", tela);
            labelPs[3].Font = new System.Drawing.Font("Arial", 12);
            top += 30;

            labelPs[4] = new LabelP(185, 20, top, left + 25, "Custos com Fornecedores:", tela);
            labelPs[5] = new LabelP(110, 20, top, left + 225, $"R$: {fornecedores}", tela);

            top += 60;
            resultado += contasVariadas + salarios + emprestimos;
            labelPs[6] = new LabelP(300, 20, top, left, $"Lucro Bruto     :    R$ {resultado}", tela);
            labelPs[6].Font = new System.Drawing.Font("Arial", 12);
            top += 30;

            labelPs[7] = new LabelP(185, 20, top, left + 25, "Despesas Operacionais:", tela);
            labelPs[8] = new LabelP(110, 20, top, left + 225, $"R$: {contasVariadas + salarios}", tela);
            top += 30;

            labelPs[9] = new LabelP(185, 20, top, left + 50, "Salários:", tela);
            labelPs[10] = new LabelP(110, 20, top, left + 250, $"R$: {salarios}", tela);
            top += 30;

            labelPs[11] = new LabelP(185, 20, top, left + 50, "Contas Váriadas:", tela);
            labelPs[12] = new LabelP(110, 20, top, left + 250, $"R$: {contasVariadas}", tela);
            top += 30;

            labelPs[13] = new LabelP(185, 20, top, left + 25, "Despesas Financeiras:", tela);
            labelPs[14] = new LabelP(110, 20, top, left + 225, $"R$: {emprestimos}", tela);
            top += 30;

            labelPs[15] = new LabelP(185, 20, top, left + 50, "Empréstimos", tela);
            labelPs[16] = new LabelP(110, 20, top, left + 250, $"R$: {emprestimos}", tela);

            barra = new Panel();
            barra.Top = 135;
            barra.Left = 35;
            barra.Width = 430;
            barra.Height = 500;
            barra.BackColor = Color.White;
            tela.Controls.Add(barra);

            barra2 = new Panel();
            barra2.Top = 125;
            barra2.Left = 25;
            barra2.Width = 450;
            barra2.Height = 520;
            barra2.BackColor = Color.Black;
            tela.Controls.Add(barra2);

        }
        public double pegaID(string dado, string tabela, string where)
        {
            string sql = $"select {dado} from {tabela} where {where}";
            dt = dao.lerTabela(sql);
            dinheiro = 0;
            if (dt.Rows.Count >= 1)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dinheiro += double.Parse(dt.Rows[i].ItemArray[0].ToString());
                }
            }
            return dinheiro;
        }
        public override void fechar(TelaPadrao tela)
        {
            foreach (LabelP labelP in labelPs)
            {
                tela.Controls.Remove(labelP);
            }
            tela.Controls.Remove(barra);
            tela.Controls.Remove(barra2);
        }
    }
}