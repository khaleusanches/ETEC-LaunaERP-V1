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


create table telefones(
  id int unique not null auto_increment,    primary key (id),
  idfornecedorfk int not null,              foreign key (idfornecedorfk) references fornecedores (id),
  tel varchar(16) unique not null,
  obs varchar (48)
);

--------------------------------------------

create table produtos(
  id int unique not null auto_increment,    primary key(id),
  nome varchar(64) unique not null,
  valor decimal (10,2),
  estoque int,
  descricao varchar(180),
  disponivel varchar(1),                    check (disponivel = 's' or disponivel = 'n')
);

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

--------------------------------------------

create table clientes(
  id int unique not null auto_increment,    primary key(id),
  nome varchar(64) not null,
  cpf varchar(11) unique not null,
  desconto decimal(10,2) not null default '0.8'
);

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

create table cargos(
  id int unique not null auto_increment,  primary key(id),
  nome varchar(32) unique not null,
  descricao varchar (180)
);

--------------------------------------------
create table classes (
  id int unique not null auto_increment,     primary key(id),
  nome varchar(64),  cargoalvo varchar(64),
  visualfuncionariosbasico varchar(1),  check (visualfuncionariosbasico = 's' or visualfuncionariosbasico = 'n'),
  editarfuncionariosbasico varchar(1),  check (editarfuncionariosbasico = 's' or editarfuncionariosbasico = 'n'),
  editarcargosesetores varchar(1),  check (editarcargosesetores = 's' or editarcargosesetores = 'n'),
  visualfuncionarioscompleto varchar(1),  check (visualfuncionarioscompleto = 's' or visualfuncionarioscompleto = 'n'),
  editarfuncionarioscompleto varchar(1),  check (editarfuncionarioscompleto = 's' or editarfuncionarioscompleto = 'n'),
  visualfornecedores varchar(1),  check (visualfornecedores = 's' or visualfornecedores = 'n'),
  editarfornecedores varchar(1),  check (editarfornecedores = 's' or editarfornecedores = 'n'),
  visualestoque varchar(1),  check (visualestoque = 's' or visualestoque = 'n'),
  editarestoque varchar(1),  check (editarestoque = 's' or editarestoque = 'n'),
  visualcatalogo varchar(1),  check (visualcatalogo = 's' or visualcatalogo = 'n'),
  editarcatalogo varchar(1),  check (editarcatalogo = 's' or editarcatalogo = 'n'),
  operarpov varchar(1),  check (operarpov = 's' or operarpov = 'n'),
  visualvendas varchar(1),  check (visualvendas = 's' or visualvendas = 'n');
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
('9', 'Gerenciamento Geral',                         's', 's', 's', 's', 's', 's', 's', 's', 's', 's', 's', 'n', 's');
  
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
