
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

namespace GerGeral
{
    public class GerGeral : SetorAdministrativo
    {
        DataTable dt = new DataTable();
        Banco banco = new Banco();
        DataTable DT_consultaID = new DataTable();

        //--------------------------------------------------------------------
        public DataTable ExbFornecedoresNome() 
        {
            dt = banco.consultar(
            "select"
                +" fornecedores.id as 'ID',"
                +" nome as 'Nome',"
                +" razaosocial as 'Razão Social'"               
                +" cnpj as 'CNPJ/CPF',"
                +" email as 'Correio Eletrônico'"
                +" tel as 'Tel',"
                +" obs as '',"
                +" endereco as 'Endereço',"
            +" from fornecedores"
            +" inner join telefones"
            +" on idfornecedorfk = fornecedores.id"
            +"order by fornecedores.id");
            return dt;
        }
        public DataTable ExbFornecedoresID() 
        {
            dt = banco.consultar(
            "select"
                +" fornecedores.id as 'ID',"
                +" nome as 'Nome',"
                +" razaosocial as 'Razão Social'"               
                +" cnpj as 'CNPJ/CPF',"
                +" email as 'Correio Eletrônico'"
                +" tel as 'Tel',"
                +" obs as '',"
                +" endereco as 'Endereço',"
            +" from fornecedores"
            +" inner join telefones"
            +" on idfornecedorfk = fornecedores.id"
            +"order by nome");
            return dt;
        }
        //--------------------------------------------------------------------               
        public void CadCategoria(string nome, string descricao)
        {
            banco.comandar("insert into categorias (nome, descricao) values ('"+nome+"', '"+descricao+"')");
            fechar();
        } 
        public void AtuCategoria(int i, string nome, string descricao)
        {
            banco.comandar("update categorias set nome = '"+nome+"', descricao = '"+descricao+"' where id = '"+i+"'");
            fechar();
        }
        public void DelCategoria(int i)
        {
            banco.comandar("update produtos set idcategoriafk = 1 where idcategoriafk = '"+i+"'; Delete * from categorias where id = '"+i+"'");
            fechar();
        }
      //--------------------------------------------------------------------
        public void CadProduto(string nome, string valor, string categoria, string descricao)
        {
          banco.comandar(
            "insert into produtos(nome, valor, idcategoriafk, descricao, disponivel) "
            + "values ('"+nome+"', '"+valor+"', '"+categoria+"', '"+" '"+descricao+"', 's')");
            fechar();
        }   
        public void AtuProduto(int i, string nome, string valor, string categoria, string descricao)
        {
            banco.comandar("update produtos set nome = '"+nome+"', valor = '"+valor+"', idcategoriafk = '"+categoria+"', descricao = '"+descricao+"' where id = '"+i+"'");
            fechar();
        }
        public void DelProduto(int i)
        {
            dt = banco.comandar("select id from lotes where idprodutofk = '"+i+"'");
            if (dt = null) {banco.comandar("Delete * from categorias where id = '"+i+"'"); fechar()}
            else {}
            fechar();
        }
      //--------------------------------------------------------------------      
        public void CadLote(string produto, int quantidade, string fornecedor, int aquisicao, int fabricacao, int validade, int notafiscal, string localizacao)
        {
            banco.comandar("insert into lotes(idprodutofk, quantidade, idfornecedor, aquisicao, fabricacao, validade, notafiscal, localizacao) " +
            "values ('"+idprodutofk+"', '"+quantidade+"', '"+idfornecedor+"', '"+aquisicao+"', '"+fabricacao+"', '"+validade+"', '"+notafiscal+"', '"+localizacao+"')");
            fechar();
        } 
        public void AtuLote(int i, string produto, int quantidade, string fornecedor, int aquisicao, int fabricacao, int validade, int notafiscal, string localizacao)
        {
            banco.comandar("update lotes set idprodutofk = '"+produto+"', quantidade = '"+quantidade+"', fornecedor = '"+idfornecedor+"', aquisicao = '"+aquisicao+"', fabricacao = '"+fabricacao+"', validade = '"+validade+"', notafiscal = '"+notafiscal+"', localizacao = '"+localizacao+"' where id = '"+i+"'");
            fechar();
        }
        public void DelLote(int i)
        {
            banco.comandar("delete * from lotes where idlotefk = '"+i+"')");
            fechar();
        }
        
