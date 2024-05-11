use Negocios2023
go

--SP LISTAR PROVEEDORES
CREATE PROCEDURE ListarProveedores
AS
BEGIN
    SELECT * FROM tb_proveedores;
END
go

--SP INSERTAR PROVEEDOR
CREATE OR ALTER PROCEDURE InsertarProveedor
	@IdProveedor int,
    @NombreCia varchar(40),
    @NombreContacto varchar(30),
    @CargoContacto varchar(30),
    @Direccion varchar(60),
    @IdPais char(3),
    @Telefono varchar(24),
    @Fax varchar(24)
AS
BEGIN
    INSERT INTO tb_proveedores (IdProveedor, NombreCia, NombreContacto, CargoContacto, Direccion, idpais, Telefono, Fax)
    VALUES (@IdProveedor, @NombreCia, @NombreContacto, @CargoContacto, @Direccion, @IdPais, @Telefono, @Fax);
END
go

--SP ACTUALIZAR PROVEEDOR
CREATE PROCEDURE ActualizarProveedor
    @IdProveedor int,
    @NombreCia varchar(40),
    @NombreContacto varchar(30),
    @CargoContacto varchar(30),
    @Direccion varchar(60),
    @IdPais char(3),
    @Telefono varchar(24),
    @Fax varchar(24)
AS
BEGIN
    UPDATE tb_proveedores
    SET NombreCia = @NombreCia,
        NombreContacto = @NombreContacto,
        CargoContacto = @CargoContacto,
        Direccion = @Direccion,
        idpais = @IdPais,
        Telefono = @Telefono,
        Fax = @Fax
    WHERE IdProveedor = @IdProveedor;
END
go

--SP ELIMINAR PROVEEDOR
CREATE PROCEDURE EliminarProveedor
    @IdProveedor int
AS
BEGIN
    DELETE FROM tb_proveedores WHERE IdProveedor = @IdProveedor;
END
go

CREATE PROCEDURE ListarPaises
AS
BEGIN
    SELECT IdPais, NombrePais FROM tb_paises;
END
go

--SP SELECCIONAR PROVEEDOR
CREATE PROCEDURE SeleccionarProveedor
    @IdProveedor int
AS
BEGIN
    SELECT *
    FROM tb_proveedores
    WHERE IdProveedor = @IdProveedor;
END
GO