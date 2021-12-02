create database Sistema_matricula
GO

--Tabla que almacena periodos
create table Periodo(
    fecha_inicio Date not null,
    fecha_final Date not null,
    anho int not null,
    numero int not null,
    nota_minima int not null,
    estado int not null,
    CONSTRAINT verif_anho check(anho>2021),
    constraint pk_periodo primary key (anho, numero)
);


--Tabla que almacena usuarios
create table Usuario(
    nombre varchar(50) not null,
    apellido1 varchar(50) not null,
    apellido2 varchar(50) not null,
    cedula int not null,
    telefono int,
    ciudad varchar(50),
    canton varchar(50),
    fecha_nacimiento Date not null,
    fecha_creacion Date not null,
    sexo varchar(50) not null,
    passw varchar(50) not null,
    constraint pk_usuario primary key (cedula)
);

alter table Usuario add apellido1 varchar(50);
alter table Usuario add apellido2 varchar(50);

--Tabla que almacena padres de estudiantes
create table Padre(
    nombre_conyugue varchar(50),
    telefono_conyugue int,
    profesion varchar(50),
    cedula int not null,
    constraint fk_usuario_padre foreign key (cedula) references Usuario (cedula),
    constraint pk_padre primary key (cedula)
);

--Tabla para nuevos roles
create table roll(
    nombre varchar(50) not null,
    permisos int not null, --atributo que determina los permisos de usuario que tendra el roll
    cedula int not null,
    constraint fk_usuario_roll foreign key (cedula) references Usuario(cedula),
    constraint pk_roll primary key (cedula)
);

--Tabla que almacena grados
create table Grado(
    numero int not null,
    descripcion varchar(100) not null,
    constraint pk_grado primary key (numero)
);

--Tabla que almacena materias por grado
create table Materia_Grado(
    descripcion_materia varchar(50) not null,
    nombre varchar(50) not null,
    numero_grado int not null,
    costo int not null,
    constraint fk_grado_materia foreign key (numero_grado) references Grado (numero),
    constraint pk_materia_grado primary key (nombre, numero_grado)
);

--Tabla que almacena grupos
create table Grupo(
    nombre_materia varchar(50) not null,
    codigo varchar(50) not null,
    cupo int not null,
    numero_grado int not null,
    numero_periodo int not null,
    anho_periodo int not null,
    estado int not null,
    constraint fk_materia_grupo foreign key (nombre_materia, numero_grado) references Materia_grado (nombre, numero_grado),
    constraint fk_periodo_grupo foreign key (anho_periodo, numero_periodo) references Periodo (anho, numero),
    constraint pk_grupo primary key (codigo, anho_periodo, numero_periodo, nombre_materia, numero_grado)
);

--Tabla que almacena estudiantes
create table Estudiante(
    numero_grado int not null,
    cedula_padre int not null,
    cedula int not null,
    constraint fk_grado_estudiante foreign key (numero_grado) references Grado (numero),
    constraint fk_padre_estudiante foreign key (cedula_padre) references Padre (cedula),
    constraint fk_usuario_estudiante foreign key (cedula) references Usuario (cedula),
    constraint pk_estudiante primary key (cedula)
);

--Tabla que almacena estudiantes ligados a grupos
create table Estudiante_grupo(
    cedula_estudiante int not null,
    codigo_grupo varchar(50) not null,
    periodo int not null,
    anho_periodo int not null,
    nombre_materia varchar(50) not null,
    numero_grado int not null,
    notaTotal float not null,
    constraint fk_grupo_estudiante foreign key (codigo_grupo, anho_periodo, periodo, nombre_materia, numero_grado) references Grupo (codigo, anho_periodo, numero_periodo, nombre_materia, numero_grado),
    constraint fk_estudiante_grupo foreign key (cedula_estudiante) references Estudiante (cedula),
    constraint pk_estudiante_grupo primary key (cedula_estudiante, codigo_grupo, anho_periodo, periodo, nombre_materia, numero_grado)
);

--Tabla que almacena evaluaciones ligadas a grupos
create table Evaluacion_grupo(
    nombre_materia varchar(50) not null,
    grado int not null,
    numero_periodo int not null,
    anho_periodo int not null,
    grupo varchar(50) not null,
    porcentaje decimal not null,
    criterio varchar(50) not null,
    constraint fk_grupo_evaluacion foreign key (grupo, anho_periodo, numero_periodo, nombre_materia, grado) references Grupo (codigo, anho_periodo, numero_periodo, nombre_materia, numero_grado),
    constraint pk_evaluacion primary key (grupo, anho_periodo, numero_periodo, nombre_materia, grado, criterio)
);

--Tabla que almacena las evaluaciones asociadas a estudiantes de un determinado grupo
create table Evaluacion_estudiante_grupo(
    nombre_materia varchar(50) not null,
    grado int not null,
    numero_periodo int not null,
    anho_periodo int not null,
    grupo varchar(50) not null,
    criterio varchar(50) not null,
    cedula_estudiante int not null,
    nota float not null,
    constraint fk_grupo_evaluacion_estudiante foreign key (grupo, anho_periodo, numero_periodo, nombre_materia, grado, criterio) references Evaluacion_grupo (grupo, anho_periodo, numero_periodo, nombre_materia, grado, criterio),
    constraint fk_estudiante_evaluacion_grupo foreign key (cedula_estudiante, grupo, anho_periodo, numero_periodo, nombre_materia, grado) references Estudiante_Grupo (cedula_estudiante, codigo_grupo, anho_periodo, periodo, nombre_materia, numero_grado),
    constraint pk_evaluacion_estudiante_grupo primary key (grupo, anho_periodo, numero_periodo, nombre_materia, grado, criterio, cedula_estudiante)
);

