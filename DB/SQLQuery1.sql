-- Borrado de tablas.
drop table if exists color;
drop table if exists marca;
drop table if exists categoria;
drop table if exists proveedor;
drop table if exists articulo;
drop table if exists Artic_imagenes;
drop table if exists compras;
drop table if exists Artic_compras;
drop table if exists comentarios;
drop table if exists cupon;
drop table if exists pago;
drop table if exists factura;
drop table if exists Item_Factura;
drop table if exists Nota_credito;
drop table if exists oferta;
drop table if exists oferta_estado;
drop table if exists oferta_firmas;
drop table if exists bitacora;
drop table if exists MpCredenciales;
drop table if exists Orden_retiro;
drop table if exists OrdenVoucher;
drop table if exists sesion;
drop table if exists [Limites_fidelizacion];
drop table if exists Usuario;
drop table if exists [Tipo_usuario];
drop table if exists Cliente;
drop table if exists Empleado;
drop table if exists IntegridadV;
drop table if exists Diccionario_idioma;
drop table if exists Diccionario_palabra;
drop table if exists Diccionario_base;

-- Creacion de tablas
CREATE TABLE [Color]
(
	Id bigint NOT NULL identity(1,1) primary key,
	[nombre] varchar(50) NULL,
	[rojo] varchar(50) NULL,
	[verde] varchar(50) NULL,
	[azul] varchar(50) NULL,
	[hexa] varchar(50) NULL,
	[estado] varchar(50) NULL
)
GO

CREATE TABLE [Marca]
(
	Id bigint NOT NULL identity(1,1) primary key,
	[nombre] varchar(50) NULL,
	[web] varchar(50) NULL,
	[estado] varchar(50) NULL
)
GO

CREATE TABLE [Categoria]
(
	Id bigint NOT NULL identity(1,1) primary key,
	[descrip] varchar(50) NULL,
	[estado] varchar(50) NULL,
	[IdArticulo] bigint NULL
)
GO

CREATE TABLE [Proveedor]
(
	Id bigint NOT NULL identity(1,1) primary key,
	[nombre] varchar(100) NULL,
	[email] varchar(50) NULL,
	[direccion] varchar(50) NULL,
	[estado] varchar(50) NULL
)
GO

CREATE TABLE [Articulo]
(
	Id bigint NOT NULL identity(1,1) primary key,
	[color] bigint NULL,
	[categoria] bigint NULL,
	[estado] char(50) NULL,
	[marca] bigint NULL,
	[precio_venta] decimal NULL,
	[descrip] varchar(50) NULL,
	[lote] varchar(50) NULL,
	[stock] int NULL,
	[IdColor] bigint NULL,
	[IdMarca] bigint NULL,
	[IdProveedor] bigint NULL,
	[IdCategoria] bigint NULL,
	[IdImagen] varchar(50) NULL,
	[activo] varchar(50) NULL
)
GO

CREATE TABLE [Artic_imagenes]
(
	Id bigint NOT NULL identity(1,1) primary key,
	[archivo] varchar(50) NULL,
	[IdArticulo] varchar(50) NULL
)
GO

CREATE TABLE [Compras]
(
	Id bigint NOT NULL identity(1,1) primary key,
	[total] float NULL,
	[IdUsuario] bigint NULL,
	[IdTipoPago] bigint NULL,
	[fec_compra] date NULL,
	[codDescuento] varchar(50) NULL,
	[estado] varchar(50) NULL,
	[hash] text NULL
)
GO

CREATE TABLE [Artic_compras]
(
	Id bigint not NULL identity(1,1) PRIMARY KEY,
	[IdArticulo] bigint NULL
)
GO

CREATE TABLE [Comentarios]
(
	Id bigint not NULL identity(1,1) PRIMARY KEY,
	[texto] varchar(50) NULL,
	[IdUsuario] bigint NULL,
	[fec_alta] date NULL,
	[indice_aceptacion] int NULL,
	[IdCompra] bigint NULL,
	[estado] varchar(50) NULL
)
GO

CREATE TABLE [Cupon]
(
	[codDescuento] varchar(50) NOT NULL primary key,
	[fec_emision] date NULL,
	[fec_vencimiento] date NULL,
	[valor] float NULL,
	[estado] varchar(50) NULL,
	[IdUsuario] bigint NULL
)
GO

CREATE TABLE [Pago]
(
	Id bigint not NULL identity(1,1) PRIMARY KEY,
	[fecPago] date NULL,
	[IdCompra] bigint NULL,
	[estado] varchar(50) NULL,
	[paymendtData] text NULL,
	[hash] text NULL
)
GO

CREATE TABLE [Factura]
(
	Id bigint not NULL identity(1,1) PRIMARY KEY,
	[fecEmision] date NULL,
	[total] float NULL,
	[numFactura] varchar(50) NULL,
	[idCliente] bigint NULL,
	[urlComprobante] varchar(50) NULL,
	[emailEnvio] varchar(50) NULL,
	[tipo] varchar(50) NULL,
	[estado] char(10) NULL
)
GO

