create database projeto;
use projeto;

--------------------------------------------

create table fornecedores(
id int unique auto_increment,
nome varchar(64) unique not null,
cnpj varchar(18) unique not null,
endereco varchar(200),
correioeletronico varchar(80) unique not null,
primary key(id)
);

select * from fornecedores;
drop table fornecedores;

create table telefones(
id int unique auto_increment,
idfornecedorfk int not null,
especificacao varchar (40),
numero varchar(16) unique not null,
primary key (id),
foreign key (idfornecedorfk) references fornecedores (id)
);

select * from telefones;
drop table telefones;

--------------------------------------------

create table produtos(
id int unique auto_increment,
nome varchar(32) unique not null,
descricao varchar(180),
fornecedor varchar(64) not null,
estoque int,
primary key(id)
);

select * from produtos;
drop table produtos;

--------------------------------------------

create table lotes(
id int unique auto_increment,
idprodutofk int not null,
fornecedor varchar(64) not null,
aquisicao datetime not null,
fabricacao datetime not null,
validade datetime not null,
notafiscal int unique not null,
localizacao varchar(32) not null,
primary key(id),
foreign key (idprodutofk) references produtos (id)
);

select * from lotes;
drop table lotes;

--------------------------------------------

create table cargos(
id int unique auto_increment,
nome varchar(32) unique not null,
descricao varchar (80),
nivel int not null,
primary key(id)
);

select * from cargos;
drop table cargos;

create table setores(
id int unique auto_increment,
nome varchar(32) unique not null,
primary key(id)
);

select * from setores;
drop table setores;

--------------------------------------------

create table funcionarios(
id int unique auto_increment,
nome varchar(64) not null,
email varchar(64) unique not null,
tel varchar(16) unique not null,
rg varchar(9) unique not null,
cpf varchar(11) unique not null,
nascimento date not null,
pis varchar(11) unique not null,
endereco varchar(200) not null,
idcargofk int not null,
idsetorfk int not null,
admissao date not null,
salario decimal(10,2) not null,
login varchar(32) unique not null,
psswrd varchar(32) not null,
desconto decimal(10,2),
primary key(id),
foreign key (idcargofk) references cargos (id),
foreign key (idsetorfk) references setores (id)
);

select * from funcionarios;
drop table funcionarios;

--------------------------------------------

create table clientes(
id int unique auto_increment,
nome varchar(64) not null,
cpf varchar(11) unique not null,
desconto decimal(10,2),
primary key(id)
);

select * from clientes;
drop table clientes;

--------------------------------------------

create table operacoes(
id int unique auto_increment,
idclientefk int,
total decimal(10,2),
troco decimal(10,2),
desconto decimal(10,2),
dataehora date not null,
primary key(id),
foreign key (idclientefk) references clientes (id)
);

create table vendas(
id int auto_increment,
idnotafiscalfk int,
idprodutofk int,
quantidade int,
primary key (id),
foreign key (idprodutofk) references produtos (id),
foreign key (idnotafiscalfk) references operacoes (id)
);

select * from vendas;
drop table vendas;
