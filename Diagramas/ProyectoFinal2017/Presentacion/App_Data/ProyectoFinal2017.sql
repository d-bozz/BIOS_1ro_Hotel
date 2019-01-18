use master
go

--------------------------
if exists(select * from sysdatabases where name = 'ProyectoFinal2017')
begin
	drop database ProyectoFinal2017
end
go


--creo la base de datos
create database ProyectoFinal2017
go


--selecciono la base de datos
use ProyectoFinal2017
go

create table Hoteles
(
	nombreHotel varchar(50) not null primary key,
	calle varchar(50) not null,
	nroPuerta int not null,
	ciudad varchar(50) not null,
	telefono int not null,
	fax int not null,
	accesoPlaya bit not null,
	piscina bit not null,
	estrellas int not null,
	Foto varchar (100) not null
)
go

create table Habitaciones
(
	nombreHotel varchar(50) not null foreign key references Hoteles(nombreHotel),
	nroHabitacion int not null,
	piso int not null,
	cantHuepedes int not null,
	costoDiario int not null,
	descripcion varchar (50)not null,
	primary key (nombreHotel, nroHabitacion) 
	
	
)
go

create table Usuarios
(
	name varchar(50) not null primary key,
	contraseña varchar (50)not null,
	nombreCompleto varchar (50) not null,
)
go


CREATE TABLE Clientes
(
name varchar(50) primary key foreign key references Usuarios(name),
tarjeta varchar(16) not null unique,
direccion varchar (50) not null
)

go


CREATE TABLE Administradores
(
name varchar(50) primary key foreign key references Usuarios(name),
cargo varchar (50)not null
)

go

CREATE TABLE Telefonos
(
name varchar(50) foreign key references Clientes(name),
telefono int, 
PRIMARY KEY (name, telefono)
)

go

CREATE TABLE Reservas
(
id int not null identity primary key,
nombreHotel varchar (50) not null,
nroHabitacion int not null,
foreign key (nombrehotel, nrohabitacion) references habitaciones (nombrehotel, nrohabitacion),
name varchar (50) not null foreign key references usuarios(name),
fechaInicio date not null,
fechaFin date not null,
estadoActual varchar (50) not null
)

go



INSERT INTO Hoteles (nombreHotel, calle, nroPuerta, ciudad, telefono, fax, accesoPlaya , piscina, estrellas, Foto) VALUES ('Winterfell', 8, 111, 'kingslanding', 255,166,'true','true',4,'~/images/Koala.jpg')
INSERT INTO Hoteles (nombreHotel, calle, nroPuerta, ciudad, telefono, fax, accesoPlaya , piscina, estrellas, Foto) VALUES ('Caribe', 8, 111, 'kingslanding', 255,166,'true','true',4,'~/images/caribe.jpg')
INSERT INTO Hoteles (nombreHotel, calle, nroPuerta, ciudad, telefono, fax, accesoPlaya , piscina, estrellas, Foto) VALUES ('Bates', 8, 111, 'kingslanding', 255,166,'true','true',4,'~/images/Koala.jpg')


INSERT INTO Habitaciones (nombreHotel, nroHabitacion, piso, cantHuepedes, costoDiario, descripcion) VALUES ('Winterfell', 8, 21, 25, 500,'Lindo, bonito y barato.')

INSERT INTO Usuarios (name, contraseña, nombreCompleto) VALUES ('d-bozz', 'qwerty', 'Damian Boz')
INSERT INTO Usuarios (name, contraseña, nombreCompleto) VALUES ('damianh', 'qwerty', 'Damian Hernandez')
INSERT INTO Usuarios (name, contraseña, nombreCompleto) VALUES ('admin', 'admin', 'administrador')
INSERT INTO Usuarios (name, contraseña, nombreCompleto) VALUES ('cliente', 'cliente', 'carlitos')
INSERT INTO Usuarios (name, contraseña, nombreCompleto) VALUES ('cliente2', 'cliente2', 'jose')




INSERT INTO Administradores (name, cargo) VALUES ('d-bozz', 'Jefe')
INSERT INTO Administradores (name, cargo) VALUES ('admin', 'Administrativo')


INSERT INTO Clientes (name, tarjeta, direccion) VALUES ('damianh','1234567812345678','donde queda mi casa')
INSERT INTO Clientes (name, tarjeta, direccion) VALUES ('cliente','1234567812345671','Tarantino 123')
INSERT INTO Clientes (name, tarjeta, direccion) VALUES ('cliente2','1234567812345679','la casita del arbol')


