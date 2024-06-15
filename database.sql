drop database atividade1csharp;
create database atividade1csharp;
use atividade1csharp;
--------------------------------------------
create table fornecedores(
  id int auto_increment unique not null,    primary key(id),
  nome varchar(64) unique not null,
  razaosocial varchar(80) unique not null,
  cnpj varchar(18) unique not null,
  endereco varchar(200),
  email varchar(80) unique not null
);
insert into fornecedores(nome, razaosocial, cnpj, endereco, email) values
  ('Fornecedor1', 'Fornecedor1', 'XX.XXX.XXX/0001-XX', 'Endereço 1', 'Fornecedor1@email'),
  ('Fornecedor2', 'Fornecedor2', 'XX.XXX.XXX/0002-XX', 'Endereço 2', 'Fornecedor2@email'),
  ('Fornecedor3', 'Fornecedor3', 'XX.XXX.XXX/0003-XX', 'Endereço 3', 'Fornecedor3@email'),
  ('Fornecedor4', 'Fornecedor4', 'XX.XXX.XXX/0004-XX', 'Endereço 4', 'Fornecedor4@email');

create table telefones(
  id int unique not null auto_increment,    primary key (id),
  idfornecedorfk int not null,              foreign key (idfornecedorfk) references fornecedores (id),
  tel varchar(16) unique not null,
  obs varchar (48)
);
insert into telefones(idfornecedorfk, tel, obs) values
  (1, 'XX XX XXXX-XXX1', 'Tel 1A'), (1, 'XX XX XXXX-XXX2', 'Tel 1B'), (1, 'XX XX XXXX-XXX3', 'Tel 1C'),
  (2, 'XX XX XXXX-XXX4', 'Tel 2A'), (2, 'XX XX XXXX-XXX5', 'Tel 2B'), (2, 'XX XX XXXX-XXX6', 'Tel 2C'),
  (3, 'XX XX XXXX-XXX7', 'Tel 3A'), (3, 'XX XX XXXX-XXX8', 'Tel 3B'), (3, 'XX XX XXXX-XXX9', 'Tel 3C'),
  (4, 'XX XX XXXX-XX10', 'Tel 4A'), (4, 'XX XX XXXX-XX11', 'Tel 4B'), (4, 'XX XX XXXX-XX12', 'Tel 4C');
--------------------------------------------
create table categorias(
  id int not null unique auto_increment,    primary key(id),
  nome varchar(64) unique not null,
  descricao varchar(180)
);
insert into categorias values
  (0, 'Não Categorizado', 'Produtos não categorizados');

create table produtos(
  id int unique not null auto_increment,    primary key(id),
  nome varchar(64) unique not null,
  valor decimal (10,2),
  idcategoriafk int default 0,            foreign key(idcategoriafk) references categorias(id),
  estoque int,
  descricao varchar(180),
  disponivel varchar(1),                    check (disponivel = 's' or disponivel = 'n')
);
insert into produtos(nome, valor, idcategoriafk, estoque, descricao, disponivel) values
  ('Produto 1', 23, 1, 100, '', 's'),
  ('Produto 2', 26, 1, 200, '', 's'),
  ('Produto 3', 24, 1, 215, '', 's'),
  ('Prodto 4', 12, 1, 133, '', 's'),
  ('Produto 5', 132, 1, 546, '', 'n'),
  ('Produto 6', 27, 1, 458, '', 'n'),
  ('Produto 7', 23, 1, 115, '', 'n'),
  ('Produto 8', 44, 1, 746, '', 's'),
  ('Produto 9', 52, 1, 184, '', 'n'),
  ('Produto 10', 122, 1, 154, '', 's');
