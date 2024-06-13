drop database atividade1csharp;
create database atividade1csharp;
use atividade1csharp;
--------------------------------------------
create table fornecedores(
  id int auto_increment unique not null,    primary key(id),
  nome varchar(64) unique not null,
  cnpj varchar(18) unique not null,
  endereco varchar(200),
  email varchar(80) unique not null
);
insert into fornecedores(nome, cnpj, endereco, email) values
('Fornecedor1', 'XX.XXX.XXX/0001-XX', 'Endereço 1', 'Fornecedor1@email'),
('Fornecedor2', 'XX.XXX.XXX/0002-XX', 'Endereço 2', 'Fornecedor2@email'),
('Fornecedor3', 'XX.XXX.XXX/0003-XX', 'Endereço 3', 'Fornecedor3@email'),
('Fornecedor4', 'XX.XXX.XXX/0004-XX', 'Endereço 4', 'Fornecedor4@email'),
('Fornecedor5', 'XX.XXX.XXX/0005-XX', 'Endereço 5', 'Fornecedor5@email'),
('Fornecedor6', 'XX.XXX.XXX/0006-XX', 'Endereço 6', 'Fornecedor6@email'),
('Fornecedor7', 'XX.XXX.XXX/0007-XX', 'Endereço 7', 'Fornecedor7@email'),
('Fornecedor8', 'XX.XXX.XXX/0008-XX', 'Endereço 8', 'Fornecedor8@email'),
('Fornecedor9', 'XX.XXX.XXX/0009-XX', 'Endereço 9', 'Fornecedor9@email'),
('Fornecedor10', 'XX.XXX.XXX/0010-XX', 'Endereço 10', 'Fornecedor10@email');

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
(4, 'XX XX XXXX-XX10', 'Tel 4A'), (4, 'XX XX XXXX-XX11', 'Tel 4B'), (4, 'XX XX XXXX-XX12', 'Tel 4C'),
(5, 'XX XX XXXX-XX13', 'Tel 5A'), (5, 'XX XX XXXX-XX14', 'Tel 5B'), (5, 'XX XX XXXX-XX15', 'Tel 5C'),
(6, 'XX XX XXXX-XX16', 'Tel 6A'), (6, 'XX XX XXXX-XX17', 'Tel 6B'), (6, 'XX XX XXXX-XX18', 'Tel 6C'),
(7, 'XX XX XXXX-XX19', 'Tel 7A'), (7, 'XX XX XXXX-XX20', 'Tel 7B'), (7, 'XX XX XXXX-XX21', 'Tel 7C'),
(8, 'XX XX XXXX-XX22', 'Tel 8A'), (8, 'XX XX XXXX-XX23', 'Tel 8B'), (8, 'XX XX XXXX-XX24', 'Tel 8C'),
(9, 'XX XX XXXX-XX25', 'Tel 9A'), (9, 'XX XX XXXX-XX26', 'Tel 9B'), (9, 'XX XX XXXX-XX27', 'Tel 9C'),
(10, 'XX XX XXXX-XX28', 'Tel 10A'), (10, 'XX XX XXXX-XX29', 'Tel 10B'), (10, 'XX XX XXXX-XX30', 'Tel 10C');
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
  ('Produto 10', 122, 1, 154, '', 's'),
  ('Produto 11', 34, 1, 188, '', 'n'),
  ('Produto 12', 56, 1, 484, '', 's'),
  ('Produto 13', 48, 1, 44, '', 's'),
  ('Produto 14', 260, 1, 418, '', 's'),
  ('Produto 15', 154, 1, 582, '', 's'),
  ('Produto 16', 51, 1, 362, '', 'n'),
  ('Produto 17', 26, 1, 54, '', 'n'),
  ('Produto 18', 50, 1, 74, '', 'n'),
  ('Produto 19', 10, 1, 556, '', 's'),
  ('Produto 20', 184, 1, 112, '', 's');
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
(8, 750, 'Fornecedor4', 20240302, 20240228, 20241006, 8, 'Sessão 2 Fileira 3 Prateleira 3'),
(9, 200, 'Fornecedor5', 20240531, 20240516, 20241004, 9, 'Sessão 2 Fileira 4 Prateleira 4'),
(10, 180, 'Fornecedor5', 20240523, 20240516, 20240911, 10, 'Sessão 2 Fileira 5 Prateleira 5'),
(11, 200, 'Fornecedor6', 20240423, 20240412, 20240815, 11, 'Sessão 3 Fileira 1 Prateleira 1'),
(12, 500, 'Fornecedor6', 20240421, 20240416, 20240814, 12, 'Sessão 3 Fileira 2 Prateleira 2'),
(13, 100, 'Fornecedor7', 20240219, 20240210, 20240621, 13, 'Sessão 3 Fileira 3 Prateleira 3'),
(14, 450, 'Fornecedor7', 20240217, 20240202, 20240719, 14, 'Sessão 3 Fileira 4 Prateleira 4'),
(15, 600, 'Fornecedor8', 20240315, 20240314, 20240718, 15, 'Sessão 3 Fileira 5 Prateleira 5'),
(16, 380, 'Fornecedor8', 20240417, 20240412, 20241013, 16, 'Sessão 4 Fileira 1 Prateleira 1'),
(17, 100, 'Fornecedor9', 20240511, 20240501, 20240928, 17, 'Sessão 4 Fileira 2 Prateleira 2'),
(18, 200, 'Fornecedor9', 20240402, 20240328, 20240829, 18, 'Sessão 4 Fileira 3 Prateleira 3'),
(19, 580, 'Fornecedor10', 20240503, 20240428, 20240604, 19, 'Sessão 4 Fileira 4 Prateleira 4'),
(20, 150, 'Fornecedor10', 20240413, 20240401, 20240606, 20, 'Sessão 4 Fileira 5 Prateleira 5');
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
('Cliente4', '4XXXXXXXXXX', '0.9'),
('Cliente5', '5XXXXXXXXXX', '0.9'),
('Cliente6', '6XXXXXXXXXX', '0.9'),
('Cliente7', '7XXXXXXXXXX', '0.9'),
('Cliente8', '8XXXXXXXXXX', '0.9'),
('Cliente9', '9XXXXXXXXXX', '0.9'),
('Cliente10', '10XXXXXXXXX', '0.9');