CREATE TABLE Item_Factura
(
	Id bigint not NULL identity(1,1) PRIMARY KEY,
	[IdFactura] bigint NULL,
	[IdArticulo] bigint NULL,
	[Valor] float NULL
)
GO


CREATE TABLE [Nota_credito]
(
	Id bigint not NULL identity(1,1) PRIMARY KEY,
	[idfactura] bigint NOT NULL,
	[fecNota] date NULL,
	[urlNota] varchar(50) NULL
)
GO

CREATE TABLE [Oferta]
(
	Id bigint not NULL identity(1,1) PRIMARY KEY,
	[desde] date NULL,
	[hasta] date NULL,
	[valor] float NULL,
	[Idcategoria] bigint NULL,
	[Idmarca] bigint NULL,
	[estado] varchar(50) NULL
)
GO

CREATE TABLE [oferta_estado]
(
	Id bigint not NULL identity(1,1) PRIMARY KEY,
	[descrip] varchar(50) NULL
)
GO

CREATE TABLE [oferta_firmas]
(
	Id bigint not NULL identity(1,1) PRIMARY KEY,
	[idoferta] bigint NOT NULL,
	[idfirmante] bigint NULL,
	[aprueba] char(10) NULL,
	[fechaFirma] date NULL
)
GO

CREATE TABLE Bitacora
(
	Id bigint not NULL identity(1,1) PRIMARY KEY,
	[Type] bigint NULL,
	[fec_log] date NULL,
	[payload] TEXT not NULL,
	[IdUsuario] bigint NULL
)
GO

CREATE TABLE [MpCredenciales]
(
	Id bigint not NULL identity(1,1) PRIMARY KEY,
	[publicKey] varchar(50) NULL,
	[token] varchar(50) NULL
)
GO

CREATE TABLE [Orden_retiro]
(
	Id bigint not NULL identity(1,1) PRIMARY KEY,
	[IdCompra] bigint NULL,
	[ExpendidoPor] bigint NULL,
	[fechaExp] date NULL,
	[conformidad] char(10) NULL
)
GO

CREATE TABLE [OrdenVoucher]
(
	Id bigint not NULL identity(1,1) PRIMARY KEY,
	[fecDesde] date NULL,
	[fecHasta] varchar(50) NULL,
	[cargadoPor] bigint NULL,
	[valor] float NULL,
	[activo] int NULL
)
GO

CREATE TABLE [Limites_fidelizacion]
(
	Id bigint not NULL identity(1,1) PRIMARY KEY,
	[desde] date NULL,
	[hasta] date NULL,
	[aprobado_por] bigint NULL,
	[total] int NULL,
	[costo] float NULL
)
GO

CREATE TABLE [Sesion]
(
	Id bigint not NULL identity(1,1) PRIMARY KEY,
	[startDate] date NULL,
	[endDate] date NULL,
	[Idusuario] bigint NULL
)
GO

CREATE TABLE [Tipo_usuario]
(
	Id bigint not NULL identity(1,1) PRIMARY KEY,
	[descrip] varchar(50) NULL
)
GO

CREATE TABLE [Usuario]
(
	Id bigint not NULL identity(1,1) PRIMARY KEY,
	document varchar(20),
	pwd varchar(100),
	tipo bigint,
	estado varchar(10),
	fecha_alta datetime,
	intentos int
)
GO

CREATE TABLE Usuario_Estado
(
	cod varchar(10),
	descrip varchar(100)
)
GO

CREATE TABLE [Cliente]
(
	Id bigint not NULL identity(1,1) PRIMARY KEY,
	usuario_id varchar(20),
	nombre varchar(100),
	apellido varchar(100),
	email varchar(100),
	tel varchar(100)
)
GO

CREATE TABLE Empleado
(
	Id bigint not NULL identity(1,1) PRIMARY KEY,
	usuario_id bigint,
	nombre varchar(100),
	apellido varchar(100),
	email varchar(100),
	fec_nac varchar(100)
)
GO

CREATE TABLE [IntegridadV]
(
	[Idtabla] varchar(50) NULL,
	[Nombre] varchar(50) NULL,
	[DVV] text NULL
)
GO

create table Diccionario_base
(
	Id		 bigint NOT NULL identity(1,1) primary key,
	IdIdioma bigint NOT NULL,
	[key]	 varchar(50),
	valor	 varchar(100)
)
GO

create table Diccionario_palabra
(
	Id    bigint NOT NULL identity(1,1) primary key,
	[key] varchar(50) NULL
)
GO

create table Diccionario_idioma
(
	Id bigint NOT NULL identity(1,1) primary key,
	[descrip]	varchar(50) NULL
)
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

CREATE TABLE [Usuario_permiso]
(
	[IdUsuario] bigint NULL,
	[Idpermiso] bigint NULL
)
GO