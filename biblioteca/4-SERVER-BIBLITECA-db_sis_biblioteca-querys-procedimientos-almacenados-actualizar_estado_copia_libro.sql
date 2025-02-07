


CREATE PROCEDURE [catalogo].[actualizar_estado_copia_libro]
    @id_copia_libro INT
AS
BEGIN
    SET NOCOUNT ON;

    -- Actualizar el estado de la copia de libro
    UPDATE [db_sis_biblioteca].[catalogo].[copia_libro]
    SET estado_copia = 'Prestado'
    WHERE id_copia_libro = @id_copia_libro
      AND estado_copia = 'Disponible';
END;