--Tabla que almacena el registro de asistencias de un estudiante para un determinado grupo
create table Asistencia(
    fecha date not null,
    codigo_grupo varchar(50) not null,
    numero_periodo int not null,
    anho_periodo int not null,
    nombre_materia varchar(50) not null,
    grado int not null,
    cedula_estudiante int not null,
    estado int not null,
    constraint fk_grupo_asistencia foreign key (cedula_estudiante, codigo_grupo, anho_periodo, numero_periodo, nombre_materia, grado) references Estudiante_Grupo (cedula_estudiante, codigo_grupo, anho_periodo, periodo, nombre_materia, numero_grado),
    constraint pk_asistencia primary key (cedula_estudiante, codigo_grupo, anho_periodo, numero_periodo, nombre_materia, grado, fecha)
);

--Tabla que almacena los registros de matricula
create table Matricula(
    estudiante int not null,
    numero_periodo int not null,
    anho_periodo int not null,
    codigo_grupo varchar(50) not null,
    materia varchar(50) not null,
    estado varchar(50) not null,
    grado int not null,
    constraint estudiante_matricula foreign key (estudiante) references Estudiante(cedula),
    constraint grupo_matricula foreign key (codigo_grupo, anho_periodo, numero_periodo, materia, grado) references Grupo (codigo, anho_periodo, numero_periodo, nombre_materia, numero_grado),
    constraint pk_matricula primary key (estudiante, anho_periodo, numero_periodo, codigo_grupo, materia, grado)
);

--Tabla que almacena profesores
create table Profesor(
    cedula int not null,
    constraint fk_usuario_profesor foreign key (cedula) references Usuario(cedula),
    constraint pk_profesor primary key (cedula)
);

--Tabla que almacena administradores
create table Administrador(
    cedula int not null,
    constraint fk_usuario_administrador foreign key (cedula) references Usuario(cedula),
    constraint pk_administrador primary key (cedula)
);

--Tabla que almacena profesores ligados a un grupo
create table profesor_grupo(
    numero_periodo int not null,
    anho_periodo int not null,
    nombre_materia varchar(50) not null,
    grado int not null,
    grupo varchar(50),
    profesor int not null,
    constraint fk_profesor_grupo foreign key (profesor) references Profesor(cedula),
    constraint fk_grupo_Profesor foreign key (grupo, anho_periodo, numero_periodo, nombre_materia, grado) references Grupo (codigo, anho_periodo, numero_periodo, nombre_materia, numero_grado),
)

--Tabla que registra el salario de un profesor
create table Salario(
    monto_salario int not null,
    inicio_periodo_salario Date not null,
    final_periodo_salario Date not null,
    profesor int not null,
    concepto varchar(50) not null,
    constraint fk_profesor_salario foreign key (profesor) references Profesor(cedula),
    constraint pk_salario primary key (profesor, inicio_periodo_salario, final_periodo_salario)
);

drop table Factura
--Tabla que almacena las facturas
create table Factura(
    numero int not null,
    monto int not null,
    cedula_padre int not null,
    constraint fk_padre_factura foreign key (cedula_padre) references Padre (cedula),
    constraint pk_factura primary key(numero)
);
drop table Cobro
--Tabla que almacena los cobros ligados a un estudiante
create table Cobro(
    monto int not null,
    estudiante int not null,
    codigo_grupo varchar(50) not null,
    numero_periodo int not null,
    anho_periodo int not null,
    fecha_generacion date not null,
    fecha_pago date not null,
    estado varchar(50) not null,
    concepto varchar(100) not null,
    materia varchar(50) not null,
    grado int not null,
    numero_factura int,
    constraint fk_matricula_cobro foreign key (estudiante, anho_periodo, numero_periodo, codigo_grupo, materia, grado) references Matricula (estudiante, anho_periodo, numero_periodo, codigo_grupo, materia, grado),
    constraint fk_factura_cobro foreign key (numero_factura) references Factura(numero),
    constraint pk_cobro primary key (estudiante, anho_periodo, numero_periodo, codigo_grupo, materia, grado, fecha_pago)
);

--Recibe los datos de un grupo
--Suma los porcentajes de todas las evaluaciones de un grupo especifico
create function dbo.sumaEvaluaciones(@codigo_grupo varchar(50), @anho_periodo int, @numero_periodo int, @materia varchar(50))
returns int
AS
begin
declare @ret int
select @ret = sum(ev_g.porcentaje) from Evaluacion_grupo as ev_g where ev_g.grupo = @codigo_grupo and ev_g.anho_periodo = @anho_periodo and ev_g.numero_periodo = @numero_periodo and ev_g.nombre_materia = @materia
return @ret
end

print cast(dbo.sumaEvaluaciones ('45ES', 2023, 2, 'Español') as char(3))


--recibe todos los datos de un Periodo
--Registra un periodo dentro de la tabla correspondiente
create procedure registro_periodo(
    @numero int,
    @anho int,
    @nota_minima int,
    @fecha_inicio date,
    @fecha_final date,
    @estado int )
    as
    begin
        insert into Periodo values(@fecha_inicio, @fecha_final, @anho, @numero, @nota_minima, @estado)
    end
   
--los datos necesarios para eliminar un periodo
--elimina un periodo de la tabla correspondiente
create procedure eliminacion_periodo(
    @numero int,
    @anho int)
    as
    begin
        delete from Periodo where numero = @numero and anho = @anho
    end


--Recibe un grado y los datos del periodo requerido
--Devuelve una tabla que contiene grupos con cupos diferentes de 0
create function grupoConCupo(@grado int, @periodo int,@anho int)
returns table 
as
RETURN
(select codigo, anho_periodo, numero_periodo, nombre_materia, numero_grado from Grupo as G where G.numero_grado = @grado and G.numero_periodo = @periodo and G.anho_periodo = @anho and G.cupo != 0)

drop proc registrarMatricula
--Recibe los datos del estudiante y el grupo al que se desea matricular
--Registra una matricula en su respectiva tabla
create procedure registrarMatricula
    (@estudiante int, 
    @grupo varchar(50), 
    @anho_periodo int, 
    @numero_periodo int, 
    @materia varchar(50), 
    @grado int,
    @cedula_padre int,
    @fecha_generacion date,
    @fecha_pago date)
as

