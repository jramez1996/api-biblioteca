CREATE PROCEDURE [prestamo].[insertar_prestamo]
    @fecha_prestamo DATETIME,
    @fecha_devolucion_estimada DATETIME,
    @estado_prestamo NVARCHAR(50),
    @id_cliente INT,
    @estado INT,
    @fecha_registro DATETIME,
    @usuario_registro NVARCHAR(50),
    @id_prestamo INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    
    -- Insertar el préstamo en la tabla 'prestamo'
    INSERT INTO prestamo.prestamo 
    (
        fecha_prestamo,
        fecha_devolucion_estimada,
        estado_prestamo,
        id_cliente,
        estado,
        fecha_registro,
        usuario_registro
    )
    VALUES
    (
        @fecha_prestamo,
        @fecha_devolucion_estimada,
        @estado_prestamo,
        @id_cliente,
        @estado,
        @fecha_registro,
        @usuario_registro
    );
    
    -- Obtener el ID del préstamo insertado
    SET @id_prestamo = SCOPE_IDENTITY();
END;