----------------------------
create table lotes(
  id int unique not null auto_increment,    primary key(id),
  idprodutofk int not null,                 foreign key (idprodutofk) references produtos (id),
  quantidade int not null,                  check (quantidade>0),
  fornecedor varchar(64) not null,
  aquisicao date not null,
  fabricacao date not null,
  validade date not null,
  notafiscal int unique not null,
  localizacao varchar(32) not null
);
insert into lotes(idprodutofk, quantidade, fornecedor, aquisicao, fabricacao, validade, notafiscal, localizacao) values
(1, 100, 'Fornecedor1', 20240425, 20240331, 20240624, 1, 'Sessão 1 Fileira 1 Prateleira 1'),
(2, 200, 'Fornecedor1', 20240422, 20240410, 20240826, 2, 'Sessão 1 Fileira 2 Prateleira 2'),
(3, 250, 'Fornecedor2', 20240212, 20240108, 20240922, 3, 'Sessão 1 Fileira 3 Prateleira 3'),
(4, 150, 'Fornecedor2', 20240212, 20240208, 20240624, 4, 'Sessão 1 Fileira 4 Prateleira 4'),
(5, 540, 'Fornecedor3', 20240323, 20240318, 20240821, 5, 'Sessão 1 Fileira 5 Prateleira 5'),
(6, 480, 'Fornecedor3', 20240215, 20240202, 20240814, 6, 'Sessão 2 Fileira 1 Prateleira 1'),
(7, 130, 'Fornecedor4', 20240312, 20240228, 20240911, 7, 'Sessão 2 Fileira 2 Prateleira 2'),
(8, 750, 'Fornecedor4', 20240302, 20240228, 20241006, 8, 'Sessão 2 Fileira 3 Prateleira 3');
--------------------------------------------
create table clientes(
  id int unique not null auto_increment,    primary key(id),
  nome varchar(64) not null,
  cpf varchar(11) unique not null,
  desconto decimal(10,2) not null default '0.8'
);
insert into clientes(nome, cpf, desconto) values
('Cliente1', '1XXXXXXXXXX', '0.9'),
('Cliente2', '2XXXXXXXXXX', '0.9'),
('Cliente3', '3XXXXXXXXXX', '0.9'),
('Cliente4', '4XXXXXXXXXX', '0.9');
--------------------------------------------
create table operacoes(
  id int unique not null auto_increment,    primary key(id),
  idclientefk int,                          foreign key (idclientefk) references clientes (id),
  total decimal(10,2),                      check (total>0),
  troco decimal(10,2),                      check (troco>0),
  desconto decimal(10,2),
  avaliacao int,
  dataehora datetime
);
create table vendas(
  id int unique not null auto_increment,    primary key (id),
  idoperacaofk int not null,                foreign key (idoperacaofk) references operacoes (id),
  idprodutofk int not null,                 foreign key (idprodutofk) references produtos (id),
  quantidade int not null
  );
--------------------------------------------
create table setores(
  id int unique not null auto_increment,   primary key(id),
  nome varchar(32) unique not null
);
insert into setores values
(1, 'Administrativo'),
(2, 'Recursos Humanos'),
(3, 'Financeiro'),
(4, 'Vendas'),
(5, 'Logística'),
(6, 'TI'),
(7, 'Limpeza');

create table cargos(
  id int unique not null auto_increment,  primary key(id),
  nome varchar(32) unique not null,
  descricao varchar (180)
);
insert into cargos (nome) values
  (1, 'Gerente'),
  (2, 'Assistente'),
  (3, 'Auxiliar'),
  (4, 'Operador(a)'),
  (5, 'Diretor'),
  (6, 'Caixa'),
  (7, 'Cozinheiro(a)'),
  (8, 'Entregador(a)'),
  (9, 'Mensageiro(a)'),
  (10, 'Secreatário(a)'),
  (11, 'Zelador'),
  (12, 'Repositor'),
  (13, 'Segurança'),
  (14, 'Vendedor(a)'),
  (15, 'Programador');