BEGIN
    --declare @tabla table
    --set @tabla = 
    declare @entrar int, @codigo varchar(50), @periodoA int, @anhoA int, @materiaA varchar(50), @gradoA int;
    set @entrar = 0
    --if (exists(select codigo, anho_periodo, numero_periodo, nombre_materia, numero_grado from Grupo as G where G.numero_grado = @grado and G.numero_periodo = @numero_periodo and G.anho_periodo = @anho_periodo and G.cupo != 0))
    declare cursoActual cursor local
        for select codigo, numero_periodo, anho_periodo, nombre_materia, numero_grado from Grupo as G where G.numero_grado = @grado and G.numero_periodo = @numero_periodo and G.anho_periodo = @anho_periodo
        open cursoActual
        FETCH next from cursoActual into @codigo, @periodoA, @anhoA, @materiaA, @gradoA;
        while @@fetch_status = 0
        BEGIN
            if (exists(select codigo, anho_periodo, numero_periodo, nombre_materia, numero_grado from Grupo as G where G.numero_grado = @grado and G.numero_periodo = @numero_periodo and G.anho_periodo = @anho_periodo and G.cupo != 0)) and @entrar=0
            begin
                set @entrar = 1
                insert into matricula(codigo_grupo, anho_periodo, numero_periodo, materia, grado, estudiante) values (@grupo, @anho_periodo, @numero_periodo, @materia, @grado, @estudiante);
                exec registro_estudiante @gradoA, @cedula_padre, @estudiante 
                exec registro_estudiante_grupo @estudiante,  @codigo, @periodoA, @anhoA, @materiaA, @gradoA
                exec registro_cobro @estudiante, @codigo, @periodoA, @anhoA, @fecha_generacion, @fecha_pago, 'por pagar', 'Matricula', @materiaA, @gradoA
                --exec generarMensualidades(@estudiante, @codigo, @anhoA, @materiaA, @gradoA, @periodoA, @cedula_padre, @fecha_generacion, @fecha_pago)
            end
            fetch next from cursoActual into @codigo, @periodoA, @anhoA, @materiaA, @gradoA
        END
    close cursoActual
    deallocate cursoActual
end

create procedure generarMensualidades(
    @estudiante int, 
    @grupo varchar(50), 
    @anho_periodo int, 
    @numero_periodo int, 
    @materia varchar(50), 
    @grado int,
    @cedula_padre int,
    @fecha_generacion date,
    @fecha_pago date)
    AS
    BEGIN
        declare @meses int
        set @meses = 0
        while @meses <> 12
        set @fecha_pago = (CONVERT(varchar(110),DATEADD(month,@meses,GETDATE()),107) AS [MMM-DD-YYYY])
        BEGIN
            exec registro_cobro @estudiante, @grupo, @numero_periodo, @anho_periodo, @fecha_generacion, @fecha_pago, 'por pagar', 'Mensualidad', @materia, @grado
        END
    END

--Recibe los datos de un estudiante y del grupo al que es ligado
--Registra a un estudiante ligado a un grupo, en la tabla de estudiantes por grupo
create procedure registro_estudiante_grupo
    (@estudiante int, 
    @grupo varchar(50), 
    @numero_periodo int, 
    @anho_periodo int, 
    @materia varchar(50), 
    @grado int)
as
BEGIN
    declare @grado_est INT
    select @grado_est = Estudiante.numero_grado from Estudiante where Estudiante.cedula = @estudiante
    if(@grado_est = @grado)
    begin
        insert into Estudiante_grupo values (@estudiante, @grupo, @numero_periodo, @anho_periodo, @materia, @grado);
	end
END

--Recibe todos los datos de un grupo
--Registra un grupo en la base de datos
create procedure registrar_grupo
    (@anho_periodo int,
    @numero_periodo int,
    @codigo varchar(50),
    @materia varchar(50),
    @grado int,
    @estado int,
    @cupo int)
AS
begin
    insert into Grupo values (@materia,@codigo,@cupo,@grado,@numero_periodo,@anho_periodo,@estado)
end

--los datos necesarios para la eliminacion de un grupo
--elimina un grupo en la base de datos
create procedure eliminar_grupo
    (@anho_periodo int,
    @numero_periodo int,
    @codigo varchar(50),
    @materia varchar(50),
    @grado int)
AS
begin
    delete from Grupo where codigo = @codigo and numero_periodo = @numero_periodo and anho_periodo = @anho_periodo and nombre_materia = @materia and numero_grado = @grado
end

--Recibe la cedula de un estudiante
--Devuelve verdadero(1) en caso de que exista un estudiante con la cedula indicada
create function verificarEstudiante(@cedula int)
returns INT
AS
BEGIN
    declare @comp INT, @ret int
    set @ret = 0
    select @comp = cedula from Estudiante where @cedula = cedula
    if(@cedula = @comp)
        BEGIN   
            set @ret = 1
        END
    return @ret
END

--Recibe todos los datos de un estudiante
--Registra a un estudiante en la tabla correspondiente
create procedure registro_estudiante
    (
    @grado int,
    @cedula_padre int,
    @cedula int
    )
    AS
    BEGIN
    declare @existencia INT
        set @existencia = dbo.verificarEstudiante(@cedula)
        if(@existencia = 0)
        begin
            insert into Estudiante values(@grado, @cedula_padre, @cedula)
        end
    END
    
--Recibe los datos necesarios para la elinminacion de un estudiante
--elimina a un estudiante en la tabla correspondiente
create procedure eliminar_estudiante
    (
    @cedula int
    )
    AS
    BEGIN
    declare @existencia INT
        set @existencia = dbo.verificarEstudiante(@cedula)
        if(@existencia = 0)
        begin
            delete from Estudiante where cedula = @cedula
        end
    END

------ Información de usuarios mal planteada, se crearón funciones en lugar de vistas, y tabla de usuarios falta de los atributos "apellido1" y "apellido2"

--Retorna la informacion general de todos los estudiantes
create view informacionUsuarios as (select u.nombre from Usuario as u)

