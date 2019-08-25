
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

insert into usuario(document,pwd,tipo_usuario,activo,fecha_alta) values('33295215','123',2,'true',getdate());
insert into usuario(document,pwd,tipo_usuario,activo,fecha_alta) values('33291515','123',2,'true',getdate());

insert into empleado(usuario_id,nombre,apellido,email,fec_nac,activo) values(1,'Damian','Cipolat','damian.cipolat@gmail.com',getdate(),'true');
insert into empleado(usuario_id,nombre,apellido,email,fec_nac,activo) values(2,'Sebastian','Cipolat','sebastian.cipolat@gmail.com',getdate(),'true');