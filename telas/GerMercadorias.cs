
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
    public class GerMercadorias//Métodos diferentes de exibir os produtos e os lotes no estoque
    {
        DataTable dt = new DataTable();
        Banco banco = new Banco();
        DataTable DT_consultaID = new DataTable();

        //---------------------------------------------------------
        public DataTable ExbEstoqueID() 
        //1 Lista todos os produtos cadastrados organizando pelo ID do produto
        {
            dt = banco.consultar(
            "select"
                +" id as 'ID',"                        +" nome as 'Produto',"
                +" valor as 'Valor unitário (R$)',"    +" estoque as 'Quantidade em estoque',"
                +" descricao as 'Descrição',"          +" disponivel as 'A venda'"
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
                +" nome as 'Produto',"                +" id as 'ID',"
                +" valor as 'Valor unitário (R$)',"   +" estoque as 'Quantidade em estoque',"
                +" descricao as 'Descrição',"         +" disponivel as 'A venda'"
            +" from produtos"
            +" order by nome"
            );
            return dt;
        }
        
        public DataTable ExbCatalogoID() 
        //Lista produtos DISPONÍVEL NO CATALOGO organizando pelo id do produto
        {
            dt = banco.consultar(
            "select"
                +" id as 'ID',"                        +" nome as 'Produto',"
                +" valor as 'Valor unitário (R$)',"    +" estoque as 'Quantidade em estoque',"
                +" descricao as 'Descrição'"
            +" from produtos"
            +" where disponivel = 's'"
            +" order by id"
            );
            return dt;
        }
        
        public DataTable ExbCatalogoNome() 
        //Lista produtos  DISPONÍVEL NO CATALOGO organizando pelo nome do produto
        {
            dt = banco.consultar(
            "select"
                +" nome as 'Produto',"                +" id as 'ID',"
                +" valor as 'Valor unitário (R$)',"   +" estoque as 'Quantidade em estoque',"
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
                +" id as 'ID',"                      +" nome as 'Produto',"
                +" valor as 'Valor unitário (R$)'"   +" estoque as 'Quantidade em estoque',"
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
                +" nome as 'Produto',"                +" id as 'ID',"
                +" valor as 'Valor unitário (R$)'"    +" estoque as 'Quantidade em estoque',"
                +" descricao as 'Descrição'"
            +" from produtos"
            +" where disponivel = 'n'"
            +" order by nome"
            );
            return dt;
        }
//------------------------------------------------------------
//------------------------------------------------------------
        public DataTable ExbLotes() 
        //Lista todos os lotes cadastrados organizando pelo nome do produto no lote
        {
            dt = banco.consultar(
            "select"  
                +" lotes.id as 'ID Lote',"                +" nome as 'Produto',"         
                +" aquisicao as 'Data de aquisição',"     +" fabricacao as 'Data de fabricação',"
                +" validade as 'Data de validade',"       +" notafiscal as 'Nota Fiscal',"
                +" disponivel as 'Produto a venda'"
                +" from lotes'"
                +" inner join produtos
            +" on idprodutofk = produtos.id"
            +" order by nome"
            );
            return dt;
        }  
        
        public DataTable ExbLotesAntigos() 
        //Lista todos os lotes cadastrados organizando pela data de aquisição (antigo para recentes)
        {
            dt = banco.consultar(
            "select"  
                +" lotes.id as 'ID Lote',"            +" aquisicao as 'Data de aquisição',"
                +" nome as 'Produto',"                +" fabricacao as 'Data de fabricação',"
                +" validade as 'Data de validade',"   +" notafiscal as 'Nota Fiscal',"
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
                +" lotes.id as 'ID Lote',"                +" aquisicao as 'Data de aquisição',"
                +" nome as 'Produto',"                    +" lotes.id as 'ID Lote',"
                +" fabricacao as 'Data de fabricação',"   +" validade as 'Data de validade',"
                +" notafiscal as 'Nota Fiscal',"          +" disponivel as 'Produto a venda'"
            +" from lotes'"
            +" inner join produtos"
            +" on idprodutofk = produtos.id"
            +" order by aquisicao desc"
            );
            return dt;
        }
        
        public DataTable ExbFabricadosAntigos() 
        //Lista todos os lotes cadastrados organizando pela data de fabricacao (antigos para recentes)
        {
            dt = banco.consultar(
            "select"     
                +" lotes.id as 'ID Lote',"             +" fabricacao as 'Data de fabricação',"
                +" nome as 'Produto',"                 +" aquisicao as 'Data de aquisição',"
                +" validade as 'Data de validade',"    +" notafiscal as 'Nota Fiscal',"
                +" disponivel as 'Produto a venda'"
            +" from lotes'"
            +" inner join produtos on"
            +" idprodutofk = produtos.id"
            +" order by fabricacao"
            );
            return dt;
        }  
    
        public DataTable ExbFabricadosRecentes() 
        //Lista todos os lotes cadastrados organizando pela data de aquisição (recentes para antigos)
        {
            dt = banco.consultar(
            "select"     
                +" lotes.id as 'ID Lote',"             +" fabricacao as 'Data de fabricação',"
                +" nome as 'Produto',"                 +" aquisicao as 'Data de aquisição',"
                +" validade as 'Data de validade',"    +" notafiscal as 'Nota Fiscal',"
                +" disponivel as 'Produto a venda'"
            +" from lotes'"
            +" inner join produtos"
            +" on idprodutofk = produtos.id"
            +" order by fabricacao desc"
            );
            return dt;
        }
        
        public DataTable ExbValidadeProxima() 
        //Lista todos os lotes cadastrados organizando pela data de validade (proximos para distantes)
        {
            dt = banco.consultar(
            "select"     
                +" lotes.id as 'ID Lote',"                  +" validade as 'Data de validade',"
                +" nome as 'Produto',"                      +" aquisicao as 'Data de aquisição',"
                +" fabricacao as 'Data de fabricação',"     +" notafiscal as 'Nota Fiscal',"
                +" disponivel as 'Produto a venda'"
            +" from lotes'"
            +" inner join produtos on"
            +" idprodutofk = produtos.id"
            +" order by validade"
            );
            return dt;
        }  

        public DataTable ExbValidadeDistante() 
        //Lista todos os lotes cadastrados organizando pela data de validade (distante para próximos)
        {
            dt = banco.consultar(
            "select"    
                +" lotes.id as 'ID Lote',"                +" nome as 'Produto',"       
                +" validade as 'Data de validade',"       +" aquisicao as 'Data de aquisição',"
                +" fabricacao as 'Data de fabricação',"   +" notafiscal as 'Nota Fiscal',"
                +" disponivel as 'Produto a venda'"       
            +" from lotes'"
            +" inner join produtos"
            +" on idprodutofk = produtos.id"
            +" order by validade desc"
            );
            return dt;
        //------------------------------------------------------------------
        //------------------------------------------------------------------
        public DataTable ExbLotesProdSel() 
        //Lista lotes do produto selecionado organizando pelo nome do produto no lote
        {
            dt = banco.consultar(
            "select"  
                +" lotes.id as 'ID Lote',"                +" nome as 'Produto',"         
                +" aquisicao as 'Data de aquisição',"     +" fabricacao as 'Data de fabricação',"
                +" validade as 'Data de validade',"       +" notafiscal as 'Nota Fiscal',"
                +" disponivel as 'Produto a venda'"
                +" from lotes'"
                +" inner join produtos
            +" on idprodutofk = produtos.id"
            +" and idprodutofk = '"+i+"'"
            +" order by nome"
            );
            return dt;
        }  
        
        public DataTable ExbLotesAntigosProdSel() 
        //Lista lotes do produto selecionado organizando pela data de aquisição (antigo para recentes)
        {
            dt = banco.consultar(
            "select"  
                +" lotes.id as 'ID Lote',"            +" aquisicao as 'Data de aquisição',"
                +" nome as 'Produto',"                +" fabricacao as 'Data de fabricação',"
                +" validade as 'Data de validade',"   +" notafiscal as 'Nota Fiscal',"
                +" disponivel as 'Produto a venda'"
            +" from lotes'"
            +" inner join produtos on"
            +" idprodutofk = produtos.id"
            +" and idprodutofk = '"+i+"'"
            +" order by aquisicao"
            );
            return dt;
        }  

        public DataTable ExbLotesRecentesProdSel() 
        //Lista lotes do produto selecionado organizando pela data de aquisição (recentes para antigos)
        {
            dt = banco.consultar(
            "select"  
                +" lotes.id as 'ID Lote',"                +" aquisicao as 'Data de aquisição',"
                +" nome as 'Produto',"                    +" lotes.id as 'ID Lote',"
                +" fabricacao as 'Data de fabricação',"   +" validade as 'Data de validade',"
                +" notafiscal as 'Nota Fiscal',"          +" disponivel as 'Produto a venda'"
            +" from lotes'"
            +" inner join produtos"
            +" on idprodutofk = produtos.id"
            +" and idprodutofk = '"+i+"'"
            +" order by aquisicao desc"
            );
            return dt;
        }
        
        public DataTable ExbFabricadosAntigosProdSel() 
        //Lista lotes do produto selecionado organizando pela data de fabricacao (antigos para recentes)
        {
            dt = banco.consultar(
            "select"     
                +" lotes.id as 'ID Lote',"             +" fabricacao as 'Data de fabricação',"
                +" nome as 'Produto',"                 +" aquisicao as 'Data de aquisição',"
                +" validade as 'Data de validade',"    +" notafiscal as 'Nota Fiscal',"
                +" disponivel as 'Produto a venda'"
            +" from lotes'"
            +" inner join produtos on"
            +" idprodutofk = produtos.id"
            +" and idprodutofk = '"+i+"'"
            +" order by fabricacao"
            );
            return dt;
        }  
    
        public DataTable ExbFabricadosRecentesProdSel() 
        //Lista lotes do produto selecionado organizando pela data de aquisição (recentes para antigos)
        {
            dt = banco.consultar(
            "select"     
                +" lotes.id as 'ID Lote',"             +" fabricacao as 'Data de fabricação',"
                +" nome as 'Produto',"                 +" aquisicao as 'Data de aquisição',"
                +" validade as 'Data de validade',"    +" notafiscal as 'Nota Fiscal',"
                +" disponivel as 'Produto a venda'"
            +" from lotes'"
            +" inner join produtos"
            +" on idprodutofk = produtos.id"
            +" and idprodutofk = '"+i+"'"
            +" order by fabricacao desc"
            );
            return dt;
        }
        
        public DataTable ExbValidadeProximaProdSel() 
        //Lista lotes do produto selecionado organizando pela data de validade (proximos para distantes)
        {
            dt = banco.consultar(
            "select"     
                +" lotes.id as 'ID Lote',"                  +" validade as 'Data de validade',"
                +" nome as 'Produto',"                      +" aquisicao as 'Data de aquisição',"
                +" fabricacao as 'Data de fabricação',"     +" notafiscal as 'Nota Fiscal',"
                +" disponivel as 'Produto a venda'"
            +" from lotes'"
            +" inner join produtos on"
            +" idprodutofk = produtos.id"
            +" and idprodutofk = '"+i+"'"
            +" order by validade"
            );
            return dt;
        }  

        public DataTable ExbValidadeDistanteProdSel() 
        //Lista lotes do produto selecionado organizando pela data de validade (distante para próximos)
        {
            dt = banco.consultar(
            "select"    
                +" lotes.id as 'ID Lote',"                +" nome as 'Produto',"       
                +" validade as 'Data de validade',"       +" aquisicao as 'Data de aquisição',"
                +" fabricacao as 'Data de fabricação',"   +" notafiscal as 'Nota Fiscal',"
                +" disponivel as 'Produto a venda'"       
            +" from lotes'"
            +" inner join produtos"
            +" on idprodutofk = produtos.id"
            +" and idprodutofk = '"+i+"'"
            +" order by validade desc"
            );
            return dt;
        //------------------------------------------------------------------
        //------------------------------------------------------------------
        public DataTable ExbLotesFornSel() 
        //Lista lotes do fornecedor selecionado organizando pelo nome do produto no lote
        {
            dt = banco.consultar(
            "select"  
                +" lotes.id as 'ID Lote',"                +" nome as 'Produto',"         
                +" aquisicao as 'Data de aquisição',"     +" fabricacao as 'Data de fabricação',"
                +" validade as 'Data de validade',"       +" notafiscal as 'Nota Fiscal',"
                +" disponivel as 'Produto a venda'"
                +" from lotes'"
                +" inner join produtos
            +" on idprodutofk = produtos.id"
            +" and idfornecedor = '"+i+"'"
            +" order by nome"
            );
            return dt;
        }  
        
        public DataTable ExbLotesAntigosFornSel() 
        //Lista lotes do fornecedor selecionado organizando pela data de aquisição (antigo para recentes)
        {
            dt = banco.consultar(
            "select"  
                +" lotes.id as 'ID Lote',"            +" aquisicao as 'Data de aquisição',"
                +" nome as 'Produto',"                +" fabricacao as 'Data de fabricação',"
                +" validade as 'Data de validade',"   +" notafiscal as 'Nota Fiscal',"
                +" disponivel as 'Produto a venda'"
            +" from lotes'"
            +" inner join produtos on"
            +" idprodutofk = produtos.id"
            +" and idfornecedor = '"+i+"'"
            +" order by aquisicao"
            );
            return dt;
        }  

        public DataTable ExbLotesRecentesFornSel() 
        //Lista lotes do fornecedor selecionado organizando pela data de aquisição (recentes para antigos)
        {
            dt = banco.consultar(
            "select"  
                +" lotes.id as 'ID Lote',"                +" aquisicao as 'Data de aquisição',"
                +" nome as 'Produto',"                    +" lotes.id as 'ID Lote',"
                +" fabricacao as 'Data de fabricação',"   +" validade as 'Data de validade',"
                +" notafiscal as 'Nota Fiscal',"          +" disponivel as 'Produto a venda'"
            +" from lotes'"
            +" inner join produtos"
            +" on idprodutofk = produtos.id"
            +" and idfornecedor = '"+i+"'"
            +" order by aquisicao desc"
            );
            return dt;
        }
        
        public DataTable ExbFabricadosAntigosFornSel() 
        //Lista lotes do fornecedor selecionado organizando pela data de fabricacao (antigos para recentes)
        {
            dt = banco.consultar(
            "select"     
                +" lotes.id as 'ID Lote',"             +" fabricacao as 'Data de fabricação',"
                +" nome as 'Produto',"                 +" aquisicao as 'Data de aquisição',"
                +" validade as 'Data de validade',"    +" notafiscal as 'Nota Fiscal',"
                +" disponivel as 'Produto a venda'"
            +" from lotes'"
            +" inner join produtos on"
            +" idprodutofk = produtos.id"
            +" and idfornecedor = '"+i+"'"
            +" order by fabricacao"
            );
            return dt;
        }  
    
        public DataTable ExbFabricadosRecentesFornSel() 
        //Lista lotes do fornecedor selecionado organizando pela data de aquisição (recentes para antigos)
        {
            dt = banco.consultar(
            "select"     
                +" lotes.id as 'ID Lote',"             +" fabricacao as 'Data de fabricação',"
                +" nome as 'Produto',"                 +" aquisicao as 'Data de aquisição',"
                +" validade as 'Data de validade',"    +" notafiscal as 'Nota Fiscal',"
                +" disponivel as 'Produto a venda'"
            +" from lotes'"
            +" inner join produtos"
            +" on idprodutofk = produtos.id"
            +" and idfornecedor = '"+i+"'"
            +" order by fabricacao desc"
            );
            return dt;
        }
        
        public DataTable ExbValidadeProximaFornSel() 
        //Lista lotes do fornecedor selecionado organizando pela data de validade (proximos para distantes)
        {
            dt = banco.consultar(
            "select"     
                +" lotes.id as 'ID Lote',"                  +" validade as 'Data de validade',"
                +" nome as 'Produto',"                      +" aquisicao as 'Data de aquisição',"
                +" fabricacao as 'Data de fabricação',"     +" notafiscal as 'Nota Fiscal',"
                +" disponivel as 'Produto a venda'"
            +" from lotes'"
            +" inner join produtos on"
            +" idprodutofk = produtos.id"
            +" and idfornecedor = '"+i+"'"
            +" order by validade"
            );
            return dt;
        }  

        public DataTable ExbValidadeDistanteFornSel() 
        //Lista lotes do fornecedor selecionado organizando pela data de validade (distante para próximos)
        {
            dt = banco.consultar(
            "select"    
                +" lotes.id as 'ID Lote',"                +" nome as 'Produto',"       
                +" validade as 'Data de validade',"       +" aquisicao as 'Data de aquisição',"
                +" fabricacao as 'Data de fabricação',"   +" notafiscal as 'Nota Fiscal',"
                +" disponivel as 'Produto a venda'"       
            +" from lotes'"
            +" inner join produtos"
            +" on idprodutofk = produtos.id"
            +" and idfornecedor = '"+i+"'"
            +" order by validade desc"
            );
            return dt;
        //------------------------------------------------------------------
        //------------------------------------------------------------------

 
        public void fechar()
        {
            dt.Clear();
        }
    }
}