INSERT INTO Telefonos (name,telefono) VALUES ('damianh',98762312)
INSERT INTO Telefonos (name,telefono) VALUES ('damianh',85728123)

INSERT INTO Reservas (nombreHotel, nroHabitacion, name, fechaInicio, fechaFin, estadoActual) VALUES ('Winterfell', 8, 'damianh', '2019-12-31', '2020-01-05','activa')
INSERT INTO Reservas (nombreHotel, nroHabitacion, name, fechaInicio, fechaFin, estadoActual) VALUES ('Winterfell', 8, 'damianh', '2020-12-31', '2021-01-05','activa')
INSERT INTO Reservas (nombreHotel, nroHabitacion, name, fechaInicio, fechaFin, estadoActual) VALUES ('Winterfell', 8, 'damianh', '2059-10-20', '2059-10-22','activa')
INSERT INTO Reservas (nombreHotel, nroHabitacion, name, fechaInicio, fechaFin, estadoActual) VALUES ('Winterfell', 8, 'damianh', '2099-10-20', '2099-10-22','activa')

INSERT INTO Reservas (nombreHotel, nroHabitacion, name, fechaInicio, fechaFin, estadoActual) VALUES ('Winterfell', 8, 'cliente2', '2020-12-31', '2021-01-05','activa')






--Logueo--
go
Create Procedure LogueoCliente
--Alter Procedure LogueoCliente 
 @usuario varchar(50),
 @contraseña varchar(50) 
  AS
Begin
	SELECT u.name, u.contraseña, u.nombreCompleto, C.tarjeta, C.direccion
	From Usuarios U inner join Clientes C on U.name = C.name
	Where u.name = @usuario and u.contraseña = @contraseña
End
go

Create Procedure LogueoAdministrador 
@usuario varchar(50), 
@contraseña varchar(50) 
AS
Begin
	Select u.name, u.contraseña, u.nombreCompleto, a.cargo
	From Usuarios U inner join Administradores A on U.name = A.name
	Where u.name = @usuario and u.contraseña = @contraseña
End
go

--Hotel--

CREATE PROC BuscarHotel
--ALTER PROC BuscarHotel
@nombreHotel varchar(50)
as
BEGIN
SELECT *  FROM Hoteles WHERE nombreHotel = @nombreHotel
END
GO

CREATE PROC EliminarHotel
--ALTER PROC EliminarHotel
@nombreHotel varchar(50)
as
BEGIN

IF NOT EXISTS (SELECT nombreHotel FROM Hoteles WHERE nombreHotel = @nombreHotel)
RETURN -1 --no esta el que quiero eliminar

DECLARE @ERROR int
BEGIN TRAN

DELETE FROM Reservas WHERE nombreHotel = @nombreHotel
SET @ERROR = @@ERROR
IF @ERROR <> 0 
BEGIN
ROLLBACK TRAN
RETURN -6 --ERROR SQL
END

DELETE FROM Habitaciones WHERE nombreHotel = @nombreHotel
SET @ERROR = @@ERROR
IF @ERROR <> 0 
BEGIN
ROLLBACK TRAN
RETURN -6 --ERROR SQL
END

DELETE FROM Hoteles WHERE nombreHotel = @nombreHotel
SET @ERROR = @@ERROR
IF @ERROR <> 0
BEGIN
ROLLBACK TRAN
RETURN -6 --ERROR SQL
END

COMMIT TRAN
RETURN 1

END
GO

CREATE PROC ModificarHotel
--ALTER PROC ModificarHotel
	@nombreHotel varchar(50),
	@calle varchar(50) ,
	@nroPuerta int,
	@ciudad varchar(50),
	@telefono int,
	@fax int,
	@accesoPlaya bit,
	@piscina bit,
	@estrellas int,
	@Foto varchar (100) 
as
BEGIN

IF NOT EXISTS (SELECT @nombreHotel FROM Hoteles WHERE nombreHotel = @nombreHotel)
RETURN -1 --no esta el que quiero modificar

