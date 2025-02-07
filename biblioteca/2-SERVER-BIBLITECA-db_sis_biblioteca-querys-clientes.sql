CREATE TABLE cliente.cliente (
    id_cliente INT IDENTITY(1,1) PRIMARY KEY,
    nombres VARCHAR(100) NOT NULL,
    apellidos VARCHAR(250) NOT NULL,
    numero_documento_identidad VARCHAR(20) NOT NULL UNIQUE,
    telefono VARCHAR(20) NULL,
    correo VARCHAR(50) NULL,
    direccion VARCHAR(100) NULL,
    id_ubigeo INT NULL,
    estado BIT NOT NULL DEFAULT 1,
    fecha_registro DATETIME DEFAULT GETDATE(),
    usuario_registro VARCHAR(50) NOT NULL,
    usuario_modificacion VARCHAR(50) NULL,
    usuario_eliminacion VARCHAR(50) NULL,
    fecha_eliminacion DATETIME NULL
);

CREATE TABLE seguridad.cliente_otp (
    id_cliente_otp INT IDENTITY(1,1) PRIMARY KEY,
    codigo VARCHAR(50) NOT NULL,
    fecha_generacion DATETIME DEFAULT GETDATE(),
    fecha_expiracion DATETIME NOT NULL,
    usuario_registro VARCHAR(50) NOT NULL,
    usuario_modificacion VARCHAR(50) NULL,
    usuario_eliminacion VARCHAR(50) NULL,
    fecha_eliminacion DATETIME NULL
);
