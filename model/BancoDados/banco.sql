create Database testeando;
use testeando;

create table usuario(
	ID_Usuario int primary key auto_increment,
    Nome_Usuario varchar(25),
    Senha_Usuario varchar(25),
    Status_Usuario varchar(1),
    Nivel_Usuario int
);

insert into usuario(Nome_Usuario, Senha_Usuario, Status_Usuario, Nivel_Usuario) values
(
	"beringela", "clebeinho", "1", 5
);

select * from usuario where Nome_Usuario='batata'