DECLARE @ERROR int
UPDATE Hoteles SET nombreHotel = @nombreHotel, calle = @calle, 
nroPuerta = @nroPuerta, ciudad = @ciudad, telefono = @telefono,
fax = @fax, accesoPlaya = @accesoPlaya, piscina = @piscina, estrellas = @estrellas, Foto = @Foto 
WHERE nombreHotel = @nombreHotel
SET @ERROR = @@ERROR

IF @ERROR <> 0
RETURN -6 --ERROR SQL

RETURN 1

END	
GO

CREATE PROC AgregarHotel
--ALTER PROC AgregarHotel
@nombreHotel varchar(50),
	@calle varchar(50) ,
	@nroPuerta int,
	@ciudad varchar(50),
	@telefono int,
	@fax int,
	@accesoPlaya bit,
	@piscina bit,
	@estrellas int,
	@Foto varchar (100) 
as
BEGIN

IF EXISTS (SELECT nombreHotel FROM Hoteles WHERE nombreHotel = @nombreHotel)
RETURN -1 --Hotel repetido

DECLARE @ERROR int
INSERT Hoteles(nombreHotel, calle,nroPuerta,ciudad,telefono,fax,accesoPlaya,piscina,estrellas,Foto) 
VALUES (@nombreHotel, @calle,@nroPuerta,@ciudad,@telefono,@fax,@accesoPlaya,@piscina,@estrellas,@Foto)
SET @ERROR = @@ERROR

IF @ERROR <> 0
RETURN -6 --ERROR SQL

RETURN 1

END
GO

--Habitacion--


CREATE PROC BuscarHabitacion
--ALTER PROC BuscarHabitacion

@nombreHotel varchar(50),
@nroHabitacion varchar(50)
as
BEGIN

SELECT * FROM Habitaciones WHERE nroHabitacion = @nroHabitacion and nombreHotel = @nombreHotel
END
GO

CREATE PROC EliminarHabitacion
--ALTER PROC EliminarHabitacion
@nombreHotel varchar(50),
@nroHabitacion varchar(50)
as
BEGIN

IF NOT EXISTS (SELECT nombreHotel FROM Hoteles WHERE nombreHotel = @nombreHotel)
RETURN -1 --no existe el hotel

IF NOT EXISTS (SELECT nroHabitacion FROM Habitaciones WHERE nroHabitacion = @nroHabitacion)
RETURN -2 --no existe la habitacion


DECLARE @ERROR int
BEGIN TRAN

DELETE FROM Reservas WHERE nombreHotel = @nombreHotel AND  nroHabitacion = @nroHabitacion
SET @ERROR = @@ERROR
IF @ERROR <> 0 
BEGIN
ROLLBACK TRAN
RETURN -6 --ERROR SQL
END

DELETE FROM Habitaciones WHERE nombreHotel = @nombreHotel AND  nroHabitacion = @nroHabitacion
SET @ERROR = @@ERROR
IF @ERROR <> 0 
BEGIN
ROLLBACK TRAN
RETURN -6 --ERROR SQL
END

COMMIT TRAN
RETURN 1

END
GO

CREATE PROC ModificarHabitacion
--ALTER PROC ModificarHabitcion 
	@nombreHotel varchar(50),
	@nroHabitacion int,
	@piso int,
	@cantHuepedes int,
	@costoDiario int,
	@descripcion varchar (50)
as
BEGIN

IF NOT EXISTS (SELECT nombreHotel FROM Hoteles WHERE nombreHotel = @nombreHotel)
RETURN -1 --no existe el hotel

IF NOT EXISTS (SELECT @nroHabitacion FROM Habitaciones WHERE nroHabitacion = @nroHabitacion)
RETURN -2 --no esta el que quiero modificar

DECLARE @ERROR int
UPDATE Habitaciones SET nombreHotel = @nombreHotel, nroHabitacion = @nroHabitacion, 
piso = @piso, cantHuepedes = @cantHuepedes, costoDiario = @costoDiario,
descripcion = @descripcion 
WHERE nombreHotel = @nombreHotel AND nroHabitacion = @nroHabitacion
SET @ERROR = @@ERROR

IF @ERROR <> 0
RETURN -6 --ERROR SQL

RETURN 1

END	
GO

CREATE PROC AgregarHabitacion
--ALTER PROC AgregarHabitacion
	@nombreHotel varchar(50),
	@nroHabitacion int,
	@piso int,
	@cantHuepedes int,
	@costoDiario int,
	@descripcion varchar (50) 
as
BEGIN