create VIEW informacionEstudiantes as
(select u.nombre, u.apellido1, u.apellido2, e.cedula, e.grado, u.sexo, u.telefono, u.ciudad from Estudiante as e inner join Usuario as u on e.cedula = u.cedula)

--Retorna la informacion general de todos los profesores
create view informacionProfesor
as
(select u.nombre, u.apellido1, u.apellido2, p.cedula, u.sexo, u.telefono, u.ciudad from Profesor as p inner join Usuario as u on e.cedula = u.cedula)

--Retorna la informacion general de todos los padres
create function informacionPadre
as
(select u.nombre, u.apellido1, u.apellido2, e.cedula,e.nombre_conyugue, e.telefono_conyugue, u.sexo, u.telefono, u.ciudad from Padre as p inner join Usuario as u on p.cedula = u.cedula)

--XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX

--Recibe la cedula de un padre
--Devuelve verdadero(1) en caso de que exista un padre con la cedula indicada
create function verificarPadre(@cedula int)
returns INT
AS
BEGIN
    declare @comp INT, @ret int
    set @ret = 0
    select @comp = cedula from Padre where @cedula = cedula
    if(@cedula = @comp)
        BEGIN   
            set @ret = 1
        END
    return @ret
END

--Recibe la cedula de un profesor
--Devuelve verdadero(1) en caso de que exista un padre con la cedula indicada
create function verificarProfesor(@cedula int)
returns INT
AS
BEGIN
    declare @comp INT, @ret int
    set @ret = 0
    select @comp = cedula from Profesor where @cedula = cedula
    if(@cedula = @comp)
        BEGIN   
            set @ret = 1
        END
    return @ret
END

--Recibe la cedula de un usuario
--Devuelve verdadero(1) en caso de que exista un usuario con la cedula indicada
create function verificarUsuario(@cedula int)
returns INT
AS
BEGIN
    declare @comp INT, @ret int
    set @ret = 0
    select @comp = cedula from Usuario where @cedula = cedula
    if(@cedula = @comp)
        BEGIN   
            set @ret = 1
        END
    return @ret
END

--Recibe todos los datos de un usuario
--Registra un usuario en la base de datos
create procedure registrar_usuario
    (@nombre varchar(50),
    @cedula int,
    @telefono int,
    @ciudad varchar(50),
    @canton varchar(50),
    @fecha_nacimiento date,
    @fecha_creacion date,
    @sexo varchar(50),
    @passw varchar(50),
	@apellido1 varchar(50),
	@apellido2 varchar(50))
AS
begin
    declare @existencia INT
    set @existencia = dbo.verificarUsuario(@cedula)
    if(@existencia = 0)
    begin
        insert into Usuario(nombre, apellido1, apellido2, cedula, telefono, ciudad, canton, fecha_nacimiento, fecha_creacion, sexo, passw) values (@nombre,@apellido1, @apellido2,@cedula,@telefono,@ciudad,@canton,@fecha_nacimiento,@fecha_creacion, @sexo, @passw)
    end
end

--Recibe los datos necesarios para la eliminacion de un usuario
--elimina un usuario en la base de datos
create procedure eliminar_usuario
    (@cedula int)
AS
begin
    declare @existencia INT
    set @existencia = dbo.verificarUsuario(@cedula) --Faltó aderir el esquema y un arroba
    if(@existencia = 1)
    begin
        delete from Usuario where cedula = @cedula
    end
end

--Recibe los datos de un grupo
--devuelve la cantidad de estudiantes en un grupo
create function cantEstudiantesGrupo(@codigo varchar(50), @periodo int, @anho_periodo int, @materia varchar(50), @grado int)
returns int
AS
begin
declare @ret INT
select @ret = count(cedula_estudiante) from Estudiante_grupo as EG where EG.codigo_grupo = @codigo and EG.periodo = @periodo and EG.anho_periodo = @anho_periodo and EG.nombre_materia = @materia and EG.numero_grado = @grado
return @ret
end

--Recibe los datos de un grupo
--Cambia el estado de un grupo
create procedure cambiarEstadoGrupo(@codigo varchar(50), @periodo int, @anho_periodo int, @materia varchar(50), @grado int, @nuevoEstado int)
AS
BEGIN
    update Grupo set estado = @nuevoEstado where Grupo.codigo = @codigo and Grupo.numero_periodo = @periodo and Grupo.anho_periodo = @anho_periodo and Grupo.nombre_materia = @materia and Grupo.numero_grado = @grado
END

--Recibe la cedula de un profesor
--Registra a un profesor en la tabla correspondiente
create procedure registro_profesor(
    @cedula int
    )
    AS
    BEGIN
        declare @existencia INT
        set @existencia = dbo.verificarProfesor(@cedula)
        if @existencia = 0
        begin
            insert into Profesor values(@cedula)
        end
    END
    
--Recibe la cedula de un profesor
--elimina a un profesor en la tabla correspondiente
create procedure eliminar_profesor(
    @cedula int
    )
    AS
    BEGIN
        declare @existencia INT
        set @existencia = dbo.verificarProfesor(@cedula)
        if @existencia = 1
        begin
            delete from Profesor where cedula =  @cedula
        end
    END

--Recibe los datos del profesor y el grupo al que desea asociarse
--Registra un profesor asociado a un grupo
create procedure registro_profesor_grupo
(
    @numero_periodo int,
    @anho_periodo int,
    @materia varchar(50),
    @grado int,
    @grupo varchar(50),
    @cedula int
)
as 
BEGIN
    insert into profesor_grupo values (@numero_periodo, @anho_periodo, @materia, @grado, @grupo, @cedula)
END

--Recibe todos los datos de un padre
--Registra la informacion de un padre dentro de la tabla correspondiente
create procedure registro_padre
(
    @nombre_c varchar(50),
    @telefono_c INT,
    @profesion varchar(50),
    @cedula int
)
AS
BEGIN
    declare @existencia int
    set @existencia = dbo.verificarPadre(@cedula) 
    if @existencia = 0
    begin
        insert into Padre values (@nombre_c, @telefono_c, @profesion, @cedula)
    end
