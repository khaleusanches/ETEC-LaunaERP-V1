drop database projeto;

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
id int unique not null auto_increment,    primary key(id),
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

create table clientes(
id int unique not null auto_increment,    primary key(id),
nome varchar(64) not null,
cpf varchar(11) unique not null,
desconto decimal(10,2) not null default '0.9'
);

--------------------------------------------

create table operacoes(
id int unique not null auto_increment,    primary key(id),
cpfcliente varchar(11),                          
total decimal(10,2),                      check (total>=0),
troco decimal(10,2),                      check (troco>=0),
desconto decimal(10,2),
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
idsetor int not null,
idcargo int not null,
class int not null,
admissao date not null,
salario decimal(10,2) not null,
login varchar(32) unique not null,
senha varchar(32) not null,
desconto decimal(10,2) not null default '0.8'
);

--------------------------------------------

insert into fornecedores(nome, cnpj, endereco, email) values
("Fornecedor1", "XX.XXX.XXX/0001-XX", "Endereço 1", "Fornecedor1@email"),
("Fornecedor2", "XX.XXX.XXX/0002-XX", "Endereço 2", "Fornecedor2@email"),
("Fornecedor3", "XX.XXX.XXX/0003-XX", "Endereço 3", "Fornecedor3@email"),
("Fornecedor4", "XX.XXX.XXX/0004-XX", "Endereço 4", "Fornecedor4@email"),
("Fornecedor5", "XX.XXX.XXX/0005-XX", "Endereço 5", "Fornecedor5@email"),
("Fornecedor6", "XX.XXX.XXX/0006-XX", "Endereço 6", "Fornecedor6@email"),
("Fornecedor7", "XX.XXX.XXX/0007-XX", "Endereço 7", "Fornecedor7@email"),
("Fornecedor8", "XX.XXX.XXX/0008-XX", "Endereço 8", "Fornecedor8@email"),
("Fornecedor9", "XX.XXX.XXX/0009-XX", "Endereço 9", "Fornecedor9@email"),
("Fornecedor10", "XX.XXX.XXX/0010-XX", "Endereço 10", "Fornecedor10@email");

insert into telefones(idfornecedorfk, tel, obs) values
(1, "XX XX XXXX-XXX1", "Tel 1A"), (1, "XX XX XXXX-XXX2", "Tel 1B"), (1, "XX XX XXXX-XXX3", "Tel 1C"),
(2, "XX XX XXXX-XXX4", "Tel 2A"), (2, "XX XX XXXX-XXX5", "Tel 2B"), (2, "XX XX XXXX-XXX6", "Tel 2C"),
(3, "XX XX XXXX-XXX7", "Tel 3A"), (3, "XX XX XXXX-XXX8", "Tel 3B"), (3, "XX XX XXXX-XXX9", "Tel 3C"),
(4, "XX XX XXXX-XX10", "Tel 4A"), (4, "XX XX XXXX-XX11", "Tel 4B"), (4, "XX XX XXXX-XX12", "Tel 4C"),
(5, "XX XX XXXX-XX13", "Tel 5A"), (5, "XX XX XXXX-XX14", "Tel 5B"), (5, "XX XX XXXX-XX15", "Tel 5C"),
(6, "XX XX XXXX-XX16", "Tel 6A"), (6, "XX XX XXXX-XX17", "Tel 6B"), (6, "XX XX XXXX-XX18", "Tel 6C"),
(7, "XX XX XXXX-XX19", "Tel 7A"), (7, "XX XX XXXX-XX20", "Tel 7B"), (7, "XX XX XXXX-XX21", "Tel 7C"),
(8, "XX XX XXXX-XX22", "Tel 8A"), (8, "XX XX XXXX-XX23", "Tel 8B"), (8, "XX XX XXXX-XX24", "Tel 8C"),
(9, "XX XX XXXX-XX25", "Tel 9A"), (9, "XX XX XXXX-XX26", "Tel 9B"), (9, "XX XX XXXX-XX27", "Tel 9C"),
(10, "XX XX XXXX-XX28", "Tel 10A"), (10, "XX XX XXXX-XX29", "Tel 10B"), (10, "XX XX XXXX-XX30", "Tel 10C");

insert into produtos(nome, valor, estoque, descricao) values
("Produto 1", 23, 100, ""),
("Produto 2", 26, 200, ""),
("Produto 3", 24, 215, ""),
("Produto 4", 12, 133, ""),
("Produto 5", 132, 546, ""),
("Produto 6", 27, 458, ""),
("Produto 7", 23, 115, ""),
("Produto 8", 44, 746, ""),
("Produto 9", 52, 184, ""),
("Produto 10", 122,154, ""),
("Produto 11", 34, 188, ""),
("Produto 12", 56, 484, ""),
("Produto 13", 48, 44, ""),
("Produto 14", 260, 418, ""),
("Produto 15", 154, 582, ""),
("Produto 16", 51, 362, ""),
("Produto 17", 26, 54, ""),
("Produto 18", 50, 74, ""),
("Produto 19", 10, 556, ""),
("Produto 20", 184, 112, "");

