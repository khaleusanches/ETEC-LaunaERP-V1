using CaixaDeFerramentasPerso;
using Logica;
using System;
using System.Data;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using static System.Net.Mime.MediaTypeNames;

namespace Telas
{
    public class BancoDRE : InterfacesBanco
    {
        LabelP[] labelPs = new LabelP[19];
        Panel barra, barra2;
        DataTable dt;
        DAO dao = new DAO();
        DateTime dataAtual = DateTime.Now;
        double dinheiro = 0;
        double resultado = 0;
        private TelaPadrao tela;
        double caixa, fornecedores, contasVariadas, salarios, emprestimosPagos, emprestimosFeitos;
        double faturamento, receitaLiquida, lucroBruto, despesasOperacionais, resultadoOperacional, despesasFinanceiras, resultadoFinanceiro;
        int top;
        int left;
        Chart graficoMensal = new Chart();
        ChartArea chartArea1 = new ChartArea();
        ComboBoxP cbMes;
        string[] meses = new string[] { "Janeiro", "Fevereiro", "Março", "Abril", "Maio", "Junho", "Julho", "Agosto", "Setembro", "Outubro", "Novembro", "Dezembro" };
        private ComboBoxP cbTipoDeExibicao;

        public override void exibir(TelaPadrao tela)
        {
            top = 125;
            left = 45;
            this.tela = tela;
            cbMes = new ComboBoxP(100, 25, 90, 475, new string[]{"Janeiro", "Fevereiro", "Março", "Abril", "Maio", "Junho", "Julho", "Agosto", "Setembro", "Outubro", "Novembro", "Dezembro", "1° Semestre", "2° Semestre"}, tela);
            cbMes.SelectedIndexChanged += CbMes_SelectedIndexChanged;
            cbTipoDeExibicao = new ComboBoxP(100, 25, 90, 625, new string[] { "Texto", "Gráfico" }, tela);
            cbTipoDeExibicao.SelectedIndex = 1;
            cbTipoDeExibicao.SelectedIndexChanged += CbMes_SelectedIndexChanged;
        }

