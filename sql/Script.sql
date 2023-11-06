-- registro_universitario.dbo.calificaciones definition

-- Drop table

-- DROP TABLE registro_universitario.dbo.calificaciones;

CREATE TABLE calificaciones (
	id int IDENTITY(1,1) NOT NULL,
	id_estudiante int NULL,
	id_materia int NULL,
	puntuacion decimal(5,2) NULL,
	fecha_calificacion date NULL,
	CONSTRAINT PK__califica__3213E83F77736D93 PRIMARY KEY (id)
);


-- registro_universitario.dbo.calificaciones foreign keys

ALTER TABLE registro_universitario.dbo.calificaciones ADD CONSTRAINT FK__calificac__id_es__76969D2E FOREIGN KEY (id_estudiante) REFERENCES estudiantes(id);
ALTER TABLE registro_universitario.dbo.calificaciones ADD CONSTRAINT FK__calificac__id_ma__778AC167 FOREIGN KEY (id_materia) REFERENCES materias(id);


-- registro_universitario.dbo.departamentos definition

-- Drop table

-- DROP TABLE registro_universitario.dbo.departamentos;

CREATE TABLE departamentos (
	id int IDENTITY(1,1) NOT NULL,
	nombre_departamento nvarchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	descripcion nvarchar(200) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	ubicacion nvarchar(100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	CONSTRAINT PK__departam__3213E83F51C30EAC PRIMARY KEY (id)
);



-- registro_universitario.dbo.estudiantes definition

-- Drop table

-- DROP TABLE registro_universitario.dbo.estudiantes;

CREATE TABLE estudiantes (
	id int IDENTITY(1,1) NOT NULL,
	nombre nvarchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	apellido nvarchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	direccion nvarchar(100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	correo_electronico nvarchar(100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	numero_telefono nvarchar(20) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	CONSTRAINT PK__estudian__3213E83FC9E5B0B2 PRIMARY KEY (id)
);

-- registro_universitario.dbo.materias definition

-- Drop table

-- DROP TABLE registro_universitario.dbo.materias;

CREATE TABLE materias (
	id int IDENTITY(1,1) NOT NULL,
	nombre_materia nvarchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	descripcion nvarchar(200) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	codigo_curso nvarchar(20) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	creditos int NULL,
	ID_Profesor int NULL,
	CONSTRAINT PK__materias__3213E83F68E143F9 PRIMARY KEY (id)
);


-- registro_universitario.dbo.materias foreign keys

ALTER TABLE registro_universitario.dbo.materias ADD CONSTRAINT FK__materias__ID_Pro__6FE99F9F FOREIGN KEY (ID_Profesor) REFERENCES profesores(id);
-- registro_universitario.dbo.horarios_clases definition

-- Drop table

-- DROP TABLE registro_universitario.dbo.horarios_clases;

CREATE TABLE horarios_clases (
	id int IDENTITY(1,1) NOT NULL,
	id_materia int NULL,
	hora_inicio time NULL,
	hora_finalizacion time NULL,
	aula nvarchar(20) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	Lunes bit NULL,
	martes bit NULL,
	miercoles bit NULL,
	jueves bit NULL,
	viernes bit NULL,
	CONSTRAINT PK__horarios__3213E83F47F8D337 PRIMARY KEY (id)
);


-- registro_universitario.dbo.horarios_clases foreign keys

ALTER TABLE registro_universitario.dbo.horarios_clases ADD CONSTRAINT FK__horarios___id_ma__7A672E12 FOREIGN KEY (id_materia) REFERENCES materias(id);


-- registro_universitario.dbo.inscripciones definition

-- Drop table

-- DROP TABLE registro_universitario.dbo.inscripciones;

CREATE TABLE inscripciones (
	id int IDENTITY(1,1) NOT NULL,
	id_estudiante int NULL,
	id_materia int NULL,
	fecha_inscripcion date NULL,
	estado nvarchar(20) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	CONSTRAINT PK__inscripc__3213E83F2087BE3E PRIMARY KEY (id)
);


-- registro_universitario.dbo.inscripciones foreign keys

ALTER TABLE registro_universitario.dbo.inscripciones ADD CONSTRAINT FK__inscripci__id_es__72C60C4A FOREIGN KEY (id_estudiante) REFERENCES estudiantes(id);
ALTER TABLE registro_universitario.dbo.inscripciones ADD CONSTRAINT FK__inscripci__id_ma__73BA3083 FOREIGN KEY (id_materia) REFERENCES materias(id);


-- registro_universitario.dbo.profesores definition

-- Drop table

-- DROP TABLE registro_universitario.dbo.profesores;

CREATE TABLE profesores (
	id int IDENTITY(1,1) NOT NULL,
	nombre nvarchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	apellido nvarchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	correo_electronico nvarchar(100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	numero_telefono nvarchar(20) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	CONSTRAINT PK__profesor__3213E83FCF11B7D9 PRIMARY KEY (id)
);


CREATE PROCEDURE ConsultarCalificaciones
AS
BEGIN
    SELECT * FROM calificaciones;
END;

CREATE PROCEDURE ConsultarEstudiantes
AS
BEGIN
    SELECT * FROM estudiantes;
END;

CREATE PROCEDURE ConsultarHorariosClases
AS
BEGIN
    SELECT * FROM horarios_clases;
END;

CREATE PROCEDURE ConsultarInscripciones
AS
BEGIN
    SELECT * FROM inscripciones;
END;

CREATE PROCEDURE ConsultarMaterias
AS
BEGIN
    SELECT * FROM materias;
END;

CREATE PROCEDURE ConsultarProfesores
AS
BEGIN
    SELECT * FROM profesores;
END;

CREATE PROCEDURE CrearCalificacion
    @ID_Estudiante INT,
    @ID_Materia INT,
    @Puntuacion DECIMAL(5, 2),
    @FechaCalificacion DATE
AS
BEGIN
    INSERT INTO calificaciones (id_estudiante, id_materia, puntuacion, fecha_calificacion)
    VALUES (@ID_Estudiante, @ID_Materia, @Puntuacion, @FechaCalificacion);
END;

CREATE PROCEDURE CrearEstudiante
    @Nombre NVARCHAR(50),
    @Apellido NVARCHAR(50),
    @Direccion NVARCHAR(100),
    @CorreoElectronico NVARCHAR(100),
    @NumeroTelefono NVARCHAR(20)
AS
BEGIN
    INSERT INTO estudiantes (nombre, apellido, direccion, correo_electronico, numero_telefono)
    VALUES (@Nombre, @Apellido, @Direccion, @CorreoElectronico, @NumeroTelefono);
END;

CREATE PROCEDURE CrearHorarioClase
    @ID_Materia INT,
    @HoraInicio TIME,
    @HoraFinalizacion TIME,
    @Aula NVARCHAR(20),
    @Lunes BIT,
    @Martes BIT,
    @Miercoles BIT,
    @Jueves BIT,
    @Viernes BIT
AS
BEGIN
    INSERT INTO horarios_clases (id_materia, hora_inicio, hora_finalizacion, aula, Lunes, martes, miercoles, jueves, viernes)
    VALUES (@ID_Materia, @HoraInicio, @HoraFinalizacion, @Aula, @Lunes, @Martes, @Miercoles, @Jueves, @Viernes);
END;

CREATE PROCEDURE CrearInscripcion
    @ID_Estudiante INT,
    @ID_Materia INT,
    @FechaInscripcion DATE,
    @Estado NVARCHAR(20)
AS
BEGIN
    INSERT INTO inscripciones (id_estudiante, id_materia, fecha_inscripcion, estado)
    VALUES (@ID_Estudiante, @ID_Materia, @FechaInscripcion, @Estado);
END;

CREATE PROCEDURE CrearMateria
    @NombreMateria NVARCHAR(50),
    @Descripcion NVARCHAR(200),
    @CodigoCurso NVARCHAR(20),
    @Creditos INT,
    @ID_Profesor INT
AS
BEGIN
    INSERT INTO materias (nombre_materia, descripcion, codigo_curso, creditos, ID_Profesor)
    VALUES (@NombreMateria, @Descripcion, @CodigoCurso, @Creditos, @ID_Profesor);
END;

CREATE PROCEDURE CrearProfesor
    @Nombre NVARCHAR(50),
    @Apellido NVARCHAR(50),
    @CorreoElectronico NVARCHAR(100),
    @NumeroTelefono NVARCHAR(20)
AS
BEGIN
    INSERT INTO profesores (nombre, apellido, correo_electronico, numero_telefono)
    VALUES (@Nombre, @Apellido, @CorreoElectronico, @NumeroTelefono);
END;

CREATE PROCEDURE EliminarCalificacion
    @ID_Calificacion INT
AS
BEGIN
    DELETE FROM calificaciones WHERE id = @ID_Calificacion;
END;

CREATE PROCEDURE EliminarEstudiante
    @ID_Estudiante INT
AS
BEGIN
    DELETE FROM inscripciones WHERE id_estudiante = @ID_Estudiante;
    DELETE FROM calificaciones WHERE id_estudiante = @ID_Estudiante;
    DELETE FROM estudiantes WHERE id = @ID_Estudiante;
END;

CREATE PROCEDURE EliminarHorarioClase
    @ID_Horario INT
AS
BEGIN
    DELETE FROM horarios_clases WHERE id = @ID_Horario;
END;

CREATE PROCEDURE EliminarInscripcion
    @ID_Inscripcion INT
AS
BEGIN
    DELETE FROM inscripciones WHERE id = @ID_Inscripcion;
END;

CREATE PROCEDURE EliminarMateria
    @ID_Materia INT
AS
BEGIN
    DELETE FROM horarios_clases WHERE id_materia = @ID_Materia;
    DELETE FROM materias WHERE id = @ID_Materia;
END	;

CREATE PROCEDURE EliminarProfesor
    @ID_Profesor INT
AS
BEGIN
    DELETE FROM materias WHERE ID_Profesor = @ID_Profesor;
    DELETE FROM profesores WHERE id = @ID_Profesor;
END;

CREATE PROCEDURE ModificarCalificacion
    @ID_Calificacion INT,
    @ID_Estudiante INT = NULL,
    @ID_Materia INT = NULL,
    @Puntuacion DECIMAL(5, 2) = NULL,
    @FechaCalificacion DATE = NULL
AS
BEGIN
    DECLARE @SQL NVARCHAR(MAX);

    SET @SQL = 'UPDATE calificaciones SET ';
    
    IF @ID_Estudiante IS NOT NULL
    BEGIN
        SET @SQL = @SQL + 'id_estudiante = @ID_Estudiante, ';
    END

    IF @ID_Materia IS NOT NULL
    BEGIN
        SET @SQL = @SQL + 'id_materia = @ID_Materia, ';
    END

    IF @Puntuacion IS NOT NULL
    BEGIN
        SET @SQL = @SQL + 'puntuacion = @Puntuacion, ';
    END

    IF @FechaCalificacion IS NOT NULL
    BEGIN
        SET @SQL = @SQL + 'fecha_calificacion = @FechaCalificacion, ';
    END

    IF LEN(@SQL) > 29 -- Verifica que se hayan agregado campos para actualizar
    BEGIN
        -- Elimina la coma y espacio al final de la cadena
        SET @SQL = LEFT(@SQL, LEN(@SQL) - 1);
        
        -- Agrega la cláusula WHERE para actualizar la calificación específica
        SET @SQL = @SQL + ' WHERE id = @ID_Calificacion;';
        
        -- Ejecuta la consulta SQL dinámica
        EXEC sp_executesql @SQL,
            N'@ID_Calificacion INT, @ID_Estudiante INT, @ID_Materia INT, @Puntuacion DECIMAL(5, 2), @FechaCalificacion DATE',
            @ID_Calificacion, @ID_Estudiante, @ID_Materia, @Puntuacion, @FechaCalificacion;
    END
END;

CREATE PROCEDURE ModificarEstudiante
    @ID_Estudiante INT,
    @Nombre NVARCHAR(50) = NULL,
    @Apellido NVARCHAR(50) = NULL,
    @Direccion NVARCHAR(100) = NULL,
    @CorreoElectronico NVARCHAR(100) = NULL,
    @NumeroTelefono NVARCHAR(20) = NULL
AS
BEGIN
    DECLARE @SQL NVARCHAR(MAX);

    SET @SQL = 'UPDATE estudiantes SET ';
    
    IF @Nombre IS NOT NULL
    BEGIN
        SET @SQL = @SQL + 'nombre = @Nombre, ';
    END

    IF @Apellido IS NOT NULL
    BEGIN
        SET @SQL = @SQL + 'apellido = @Apellido, ';
    END

    IF @Direccion IS NOT NULL
    BEGIN
        SET @SQL = @SQL + 'direccion = @Direccion, ';
    END

    IF @CorreoElectronico IS NOT NULL
    BEGIN
        SET @SQL = @SQL + 'correo_electronico = @CorreoElectronico, ';
    END

    IF @NumeroTelefono IS NOT NULL
    BEGIN
        SET @SQL = @SQL + 'numero_telefono = @NumeroTelefono, ';
    END

    IF LEN(@SQL) > 15 -- Verifica que se hayan agregado campos para actualizar
    BEGIN
        -- Elimina la coma y espacio al final de la cadena
        SET @SQL = LEFT(@SQL, LEN(@SQL) - 1);
        
        -- Agrega la cláusula WHERE para actualizar el estudiante específico
        SET @SQL = @SQL + ' WHERE id = @ID_Estudiante;';
        
        -- Ejecuta la consulta SQL dinámica
        EXEC sp_executesql @SQL,
            N'@ID_Estudiante INT, @Nombre NVARCHAR(50), @Apellido NVARCHAR(50), @Direccion NVARCHAR(100), @CorreoElectronico NVARCHAR(100), @NumeroTelefono NVARCHAR(20)',
            @ID_Estudiante, @Nombre, @Apellido, @Direccion, @CorreoElectronico, @NumeroTelefono;
    END
END;

CREATE PROCEDURE ModificarHorarioClase
    @ID_Horario INT,
    @ID_Materia INT = NULL,
    @HoraInicio TIME = NULL,
    @HoraFinalizacion TIME = NULL,
    @Aula NVARCHAR(20) = NULL,
    @Lunes BIT = NULL,
    @Martes BIT = NULL,
    @Miercoles BIT = NULL,
    @Jueves BIT = NULL,
    @Viernes BIT = NULL
AS
BEGIN
    DECLARE @SQL NVARCHAR(MAX);

    SET @SQL = 'UPDATE horarios_clases SET ';
    
    IF @ID_Materia IS NOT NULL
    BEGIN
        SET @SQL = @SQL + 'id_materia = @ID_Materia, ';
    END

    IF @HoraInicio IS NOT NULL
    BEGIN
        SET @SQL = @SQL + 'hora_inicio = @HoraInicio, ';
    END

    IF @HoraFinalizacion IS NOT NULL
    BEGIN
        SET @SQL = @SQL + 'hora_finalizacion = @HoraFinalizacion, ';
    END

    IF @Aula IS NOT NULL
    BEGIN
        SET @SQL = @SQL + 'aula = @Aula, ';
    END

    IF @Lunes IS NOT NULL
    BEGIN
        SET @SQL = @SQL + 'Lunes = @Lunes, ';
    END

    IF @Martes IS NOT NULL
    BEGIN
        SET @SQL = @SQL + 'martes = @Martes, ';
    END

    IF @Miercoles IS NOT NULL
    BEGIN
        SET @SQL = @SQL + 'miercoles = @Miercoles, ';
    END

    IF @Jueves IS NOT NULL
    BEGIN
        SET @SQL = @SQL + 'jueves = @Jueves, ';
    END

    IF @Viernes IS NOT NULL
    BEGIN
        SET @SQL = @SQL + 'viernes = @Viernes, ';
    END

    IF LEN(@SQL) > 24 -- Verifica que se hayan agregado campos para actualizar
    BEGIN
        -- Elimina la coma y espacio al final de la cadena
        SET @SQL = LEFT(@SQL, LEN(@SQL) - 1);
        
        -- Agrega la cláusula WHERE para actualizar el horario de clase específico
        SET @SQL = @SQL + ' WHERE id = @ID_Horario;';
        
        -- Ejecuta la consulta SQL dinámica
        EXEC sp_executesql @SQL,
            N'@ID_Horario INT, @ID_Materia INT, @HoraInicio TIME, @HoraFinalizacion TIME, @Aula NVARCHAR(20), @Lunes BIT, @Martes BIT, @Miercoles BIT, @Jueves BIT, @Viernes BIT',
            @ID_Horario, @ID_Materia, @HoraInicio, @HoraFinalizacion, @Aula, @Lunes, @Martes, @Miercoles, @Jueves, @Viernes;
    END
END;

CREATE PROCEDURE ModificarInscripcion
    @ID_Inscripcion INT,
    @ID_Estudiante INT = NULL,
    @ID_Materia INT = NULL,
    @FechaInscripcion DATE = NULL,
    @Estado NVARCHAR(20) = NULL
AS
BEGIN
    DECLARE @SQL NVARCHAR(MAX);

    SET @SQL = 'UPDATE inscripciones SET ';
    
    IF @ID_Estudiante IS NOT NULL
    BEGIN
        SET @SQL = @SQL + 'id_estudiante = @ID_Estudiante, ';
    END

    IF @ID_Materia IS NOT NULL
    BEGIN
        SET @SQL = @SQL + 'id_materia = @ID_Materia, ';
    END

    IF @FechaInscripcion IS NOT NULL
    BEGIN
        SET @SQL = @SQL + 'fecha_inscripcion = @FechaInscripcion, ';
    END

    IF @Estado IS NOT NULL
    BEGIN
        SET @SQL = @SQL + 'estado = @Estado, ';
    END

    IF LEN(@SQL) > 24 -- Verifica que se hayan agregado campos para actualizar
    BEGIN
        -- Elimina la coma y espacio al final de la cadena
        SET @SQL = LEFT(@SQL, LEN(@SQL) - 1);
        
        -- Agrega la cláusula WHERE para actualizar la inscripción específica
        SET @SQL = @SQL + ' WHERE id = @ID_Inscripcion;';
        
        -- Ejecuta la consulta SQL dinámica
        EXEC sp_executesql @SQL,
            N'@ID_Inscripcion INT, @ID_Estudiante INT, @ID_Materia INT, @FechaInscripcion DATE, @Estado NVARCHAR(20)',
            @ID_Inscripcion, @ID_Estudiante, @ID_Materia, @FechaInscripcion, @Estado;
    END
END;

CREATE PROCEDURE ModificarMateria
    @ID_Materia INT,
    @NombreMateria NVARCHAR(50) = NULL,
    @Descripcion NVARCHAR(200) = NULL,
    @CodigoCurso NVARCHAR(20) = NULL,
    @Creditos INT = NULL,
    @ID_Profesor INT = NULL
AS
BEGIN
    DECLARE @SQL NVARCHAR(MAX);

    SET @SQL = 'UPDATE materias SET ';
    
    IF @NombreMateria IS NOT NULL
    BEGIN
        SET @SQL = @SQL + 'nombre_materia = @NombreMateria, ';
    END

    IF @Descripcion IS NOT NULL
    BEGIN
        SET @SQL = @SQL + 'descripcion = @Descripcion, ';
    END

    IF @CodigoCurso IS NOT NULL
    BEGIN
        SET @SQL = @SQL + 'codigo_curso = @CodigoCurso, ';
    END

    IF @Creditos IS NOT NULL
    BEGIN
        SET @SQL = @SQL + 'creditos = @Creditos, ';
    END

    IF @ID_Profesor IS NOT NULL
    BEGIN
        SET @SQL = @SQL + 'ID_Profesor = @ID_Profesor, ';
    END

    IF LEN(@SQL) > 20 -- Verifica que se hayan agregado campos para actualizar
    BEGIN
        -- Elimina la coma y espacio al final de la cadena
        SET @SQL = LEFT(@SQL, LEN(@SQL) - 1);
        
        -- Agrega la cláusula WHERE para actualizar la materia específica
        SET @SQL = @SQL + ' WHERE id = @ID_Materia;';
        
        -- Ejecuta la consulta SQL dinámica
        EXEC sp_executesql @SQL,
            N'@ID_Materia INT, @NombreMateria NVARCHAR(50), @Descripcion NVARCHAR(200), @CodigoCurso NVARCHAR(20), @Creditos INT, @ID_Profesor INT',
            @ID_Materia, @NombreMateria, @Descripcion, @CodigoCurso, @Creditos, @ID_Profesor;
    END
END;

CREATE PROCEDURE ModificarProfesor
    @ID_Profesor INT,
    @Nombre NVARCHAR(50) = NULL,
    @Apellido NVARCHAR(50) = NULL,
    @CorreoElectronico NVARCHAR(100) = NULL,
    @NumeroTelefono NVARCHAR(20) = NULL
AS
BEGIN
    DECLARE @SQL NVARCHAR(MAX);

    SET @SQL = 'UPDATE profesores SET ';
    
    IF @Nombre IS NOT NULL
    BEGIN
        SET @SQL = @SQL + 'nombre = @Nombre, ';
    END

    IF @Apellido IS NOT NULL
    BEGIN
        SET @SQL = @SQL + 'apellido = @Apellido, ';
    END

    IF @CorreoElectronico IS NOT NULL
    BEGIN
        SET @SQL = @SQL + 'correo_electronico = @CorreoElectronico, ';
    END

    IF @NumeroTelefono IS NOT NULL
    BEGIN
        SET @SQL = @SQL + 'numero_telefono = @NumeroTelefono, ';
    END

    IF LEN(@SQL) > 26 -- Verifica que se hayan agregado campos para actualizar
    BEGIN
        -- Elimina la coma y espacio al final de la cadena
        SET @SQL = LEFT(@SQL, LEN(@SQL) - 1);
        
        -- Agrega la cláusula WHERE para actualizar el profesor específico
        SET @SQL = @SQL + ' WHERE id = @ID_Profesor;';
        
        -- Ejecuta la consulta SQL dinámica
        EXEC sp_executesql @SQL,
            N'@ID_Profesor INT, @Nombre NVARCHAR(50), @Apellido NVARCHAR(50), @CorreoElectronico NVARCHAR(100), @NumeroTelefono NVARCHAR(20)',
            @ID_Profesor, @Nombre, @Apellido, @CorreoElectronico, @NumeroTelefono;
    END
END;

CREATE PROCEDURE ReporteEstudiantesMateriasCalificaciones
AS
BEGIN
    SELECT
        E.Nombre AS NombreEstudiante,
        E.Apellido AS ApellidoEstudiante,
        M.nombre_materia AS Materia,
        p.nombre as NombreProfesor,
        p.apellido as ApellidoProfesor,
        c.puntuacion,
        c.fecha_calificacion 
    FROM Estudiantes E
    INNER JOIN calificaciones C ON E.ID = c.ID_Estudiante
    INNER JOIN Materias M ON c.ID_Materia = M.id
    INNER JOIN profesores p on p.id = m.ID_Profesor 
    ORDER BY E.Nombre, E.Apellido, M.Nombre_Materia;
END;

CREATE PROCEDURE ReporteEstudiantesMateriasHorarios
AS
BEGIN
    SELECT
        E.Nombre AS NombreEstudiante,
        E.Apellido AS ApellidoEstudiante,
        M.nombre_materia AS Materia,
        p.nombre as NombreProfesor,
        p.apellido as ApellidoProfesor ,
        HC.lunes,
        HC.martes,
        HC.miercoles,
        HC.jueves,
        HC.viernes,
        HC.Hora_Inicio,
        HC.Hora_Finalizacion,
        HC.Aula
    FROM Estudiantes E
    INNER JOIN Inscripciones I ON E.ID = I.ID_Estudiante
    INNER JOIN Materias M ON I.ID_Materia = M.id
    LEFT JOIN horarios_clases HC ON M.ID = HC.ID_Materia
    INNER JOIN profesores p on p.id = m.ID_Profesor 
    ORDER BY E.Nombre, E.Apellido, M.Nombre_Materia;
END;