--------------------------------------------
create table classes (
  id int unique not null auto_increment,     primary key(id),
  nome varchar(64),  cargoalvo varchar(64),
  visualfuncionariosbasico varchar(1),      check (visualfuncionariosbasico = 's' or visualfuncionariosbasico = 'n'),
  editarfuncionariosbasico varchar(1),      check (editarfuncionariosbasico = 's' or editarfuncionariosbasico = 'n'),
  editarcargosesetores varchar(1),          check (editarcargosesetores = 's' or editarcargosesetores = 'n'),
  visualfuncionarioscompleto varchar(1),    check (visualfuncionarioscompleto = 's' or visualfuncionarioscompleto = 'n'),
  editarfuncionarioscompleto varchar(1),    check (editarfuncionarioscompleto = 's' or editarfuncionarioscompleto = 'n'),
  visualfornecedores varchar(1),            check (visualfornecedores = 's' or visualfornecedores = 'n'),
  editarfornecedores varchar(1),            check (editarfornecedores = 's' or editarfornecedores = 'n'),
  visualestoque varchar(1),                 check (visualestoque = 's' or visualestoque = 'n'),
  editarestoque varchar(1),                 check (editarestoque = 's' or editarestoque = 'n'),
  visualcatalogo varchar(1),                check (visualcatalogo = 's' or visualcatalogo = 'n'),
  editarcatalogo varchar(1),                check (editarcatalogo = 's' or editarcatalogo = 'n'),
  operarpov varchar(1),                     check (operarpov = 's' or operarpov = 'n'),
  visualvendas varchar(1),                  check (visualvendas = 's' or visualvendas = 'n')
);
insert into classes (id, nome, visualfuncionariosbasico, editarfuncionariosbasico, visualfuncionarioscompleto, editarfuncionarioscompleto, editarcargosesetores, 
visualfornecedores, editarfornecedores, visualestoque, editarestoque, visualcatalogo, editarcatalogo, operarpov, visualvendas) values
('1', 'Setor de Recursos Humanos',                   's', 's', 'n', 'n', 's', 'n', 'n', 'n', 'n', 'n', 'n', 'n', 'n'),
('2', 'Gerenciamento do Setor de Recursos Humanos',  's', 's', 's', 's', 's', 'n', 'n', 'n', 'n', 'n', 'n', 'n', 'n'),
('3', 'Setor Financeiro',                            's', 'n', 'n', 'n', 'n', 's', 's', 's', 'n', 's', 'n', 'n', 'n'),
('4', 'Gerenciamento do Setor Financeiro',           's', 'n', 'n', 'n', 'n', 's', 's', 's', 'n', 's', 'n', 'n', 's'),
('5', 'Setor Logístico',                             'n', 'n', 'n', 'n', 'n', 's', 'n', 's', 's', 's', 's', 'n', 'n'),
('6', 'Gerenciamento do Setor Logístico',            's', 'n', 'n', 'n', 'n', 's', 'n', 's', 's', 's', 's', 's', 's'),
('7', 'Setor de Vendas',                             'n', 'n', 'n', 'n', 'n', 'n', 'n', 's', 'n', 's', 's', 's', 'n'),
('8', 'Gerenciamento do Setor de Vendas',            's', 'n', 'n', 'n', 'n', 'n', 'n', 's', 'n', 's', 's', 'n', 's'),
('9', 'Setor Administrativo',                        's', 'n', 'n', 'n', 's', 's', 's', 's', 'n', 's', 's', 'n', 's'),
('10', 'Gerenciamento Geral',                         's', 's', 's', 's', 's', 's', 's', 's', 's', 's', 's', 'n', 's'),
('11', 'Não classificado',                            'n', 'n', 'n', 'n', 'n', 'n', 'n', 'n', 'n', 'n', 'n', 'n', 'n');
--------------------------------------------
create table funcionarios(
  id int unique not null auto_increment,     primary key(id),
  nome varchar(64) not null,
  email varchar(64) unique not null,
  tel varchar(16) unique not null,
  rg varchar(9) unique not null,
  nascimento date not null,
  pis varchar(11) unique not null,
  endereco varchar(200) not null,
  idcargofk int not null,                    foreign key (idcargofk) references cargos (id),
  idsetorfk int not null,                    foreign key (idsetorfk) references setores (id),
  class int,
  admissao date not null,
  salario decimal(10,2) not null,
  login varchar(32) unique,
  senha varchar(32),
  desconto decimal(10,2) not null default '0.8'
);

