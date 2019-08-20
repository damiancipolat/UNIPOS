

CREATE TABLE [Artic_imagenes]
(
	Id varchar(50) NOT NULL,
	[archivo] varchar(50) NULL,
	[IdArticulo] varchar(50) NULL
)
GO



CREATE TABLE [Categoria]
(
	Id bigint NOT NULL,
	[descrip] varchar(50) NULL,
	[estado] varchar(50) NULL,
	[IdArticulo] bigint NULL
)
GO

CREATE TABLE [Cliente]
(
	Id bigint NOT NULL,
	[IdUsuario] bigint NULL,
	[dni] varchar(50) NULL,
	[ranking] int NULL
)
GO

CREATE TABLE [Color]
(
	Id bigint NOT NULL,
	[nombre] varchar(50) NULL,
	[rojo] varchar(50) NULL,
	[verde] varchar(50) NULL,
	[azul] varchar(50) NULL,
	[hexa] varchar(50) NULL,
	[estado] varchar(50) NULL
)
GO








CREATE TABLE [Empleado]
(
	Id bigint NOT NULL,
	[legajo] varchar(50) NULL,
	[rol] bigint NULL,
	[IdUsuario] bigint NULL,
	[password] varchar(50) NULL
)
GO



CREATE TABLE [Idiomas]
(
	[codIdioma] varchar(50) NOT NULL,
	[descr] varchar(50) NULL
)
GO

CREATE TABLE [IntegridadV]
(
	[Idtabla] varchar(50) NULL,
	[Nombre] varchar(50) NULL,
	[DVV] text NULL
)
GO


CREATE TABLE [Limites_fidelizacion]
(
	Id bigint NULL,
	[desde] date NULL,
	[hasta] date NULL,
	[aprobado_por] bigint NULL,
	[total] int NULL,
	[costo] float NULL
)
GO

CREATE TABLE [Log]
(
	Id bigint NOT NULL,
	[Type] bigint NULL,
	[fec_log] date NULL,
	[payload] LONGTEXT NULL,
	[IdUsuario] bigint NULL
)
GO

CREATE TABLE [Marca]
(
	Id bigint NOT NULL,
	[nombre] varchar(50) NULL,
	[web] varchar(50) NULL,
	[estado] varchar(50) NULL
)
GO

CREATE TABLE [MpCredenciales]
(
	[appId] varchar(50) NULL,
	[publicKey] varchar(50) NULL,
	[token] varchar(50) NULL
)
GO




CREATE TABLE [Orden_retiro]
(
	Id bigint NULL,
	[IdCompra] bigint NULL,
	[ExpendidoPor] bigint NULL,
	[fechaExp] date NULL,
	[conformidad] char(10) NULL
)
GO

CREATE TABLE [OrdenVoucher]
(
	Id bigint NULL,
	[fecDesde] date NULL,
	[fecHasta] varchar(50) NULL,
	[cargadoPor] bigint NULL,
	[valor] float NULL,
	[activo] int NULL
)
GO


GO


GO

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



CREATE TABLE [Sesion]
(
	Id bigint NOT NULL,
	[startDate] date NULL,
	[endDate] date NULL,
	[Idusuario] bigint NULL
)
GO

CREATE TABLE [Tipo_usuario]
(
	Id bigint NOT NULL,
	[descrip] varchar(50) NULL,
	[estado] varchar(50) NULL
)
GO

CREATE TABLE [TipoPago]
(
	Id bigint NOT NULL,
	[descript] varchar(50) NULL,
	[estado] varchar(50) NULL,
	[IdPago] bigint NULL
)
GO

CREATE TABLE [Usuario]
(
	Id bigint NOT NULL,
	[nombre] varchar(50) NULL,
	[apellido] varchar(50) NULL,
	[fec_nac] date NULL,
	[tipo_usuario] bigint NULL,
	[estado] varchar(50) NULL
)
GO

CREATE TABLE [Usuario_permiso]
(
	[IdUsuario] bigint NULL,
	[Idpermiso] bigint NULL
)
GO