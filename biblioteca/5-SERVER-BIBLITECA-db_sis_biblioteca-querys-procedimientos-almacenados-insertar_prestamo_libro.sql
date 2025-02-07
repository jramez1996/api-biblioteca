


CREATE PROCEDURE [prestamo].[insertar_prestamo_libro]
    @id_prestamo INT,
    @id_copia_libro INT,
    @estado_libro NVARCHAR(50),
    @fecha_registro DATETIME,
    @usuario_registro NVARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;
    
    -- Insertar el libro en la tabla 'prestamo_libro'
    INSERT INTO prestamo.prestamo_libro
    (
        id_prestamo,
        id_copia_libro,
        estado_libro,
        fecha_registro,
        usuario_registro
    )
    VALUES
    (
        @id_prestamo,
        @id_copia_libro,
        @estado_libro,
        @fecha_registro,
        @usuario_registro
    );
END;