IF EXISTS (SELECT nroHabitacion FROM Habitaciones WHERE nroHabitacion = @nroHabitacion)
RETURN -2 --Habitacion repetida

DECLARE @ERROR int
INSERT Habitaciones(nombreHotel, nroHabitacion,piso,cantHuepedes,costoDiario,descripcion) 
VALUES (@nombreHotel, @nroHabitacion,@piso,@cantHuepedes,@costoDiario,@descripcion)
SET @ERROR = @@ERROR

IF @ERROR <> 0
RETURN -6 --ERROR SQL

RETURN 1

END
GO

--Administrador

CREATE PROC BuscarAdministrador
--ALTER PROC BuscarAdministrador
@usuario varchar(50)
as
BEGIN
SELECT ad.name, us.contraseña, us.nombreCompleto, ad.cargo  FROM Administradores ad join Usuarios us on ad.name = us.name
where ad.name = @usuario
END
GO

CREATE PROC EliminarAdministrador
--ALTER PROC EliminarAdministrador
@usuario varchar(50)
as
BEGIN

IF NOT EXISTS (SELECT name FROM Usuarios WHERE name = @usuario)
RETURN -1 --no existe el usuario

IF NOT EXISTS (SELECT name FROM Administradores WHERE name = @usuario)
RETURN -2 --es un cliente

DECLARE @ERROR int

BEGIN TRAN
DELETE FROM Administradores WHERE name = @usuario
SET @ERROR = @@ERROR

IF @ERROR <> 0 
BEGIN
ROLLBACK TRAN
RETURN -6 --ERROR SQL
END

DELETE FROM Usuarios WHERE name = @usuario
SET @ERROR = @@ERROR

IF @ERROR <> 0 
BEGIN
ROLLBACK TRAN
RETURN -6 --ERROR SQL
END

COMMIT TRAN
RETURN 1


END
GO

CREATE PROC ModificarAdministrador
--ALTER PROC ModificarAdministrador 
	@usuario varchar(50) ,
	@contraseña varchar (50),
	@nombreCompleto varchar (50),
	@cargo varchar (50)
as
BEGIN

IF NOT EXISTS (SELECT name FROM Usuarios WHERE name = @usuario)
RETURN -1 --no existe el usuario

IF NOT EXISTS (SELECT name FROM Administradores WHERE name = @usuario)
RETURN -2 --es un cliente


DECLARE @ERROR INT
BEGIN TRAN
UPDATE Administradores SET cargo = @cargo WHERE name = @usuario
SET @ERROR = @@ERROR

IF @ERROR <> 0
BEGIN
ROLLBACK TRAN
RETURN -6 --ERROR SQL
END

UPDATE Usuarios SET contraseña = @contraseña, nombreCompleto = @nombreCompleto 
WHERE name = @usuario
SET @ERROR = @@ERROR

IF @ERROR <> 0
BEGIN
ROLLBACK TRAN
RETURN -6 --ERROR SQL
END

COMMIT TRAN
RETURN 1						

END	
GO

CREATE PROC AgregarAdministrador
--ALTER PROC AgregarAdministrador 
	@usuario varchar(50) ,
	@contraseña varchar (50),
	@nombreCompleto varchar (50),
	@cargo varchar (50)
as
BEGIN

IF EXISTS (SELECT * FROM Usuarios WHERE name = @usuario)
RETURN -1 --si ESTA no lo puedo agregar

DECLARE @ERROR int
BEGIN TRAN
INSERT Usuarios(name,contraseña,nombreCompleto) VALUES 
(@usuario,@contraseña,@nombreCompleto)

SET @ERROR = @@ERROR
IF @ERROR<>0
BEGIN
ROLLBACK TRAN
RETURN -6 --ERROR SQL
END

INSERT Administradores(name,cargo) VALUES (@usuario,@cargo)

SET @ERROR = @@ERROR
IF @ERROR<>0
BEGIN
ROLLBACK TRAN
RETURN -6 --ERROR SQL
END

COMMIT TRAN
RETURN 1						

END	
GO

--Cliente

CREATE PROC BuscarCliente
--ALTER PROC BuscarCliente
@usuario varchar(50)
as
BEGIN
SELECT u.name, u.contraseña, u.nombreCompleto, c.direccion, c.tarjeta
FROM Clientes c JOIN Usuarios u ON c.name = u.name
WHERE u.name = @usuario
END
GO