END

--Recibe los datos necesarios para la eliminacion de un padre
--elimina la informacion de un padre de la tabla correspondiente
create procedure eliminar_padre
(
    @cedula int
)
AS
BEGIN
    declare @existencia int
    set @existencia = dbo.verificarPadre(@cedula)

    if @existencia = 0
    begin
        delete from Padre where cedula = @cedula
    end
END

--Recibe todos los datos de una materia
--Registra la informacion de una materia dentro de la tabla correspondiente
create procedure registro_materia
(
    @descripcion varchar(50),
    @nombre varchar(50),
    @grado int,
    @costo int
)
AS
BEGIN
    insert into Materia_Grado values(@descripcion, @nombre, @grado, @costo)
END

--Recibe todos los datos de un grado
--Registra la informacion de un grado dentro de la tabla correspondiente
create procedure registro_grado
(
    @numero int,
    @descripcion varchar(50)
)
AS
BEGIN
    insert into Grado values(@numero, @descripcion)
END

--Recibe todos los datos necesarios para realizar un cobro
--Registra la informacion de un cobro dentro de la tabla correspondiente
create procedure registro_cobro
(
    @estudiante int,
    @codigo_grupo varchar(50),
    @numero_periodo int,
    @anho_periodo int,
    @fecha_generacion date,
    @fecha_pago date,
    @estado varchar(50),
    @concepto varchar(100),
    @materia varchar(50),
    @grado int
)
AS
BEGIN
declare  @monto int
    set @monto = (select costo from Materia_Grado where Materia_Grado.nombre = @materia and Materia_Grado.numero_grado = @grado);
    insert into Cobro (monto, estudiante, codigo_grupo, numero_periodo, anho_periodo, fecha_generacion, fecha_pago, estado, concepto, materia, grado) values (@monto, @estudiante, @codigo_grupo, @numero_periodo, @anho_periodo, @fecha_generacion, @fecha_pago, @estado, @concepto, @materia, @grado)
END

--Recibe todos los datos necesarios para eliminar un cobro
--elimina un cobro dentro de la tabla correspondiente
create procedure eliminacion_cobro
(
    @estudiante int,
    @codigo_grupo varchar(50),
    @numero_periodo int,
    @anho_periodo int,
    @materia varchar(50),
    @grado int
)
AS
BEGIN
    delete from Cobro where estudiante = @estudiante and codigo_grupo = @codigo_grupo and numero_periodo = @numero_periodo and anho_periodo = @anho_periodo and materia = @materia and grado = @grado
END

--Recibe todos los datos del salario para asociarlos a los datos de un profesor
--Registra la informacion del salario de un profesor dentro de la tabla correspondiente
create procedure registro_salario
(
    @monto int,
    @inicio date,
    @final date,
    @cedula_profesor int,
    @concepto varchar(50)
)
AS
BEGIN
    insert into Salario values(@monto, @inicio, @final, @cedula_profesor, @concepto)
END

--Recibe los datos de la asistencia de un estudiante en especifico
--Crea un registro de asistencia asociado a un estudiante de un determinado grupo
create procedure registro_asistencia
(
    @fecha date,
    @codigo_grupo varchar(50),
    @numero_periodo int,
    @anho_periodo int,
    @nombre_materia varchar(50),
	@estado as int,
    @grado int,
    @cedula_estudiante int
)
AS
BEGIN
    insert into Asistencia values (@fecha, @codigo_grupo, @numero_periodo, @anho_periodo, @nombre_materia, @grado, @cedula_estudiante, @estado)
END

--Recibe los datos de un estudiante y las evaluaciones del grupo al que pertenecen, asi como la informacion del grupo.
--Crea un registro de evaluaciones asociado a un estudiante de un determinado grupo
create procedure registro_evaluaciones_notas
(
    @nombre_materia varchar(50),
    @grado int,
    @numero_periodo int,
    @anho_periodo int,
    @grupo varchar(50),
    @criterio varchar(50),
    @cedula_estudiante int,
    @nota int,
    @estado int output
)
AS
BEGIN
    if (@nota > 0 and @nota<101)
    begin
    if exists(select nombre_materia from Evaluacion_estudiante_grupo as eg where eg.nombre_materia = @nombre_materia and eg.grado = @grado and eg.numero_periodo = @numero_periodo and eg.anho_periodo = @anho_periodo and eg.grupo = @grupo and eg.cedula_estudiante  = @cedula_estudiante)
        insert into Evaluacion_estudiante_grupo values(@nombre_materia, @grado, @numero_periodo, @anho_periodo, @grupo, @criterio, @cedula_estudiante, @nota)
        set @estado = 1
    end
    else
    BEGIN
         set @estado = 0
    end
END

--Recibe los datos de un grupo
--Verifica que un grupo tenga evaluaciones y que los porcentajes sumados de las evaluaciones sean iguales a 100
create function verificarEvaluaciones
(@codigo varchar(50), @periodo int, @anho_periodo int, @materia varchar(50), @grado int)
returns int
as
BEGIN
    declare @total int, @estado int
    set @estado = 0
    if exists(select distinct grupo from Evaluacion_grupo as G where G.grupo = @codigo and G.numero_periodo = @periodo and G.anho_periodo = @anho_periodo and G.nombre_materia = @materia and G.grado = @grado)
    begin
            set @total = (select sum(porcentaje) from Evaluacion_grupo as EG where EG.grupo = @codigo and EG.numero_periodo = @periodo and EG.anho_periodo = @anho_periodo and EG.nombre_materia = @materia and EG.grado = @grado)
            if @total = 100
                BEGIN   
                    set @estado = 1
                END
    end
    else
    BEGIN
        set @estado = 0
    END
    return @estado
END

