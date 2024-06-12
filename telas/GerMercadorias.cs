
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
    //Métodos diferentes de exibir os produtos e os lotes no estoque
    {
        DataTable dt = new DataTable();
        Banco banco = new Banco();
        DataTable DT_consultaID = new DataTable();



        //---------------------------------------------------------
        public DataTable ExbEstoqueID() 
        //Lista todos os produtos cadastrados organizando pelo ID do produto
        {
            dt = banco.consultar(
            "select"
                +" id as 'ID',"
                +" nome as 'Produto',"
                +" valor as 'Valor unitário (R$)',"
                +" estoque as 'Quantidade em estoque',"
                +" descricao as 'Descrição',"
                +" disponivel as 'A venda'"
            +" from produtos"
            +" order by id"
            );
            return dt;
        }

        public DataTable ExbEstoqueNome() 
        //Lista todos os produtos cadastrados organizando pelo nome do produto
        {
            dt = banco.consultar(
            "select"
                +" nome as 'Produto',"
                +" id as 'ID',"
                +" valor as 'Valor unitário (R$)',"
                +" estoque as 'Quantidade em estoque',"
                +" descricao as 'Descrição',"
                +" disponivel as 'A venda'"
            +" from produtos"
            +" order by nome"
            );
            return dt;
        }
        
        public DataTable ExbCatalogoID() 
        //Lista produtos disponíveis para compra organizando pelo id do produto
        {
            dt = banco.consultar(
            "select"
                +" id as 'ID',"
                +" nome as 'Produto',"
                +" valor as 'Valor unitário (R$)',"
                +" estoque as 'Quantidade em estoque',"
                +" descricao as 'Descrição'"
            +" from produtos"
            +" where disponivel = 's'"
            +" order by id"
            );
            return dt;
        }
        
        public DataTable ExbCatalogoNome() 
        //Lista produtos disponíveis para compra organizando pelo nome do produto
        {
            dt = banco.consultar(
            "select"
                +" nome as 'Produto',"
                +" id as 'ID',"
                +" valor as 'Valor unitário (R$)',"
                +" estoque as 'Quantidade em estoque',"
                +" descricao as 'Descrição'"
            +" from produtos"
            +" where disponivel = 's'"
            +" order by nome"
            );
            return dt;
        }   
        
        public DataTable ExbIndisponiveisID() 
        //Lista produtos QUE NÃO ESTÃO disponíveis para compra organizando pelo ID do produto
        {
            dt = banco.consultar(
            "select"
                +" id as 'ID',"
                +" nome as 'Produto',"
                +" valor as 'Valor unitário (R$)'"
                +" estoque as 'Quantidade em estoque',"
                +" descricao as 'Descrição'"
                +" from produtos"
            +" where disponivel = 'n'"
            +" order by id"
            );
            return dt;
        }
        
        public DataTable ExbIndisponiveisNome()  
        //Lista produtos QUE NÃO ESTÃO disponíveis para compra organizando pelo nome do produto
        {
            dt = banco.consultar(
            "select"
                +" nome as 'Produto',"
                +" id as 'ID',"
                +" valor as 'Valor unitário (R$)'"
                +" estoque as 'Quantidade em estoque',"
                +" descricao as 'Descrição'"
                +" from produtos"
            +" where disponivel = 'n'"
            +" order by nome"
            );
            return dt;
        }
//------------------------------------------------------------
        public DataTable ExbLotes() 
        //Lista todos os lotes cadastrados organizando pelo nome do produto no lote
        {
            dt = banco.consultar(
            "select"
                +" nome as 'Produto',"           
                +" lotes.id as 'ID Lote',"
                +" aquisicao as 'Data de aquisição'
                +" fabricacao as 'Data de fabricação',"
                +" validade as 'Data de validade',"
                +" notafiscal as 'Nota Fiscal',"
                +" disponivel as 'Produto a venda'"
            +" from lotes'"
            +" inner join produtos"
            +" on idprodutofk = produtos.id"
            +" order by nome"
            );
            return dt;
        }  
        
        public DataTable ExbLotesAntigos() 
        //Lista todos os lotes cadastrados organizando pela data de aquisição (antigo para recente)
        {
            dt = banco.consultar(
            "select"
                +" aquisicao as 'Data de aquisição'
                +" nome as 'Produto',"
                +" fabricacao as 'Data de fabricação',"
                +" validade as 'Data de validade',"
                +" notafiscal as 'Nota Fiscal',"
                +" disponivel as 'Produto a venda'"
            +" from lotes'"
            +" inner join produtos on"
            +" idprodutofk = produtos.id"
            +" order by aquisicao"
            );
            return dt;
        }  

        
        public DataTable ExbLotesRecentes() 
        //Lista todos os lotes cadastrados organizando pela data de aquisição (recentes para antigos)
        {
            dt = banco.consultar(
            "select"
                +" aquisicao as 'Data de aquisição'
                +" nome as 'Produto',"           
                +" lotes.id as 'ID Lote',"
                +" fabricacao as 'Data de fabricação',"
                +" validade as 'Data de validade',"
                +" notafiscal as 'Nota Fiscal',"
                +" disponivel as 'Produto a venda'"
            +" from lotes'"
            +" inner join produtos"
            +" on idprodutofk = produtos.id"
            +" order by aquisicao desc"
            );
            return dt;
        }
        
        public DataTable ExbLotesFabrAntigos() 
        //Lista todos os lotes cadastrados organizando pela data de fabricacao (antigo para recente)
        {
            dt = banco.consultar(
            "select"
                +" fabricacao as 'Data de fabricação',"
                +" nome as 'Produto',"           
                +" aquisicao as 'Data de aquisição'
                +" validade as 'Data de validade',"
                +" notafiscal as 'Nota Fiscal',"
                +" disponivel as 'Produto a venda'"
            +" from lotes'"
            +" inner join produtos on"
            +" idprodutofk = produtos.id"
            +" order by fabricacao"
            );
            return dt;
        }  

    
        public DataTable ExbLotesFabrRecentes() 
        //Lista todos os lotes cadastrados organizando pela data de aquisição (recente para antigo)
        {
            dt = banco.consultar(
            "select"
                +" fabricacao as 'Data de fabricação',"
                +" nome as 'Produto',"           
                +" lotes.id as 'ID Lote',"
                +" aquisicao as 'Data de aquisição'
                +" validade as 'Data de validade',"
                +" notafiscal as 'Nota Fiscal',"
                +" disponivel as 'Produto a venda'"
            +" from lotes'"
            +" inner join produtos"
            +" on idprodutofk = produtos.id"
            +" order by fabricacao desc"
            );
            return dt;
        }
        
        public DataTable ExbLotesAntigos() 
        //Lista todos os lotes cadastrados organizando pela data de validade (antigo para recente)
        {
            dt = banco.consultar(
            "select"
                +" validade as 'Data de validade',"
                +" nome as 'Produto',"           
                +" aquisicao as 'Data de aquisição'
                +" fabricacao as 'Data de fabricação',"
                +" notafiscal as 'Nota Fiscal',"
                +" disponivel as 'Produto a venda'"
            +" from lotes'"
            +" inner join produtos on"
            +" idprodutofk = produtos.id"
            +" order by validade"
            );
            return dt;
        }  

        
        public DataTable ExbLotesRecentes() 
        //Lista todos os lotes cadastrados organizando pela data de validade (distante para próximo)
        {
            dt = banco.consultar(
            "select"
                +" nome as 'Produto',"           
                +" lotes.id as 'ID Lote',"
                +" validade as 'Data de validade',"
                +" aquisicao as 'Data de aquisição'
                +" fabricacao as 'Data de fabricação',"
                +" notafiscal as 'Nota Fiscal',"
                +" disponivel as 'Produto a venda'"
            +" from lotes'"
            +" inner join produtos"
            +" on idprodutofk = produtos.id"
            +" order by validade desc"
            );
            return dt;
        }

        //------------------------------------------------------------------
        public DataTable ExbSelecionado(int i) 
        //Lista os lotes do produto selecionado
        {
            dt = banco.consultar(
            "select"        
                +" lotes.id as 'ID Lote',"
                +" aquisicao as 'Data de aquisição'
                +" fabricacao as 'Data de fabricação',"
                +" validade as 'Data de validade',"
                +" notafiscal as 'Nota Fiscal',"
                +" disponivel as 'Produto a venda'"
            +" from lotes'"
            +" inner join produtos"
            +" on idprodutofk = '"+i+"'"
            +" and idprodutofk = produtos.id"
            +" order by nome"
            );
            return dt;
        }  
        
        public DataTable ExbSelecionadoAntigos(int i) 
        //Lista os lotes do produto selecionado organizando pela data de aquisição (antigo para recente)
        {
            dt = banco.consultar(
            "select"
                +" aquisicao as 'Data de aquisição'
                +" fabricacao as 'Data de fabricação',"
                +" validade as 'Data de validade',"
                +" notafiscal as 'Nota Fiscal',"
                +" disponivel as 'Produto a venda'"
            +" from lotes'"
            +" inner join produtos"
            +" on idprodutofk = '"+i+"'"
            +" and idprodutofk = produtos.id"
            +" order by aquisicao"
            );
            return dt;
        }  

        
        public DataTable ExbSelecionadoRecentes(int i) 
        //Lista os lotes do produto selecionado organizando pela data de aquisição (recentes para antigos)
        {
            dt = banco.consultar(
            "select"
                +" aquisicao as 'Data de aquisição'
                +" lotes.id as 'ID Lote',"
                +" fabricacao as 'Data de fabricação',"
                +" validade as 'Data de validade',"
                +" notafiscal as 'Nota Fiscal',"
                +" disponivel as 'Produto a venda'"
            +" from lotes'"
            +" inner join produtos"
            +" on idprodutofk = '"+i+"'"
            +" and idprodutofk = produtos.id"
            +" order by aquisicao desc"
            );
            return dt;
        }
        
        public DataTable ExbSelecionadoFabrAntigos() 
        //Lista os lotes do produto selecionado organizando pela data de fabricacao (antigo para recente)
        {
            dt = banco.consultar(
            "select"
                +" fabricacao as 'Data de fabricação',"
                +" aquisicao as 'Data de aquisição'
                +" validade as 'Data de validade',"
                +" notafiscal as 'Nota Fiscal',"
                +" disponivel as 'Produto a venda'"
            +" from lotes'"
            +" inner join produtos"
            +" on idprodutofk = '"+i+"'"
            +" and idprodutofk = produtos.id"
            +" order by fabricacao"
            );
            return dt;
        }  
    
        public DataTable ExbSelecionadoFabrRecentes() 
        //Lista os lotes do produto selecionado organizando pela data de aquisição (recente para antigo)
        {
            dt = banco.consultar(
            "select"
                +" fabricacao as 'Data de fabricação',"
                +" lotes.id as 'ID Lote',"
                +" aquisicao as 'Data de aquisição'
                +" validade as 'Data de validade',"
                +" notafiscal as 'Nota Fiscal',"
                +" disponivel as 'Produto a venda'"
            +" from lotes'"
            +" inner join produtos"
            +" on idprodutofk = '"+i+"'"
            +" and idprodutofk = produtos.id"
            +" order by fabricacao desc"
            );
            return dt;
        }
        
        public DataTable ExbLotesAntigos() 
        //Lista os lotes do produto selecionado organizando pela data de validade (antigo para recente)
        {
            dt = banco.consultar(
            "select"
                +" validade as 'Data de validade',"
                +" nome as 'Produto',"           
                +" aquisicao as 'Data de aquisição'
                +" fabricacao as 'Data de fabricação',"
                +" notafiscal as 'Nota Fiscal',"
                +" disponivel as 'Produto a venda'"
            +" from lotes'"
            +" inner join produtos"
            +" on idprodutofk = '"+i+"'"
            +" and idprodutofk = produtos.id"
            +" order by validade"
            );
            return dt;
        }  

        
        public DataTable ExbLotesRecentes(int i) 
        //Lista os lotes cadastrados do produto selecionado organizando pela data de validade (distante para próximo)
        {
            dt = banco.consultar(
            "select"
                +" nome as 'Produto',"           
                +" lotes.id as 'ID Lote',"
                +" validade as 'Data de validade',"
                +" aquisicao as 'Data de aquisição'
                +" fabricacao as 'Data de fabricação',"
                +" notafiscal as 'Nota Fiscal',"
                +" disponivel as 'Produto a venda'"
            +" from lotes'"
            +" inner join produtos"
            +" on idprodutofk = '"+i+"'"
            +" and idprodutofk = produtos.id"
            +" order by validade desc"
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