        public void DelLoteProdutoSel(int i)
        {
            banco.comandar("delete * from lotes where idprodutofk = '"+i+"')");
            fechar();
        }
        
        //--------------------------------------------------------------------   
        //--------------------------------------------------------------------  
        
        //-----------------------------
        public void CadFuncionario(string nome, string cargo, string classe, string setor, string email, string tel, string rg, int nascimento, string pis, string endereco, int admissao, int salario, string login, string senha, string desconto)
        {
            banco.comandar(
            "insert into funcionarios(nome, idcargofk, idsetorfk, idclassefk, email, tel, rg, nascimento, pis, endereco, admissao, salario, login, senha, desconto) "+
            "values ('"+nome+"','"+cargo+"','"+setor+"','"+classe+"','"+email+"','"tel+"','"+rg+"','"+nascimento+"','"+pis+"','"+endereco+"','"+admissao+"','"+salario,+"','"+login+"','"+senha+"','"+desconto+"')");
            fechar();
        }
        //-----------------------------
        public void DelFuncionario(int i)        
        {
            banco.comandar("Delete * from funcionarios where id = '"+i+"'");
            fechar();
        }
        //-----------------------------
        public void AtuFuncionario(int i, string nome, string cargo, string classe, string setor, string email, string tel, string rg, int nascimento, string pis, string endereco, int admissao, int salario, string login, string senha, string desconto)
        {
            banco.comandar(
                "update funcionarios set"
                    +" nome = '"+nome+"',"
                    +" idcargofk = '"+cargo+"',"
                    +" idsetorfk = '"+setor+"',"
                    +" idclassefk = '"+classe+"',"
                    +" email = '"+email+"',"
                    +" tel = '"+tel+"',"
                    +" rg = '"+rg+"',"
                    +" nascimento = '"+nascimento+"',"
                    +" pis ='"+pis+"',"
                    +" endereco = '"+endereco+"',"
                    +" admissao = '"+admissao+"',"
                    +" salario = '"+salario+"',"
                    +" login ='"+login+"',"
                    +" senha ='"+senha+"',"
                    +" desconto = '"+desconto"
                +" where id = '"+i+"'");
            fechar();
        }
        //--------------------------------------------------------------------
        public DataTable ExbSetoresNome() 
        {
            dt = banco.consultar("select nome as 'Nome', id as 'ID' from setores order by nome");
            return dt;
        }
        
        public DataTable ExbSetoresID() 
        {
            dt = banco.consultar("select id as 'ID', nome as 'Nome' from setores order by id");
            return dt;
        }
        
        public void CadSetor(int id, string nome) 
        {
            banco.comandar(
                "insert into setores(id, nome) values '"+id+"', '"+nome+"'");
            fechar();
        }
        
        public void DelSetor(int i)
        {
            dt = banco.consultar("select idsetorfk from funcionarios where idsetorfk = '"+i+"'");
              if (dt != null) {}
              else { banco.comandar("Delete * from setores where id = '"+i+"'");
            fechar(); }
        }
        
        public void AtuSetor(int i, int id, string nome) 
        {
            banco.comandar("update setores set id = '"+id+"', nome = '"+nome+"' where id = '"+i+"'");
            fechar();
        }
//--------------------------------------------------------------------
        
        public DataTable ExbCargos() 
        {
            dt = banco.consultar("select nome as 'Nome', id as 'ID', descricao as 'Descrição' from cargos order by nome");
            return dt;
        }
        
         public DataTable ExbID() 
        {
            dt = banco.consultar("select id as 'ID', nome as 'Nome', descricao as 'Descrição' from cargos order by id");
            return dt;
         }
        
        public void CadCargo(string nome)
        {
          banco.comandar(
            "insert into cargos(nome) values ('"+nome+"')");
            fechar();
        }
        
        public void DelCargo(int i)
        {
            dt = banco.consultar("select idcargofk from funcionarios where idsetorfk = '"+i+"'");
              if (dt != null) {}
              else { banco.comandar("Delete * from cargos where id = '"+i+"'");
            fechar(); }
        }
        
        public void AtuCargo(int id, string nome, string descricap) 
        {
            banco.comandar( "update cargos set id = '"+id+"', nome = '"+nome+"', descricao = '"+descricao+"' where id = '"+i+"'");
            fechar();
        }
        //--------------------------------------------------------------------   
        //--------------------------------------------------------------------      
                         
        public void fechar()
        {
            dt.Clear();
        }
    }
}
