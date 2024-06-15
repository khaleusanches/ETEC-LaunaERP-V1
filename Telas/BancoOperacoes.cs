using CaixaDeFerramentasPerso;
using Logica;

namespace Telas
{
    internal class BancoOperacoes : InterfacesBanco
    {
        private DataGridViewP dgv;
        private DAO dao = new DAO();
        private LabelP title;

        public override void exibir(TelaPadrao tela)
        {
            title = new LabelP(100, 25, 125, 25, "OPERAÇÕES", tela);
            dgv = new DataGridViewP(680, 500, 175, 160, dao.lerTabela("select funcionarios.id, funcionarios.nome, operacoes.id, operacoes.total, operacoes.dataehora from operacoes\r\ninner join funcionarios on operacoes.idfuncionariofk = funcionarios.id;"), tela);
        }

        public override void fechar(TelaPadrao tela)
        {
            tela.Controls.Remove(title);
            tela.Controls.Remove(dgv);
        }
    }
}