GO
CREATE PROC AgregarCliente
--ALTER PROC AgregarCliente 
	@usuario varchar(50) ,
	@contraseña varchar (50),
	@nombreCompleto varchar (50),
	@tarjeta varchar(16) ,
	@direccion varchar (50)
as
BEGIN

IF EXISTS (SELECT * FROM Usuarios WHERE name = @usuario)
RETURN -1 --si ESTA no lo puedo agregar
IF EXISTS (SELECT tarjeta FROM Clientes WHERE tarjeta = @tarjeta)
RETURN -2 --si esta la tarjeta en uso no lo puedo agregar

DECLARE @ERROR int
BEGIN TRAN
INSERT Usuarios(name,contraseña,nombreCompleto) VALUES 
(@usuario,@contraseña,@nombreCompleto)

SET @ERROR = @@ERROR
IF @ERROR<>0
BEGIN
ROLLBACK TRAN
RETURN -6 --ERROR SQL
END

INSERT Clientes(name,tarjeta,direccion) VALUES (@usuario,@tarjeta,@direccion)

SET @ERROR = @@ERROR
IF @ERROR<>0
BEGIN
ROLLBACK TRAN
RETURN -6 --ERROR SQL
END

COMMIT TRAN
RETURN 1						

END	
GO

--Listas


CREATE PROC ListarHoteles
AS
BEGIN
SELECT * FROM Hoteles
END

GO

CREATE PROC ListarHabitaciones
--alter proc ListarHabitaciones
@nombreHotel varchar (50)
AS
BEGIN
SELECT hot.nombreHotel ,hab.nroHabitacion, hab.piso, hab.cantHuepedes, hab.costoDiario, hab.descripcion
FROM Hoteles hot JOIN Habitaciones hab ON hot.nombreHotel = hab.nombreHotel
where hab.nombreHotel = @nombreHotel
END
GO


CREATE PROC ListarClientes
--ALTER PROC ListarClientes
AS
BEGIN
SELECT us.name, us.contraseña, us.nombreCompleto, cli.tarjeta, cli.direccion, tel.telefono 
FROM clientes cli JOIN usuarios us ON cli.name = us.name JOIN telefonos tel ON tel.name = cli.name

END
GO

go
CREATE PROC ListarAdmin
AS
BEGIN
SELECT us.name, us.contraseña, us.nombreCompleto, ad.cargo 
FROM Administradores ad join usuarios us on ad.name = us.name

END
GO

CREATE PROC ListarUsuarios
AS
BEGIN
SELECT * FROM Usuarios
END
GO

CREATE PROC ListarReservas
AS
BEGIN
SELECT distinct nombreHotel, nroHabitacion, name, fechaInicio, fechaFin, estadoActual, id FROM Reservas

END
GO

CREATE PROC ListarReservasActivas
AS
BEGIN

SELECT distinct nombreHotel, nroHabitacion, name, fechaInicio, fechaFin, estadoActual, id FROM Reservas
WHERE estadoActual = 'activa'

END
GO

CREATE PROC ListarReservasPorHabitacion
@NombreHotel varchar(50),
@NroHabitacion int
AS
BEGIN
SELECT * FROM Reservas WHERE nombreHotel = @NombreHotel AND nroHabitacion = @NroHabitacion
END
GO

CREATE PROC ListarTelefonosPorCliente
--ALTER PROC ListarTelefonosPorCliente
@user varchar(50)
AS
BEGIN

SELECT C.name,T.telefono FROM Telefonos T JOIN Clientes C ON T.name = C.name
WHERE @user = C.name

END



go 
CREATE PROC RealizarReserva
--ALTER PROC RealizarReserva
@nombreHotel varchar (50)
,@nroHabitacion int
,@name varchar (50)
,@fechaInicio date
,@fechaFin date
,@estadoActual varchar (50)
as
BEGIN

DECLARE @dias int
SET @dias = datediff (dd,@fechaInicio,@fechaFin)
IF @dias <1 
	RETURN -2  --No pueden haber reservas que duren menos de un dia


IF NOT EXISTS (SELECT * FROM Hoteles WHERE nombreHotel = @nombreHotel)
	RETURN -1 --No esta el hotel que me pidieron

IF NOT EXISTS (SELECT * FROM Habitaciones WHERE nroHabitacion = @nroHabitacion)
	RETURN -3 --No esta la habitacion

	IF NOT EXISTS (SELECT * FROM Usuarios WHERE name = @name)
	RETURN -4 --No esta el usuario


