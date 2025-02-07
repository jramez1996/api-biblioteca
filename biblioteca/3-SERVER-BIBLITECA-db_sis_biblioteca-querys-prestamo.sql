CREATE TABLE prestamo.prestamo (
    id_prestamo INT IDENTITY(1,1) PRIMARY KEY,
    fecha_prestamo DATETIME NOT NULL DEFAULT GETDATE(),
    fecha_devolucion_estimada DATETIME NOT NULL,
    fecha_devolucion_real DATETIME NULL,
    estado_prestamo VARCHAR(50) NOT NULL,
 
    id_cliente INT NOT NULL,
    estado BIT NOT NULL DEFAULT 1,
    fecha_registro DATETIME DEFAULT GETDATE(),
    usuario_registro VARCHAR(50) NOT NULL,
    usuario_modificacion VARCHAR(50) NULL,
    usuario_eliminacion VARCHAR(50) NULL,
    fecha_eliminacion DATETIME NULL,
    FOREIGN KEY (id_libro) REFERENCES catalogo.libro(id_libro),
    FOREIGN KEY (id_cliente) REFERENCES cliente.cliente(id_cliente)
);
CREATE TABLE prestamo.prestamo_libro (
    id_prestamo_libro INT IDENTITY(1,1) PRIMARY KEY,
    id_prestamo INT NOT NULL,
    id_copia_libro INT NOT NULL,
    estado_libro VARCHAR(50) NOT NULL,  -- Estado de la copia en préstamo, como 'pendiente', 'devuelto', etc.
    fecha_registro DATETIME DEFAULT GETDATE(),
    usuario_registro VARCHAR(50) NOT NULL,
    FOREIGN KEY (id_prestamo) REFERENCES prestamo.prestamo(id_prestamo),
    FOREIGN KEY (id_copia_libro) REFERENCES catalogo.copia_libro(id_copia_libro)
);


CREATE TABLE prestamo.reserva (
    id_reserva INT IDENTITY(1,1) PRIMARY KEY,
    fecha_reserva DATETIME NOT NULL DEFAULT GETDATE(),
    estado_reserva VARCHAR(50) NOT NULL,
    id_libro INT NOT NULL,
    id_cliente INT NOT NULL,
    estado BIT NOT NULL DEFAULT 1,
    fecha_registro DATETIME DEFAULT GETDATE(),
    usuario_registro VARCHAR(50) NOT NULL,
    usuario_modificacion VARCHAR(50) NULL,
    usuario_eliminacion VARCHAR(50) NULL,
    fecha_eliminacion DATETIME NULL,
    FOREIGN KEY (id_libro) REFERENCES catalogo.copia_libro(id_copia_libro),
    FOREIGN KEY (id_cliente) REFERENCES cliente.cliente(id_cliente)
);
CREATE TABLE prestamo.reserva_libro (
    id_reserva_libro INT IDENTITY(1,1) PRIMARY KEY,
    id_reserva INT NOT NULL,
    id_copia_libro INT NOT NULL,
    estado_libro VARCHAR(50) NOT NULL,  -- Estado de la copia reservada
    fecha_registro DATETIME DEFAULT GETDATE(),
    usuario_registro VARCHAR(50) NOT NULL,
    FOREIGN KEY (id_reserva) REFERENCES prestamo.reserva(id_reserva),
    FOREIGN KEY (id_copia_libro) REFERENCES catalogo.copia_libro(id_copia_libro)
);

CREATE TABLE prestamo.usuario_black_list (
    id_usuario_black_list INT IDENTITY(1,1) PRIMARY KEY,
    fecha_inclusion DATETIME DEFAULT GETDATE(),
    motivo VARCHAR(250) NOT NULL,
    id_cliente INT NOT NULL,
    estado BIT NOT NULL DEFAULT 1,
    fecha_registro DATETIME DEFAULT GETDATE(),
    usuario_registro VARCHAR(50) NOT NULL,
    usuario_modificacion VARCHAR(50) NULL,
    usuario_eliminacion VARCHAR(50) NULL,
    fecha_eliminacion DATETIME NULL,
    FOREIGN KEY (id_cliente) REFERENCES cliente.cliente(id_cliente)
);
