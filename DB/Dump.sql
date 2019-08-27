/*
CREATE TABLE [Permiso]
(
	[Idpermiso] bigint NOT NULL,
	[descript] varchar(50) NULL
)
GO

CREATE TABLE [Permiso_jerarq]
(
	[Idpadre] bigint NULL,
	[Idhijo] bigint NULL
)
GO

CREATE TABLE [Usuario_permiso]
(
	[IdUsuario] bigint NULL,
	[Idpermiso] bigint NULL
)

select * from usuario;
select * from tipo_usuario;
select * from empleado;
select * from cliente;

insert into tipo_usuario(descrip) values('Empleado');
insert into tipo_usuario(descrip) values('Cliente');

insert into empleado(usuario_id,nombre,apellido,email,fec_nac,activo) values(1,'Damian','Cipolat','damian.cipolat@gmail.com',getdate(),'true');
insert into empleado(usuario_id,nombre,apellido,email,fec_nac,activo) values(2,'Sebastian','Cipolat','sebastian.cipolat@gmail.com',getdate(),'true');

select id,document,tipo_usuario,activo,fecha_alta from usuario where user='33291510' and pwd='1234';
*/

drop table usuario;
drop table tipo_usuario;
drop table usuario_estado;
drop table cliente;
drop table empleado;

insert into tipo_usuario(descrip) values('Empleado');
insert into tipo_usuario(descrip) values('Cliente');

insert into usuario_estado(cod,descrip) values('A','Activo');
insert into usuario_estado(cod,descrip) values('S','Suspendido');
insert into usuario_estado(cod,descrip) values('B','Baja');

insert into usuario(document,pwd,tipo,estado,fecha_alta,intentos) values('33295215','123',1,'A',getdate(),0);
insert into usuario(document,pwd,tipo,estado,fecha_alta,intentos) values('33291315','123',1,'A',getdate(),0);
insert into usuario(document,pwd,tipo,estado,fecha_alta,intentos) values('33291510','1234',1,'A',getdate(),0);

insert into cliente(usuario_id,nombre,apellido,email,tel) values(1,'Pepe','Felini','Pepe@gmial.com','1566587382');
insert into cliente(usuario_id,nombre,apellido,email,tel) values(2,'Pepe','Felini','Pepe@gmial.com','1566587382');
insert into cliente(usuario_id,nombre,apellido,email,tel) values(3,'Pepe','Felini','Pepe@gmial.com','1566587382');

select * from tipo_usuario;
select * from usuario;
select * from usuario_estado;
select * from cliente;
select * from empleado;