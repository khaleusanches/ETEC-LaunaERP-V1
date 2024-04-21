create Database testeando;
use testeando;

create table usuario(
	ID_Usuario int primary key auto_increment,
    Nome_Usuario varchar(25),
    Senha_Usuario varchar(25),
    Status_Usuario varchar(1),
    Nivel_Usuario int
);

create table fornecedores(
	ID_Fornecedor int primary key auto_increment,
    Nome_Fornecedor varchar(48),
    Categoria_Fornecedor varchar(32),
    Telefone_Fornecedor varchar(11),
    Descrição varchar(150)
);

insert into usuario(Nome_Usuario, Senha_Usuario, Status_Usuario, Nivel_Usuario) values
(
	"joao", "123", "1", 5
);
insert into fornecedores(Nome_Fornecedor, Categoria_Fornecedor, Telefone_Fornecedor, Descrição) values
('Nissin', 'Alimenticios', '11 91487-7396', 'Fornecedor de miojos');

update fornecedores 
set Nome_Fornecedor="penispenis", Categoria_Fornecedor="penis"
where ID_Fornecedor=21;


select * from fornecedores;
select * from usuario where Nome_Usuario='batata' and Senha_Usuario='clebeinho';