insert into funcionarios (nome, email, tel, rg, nascimento, pis, endereco, idsetorfk, idcargofk, class, admissao, salario, login, senha, desconto) values
('Bruna Sampaio de Oliveira', 'brunasampaio8@gmail', 			      'XX X XXXXX-XXX1', '4xxxxxxxx', 20071221, 'XXXXXX1XXXX', '6758 Alice Travessa - Ingaí, MS / 33055-287',					          1, 5, 10,  20240601, '5000', 'brunasampaio',  'senhapadrao', '0.7'),
('Larissa Silva Melo',		    'larissamelo12@gmail', 			      'XX X XXXXX-XXX2', '1xxxxxxxx', 20070112, 'XXXX2XXXXXX', '91948 Silva Rua - Patrocínio, CE / 97005-906', 					        1, 5, 10,  20240601, '5000', 'larissamelo',  'senhapadrao', '0.7'),
('Ana Maria de Assis', 		    'anamariadeassis@gmail.com', 		  'XX X XXXXX-XXX3', 'xxxxxxxx4', 20001124, 'XXXXXX7XXXX', '218 Benjamin Avenida - Treze Tílias, RJ / 95383-611',			      4, 1, 8,   20240601, '3800', 'anagerente',  'senhapadrao', '0.7'),
('Gustavo Almeida Ramos', 	  'gustavoramos@gmail.com', 		    'XX X XXXXX-XXX4', 'xxxxxxx1x', 19980812, 'XXXXXXXX6XX', '289 Mariana Travessa - Altaneira, PA / 18272-679', 			        4, 6, 7,   20240601, '1600', 'gustavocaixa',  'senhapadrao', '0.8'),
('Lizandra Alves Machado', 	  'lizandraalvesmachado@gmail.com', 'XX X XXXXX-XXX5', 'x3xxxxxxx', 20020714, 'XXXXXX7XXXX', '27898 Martins Rua - Tabaí, PI / 61345-052', 						        4, 6, 7,   20240601, '1600', 'lizandracaixa',  'senhapadrao', '0.8'),
('Eduardo Lima Oliveira', 	  'eduardolima1425@gmail.com', 		  'XX X XXXXX-XXX6', 'xxxxxxxx2', 19891231, 'XXXXXXXX4XX', '950 Raul Marginal - Cubati, AC / 47193-673', 					          5, 12, 5,  20240601, '1685', 'eduardorepositor',  'senhapadrao', '0.8'),
('João de Assis',			        'joaodeassis@gmail.com', 			    'XX X XXXXX-XXX7', 'xxxxxxx55', 20010903, 'XXX8XXXXXXX', '325 Maria Júlia Alameda - Piacatu, AM / 20447-969', 				    5, 12, 5,  20240601, '1685', 'joaorepositor',  'senhapadrao', '0.8'),
('Juliana Guedes da Silva',	  'juliana20guedes@gmail.com',	 	  'XX X XXXXX-XXX8', 'xxxxx1xxx', 20030513, 'XXXX8XXXXXX', '36343 Anthony Travessa - Trajano de Morais, PA / 48880-735', 	  4, 14, 7,  20240601,'1400',  'julianavendedora',  'senhapadrao', '0.8'),
('Damiana da Silva Souza', 	  'damianadasilva44@gmail.com', 	  'XX X XXXXX-XXX9', 'xxxx8xxxx', 19980801, 'XX1XXXXXXXX', '0953 Roberto Alameda - Goioerê, DF / 96055-289', 20030421, 		  4, 14, 7,  20240601, '1400', 'damianavendedora',  'senhapadrao', '0.8'),
('Francisco Pinto Amaral', 	  'franciscoamaral@gmail.com', 		  'XX X XXXXX-XXX0', 'xxxxx9xxx', 20050112, 'X1XXXXXXXXX', '4627 Moreira Alameda - Arvorezinha, AP / 20558-413', 20040111,  5, 8, 5,   20240601, '1355', '', '', '0.8'),
('Khaléu Sanches Mancini', 	  'khaleumancini@gmail.com', 		    'XX X XXXXX-XX11', 'x1xxxxxxx', 20030612, '1XXXXXXXXXX', '062 Maria Antonieta - Santa Maria de Itabira, PR / 80259-852',	6, 15, 10, 20070101, '5.4',  'khaleu1111', 'senhapadrao', '0.8'),
('Clara Santana Araújo', 	    'claraaraujo2@gmail.com', 		    'XX X XXXXX-XX22', 'xxx2xxxxx', 19970122, '0XXXXXXXXXX', '7252 Reis Travessa - Anitápolis, GO / 70485-158', 20040202, 		6, 15, 10, 20240601, '60',   'clara2222', 'senhapadrao', '0.8');