--Recibe los datos de un periodo
--valida todas las condiciones de apertura y en caso de cumplirlas abre un periodo determinado
create procedure aperturaPeriodo(
    @periodo int,
    @anho_periodo int,
    @estado int output
)
AS
BEGIN
--Se distinguen las cantidades de grupos, evaluaciones por grupo, estudiantes por grupo y profesores por grupo
    declare @cantGrupos int, @cantProfesores int, @gruposConEstudiantes int, @codigo varchar(50), @materia varchar(50), @grado int, @resul int, @periodoA int, @anho_periodoA int
    set @cantGrupos = (select count(codigo) from Grupo as G where G.numero_periodo = @periodo and G.anho_periodo = @anho_periodo)
    set @cantProfesores = (select count(profesor) from profesor_grupo as pg where pg.numero_periodo = @periodo and pg.anho_periodo = @anho_periodo)
    set @gruposConEstudiantes = (select count(distinct codigo_grupo) from Estudiante_Grupo as EG where EG.periodo = @periodo and EG.anho_periodo = @anho_periodo)
    set @estado = 1
    if @cantGrupos = @cantProfesores and @cantGrupos = @gruposConEstudiantes
    BEGIN
        declare cursoActual cursor local
        for select codigo, numero_periodo, anho_periodo, nombre_materia, numero_grado from Grupo where Grupo.numero_periodo = @periodo and Grupo.anho_periodo = @anho_periodo
        open cursoActual
        FETCH
        next from cursoActual into @codigo, @periodoA, @anho_periodoA, @materia, @grado
        while @@fetch_status = 0
        BEGIN
            set @resul = dbo.verificarEvaluaciones(@codigo, @periodoA, @anho_periodoA, @materia, @grado)
            if @resul = 0
                BEGIN   
                    set @estado = 0
                END
            fetch next from cursoActual into @codigo, @periodoA, @anho_periodoA, @materia, @grado
        END
        close cursoActual
        deallocate cursoActual 
    END
    ELSE
    BEGIN
        set @estado = 0
    END
    if @estado = 1
    begin
        update Periodo set estado = 1 where Periodo.numero = @periodo and Periodo.anho = @anho_periodo
    end
end
--Recibe los datos de un cobro
--Actualiza el estado de un cobro
create procedure estadoCobro(
    @estudiante int,
    @codigo_grupo varchar(50),
    @numero_periodo int,
    @anho_periodo int,
    @estado varchar(50),
    @materia varchar(50),
    @grado int,
    @factura int
)
as 
BEGIN
    update Cobro set estado = @estado where Cobro.estudiante = @estudiante  and Cobro.Codigo_grupo = @codigo_grupo and Cobro.numero_periodo = @numero_periodo and Cobro.anho_periodo = @anho_periodo and Cobro.materia = @materia and Cobro.grado = @grado
    update Cobro set numero_factura = @factura
END

drop procedure pagarTodo
--Recibe la informacion de una factura
--factura el total de los cobros de un estudiante
create procedure pagarTodo
(@cedula int)
AS
BEGIN
    declare @sumaCobros INT, 
    @estudiante int,
    @codigo_grupo varchar(50),
    @numero_periodo int,
    @anho_periodo int,
    @estado varchar(50),
    @materia varchar(50),
    @grado int,
    @monto int,
    @numeroFactura int
      declare cursoActual cursor local
        for select estudiante, codigo_grupo, numero_periodo, anho_periodo, materia, grado, monto from Cobro where Cobro.estudiante = @estudiante
        open cursoActual
        FETCH next from cursoActual into @estudiante, @codigo_grupo, @numero_periodo, @anho_periodo, @materia, @grado, @monto;
        while @@fetch_status = 0
        BEGIN
            set @numeroFactura = ROUND(((9999 - 1000) * RAND() + 1000), 0)
            --insert into Factura values(@numeroFactura, @monto)
            --exec estadoCobro @estudiante, @codigo_grupo, @numero_periodo, @anho_periodo, 'Pagado', @materia, @grado, @numeroFactura
            fetch next from cursoActual into @estudiante, @codigo_grupo, @numero_periodo, @anho_periodo, @materia, @grado, @monto;
        END
        close cursoActual
        deallocate cursoActual
    end

create procedure pagarCobro(
    @estudiante int,
    @codigo_grupo varchar(50),
    @numero_periodo int,
    @anho_periodo int,
    @estado varchar(50),
    @monto int, 
    @materia varchar(50),
    @grado int,
    @concepto varchar(50))
    as
    BEGIN
        declare @existe varchar, @numeroFactura int
        set @concepto = (select c.concepto from Cobro as c where c.estudiante = @estudiante and c.codigo_grupo = @codigo_grupo and c.numero_periodo = @numero_periodo and c.anho_periodo = @anho_periodo and c.materia = @materia and c.grado = @grado)
        if @existe != null
        BEGIN
            select @numeroFactura = ROUND(((9999 - 1000-1) * RAND() + 1000), 0)
            insert into Factura (numero, monto)values(@numeroFactura, @monto)
            exec estadoCobro @estudiante, @codigo_grupo, @numero_periodo, @anho_periodo, 'Pagado', @materia, @grado, @numeroFactura
        END
    end

exec facturacion 23214, 234575

drop function cierreGrupo

--Recibe los datos de un grupo
--Valida las condiciones de cierre de un grupo
create function ComprobarCierreGrupo(
    @codigo varchar(50), @periodo int, @anho_periodo int, @materia varchar(50), @grado int
)
returns int
as
begin
    declare @ret int, @evGrupo int, @cantEst int, @cantEvGrEst int
    set @evGrupo = (select count(grupo) from Evaluacion_grupo as G where G.grupo = @codigo and G.numero_periodo = @periodo and G.anho_periodo = @anho_periodo and G.nombre_materia = @materia and G.grado = @grado)
    set @cantEst = dbo.cantEstudiantesGrupo(@codigo, @periodo, @anho_periodo, @materia, @grado)
    set @cantEvGrEst = (select count(grupo) from Evaluacion_estudiante_grupo as EEG where EEG.grupo = @codigo and EEG.numero_periodo = @periodo and EEG.anho_periodo = @anho_periodo and EEG.nombre_materia = @materia and EEG.grado = @grado)
    set @ret = 0
    if @evGrupo * @cantEst = @cantEvGrEst
    BEGIN
        set @ret = 1
    END
    return @ret
