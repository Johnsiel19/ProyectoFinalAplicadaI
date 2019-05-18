create database UsuarioDB
go
use UsuarioDB
go
create table Usuario(
UsuarioId int primary key identity,
Nombre varchar(50),
Email varchar(50),
NivelUsuario int,
Usuario varchar(30),
Clave varchar(30),
FechaIngreso datetime
)

