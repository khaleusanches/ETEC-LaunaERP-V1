create database projeto;
use projeto;
drop database projeto;

--------------------------------------------

create table fornecedores(
id int auto_increment unique not null,
nome varchar(64) unique not null,
cnpj varchar(18) unique not null,
endereco varchar(200),
correioeletronico varchar(80) unique not null,
primary key(id)
);

select * from fornecedores;
drop table fornecedores;


create table telefones(
id int unique not null auto_increment,
idfornecedorfk int not null,
tel varchar(16) unique not null,
obs varchar (48),
primary key (id),
foreign key (idfornecedorfk) references fornecedores (id)
);

select * from telefones;
drop table telefones;

--------------------------------------------

create table produtos(
id int unique not null auto_increment,
nome varchar(64) unique not null,
valor decimal (10,2),
estoque int,
fornecedor varchar(64) not null,
descricao varchar(180),
primary key(id)
);

select * from produtos;
drop table produtos;

----------------------------

create table lotes(
id int unique not null auto_increment,
idprodutofk int not null,
fornecedor varchar(64) not null,
aquisicao date not null,
fabricacao date not null,
validade date not null,
notafiscal int unique not null,
localizacao varchar(32) not null,
primary key(id),
foreign key (idprodutofk) references produtos (id)
);

select * from lotes;
drop table lotes;

--------------------------------------------

create table operacoes(
id int unique not null auto_increment,
idclientefk int,
total decimal(10,2),
troco decimal(10,2),
desconto decimal(10,2),
dataehora datetime not null,
primary key(id),
foreign key (idclientefk) references clientes (id)
);


create table vendas(
id int unique not null auto_increment,
idoperacaofk int not null,
idprodutofk int,
quantidade int,
primary key (id),
foreign key (idoperacaofk) references operacoes (id)
foreign key (idprodutofk) references produtos (id),
);

select * from vendas;
drop table vendas;

--------------------------------------------

create table clientes(
id int unique not null auto_increment,
nome varchar(64) not null,
cpf varchar(11) unique not null,
desconto decimal(10,2) not null default '0.8',
primary key(id)
);

select * from clientes;
drop table clientes;

--------------------------------------------

create table setores(
id int unique not null auto_increment,
nome varchar(32) unique not null,
primary key(id)
);

select * from setores;
drop table setores;


create table cargos(
id int unique not null auto_increment,
nome varchar(32) unique not null,
descricao varchar (180),
nivel int not null,
primary key(id)
);

select * from cargos;
drop table cargos;

--------------------------------------------

create table funcionarios(
id int unique not null auto_increment,
nome varchar(64) not null,
email varchar(64) unique not null,
tel varchar(16) unique not null,
rg varchar(9) unique not null,
nascimento date not null,
pis varchar(11) unique not null,
endereco varchar(200) not null,
idcargofk int not null,
idsetorfk int not null,
admissao date not null,
salario decimal(10,2) not null,
login varchar(32) unique not null,
senha varchar(32) not null,
desconto decimal(10,2) not null default '0.7',
primary key(id),
foreign key (idcargofk) references cargos (id),
foreign key (idsetorfk) references setores (id)
);

select * from funcionarios;
drop table funcionarios;

--------------------------------------------