END

print cast(dbo.cierreGrupo('45ES', 2, 2023, 'Español', 3) as char)

create procedure evaluacionFinalEstudiante(@codigo varchar(50), @periodo int, @anho int, @materia varchar(50), @grado int, @estudiante int)
as 
begin
	declare @promedio float, @notaMinima int
	--La siguiente linea debe comprobar que la evaluacion por estudiante por grupo es del grupo recibido como parametro y ademas buscar las evaluaciones por grupo que tengan el mismo grupo para obtener el porcentaje de evaluacion, por lo que es bastante larga la validacion
	select @promedio = cast(sum(EEG.nota * Eg.porcentaje) as float)/100 from Evaluacion_estudiante_grupo as EEG inner join Evaluacion_grupo as EG on EEG.numero_periodo = @periodo and EEG.anho_periodo = @anho and EEG.grupo = @codigo AND EEG.nombre_materia = @materia AND EEG.grado = @grado and EEG.cedula_estudiante = @estudiante and EEG.numero_periodo = EG.numero_periodo and EEG.anho_periodo = EG.anho_periodo and EEG.grupo = EG.grupo AND EEG.nombre_materia = EG.nombre_materia AND EEG.grado = EG.grado and EEG.criterio = EG.criterio
	select @notaMinima = p.nota_minima from Periodo as p where p.numero = @periodo and p.anho = @anho
	update Estudiante_grupo set notaTotal = @promedio where Estudiante_grupo.periodo = @periodo and Estudiante_grupo.anho_periodo = @anho and Estudiante_grupo.codigo_grupo = @codigo and Estudiante_grupo.nombre_materia = @materia and Estudiante_grupo.numero_grado = @grado
end

create procedure evaluacionFinalGrupo (@codigo varchar(50), @periodo int, @anho int, @materia varchar(50), @grado int)
as 
begin
	declare @codigoA varchar(50), @periodoA int, @anhoA int, @materiaA varchar(50), @gradoA int, @estudiante int
	declare cursoActual cursor local
	for select EG.codigo_grupo, EG.periodo, EG.anho_periodo, EG.nombre_materia, EG.numero_grado, EG.cedula_estudiante from Estudiante_grupo as EG where EG.periodo = @periodo and EG.anho_periodo = @anho and EG.codigo_grupo = @codigo AND EG.nombre_materia = @materia AND EG.numero_grado = @grado
	open cursoActual
    FETCH next from cursoActual into @codigoA, @periodoA, @anhoA, @materiaA, @gradoA, @estudiante;
        while @@fetch_status = 0
        BEGIN
            exec evaluacionFinalEstudiante @codigoA, @periodoA, @anhoA, @materiaA, @gradoA, @estudiante
			fetch next from cursoActual into @codigoA, @periodoA, @anhoA, @materiaA, @gradoA
        END
	close cursoActual
    deallocate cursoActual 
end

drop procedure cierrePeriodo
--Recibe los datos de un periodo
--Valida las condiciones para que se cierre el periodo, y realiza el cierre
create procedure cierrePeriodo(@periodo int, @anho int)
as 
BEGIN
    declare @codigo varchar(50), @periodoA int, @anhoA int, @materiaA varchar(50), @gradoA int, @cierreG int, @cierreP int
    set @cierreP = 1
    declare cursoActual cursor local
        for select codigo, numero_periodo, anho_periodo, nombre_materia, numero_grado from Grupo where Grupo.numero_periodo = @periodo and Grupo.anho_periodo = @anho
        open cursoActual
        FETCH next from cursoActual into @codigo, @periodoA, @anhoA, @materiaA, @gradoA;
        while @@fetch_status = 0
        BEGIN
            set @cierreG = dbo.ComprobarCierreGrupo(@codigo, @periodoA, @anhoA, @materiaA, @gradoA)
            if @cierreG = 1 and not exists(select g.codigo from grupo as g where g.anho_periodo = @anhoA and g.codigo = @codigo and g.numero_periodo = @periodoA and g.nombre_materia = @materiaA and g.numero_grado = @gradoA and g.estado = 1)
            begin
                update Grupo set estado = 1 where Grupo.codigo = @codigo and Grupo.numero_periodo = @periodoA and Grupo.anho_periodo = @anhoA and Grupo.nombre_materia = @materiaA and Grupo.numero_grado = @gradoA
				exec evaluacionFinalGrupo  @codigo, @periodoA, @anhoA, @materiaA, @gradoA
			end
            ELSE
            BEGIN
                set @cierreP = 0
            END
            fetch next from cursoActual into @codigo, @periodoA, @anhoA, @materiaA, @gradoA
        END
        close cursoActual
        deallocate cursoActual 

        if @cierreP = 1
        BEGIN
            update Periodo set estado = 1 where Periodo.numero = @periodo and Periodo.anho = @anho
        end
End

drop function promedioGrupo
create function promedioGrupo(@anho_periodo int, @numero_periodo int, @codigo varchar(50), @materia varchar(50), @grado int ) 
    returns int
    AS
    begin 
        declare @resultado INT
        set @resultado = (select avg(nota) from Evaluacion_estudiante_grupo as EEG where EEG.anho_periodo = @anho_periodo and EEG.numero_periodo = @numero_periodo AND EEG.grupo=@codigo AND EEG.nombre_materia = @materia AND EEG.grado = @grado)
        return @resultado
    end

drop function promedioProfesoresGrupo
create function promedioProfesorGrupo (@cedula int)
    returns table
    AS
    return (select avg(EEG.nota) as 'Promedios' from Evaluacion_estudiante_grupo as EEG inner join profesor_grupo as PG on PG.profesor = @cedula and PG.numero_periodo = EEG.numero_periodo and PG.anho_periodo = EEG.anho_periodo and PG.grupo = EEG.grupo and PG.nombre_materia = EEG.nombre_materia and PG.grado = EEG.grado group by EEG.grupo)

