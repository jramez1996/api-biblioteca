CREATE TABLE catalogo.categoria (
    id_categoria INT IDENTITY(1,1) PRIMARY KEY,
    titulo VARCHAR(100) NOT NULL,
    descripcion VARCHAR(250) NULL,
    estado BIT NOT NULL DEFAULT 1,
    fecha_registro DATETIME DEFAULT GETDATE(),
    usuario_registro VARCHAR(50) NOT NULL,
    usuario_modificacion VARCHAR(50) NULL,
    usuario_eliminacion VARCHAR(50) NULL,
    fecha_eliminacion DATETIME NULL
);

CREATE TABLE catalogo.libro (
    id_libro INT IDENTITY(1,1) PRIMARY KEY,
    titulo VARCHAR(100) NOT NULL,
    descripcion VARCHAR(250) NULL,
    id_categoria INT NOT NULL,
    fecha_publicacion DATETIME NOT NULL,
    estado_prestamo INT NOT NULL,
    qr VARCHAR(50) NULL,
    estado BIT NOT NULL DEFAULT 1,
    fecha_registro DATETIME DEFAULT GETDATE(),
    usuario_registro VARCHAR(50) NOT NULL,
    usuario_modificacion VARCHAR(50) NULL,
    usuario_eliminacion VARCHAR(50) NULL,
    fecha_eliminacion DATETIME NULL,
    FOREIGN KEY (id_categoria) REFERENCES catalogo.categoria(id_categoria)
);

CREATE TABLE catalogo.copia_libro (
    id_copia_libro INT IDENTITY(1,1) PRIMARY KEY,
    qr VARCHAR(50) NOT NULL UNIQUE,
    estado_copia VARCHAR(50) NOT NULL,
    id_libro INT NOT NULL,
    estado BIT NOT NULL DEFAULT 1,
    fecha_registro DATETIME DEFAULT GETDATE(),
    usuario_registro VARCHAR(50) NOT NULL,
    usuario_modificacion VARCHAR(50) NULL,
    usuario_eliminacion VARCHAR(50) NULL,
    fecha_eliminacion DATETIME NULL,
    FOREIGN KEY (id_libro) REFERENCES catalogo.libro(id_libro)
);