IF EXISTS (SELECT id FROM Reservas re 
			WHERE (@fechaInicio <= re.fechafin)  and  (@fechaFin >= re.fechaInicio) and re.estadoActual = 'activa') --a
BEGIN
	RETURN -5 --No esta disponible
END


DECLARE @ERROR int
INSERT Reservas(nombreHotel,nroHabitacion,name,fechaInicio,fechaFin,estadoActual) VALUES (@nombreHotel,@nroHabitacion,@name,@fechaInicio,@fechaFin,@estadoActual)
SET @ERROR = @@ERROR
IF @ERROR <> 0 
	RETURN -6 --ERROR SQL
RETURN 1
END



go
CREATE PROCEDURE EliminarReserva
--alter proc EliminarReserva 
@id int 
AS
BEGIN

IF NOT EXISTS (SELECT id FROM Reservas WHERE id = @id)
RETURN -1 --no existe el id

DECLARE @ERROR int
BEGIN TRAN

DELETE FROM Reservas WHERE id = @id
SET @ERROR = @@ERROR
IF @ERROR <> 0 
BEGIN
ROLLBACK TRAN
RETURN -6 --ERROR SQL
END

COMMIT TRAN
RETURN 1

END
GO

CREATE PROC FinalizarReserva
--ALTER PROC FinalizarReserva
@id int 
AS
BEGIN

IF NOT EXISTS (SELECT * FROM Reservas WHERE Reservas.id = @id)
RETURN -1 --No encuentro la reserva

DECLARE @ERROR INT
UPDATE Reservas SET estadoActual = 'FINALIZADA'
WHERE Reservas.id = @id
SET @ERROR = @@ERROR
IF @ERROR <> 0 
BEGIN
	RETURN -6 -- ERROR DE SQL
END
RETURN 1
END
GO

CREATE PROC CancelarReserva
--ALTER PROC CancelarReserva
@ID INT
AS
BEGIN

IF NOT EXISTS (SELECT * FROM Reservas WHERE Reservas.id = @id)
RETURN -1 --No encuentro la reserva

DECLARE @ERROR INT
UPDATE Reservas SET estadoActual = 'CANCELADA'
WHERE Reservas.id = @ID
SET @ERROR = @@ERROR
IF @ERROR <> 0 
BEGIN
	RETURN -6 -- ERROR DE SQL
END
RETURN 1
END
GO

CREATE PROC BuscarReserva
--ALTER PROC BuscarReserva
@ID int
AS
BEGIN

SELECT * FROM Reservas WHERE Reservas.id = @ID

END

GO
CREATE PROC AgregarTelefono
--ALTER PROC AgregarTelefono
@telefono int,
@name varchar(50)

AS
BEGIN

IF EXISTS (SELECT * FROM Telefonos WHERE (telefono = @telefono AND name = @name)) --a
BEGIN
RETURN -1 --ya hay un numero con ese nombre
END

DECLARE @ERROR int 
INSERT INTO Telefonos (name, telefono) VALUES (@name, @telefono)
SET @ERROR = @@ERROR
IF (@ERROR <> 0)
BEGIN
RETURN -6 --Error de SQL
END

RETURN 1

END

go
CREATE PROC ListarReservasPorCliente
--ALTER PROC ListarReservasPorCliente
@name varchar(50)
AS
BEGIN

SELECT distinct nombreHotel, nroHabitacion, name, fechaInicio, fechaFin, estadoActual, id  
FROM Reservas WHERE name = @name

END
go

CREATE PROC ListarReservasActivasPorCliente
--ALTER PROC ListarReservasActivasPorCliente
@name varchar(50)
AS
BEGIN

SELECT distinct nombreHotel, nroHabitacion, name, fechaInicio, fechaFin, estadoActual, id  
FROM Reservas 
WHERE name = @name
AND estadoActual = 'activa'

END
GO

CREATE PROC ListarHotelesPorEstrellas
--ALTER PROC ListarHotelesPorEstrellas
@estrellas int
AS
BEGIN
SELECT * FROM Hoteles WHERE estrellas = @estrellas
END
GO

/*
 select * from clientes
 select * from usuarios
 select * from Reservas
 select * from hoteles
 select * from habitaciones
 */