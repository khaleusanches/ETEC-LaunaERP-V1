 using CaixaDeFerramentasPerso;
using Logica;
using System.Drawing;

namespace Telas
{
    internal class BancoOperacoes : InterfacesBanco
    {
        private DataGridViewP dgvOperacoes, dgvVendas;
        private PanelP container;
        private DAO dao = new DAO();
        private LabelP title;

        public override void exibir(TelaPadrao tela)
        {
            title = new LabelP(200, 25, 85, 500, "OPERAÇÕES DE CAIXA", tela);
            title.BackColor = System.Drawing.Color.Transparent;
            title.Font = new System.Drawing.Font("Arial", 12);
            dgvOperacoes = new DataGridViewP(500, 450, 125, 350, dao.lerTabela("select funcionarios.id as 'ID Funcionario', funcionarios.nome as 'Nome Funcionario', operacoes.id as 'ID Operação', operacoes.total as 'Valor Total', operacoes.dataehora as 'Data da operação' from operacoes\r\ninner join funcionarios on operacoes.idfuncionariofk = funcionarios.id;"), tela);
            container = new PanelP(520, 480, 125, 340, Color.FromArgb(99, 133, 199), tela);
        }

        public override void fechar(TelaPadrao tela)
        {
            tela.Controls.Remove(title);
            tela.Controls.Remove(dgvOperacoes);
            tela.Controls.Remove(container);
        }
    }
}