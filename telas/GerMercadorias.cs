
﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BancoDados;
using TL_Principal;
using TL_Gerente;
using TL_Estoque;

namespace GerMercadorias
{
    public class GerMercadorias 
    {
        DataTable dt = new DataTable();
        Banco banco = new Banco();
        DataTable DT_consultaID = new DataTable();




        
        public DataTable ExbEstoque() 
        {
            dt = banco.consultar(
            "select	id as 'ID', nome as 'Produto', valor as 'Valor unitário (R$)' estoque as 'Quantidade em estoque', descricao as 'Descrição',  disponivel as 'A venda' from produtos");
            return dt;
        }

      
        public DataTable ExbDisponiveis() 
        {
            dt = banco.consultar(
            "select	id as 'ID', nome as 'Produto', valor as 'Valor unitário (R$)' estoque as 'Quantidade em estoque', descricao as 'Descrição' from produtos where disponivel = 'n'");
            return dt;
        }   
      
        public DataTable ExbIndisponiveis() 
        {
            dt = banco.consultar(
            "select	id as 'ID', nome as 'Produto', valor as 'Valor unitário (R$)' estoque as 'Quantidade em estoque', descricao as 'Descrição' from produtos where disponivel = 's'");
            return dt;
        }

      
        public void CadProduto(string nome, string valor, string estoque, string descricao, string disponivel)
        {
          banco.comandar(
            "insert into produtos(nome, valor, estoque, descricao, disponivel);
            fechar();
        }

            
        public void DelProduto(int i)
        
        {
            banco.comandar("Delete * from produtos where id = '" + i + "'");
            fechar();
        }
        
        public void AtuProduto(int i, string nome, string valor, string estoque, string descricao, string disponivel)
        {
            banco.comandar("update produtos set nome = '" + nome + "', valor = '" + valor + "', estoque = '" + estoque + "', descricao = '" + descricao + "', disponivel = '" + disponivel + "' where id = '" + i + "'");
            fechar();
        }



                           
        public void fechar()
        {
            dt.Clear();
        }
    }
}