select * from dbo.promedioProfesorGrupo (432432)

create function promedioProfesoresGrupo()
returns table
AS
RETURN (select avg(EEG.nota) as 'Promedios', EEG.grupo, PG.profesor from Evaluacion_estudiante_grupo as EEG inner join profesor_grupo as PG on PG.numero_periodo = EEG.numero_periodo and PG.anho_periodo = EEG.anho_periodo and PG.grupo = EEG.grupo and PG.nombre_materia = EEG.nombre_materia and PG.grado = EEG.grado group by EEG.grupo, PG.profesor)

select * from dbo.promedioProfesoresGrupo()

exec cierrePeriodo 1, 2023

drop function cantidadGruposPorPeriodo
--Retorna la cantidad de grupos para cada periodo en formato de tabla indicando el periodo y la cantidad de grupos
create function cantidadGruposPorPeriodo()
returns table
as
RETURN
(select count(grupo.codigo) as 'CantGrupos', Periodo.numero, periodo.anho  from Grupo inner join Periodo on Grupo.numero_periodo=Periodo.numero and grupo.anho_periodo = periodo.anho group by periodo.numero, periodo.anho)

select * from dbo.cantidadGruposPorPeriodo()

drop function cantEstudiantesPeriodoGrupo
create function cantEstudiantesPeriodoGrupo(@periodo int, @anho int)
returns table
AS 
 return (SELECT COUNT(cedula_estudiante) as 'Cantidad de estudiantes', eg.codigo_grupo from Estudiante_grupo as eg where eg.anho_periodo = @anho and periodo = @periodo group by codigo_grupo )
 SELECT COUNT(cedula_estudiante) from Estudiante_grupo where anho_periodo = 2023 and periodo = 2 group by codigo_grupo 

select * from cantEstudiantesPeriodoGrupo(2, 2023)

--Función que retorna los cobros realizados por periodo
create function cobrosPorPeriodo()
returns table
as
RETURN
(select Cobro.monto as 'Montos',Cobro.estudiante,Cobro.anho_periodo,Cobro.numero_periodo,Cobro.codigo_grupo,Cobro.materia,Cobro.grado from Cobro)

select (select count(distinct g.codigo) from Grupo as g) + (select count (distinct c.nombre) from Materia_Grado as c)

drop function CobrosVersusFacturas
--Retorna los Cobros vs los Cobros Facturados por grado por periodo
create function CobrosVersusFacturas()
returns table
as
RETURN
(select count(cobro.monto)as 'Cobros por pagar', (select count(Factura.numero) from Factura)as 'Cobros facturados' from Cobro where Cobro.numero_factura is null) --inner join Factura on Cobro.monto=Factura.monto and Cobro.numero_factura=Factura.numero)

select * from dbo.CobrosVersusFacturas()
select * from dbo.cobrosPorPeriodo()

drop view topEstudiantesNotas
create view topEstudiantesNotas
--returns TABLE
AS
select top 10 sum((EEG.nota * EVG.porcentaje)/100) AS 'Nota total', eeg.cedula_estudiante from Estudiante_grupo as EG inner join Evaluacion_estudiante_grupo as EEG on eg.cedula_estudiante = EEG.cedula_estudiante inner join Evaluacion_grupo as EVG on EEG.anho_periodo = EVG.anho_periodo AND EEG.numero_periodo = EVG.numero_periodo AND EEG.nombre_materia = EVG.nombre_materia AND EEG.grupo = EVG.grupo AND EEG.grado = EVG.grado AND EEG.criterio = EVG.criterio group by eeg.cedula_estudiante, eeg.nota order by sum((EEG.nota * EVG.porcentaje)/100) desc

select * from topEstudiantesNotas

create view topEstudiantesAuscencias
as
select top 10 EG.cedula_estudiante, count(A.estado) as 'Auscencias' from Asistencia as A inner join Estudiante_grupo as EG on A.cedula_estudiante = EG.cedula_estudiante where A.estado = 0 group by EG.cedula_estudiante, A.estado order by count(A.estado) desc

--Retorna el top 10 de los padres con más deudas
create view topPadresDeudas
as
select top 10 Padre.cedula, count(Padre.cedula) as 'Deudores' from Padre inner join Estudiante on Estudiante.cedula_padre=Padre.cedula inner join Cobro on Cobro.estudiante = Estudiante.cedula group by Padre.cedula order by count(Padre.cedula) desc

drop function cantidadGruposEstudiante
create function cantidadGruposEstudiante(@periodo int, @anho int)
returns table
as
return(select distinct E.cedula, count(G.codigo) as 'Cantidad de grupos' from Estudiante as E inner join Estudiante_grupo as EG on E.cedula = EG.cedula_estudiante inner join Grupo as G on EG.anho_periodo = G.anho_periodo and EG.periodo = G.numero_periodo and EG.codigo_grupo = G.codigo and EG.nombre_materia = G.nombre_materia and EG.numero_grado = G.numero_grado where G.anho_periodo = @anho and G.numero_periodo = @periodo group by E.cedula, G.numero_grado)

select * from dbo.cantidadGruposEstudiante(2, 2023)

declare @salir int
set @salir = 0
while @salir <15
begin
	exec registrar_usuario 'nombre'+cast(@salir as varchar(2)), ROUND(((99999 - 10000) * RAND() + 10000), 0), ROUND(((99999 - 10000) * RAND() + 10000), 0), 'ciudad'+cast(@salir as varchar(2)), 'canton'+cast(@salir as varchar(2)), '2-20-2000', '2-23-2023', 'Masculino', 'Password'+cast(@salir as varchar(2)), 'apellido1'+cast(@salir as varchar(2)), 'apellido2'+cast(@salir as varchar(2))
	exec registrar_grupo
	exec registro_estudiante
	exec registrarMatricula 
	exec registro_estudiante_grupo
	set @salir = @salir+1
end

delete from Usuario where nombre like '%nombre%'