insert into lotes(idprodutofk, quantidade, fornecedor, aquisicao, fabricacao, validade, notafiscal, localizacao) values
(1, 100, "Fornecedor1", 20240425, 20240331, 20240624, 1, "Sessão 1 Fileira 1 Prateleira 1"),
(2, 200, "Fornecedor1", 20240422, 20240410, 20240826, 2, "Sessão 1 Fileira 2 Prateleira 2"),
(3, 250, "Fornecedor2", 20240212, 20240108, 20240922, 3, "Sessão 1 Fileira 3 Prateleira 3"),
(4, 150, "Fornecedor2", 20240212, 20240208, 20240624, 4, "Sessão 1 Fileira 4 Prateleira 4"),
(5, 540, "Fornecedor3", 20240323, 20240318, 20240821, 5, "Sessão 1 Fileira 5 Prateleira 5"),
(6, 480, "Fornecedor3", 20240215, 20240202, 20240814, 6, "Sessão 2 Fileira 1 Prateleira 1"),
(7, 130, "Fornecedor4", 20240312, 20240228, 20240911, 7, "Sessão 2 Fileira 2 Prateleira 2"),
(8, 750, "Fornecedor4", 20240302, 20240228, 20241006, 8, "Sessão 2 Fileira 3 Prateleira 3"),
(9, 200, "Fornecedor5", 20240531, 20240516, 20241004, 9, "Sessão 2 Fileira 4 Prateleira 4"),
(10, 180, "Fornecedor5", 20240523, 20240516, 20240911, 10, "Sessão 2 Fileira 5 Prateleira 5"),
(11, 200, "Fornecedor6", 20240423, 20240412, 20240815, 11, "Sessão 3 Fileira 1 Prateleira 1"),
(12, 500, "Fornecedor6", 20240421, 20240416, 20240814, 12, "Sessão 3 Fileira 2 Prateleira 2"),
(13, 100, "Fornecedor7", 20240219, 20240210, 20240621, 13, "Sessão 3 Fileira 3 Prateleira 3"),
(14, 450, "Fornecedor7", 20240217, 20240202, 20240719, 14, "Sessão 3 Fileira 4 Prateleira 4"),
(15, 600, "Fornecedor8", 20240315, 20240314, 20240718, 15, "Sessão 3 Fileira 5 Prateleira 5"),
(16, 380, "Fornecedor8", 20240417, 20240412, 20241013, 16, "Sessão 4 Fileira 1 Prateleira 1"),
(17, 100, "Fornecedor9", 20240511, 20240501, 20240928, 17, "Sessão 4 Fileira 2 Prateleira 2"),
(18, 200, "Fornecedor9", 20240402, 20240328, 20240829, 18, "Sessão 4 Fileira 3 Prateleira 3"),
(19, 580, "Fornecedor10", 20240503, 20240428, 20240604, 19, "Sessão 4 Fileira 4 Prateleira 4"),
(20, 150, "Fornecedor10", 20240413, 20240401, 20240606, 20, "Sessão 4 Fileira 5 Prateleira 5");

insert into clientes(nome, cpf, desconto) values
('Cliente1', "1XXXXXXXXXX", "0.9"),
('Cliente2', "2XXXXXXXXXX", "0.9"),
('Cliente3', "3XXXXXXXXXX", "0.9"),
('Cliente4', "4XXXXXXXXXX", "0.9"),
('Cliente5', "5XXXXXXXXXX", "0.9"),
('Cliente6', "6XXXXXXXXXX", "0.9"),
('Cliente7', "7XXXXXXXXXX", "0.9"),
('Cliente8', "8XXXXXXXXXX", "0.9"),
('Cliente9', "9XXXXXXXXXX", "0.9"),
('Cliente10', "10XXXXXXXXX", "0.9");

insert into operacoes(cpfcliente, desconto, total, troco)values
('', '1', 20, 2),
('', '1', 44, 2.5), 
("3XXXXXXXXXX", 0.9, 86, 1.2), 
("4XXXXXXXXXX", 0.9, 13, 0.5);

insert into vendas (idoperacaofk, idprodutofk, quantidade) values
(1, 2, 1),
(2, 2, 1),
(2, 4, 1),
(3, 2, 1),
(4, 2, 1),
(4, 4, 1);

