using CaixaDeFerramentasPerso;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telas
{
    internal class BancoEmprestimos : InterfacesBanco
    {
        LabelP[] labelPsEmprestimo = new LabelP[7];
        TextBoxP[] textBoxPsEmprestimo = new TextBoxP[7];
        
        public override void exibir(TelaPadrao tela)
        {
            int topEmprestimo = 165;
            int leftEmprestimo = 25;
            int incrementoTopEmprestimo = 30;

            labelPsEmprestimo[0] = new LabelP(200, 20, topEmprestimo, leftEmprestimo, "ID do Empréstimo:", tela);
            textBoxPsEmprestimo[0] = new TextBoxP(150, 20, topEmprestimo, leftEmprestimo + 160, "vazio", 10, tela);
            topEmprestimo += incrementoTopEmprestimo;

            labelPsEmprestimo[1] = new LabelP(200, 20, topEmprestimo, leftEmprestimo, "Conta Bancária:", tela);
            textBoxPsEmprestimo[1] = new TextBoxP(300, 20, topEmprestimo, leftEmprestimo + 160, "vazio", 50, tela);
            topEmprestimo += incrementoTopEmprestimo;

            labelPsEmprestimo[2] = new LabelP(200, 20, topEmprestimo, leftEmprestimo, "Valor do Empréstimo:", tela);
            textBoxPsEmprestimo[2] = new TextBoxP(150, 20, topEmprestimo, leftEmprestimo + 160, "vazio", 20, tela);
            topEmprestimo += incrementoTopEmprestimo;

            labelPsEmprestimo[3] = new LabelP(200, 20, topEmprestimo, leftEmprestimo, "Data de Liberação:", tela);
            textBoxPsEmprestimo[3] = new TextBoxP(150, 20, topEmprestimo, leftEmprestimo + 160, "vazio", 10, tela);
            topEmprestimo += incrementoTopEmprestimo;

            labelPsEmprestimo[4] = new LabelP(200, 20, topEmprestimo, leftEmprestimo, "Taxa de Juros (%):", tela);
            textBoxPsEmprestimo[4] = new TextBoxP(150, 20, topEmprestimo, leftEmprestimo + 160, "vazio", 5, tela);
            topEmprestimo += incrementoTopEmprestimo;

            labelPsEmprestimo[5] = new LabelP(200, 20, topEmprestimo, leftEmprestimo, "Prazo (meses):", tela);
            textBoxPsEmprestimo[5] = new TextBoxP(150, 20, topEmprestimo, leftEmprestimo + 160, "vazio", 3, tela);
            topEmprestimo += incrementoTopEmprestimo;
        }

        public override void fechar(TelaPadrao tela)
        {
            throw new NotImplementedException();
        }
    }
}