--------------------------------------------
create table operacoes(
  id int unique not null auto_increment,    primary key(id),
  idclientefk int,                          foreign key (idclientefk) references clientes (id),
  total decimal(10,2),                      check (total>0),
  troco decimal(10,2),                      check (troco>0),
  desconto decimal(10,2),
  dataehora datetime not null
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
  ('Gerente'),
  ('Assistente'),
  ('Auxiliar'),
  ('Operador(a)'),
  ('Diretor'),
  ('Caixa'),
  ('Cozinheiro(a)'),
  ('Entregador(a)'),
  ('Mensageiro(a)'),
  ('Secreatário(a)'),
  ('Zelador'),
  ('Repositor'),
  ('Segurança'),
  ('Vendedor(a)'),
  ('Programador');
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
  login varchar(32) unique not null,
  senha varchar(32) not null,
  desconto decimal(10,2) not null default '0.8'
);


//adicionar tel

insert into funcionarios (nome, email, tel, rg, nascimento, pis, endereco, idsetorfk, idcargofk, class, admissao, salario, login, senha, desconto) values
('Bruna Sampaio de Oliveira', 'brunasampaio8@gmail', 			'4xxxxxxxx', 20071221, 'XXXXXX1XXXX', '6758 Alice Travessa - Ingaí, MS / 33055-287',					1, 5, 10,  20240601, '5000', 'loginpadrao1',  'senhapadrao' , '0.8'),
('Larissa Silva Melo',		  'larissamelo12@gmail', 			'1xxxxxxxx', 20070112, 'XXXX2XXXXXX', '91948 Silva Rua - Patrocínio, CE / 97005-906', 					1, 5, 10,  20240601, '5000', 'loginpadrao2',  'senhapadrao', '0.8'),
('Ana Maria de Assis', 		  'anamariadeassis@gmail.com', 		'xxxxxxxx4', 20001124, 'XXXXXX7XXXX', '218 Benjamin Avenida - Treze Tílias, RJ / 95383-611',			4, 1, 8,   20240601, '3800', 'loginpadrao3',  'senhapadrao', '0.8'),
('Gustavo Almeida Ramos', 	  'gustavoramos@gmail.com', 		'xxxxxxx1x', 19980812, 'XXXXXXXX6XX', '289 Mariana Travessa - Altaneira, PA / 18272-679', 				4, 6, 7,   20240601, '1600', 'loginpadrao4',  'senhapadrao', '0.8'),
('Lizandra Alves Machado', 	  'lizandraalvesmachado@gmail.com', 'x3xxxxxxx', 20020714, 'XXXXXX7XXXX', '27898 Martins Rua - Tabaí, PI / 61345-052', 						4, 6, 7,   20240601, '1600', 'loginpadrao5',  'senhapadrao', '0.8'),
('Eduardo Lima Oliveira', 	  'eduardolima1425@gmail.com', 		'xxxxxxxx2', 19891231, 'XXXXXXXX4XX', '950 Raul Marginal - Cubati, AC / 47193-673', 					5, 12, 5,  20240601, '1685', 'loginpadrao6',  'senhapadrao', '0.8'),
('João de Assis',			  'joaodeassis@gmail.com', 			'xxxxxxx55', 20010903, 'XXX8XXXXXXX', '325 Maria Júlia Alameda - Piacatu, AM / 20447-969', 				5, 12, 5,  20240601, '1685', 'loginpadrao7',  'senhapadrao', '0.8'),
('Juliana Guedes da Silva',	  'juliana20guedes@gmail.com',	 	'xxxxx1xxx', 20030513, 'XXXX8XXXXXX', '36343 Anthony Travessa - Trajano de Morais, PA / 48880-735', 	4, 14, 7,  20240601,'1400',  'loginpadrao8',  'senhapadrao', '0.8'),
('Damiana da Silva Souza', 	  'damianadasilva44@gmail.com', 	'xxxx8xxxx', 19980801, 'XX1XXXXXXXX', '0953 Roberto Alameda - Goioerê, DF / 96055-289', 20030421, 		4, 14, 7,  20240601, '1400', 'loginpadrao9',  'senhapadrao', '0.8'),
('Francisco Pinto Amaral', 	  'franciscoamaral@gmail.com', 		'xxxxx9xxx', 20050112, 'X1XXXXXXXXX', '4627 Moreira Alameda - Arvorezinha, AP / 20558-413', 20040111, 	5, 8, 5,   20240601, '1355', 'loginpadrao10', 'senhapadrao', '0.8'),
('Khaléu Sanches Mancini', 	  'khaleumancini@gmail.com', 		'x1xxxxxxx', 20030612, '1XXXXXXXXXX', '062 Maria Antonieta - Santa Maria de Itabira, PR / 80259-852',	6, 15, 11, 20070101, '5.4',  'loginpadrao11', 'senhapadrao', '0.8'),
('Clara Santana Araújo', 	  'claraaraujo2@gmail.com', 		'xxx2xxxxx', 19970122, '0XXXXXXXXXX', '7252 Reis Travessa - Anitápolis, GO / 70485-158', 20040202, 		6, 15, 11, 20240601, '60',   'loginpadrao12', 'senhapadrao', '0.8');