insert into setores (nome) values
("Administrativo"),
("Recursos Humanos"),
("Financeiro"),
("Vendas"),
("Logística");

insert into cargos (nome) values
("Gerente"),
("Assistente"),
("Auxiliar"),
("Operador");

insert into funcionarios (nome, email, tel, rg, nascimento, pis, endereco, idsetor, idcargo, admissao, salario, login, senha, desconto) values
("gfdssss", "fdfs@email", "XX XX XXXXX-XXX1", "XXXXXXX0X", 20000101, "XXXXXXXXXX1", "Endereço A", 1, 2, 202404, 2000, "geradm", "senhapadrao", 0.7),
("hdfs", "dgfsdf@email", "XX XX XXXXX-XXX2", "XXXXXX0XXX", 20000202, "XXXXXXXXXX2", "Endereço b", 1, 3, 202404, 1200, "astadm", "senhapadrao", 0.8),
("hfdhdf", "safas@email", "XX XX XXXXX-XXX3", "XXXXXX00XX", 20000303, "XXXXXXXXXX3", "Endereço c", 1, 2, 202404, 1100, "auxadm", "senhapadrao", 0.8),
("hfd", "dgsd@email", "XX XX XXXXX-XXX4", "XXXXXXX1XX", 20000404, "XXXXXXXXXX4", "Endereço d", 2, 3, 202404, 20000, "gerrh", "senhapadrao", 0.7),
("hf", "gfrgsedfr@email", "XX XX XXXXX-XXX5", "XXX2XXXXXX", 20000505, "XXXXXXXXXX5", "Endereço e", 2, 2, 202404, 1600, "astrh", "senhapadrao", 0.8),
("shjfgsfga", "gdsfd@email", "XX XX XXXXX-X1XX", "XX9XXXXXXX", 20000615, "XXXXXXXXXX6", "Endereço f", 2, 1, 202404, 1400, "auxrh", "senhapadrao", 0.8),
("asfasd", "grfesa@email", "XX XX XXXXX-XX1X", "XXXX4XXXXX", 20000701, "XXXXXXXXXX7", "Endereço g", 3, 1, 202404, 1200, "gerfnc", "senhapadrao", 0.8),
("fsdaswd", "geasedrfasd@email", "XX XX XXXXX-X2XX", "X5XXXXXXXX", 20000811, "XXXXXXXXXX8", "Endereço h", 3, 1, 202404, 1100, "astfnc", "senhapadrao", 0.8),
("asda", "gsdfsd@email", "XX XX XXXXX-XX7X", "XXXXXXXX6X", 20000915, "XXXXXXXXXX9", "Endereço i", 3, 2, 202404, 1600, "auxfnc", "senhapadrao", 0.8),
("fcsazdfsd", "adged@email", "XX XX XXXXX-X4XX", "XXXXX4XXXX", 20001016, "XXXXXXXXX10", "Endereço j", 4, 3, 202404, 1400, "gervnd", "senhapadrao", 0.7),
("adas", "gfeda@email", "XX XX XXXXX-XX3X", "XXXXXXXXX4", 20001112, "XXXXXXXXX11", "Endereço k", 4, 4, 202404, 1500, "astvnd", "senhapadrao", 0.8),
("asdaw", "azfd@email", "XX XX XXXXX-XXX9", "XX4XXXXXXX", 20001201, "XXXXXXXXX12", "Endereço l", 4, 5, 202404, 1100, "auxvnd", "senhapadrao", 0.8),
("ges", "aa@email", "XX XX XXXXX-2XXX", "XXXXXXX3XX", 20001120, "XXXXXXXXX13", "Endereço m", 4, 1, 202404, 1800, "oprvnd", "senhapadrao", 0.8),
("gsedf", "agad@email", "XX XX XXXXX-1XXX", "XX3XXXXXXX", 20001012, "XXXXXXXXX14", "Endereço n", 5, 2, 202404, 1600, "gerlog", "senhapadrao", 0.7),
("gfa", "hrdrf@email", "XX XX XXXXX-0XXX", "XX1XXXXXXX", 20000221, "XXXXXXXXX15", "Endereço o", 5, 1, 202404, 1400, "astlog", "senhapadrao", 0.8),
("sfa", "hgsg@email", "XX XX XXXXX-XX0X", "XXXXX1XXXX", 20000223, "XXXXXXXXX16", "Endereço p", 5, 1, 202404, 1200, "auxlog", "senhapadrao", 0.8),
("sasd", "hsfaser@email", "XX XX XXXXX-X0XX", "1XXXXXXXXX", 20000108, "XXXXXXXXX17", "Endereço q", 5, 1, 202404, 1100, "oprlog", "senhapadrao", 0.8);
