
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



        //---------------------------------------------------------
        public DataTable ExbEstoque() 
        {
            dt = banco.consultar(
            "select"
                +" id as 'ID',"
                +" nome as 'Produto',"
                +" valor as 'Valor unitário (R$)',"
                +" estoque as 'Quantidade em estoque',"
                +" descricao as 'Descrição',"
                +" disponivel as 'A venda'"
             +" from produtos");
            return dt;
        }

        public DataTable ExbCatalogo() 
        {
            dt = banco.consultar(
            "select"
                +" id as 'ID',"
                +" nome as 'Produto',"
                +" valor as 'Valor unitário (R$)',"
                +" estoque as 'Quantidade em estoque',"
                +" descricao as 'Descrição'"
                +" from produtos where disponivel = 's'"
            );
            return dt;
        }   
      
        public DataTable ExbIndisponiveis() 
        {
            dt = banco.consultar(
            "select"
                +" id as 'ID',"
                +" nome as 'Produto',"
                +" valor as 'Valor unitário (R$)'"
                +" estoque as 'Quantidade em estoque',"
                +" descricao as 'Descrição'"
                +" from produtos where disponivel = 'n'"
            );
            return dt;
        }

        public DataTable ExbLotes(int i) 
        {
            dt = banco.consultar(
            "select"
                +" produtos.id as 'ID Produto',"
                +" nome as 'Produto',"
                +" lotes.id as 'ID Lote',"                
                +" aquisicao as 'Data de aquisição'
                +" fabricacao as 'Data de fabricação',"
                +" validade as 'Data de validade'"
                +" notafiscal as 'Nota Fiscal'"
            +" from produtos on produtos.id = '"+i+"'"
            +" inner join lotes on lotes.idprodutofk = '"+i+"'"
            +" order by produtos.id"
            );
            return dt;
        }  

        public DataTable ExbLotesProduto(int i) 
        {
            dt = banco.consultar(
            "select"
                +" nome as 'Produto',"
                +" produtos.id as 'ID Produto',"
                +" lotes.id as 'ID Lote',"                
                +" aquisicao as 'Data de aquisição'
                +" fabricacao as 'Data de fabricação',"
                +" validade as 'Data de validade'"
                +" notafiscal as 'Nota Fiscal'"
            +" from produtos on produtos.id = '"+i+"'"
            +" inner join lotes on lotes.idprodutofk = '"+i+"'"
            +" order by produtos.nome"
            );
            return dt;
        }   

        public DataTable ExbLotesAquisicao(int i) 
        {
            dt = banco.consultar(
            "select"
                +" produtos.id as 'ID Produto',"
                +" nome as 'Produto',"
                +" lotes.id as 'ID Lote',"               
                +" aquisicao as 'Data de aquisição',"
                +" fabricacao as 'Data de fabricação'," 
                +" validade as 'Data de validade',"
                +" notafiscal as 'Nota Fiscal'"
            +" from produtos on produtos.id = '"+i+"'"
            +" inner join lotes on lotes.idprodutofk = '"+i+"'"
            +" order by lotes.aquisicao"
            );
            return dt;
        }   

        public DataTable ExbLotesFabricacao(int i) 
        {
            dt = banco.consultar(
            "select"
                +" produtos.id as 'ID Produto',"
                +" nome as 'Produto',"
                +" lotes.id as 'ID Lote'," 
                +" fabricacao as 'Data de fabricação',"               
                +" aquisicao as 'Data de aquisição',"
                +" validade as 'Data de validade',"
                +" notafiscal as 'Nota Fiscal'"
            +" from produtos on produtos.id = '"+i+"'"
            +" inner join lotes on lotes.idprodutofk = '"+i+"'"
            +" order by lotes.fabricacao"
            );
            return dt;
        }     

        public DataTable ExbLotesValidade(int i) 
        {
            dt = banco.consultar(
            "select"
                +" produtos.id as 'ID Produto',"
                +" nome as 'Produto',"
                +" lotes.id as 'ID Lote'," 
                +" validade as 'Data de validade',"
                +" fabricacao as 'Data de fabricação',"               
                +" aquisicao as 'Data de aquisição',"
                +" notafiscal as 'Nota Fiscal'"
            +" from produtos on produtos.id = '"+i+"'"
            +" inner join lotes on lotes.idprodutofk = '"+i+"'"
            +" order by lotes.validade"
            );
            return dt;
        }     
        //------------------------------------------------------------------

       
 
        public void fechar()
        {
            dt.Clear();
        }
    }
}
