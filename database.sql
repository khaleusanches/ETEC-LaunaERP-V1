create database projeto;
use projeto;

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
id int unique not null auto_increment,    primary key(id)
nome varchar(64) unique not null,
valor decimal (10,2),
estoque int,
descricao varchar(180)
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

create table clientes(
id int unique not null auto_increment,    primary key(id),
nome varchar(64) not null,
cpf varchar(11) unique not null,
desconto decimal(10,2) not null default '0.8'
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
admissao date not null,
salario decimal(10,2) not null,
login varchar(32) unique not null,
senha varchar(32) not null,
desconto decimal(10,2) not null default '0.7'
);

--------------------------------------------