        private void CbMes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbMes.Text == "1° Semestre") 
            {
                graficoMensal.Legends.Clear();
                graficoMensal.Series.Clear();
                graficoMensal.ChartAreas.Clear();
                graficoMensal.ChartAreas.Remove(chartArea1);
                fechar(tela);
                tela.Controls.Add(cbMes);
                tela.Controls.Add(cbTipoDeExibicao);
                cbTipoDeExibicao.Enabled = false;
                exibir1Semestre();
            }
            else if(cbMes.Text == "2° Semestre")
            {
                graficoMensal.Legends.Clear();
                graficoMensal.Series.Clear();
                graficoMensal.ChartAreas.Clear();
                graficoMensal.ChartAreas.Remove(chartArea1);
                fechar(tela);
                tela.Controls.Add(cbMes);
                tela.Controls.Add(cbTipoDeExibicao);
                cbTipoDeExibicao.Enabled = false;
                exibir2Semestre();
            }
            else
            {
                caixa = pegaID("total", "operacoes", $"MONTH(dataehora)='{cbMes.SelectedIndex + 1}' and year(dataehora) = '{dataAtual.Year}'");
                fornecedores = 0 - pegaID("valor", "lotes", $"MONTH(dataCompra)='{cbMes.SelectedIndex + 1}' and year(dataCompra) = '{dataAtual.Year}'");
                contasVariadas = 0 - pegaID("valorDespesa", "despesasVariadas", $"MONTH(dataPagamento)='{cbMes.SelectedIndex + 1}' and year(dataPagamento) = '{dataAtual.Year}'");
                salarios = 0 - pegaID("valorPagamentoSal", "pagamentosSalario", $"MONTH(dataPagamentoSal)='{cbMes.SelectedIndex + 1}' and year(dataPagamentoSal) = '{dataAtual.Year}'");
                emprestimosPagos = 0 - pegaID("valorPagamentoEmprestimo", "pagamentoEmprestimos", $"MONTH(dataPagamentoEmprestimo)='{cbMes.SelectedIndex + 1}' and year(dataPagamentoEmprestimo) = '{dataAtual.Year}'");
                emprestimosFeitos = pegaID("valor_emprestimo", "emprestimos", $"MONTH(data_liberacao)='{cbMes.SelectedIndex + 1}' and year(data_liberacao) = '{dataAtual.Year}'");

                faturamento = caixa;
                receitaLiquida = faturamento;
                lucroBruto = receitaLiquida + fornecedores;
                despesasOperacionais = contasVariadas + salarios;
                resultadoOperacional = lucroBruto + despesasOperacionais;
                despesasFinanceiras = emprestimosPagos;
                resultadoFinanceiro = resultadoOperacional + emprestimosPagos;
                graficoMensal.Legends.Clear();
                graficoMensal.Series.Clear();
                graficoMensal.ChartAreas.Remove(chartArea1);
                graficoMensal.ChartAreas.Clear();
                cbTipoDeExibicao.Enabled = true;
                if(cbTipoDeExibicao.SelectedIndex == 0) 
                {
                    fechar(tela);
                    tela.Controls.Add(cbMes);
                    tela.Controls.Add(cbTipoDeExibicao);
                    exibirText();
                }
                else
                {
                    fechar(tela);
                    tela.Controls.Add(cbMes);
                    tela.Controls.Add(cbTipoDeExibicao);
                    exibirMensal();
                }
            }
            
        }
        public void exibirMensal()
        {
            graficoMensal.ChartAreas.Add(chartArea1);
            graficoMensal.Top = 125;
            tela.Controls.Add(graficoMensal);
            graficoMensal.Left = 125;
            graficoMensal.Width = 950;
            graficoMensal.Height = 500;
            graficoMensal.Series.Add("Receitas");
            graficoMensal.Series["Receitas"].ChartType = SeriesChartType.Column;
            graficoMensal.Series["Receitas"].Font = new Font("Arial", 16);
            graficoMensal.Series["Receitas"].Points.AddXY("Faturamento", faturamento);
            graficoMensal.Series["Receitas"].Points.AddXY("Deduções", 0);
            graficoMensal.Series["Receitas"].Points.AddXY("Receita Liquida", receitaLiquida);
            MessageBox.Show($"Carregando DRE do mês {cbMes.Text}");
            graficoMensal.Series["Receitas"].Points.AddXY("Custo das Mercadorias Vendidas:", fornecedores);
            graficoMensal.Series["Receitas"].Points.AddXY("Lucro Bruto", lucroBruto);
            graficoMensal.Series["Receitas"].Points.AddXY("Despesas Operacionais", despesasOperacionais);
            graficoMensal.Series["Receitas"].Points.AddXY("Resultado Operacional Bruto:", resultadoOperacional);
            graficoMensal.Series["Receitas"].Points.AddXY("Despesas Financeiras:", despesasFinanceiras);
            graficoMensal.Series["Receitas"].Points.AddXY("Resultado Financeiro:", resultadoFinanceiro);
            graficoMensal.ChartAreas[0].AxisY.Interval = 500;
            if (resultadoFinanceiro > 12000 || resultadoFinanceiro < -12000 || faturamento > 12000 || despesasOperacionais < -12000 || despesasFinanceiras < -12000)
            {
                if (resultadoFinanceiro < -100000 || resultadoFinanceiro > 100000)
                {
                    graficoMensal.ChartAreas[0].AxisY.Interval = 50000;
                }
                else
                {
                    graficoMensal.ChartAreas[0].AxisY.Interval = 10000;
                }
            }
            graficoMensal.ChartAreas[0].AxisX.MajorGrid.LineWidth = 0;

            graficoMensal.ChartAreas["ChartArea1"].AxisX.Title = "Etapas";
            graficoMensal.ChartAreas["ChartArea1"].AxisX.TitleFont = new Font("Arial", 12, FontStyle.Bold);
            graficoMensal.ChartAreas["ChartArea1"].AxisY.Title = "Valores em R$";
            graficoMensal.ChartAreas["ChartArea1"].AxisY.TitleFont = new Font("Arial", 12, FontStyle.Bold);
        }

        public void exibir1Semestre()
        {
            graficoMensal.ChartAreas.Add(chartArea1);
            graficoMensal.ChartAreas[0].AxisY.Interval = 500;
            graficoMensal.Top = 125;
            tela.Controls.Add(graficoMensal);
            graficoMensal.Left = 0;
            graficoMensal.Width = 1200;
            graficoMensal.Height = 500;

            graficoMensal.Series.Add("Faturamento");
            graficoMensal.Series.Add("Deduções");
            graficoMensal.Series.Add("Receita Liquida");
            graficoMensal.Series.Add("CMV");
            graficoMensal.Series.Add("Lucro Bruto");
            graficoMensal.Series.Add("Despesas Operacionais");
            graficoMensal.Series.Add("Resultado Operacional Bruto");
            graficoMensal.Series.Add("Despesas Financeiras");
            graficoMensal.Series.Add("Resultado Financeiro");
            double maiorResultado = 0;
            double menorResultado = 0;
            double maiorFaturamento = 0;

            for (int i = 0; i < 6; i++)
            {
                caixa = pegaID("total", "operacoes", $"MONTH(dataehora)='{i + 1}' and year(dataehora) = '{dataAtual.Year}'");
                fornecedores = 0 - pegaID("valor", "lotes", $"MONTH(dataCompra)='{i + 1}' and year(dataCompra) = '2024'");
                contasVariadas = 0 - pegaID("valorDespesa", "despesasVariadas", $"MONTH(dataPagamento)='{i + 1}' and year(dataPagamento) = '{dataAtual.Year}'");
                salarios = 0 - pegaID("valorPagamentoSal", "pagamentosSalario", $"MONTH(dataPagamentoSal)='{i + 1}' and year(dataPagamentoSal) = '{dataAtual.Year}'");
                emprestimosPagos = 0 - pegaID("valorPagamentoEmprestimo", "pagamentoEmprestimos", $"MONTH(dataPagamentoEmprestimo)='{i + 1}' and year(dataPagamentoEmprestimo) = '{dataAtual.Year}'");
                emprestimosFeitos = pegaID("valor_emprestimo", "emprestimos", $"MONTH(data_liberacao)='{i + 1}' and year(data_liberacao) = '{dataAtual.Year}'");
                faturamento = caixa;
                receitaLiquida = faturamento;
                lucroBruto = receitaLiquida + fornecedores;
                despesasOperacionais = contasVariadas + salarios;
                resultadoOperacional = lucroBruto + despesasOperacionais;
                despesasFinanceiras = emprestimosPagos;
                resultadoFinanceiro = resultadoOperacional + emprestimosPagos;
                if (maiorFaturamento < faturamento)
                {
                    maiorFaturamento = faturamento;
                }
                if (maiorResultado < resultadoFinanceiro)
                {
                    maiorResultado = resultadoFinanceiro;
                }
                else if (menorResultado > resultadoFinanceiro)
                {
                    menorResultado = resultadoFinanceiro;
                }
                graficoMensal.Series["Faturamento"].Points.AddXY(meses[i], faturamento);
                graficoMensal.Series["Deduções"].Points.AddXY(meses[i], 0);
                graficoMensal.Series["Receita Liquida"].Points.AddXY(meses[i], receitaLiquida);
                if (i == 5)
                {
                    MessageBox.Show("Carregando DRE 1° Semestre");
                }
                graficoMensal.Series["CMV"].Points.AddXY(meses[i], fornecedores);
                graficoMensal.Series["Lucro Bruto"].Points.AddXY(meses[i], lucroBruto);
                graficoMensal.Series["Despesas Operacionais"].Points.AddXY(meses[i], despesasOperacionais);
                graficoMensal.Series["Resultado Operacional Bruto"].Points.AddXY(meses[i], resultadoOperacional);
                graficoMensal.Series["Despesas Financeiras"].Points.AddXY(meses[i], despesasFinanceiras);
                graficoMensal.Series["Resultado Financeiro"].Points.AddXY(meses[i], resultadoFinanceiro);
            }
            if (maiorResultado > 11000 || menorResultado < -11000 || maiorFaturamento > 11000)
            {
                if (menorResultado < -50000 || maiorResultado > 50000 || maiorFaturamento > 50000)
                {
                    if (menorResultado < -500000 || maiorResultado > 500000 || maiorFaturamento > 500000)
                    {
                        graficoMensal.ChartAreas[0].AxisY.Interval = 50000;
                    }
                    graficoMensal.ChartAreas[0].AxisY.Interval = 10000;
                }
                else
                {
                    graficoMensal.ChartAreas[0].AxisY.Interval = 2000;
                }
            }
            else
            {
                graficoMensal.ChartAreas[0].AxisY.Interval = 500;
            }
            Legend legend = new Legend();
            graficoMensal.Legends.Add(legend);
            graficoMensal.Legends[0].Title = "Legenda";
            graficoMensal.ChartAreas["ChartArea1"].AxisX.Title = "Meses";
            graficoMensal.ChartAreas["ChartArea1"].AxisX.TitleFont = new Font("Arial", 12, FontStyle.Bold);

        }

        private void exibir2Semestre()
        {
            graficoMensal.ChartAreas.Add(chartArea1);
            graficoMensal.ChartAreas[0].AxisY.Interval = 500;
            graficoMensal.Top = 125;
            tela.Controls.Add(graficoMensal);
            graficoMensal.Left = 0;
            graficoMensal.Width = 1200;
            graficoMensal.Height = 500;

            graficoMensal.Series.Add("Faturamento");
            graficoMensal.Series.Add("Deduções");
            graficoMensal.Series.Add("Receita Liquida");
            graficoMensal.Series.Add("CMV");
            graficoMensal.Series.Add("Lucro Bruto");
            graficoMensal.Series.Add("Despesas Operacionais");
            graficoMensal.Series.Add("Resultado Operacional Bruto");
            graficoMensal.Series.Add("Despesas Financeiras");
            graficoMensal.Series.Add("Resultado Financeiro");
            double maiorResultado = 0;
            double menorResultado = 0;
            double maiorFaturamento = 0;
            for (int i = 6; i < 12; i++)
            {
                caixa = pegaID("total", "operacoes", $"MONTH(dataehora)='{i + 1}' and year(dataehora) = '{dataAtual.Year}'");
                fornecedores = 0 - pegaID("valor", "lotes", $"MONTH(dataCompra)='{i + 1}' and year(dataCompra) = '{dataAtual.Year}'");
                contasVariadas = 0 - pegaID("valorDespesa", "despesasVariadas", $"MONTH(dataPagamento)='{i + 1}' and year(dataPagamento) = '{dataAtual.Year}'");
                salarios = 0 - pegaID("valorPagamentoSal", "pagamentosSalario", $"MONTH(dataPagamentoSal)='{i + 1}' and year(dataPagamentoSal) = '{dataAtual.Year}'");
                emprestimosPagos = 0 - pegaID("valorPagamentoEmprestimo", "pagamentoEmprestimos", $"MONTH(dataPagamentoEmprestimo)='{i + 1}' and year(dataPagamentoEmprestimo) = '{dataAtual.Year}'");
                emprestimosFeitos = pegaID("valor_emprestimo", "emprestimos", $"MONTH(data_liberacao)='{i + 1}' and year(data_liberacao) = '{dataAtual.Year}'");
                faturamento = caixa;
                receitaLiquida = faturamento;
                lucroBruto = receitaLiquida + fornecedores;
                despesasOperacionais = contasVariadas + salarios;
                resultadoOperacional = lucroBruto + despesasOperacionais;
                despesasFinanceiras = emprestimosPagos;
                resultadoFinanceiro = resultadoOperacional + emprestimosPagos;
                if (maiorFaturamento < faturamento)
                {
                    maiorFaturamento = faturamento;
                }
                if (maiorResultado < resultadoFinanceiro)
                {
                    maiorResultado = resultadoFinanceiro;
                }
                else if (menorResultado > resultadoFinanceiro)
                {
                    menorResultado = resultadoFinanceiro;
                }
                if(i == 11)
                {
                    MessageBox.Show("Carregando DRE 2° Semestre");
                }
                graficoMensal.Series["Faturamento"].Points.AddXY(meses[i], faturamento);
                graficoMensal.Series["Deduções"].Points.AddXY(meses[i], 0);
                graficoMensal.Series["Receita Liquida"].Points.AddXY(meses[i], receitaLiquida);
                graficoMensal.Series["CMV"].Points.AddXY(meses[i], fornecedores);
                graficoMensal.Series["Lucro Bruto"].Points.AddXY(meses[i], lucroBruto);
                graficoMensal.Series["Despesas Operacionais"].Points.AddXY(meses[i], despesasOperacionais);
                graficoMensal.Series["Resultado Operacional Bruto"].Points.AddXY(meses[i], resultadoOperacional);
                graficoMensal.Series["Despesas Financeiras"].Points.AddXY(meses[i], despesasFinanceiras);
                graficoMensal.Series["Resultado Financeiro"].Points.AddXY(meses[i], resultadoFinanceiro);
            }
            if (maiorResultado > 11000 || menorResultado < -10000 || maiorFaturamento > 11000)
            {
                if (menorResultado < -50000 || maiorResultado > 50000 || maiorFaturamento > 50000)
                {
                    if (menorResultado < -500000 || maiorResultado > 500000 || maiorFaturamento > 500000)
                    {
                        graficoMensal.ChartAreas[0].AxisY.Interval = 50000;
                    }
                    graficoMensal.ChartAreas[0].AxisY.Interval = 10000;
                }
                else
                {
                    graficoMensal.ChartAreas[0].AxisY.Interval = 2000;
                }
            }
            else
            {
                graficoMensal.ChartAreas[0].AxisY.Interval = 500;
            }
            Legend legend = new Legend();
            graficoMensal.Legends.Add(legend);
            graficoMensal.Legends[0].Title = "Legenda";
            graficoMensal.ChartAreas["ChartArea1"].AxisX.Title = "Meses";
            graficoMensal.ChartAreas["ChartArea1"].AxisX.TitleFont = new Font("Arial", 12, FontStyle.Bold);
        }
        public void exibirText()
        {
            labelPs[0] = new LabelP(185, 20, top, left + 25, "Venda de Produtos | Caixa:", tela);
            labelPs[1] = new LabelP(110, 20, top, left + 225, $"R$: {caixa}", tela);
            top += 30;
            
            labelPs[2] = new LabelP(300, 20, top, left, $"Faturamento : {faturamento}", tela);
            labelPs[2].Font = new System.Drawing.Font("Arial", 12);
            top += 30;
            labelPs[3] = new LabelP(185, 20, top, left + 25, "Deduções da Receita Bruta: ", tela);
            labelPs[4] = new LabelP(110, 20, top, left + 225, $"R$: - 0", tela);

            top += 60;
            labelPs[5] = new LabelP(300, 20, top, left, $"Receita Liquida : R$ {receitaLiquida}", tela);
            labelPs[5].Font = new System.Drawing.Font("Arial", 12);
            top += 30;

            labelPs[6] = new LabelP(185, 20, top, left + 25, "Custo das Mercadorias Vendidas:", tela);
            labelPs[7] = new LabelP(110, 20, top, left + 225, $"R$: {fornecedores}", tela);
            

            top += 60;
            labelPs[8] = new LabelP(300, 20, top, left, $"Lucro Bruto     :    R$ {lucroBruto}", tela);
            labelPs[8].Font = new System.Drawing.Font("Arial", 12);
            top += 30;

            labelPs[9] = new LabelP(185, 20, top, left + 25, "Despesas Operacionais:", tela);
            labelPs[10] = new LabelP(110, 20, top, left + 225, $"R$: {despesasOperacionais}", tela);
            top += 30;

            labelPs[11] = new LabelP(185, 20, top, left + 50, "Salários:", tela);
            labelPs[12] = new LabelP(110, 20, top, left + 250, $"R$: {salarios}", tela);
            top += 30;

            labelPs[13] = new LabelP(185, 20, top, left + 50, "Contas Váriadas:", tela);
            labelPs[14] = new LabelP(110, 20, top, left + 250, $"R$: {contasVariadas}", tela);
           
            top += 60;
            labelPs[15] = new LabelP(300, 20, top, left, $"Resultado Operacional Bruto: R$ {resultadoOperacional}", tela);
            labelPs[15].Font = new System.Drawing.Font("Arial", 12);
            top += 30;
            labelPs[16] = new LabelP(185, 20, top, left + 50, "Pagamento de Empréstimos", tela);
            labelPs[17] = new LabelP(110, 20, top, left + 250, $"R$: {emprestimosPagos}", tela);
            
            top += 60;
            labelPs[18] = new LabelP(300, 20, top, left, $"Resultado Financeiro: R$ {resultadoFinanceiro}", tela);
            labelPs[18].Font = new System.Drawing.Font("Arial", 12);

            barra = new Panel();
            barra.Top = 100;
            barra.Left = 35;
            barra.Width = 430;
            barra.Height = 500;
            barra.BackColor = Color.White;
            tela.Controls.Add(barra);

            barra2 = new Panel();
            barra2.Top = 85;
            barra2.Left = 25;
            barra2.Width = 450;
            barra2.Height = 520;
            barra2.BackColor = Color.Black;
            tela.Controls.Add(barra2);
            top = 125;
            left = 45;
        }
        public double pegaID(string dado, string tabela, string where)
        {
            string sql = $"select {dado} from {tabela} where {where}";
            dt = dao.lerTabela(sql);
            dinheiro = 0;
            if (dt.Rows.Count > 0)
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
            graficoMensal.Series.Clear();
            graficoMensal.ChartAreas.Clear();
            graficoMensal.ChartAreas.Remove(chartArea1);
            graficoMensal.Legends.Clear();
            tela.Controls.Remove(graficoMensal);
            tela.Controls.Remove(cbMes);
            tela.Controls.Remove(cbTipoDeExibicao);
        }
    }
}