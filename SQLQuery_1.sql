create database Sistema_matricula
GO

create table Periodo(
    fecha_inicio Date not null,
    fecha_final Date not null,
    anho int,
    numero int not null,
    nota_minima int not null,
    estado int not null,
    CONSTRAINT verif_anho check(anho>2021),
    constraint pk_periodo primary key (anho, numero)
);
alter table Periodo add estado int not null

create table Usuario(
    nombre varchar(50) not null,
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

create table Padre(
    nombre_conyugue varchar(50),
    telefono_conyugue int,
    profesion varchar(50),
    cedula int not null,
    constraint fk_usuario_padre foreign key (cedula) references Usuario (cedula),
    constraint pk_padre primary key (cedula)
);

create table roll(
    nombre varchar(50) not null,
    permisos int not null,
    cedula int not null,
    constraint fk_usuario_roll foreign key (cedula) references Usuario(cedula),
    constraint pk_roll primary key (cedula)
);

create table Grado(
    numero int not null,
    descripcion varchar(100) not null,
    constraint pk_grado primary key (numero)
);

create table Materia_Grado(
    descripcion_materia varchar(50) not null,
    nombre varchar(50) not null,
    numero_grado int not null,
    costo int not null,
    constraint fk_grado_materia foreign key (numero_grado) references Grado (numero),
    constraint pk_materia_grado primary key (nombre, numero_grado)
);

create table Grupo(
    nombre_materia varchar(50) not null,
    codigo varchar(50) not null,
    cupo int not null,
    numero_grado int not null,
    numero_periodo int not null,
    anho_periodo int not null,
    estado varchar(50) not null,
    constraint fk_materia_grupo foreign key (nombre_materia, numero_grado) references Materia_grado (nombre, numero_grado),
    constraint fk_periodo_grupo foreign key (anho_periodo, numero_periodo) references Periodo (anho, numero),
    constraint pk_grupo primary key (codigo, anho_periodo, numero_periodo, nombre_materia, numero_grado)
);

create table Estudiante(
    numero_grado int not null,
    cedula_padre int not null,
    cedula int not null,
    constraint fk_grado_estudiante foreign key (numero_grado) references Grado (numero),
    constraint fk_padre_estudiante foreign key (cedula_padre) references Padre (cedula),
    constraint fk_usuario_estudiante foreign key (cedula) references Usuario (cedula),
    constraint pk_estudiante primary key (cedula)
);

create table Estudiante_grupo(
    cedula_estudiante int not null,
    codigo_grupo varchar(50) not null,
    periodo int not null,
    anho_periodo int not null,
    nombre_materia varchar(50) not null,
    numero_grado int not null,
    constraint fk_grupo_estudiante foreign key (codigo_grupo, anho_periodo, periodo, nombre_materia, numero_grado) references Grupo (codigo, anho_periodo, numero_periodo, nombre_materia, numero_grado),
    constraint fk_estudiante_grupo foreign key (cedula_estudiante) references Estudiante (cedula),
    constraint pk_estudiante_grupo primary key (cedula_estudiante, codigo_grupo, anho_periodo, periodo, nombre_materia, numero_grado)
);

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

create table Evaluacion_estudiante_grupo(
    nombre_materia varchar(50) not null,
    grado int not null,
    numero_periodo int not null,
    anho_periodo int not null,
    grupo varchar(50) not null,
    criterio varchar(50) not null,
    cedula_estudiante int not null,
    nota int not null,
    constraint fk_grupo_evaluacion_estudiante foreign key (grupo, anho_periodo, numero_periodo, nombre_materia, grado, criterio) references Evaluacion_grupo (grupo, anho_periodo, numero_periodo, nombre_materia, grado, criterio),
    constraint fk_estudiante_evaluacion_grupo foreign key (cedula_estudiante, grupo, anho_periodo, numero_periodo, nombre_materia, grado) references Estudiante_Grupo (cedula_estudiante, codigo_grupo, anho_periodo, periodo, nombre_materia, numero_grado),
    constraint pk_evaluacion_estudiante_grupo primary key (grupo, anho_periodo, numero_periodo, nombre_materia, grado, criterio, cedula_estudiante)
);

create table Asistencia(
    fecha date not null,
    codigo_grupo varchar(50) not null,
    numero_periodo int not null,
    anho_periodo int not null,
    nombre_materia varchar(50) not null,
    grado int not null,
    cedula_estudiante int not null,
    constraint fk_grupo_asistencia foreign key (cedula_estudiante, codigo_grupo, anho_periodo, numero_periodo, nombre_materia, grado) references Estudiante_Grupo (cedula_estudiante, codigo_grupo, anho_periodo, periodo, nombre_materia, numero_grado),
    constraint pk_asistencia primary key (cedula_estudiante, codigo_grupo, anho_periodo, numero_periodo, nombre_materia, grado, fecha)
);

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

create table Profesor(
    cedula int not null,
    constraint fk_usuario_profesor foreign key (cedula) references Usuario(cedula),
    constraint pk_profesor primary key (cedula)
);

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

create table Salario(
    monto_salario int not null,
    inicio_periodo_salario Date not null,
    final_periodo_salario Date not null,
    profesor int not null,
    concepto varchar(50) not null,
    constraint fk_profesor_salario foreign key (profesor) references Profesor(cedula),
    constraint pk_salario primary key (profesor, inicio_periodo_salario, final_periodo_salario)
);

create table Factura(
    numero int not null,
    monto int not null
    constraint pk_factura primary key(numero)
);

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
    numero_factura int not null,
    constraint fk_matricula_cobro foreign key (estudiante, anho_periodo, numero_periodo, codigo_grupo, materia, grado) references Matricula (estudiante, anho_periodo, numero_periodo, codigo_grupo, materia, grado),
    constraint fk_factura_cobro foreign key (numero_factura) references Factura(numero),
    constraint pk_cobro primary key (estudiante, anho_periodo, numero_periodo, codigo_grupo, materia, grado)
);

--Suma todas las evaluaciones de un grupo especifico
create function dbo.sumaEvaluaciones(@codigo_grupo varchar(50), @anho_periodo int, @numero_periodo int, @materia varchar(50))
returns int
AS
begin
declare @ret int
select @ret = sum(ev_g.porcentaje) from Evaluacion_grupo as ev_g where ev_g.grupo = @codigo_grupo and ev_g.anho_periodo = @anho_periodo and ev_g.numero_periodo = @numero_periodo and ev_g.nombre_materia = @materia
return @ret
end

--Devuelve una tabla que contiene grupos con cupos diferentes de 0
create function dbo.grupoConCupo(@grado int)
returns table 
as
RETURN
(select codigo, anho_periodo, numero_periodo, nombre_materia, numero_grado from Grupo as G where G.numero_grado = @grado and G.cupo != 0)

--Registra una matricula en su respectiva tabla
create procedure registrarMatricula
    (@estudiante int, 
    @grupo varchar(50), 
    @anho_periodo int, 
    @numero_periodo int, 
    @materia varchar(50), 
    @grado int)
as

BEGIN
    insert into matricula(codigo_grupo, anho_periodo, numero_periodo, materia, grado, estudiante) values (@grupo, @anho_periodo, @numero_periodo, @materia, @grado, @estudiante);
END

--Registra a un estudiante ligado a un grupo, en la tabla de estudiantes por grupo
create procedure registro_estudiante_grupo
    (@estudiante int, 
    @grupo varchar(50), 
    @numero_periodo int, 
    @anho_periodo int, 
    @materia varchar(50), 
    @grado int,
    @estado int output)
as
BEGIN
    declare @grado_est INT
    select @grado_est = Estudiante.numero_grado from Estudiante where Estudiante.cedula = @estudiante
    if(@grado_est = @grado)
    begin
        insert into Estudiante_grupo values (@estudiante, @grupo, @numero_periodo, @anho_periodo, @materia, @grado);
        set @estado = 1
    end
    else set @estado = 0
END

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
        set @existencia = verificarEstudiante(@cedula)
        if(@existencia = 0)
        begin
            insert into Estudiante values(@grado, @cedula_padre, @cedula)
        end
    END


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

--Registra un usuario en la base de datos
create procedure registrar_usuario
    (@nombre varchar(50),
    @cedula int,
    @telefono int,
    @ciudad varchar(50),
    @canton int,
    @fecha_nacimiento date,
    @fecha_creacion date,
    @sexo varchar(50),
    @passw varchar(50))
AS
begin
    declare @existencia INT
    set @existencia = verificarUsuario(@cedula)
    if(existencia = 0)
    begin
        insert into Usuario values (@nombre,@cedula,@telefono,@ciudad,@canton,@fecha_nacimiento,@fecha_creacion, @sexo, @passw)
    end
end

--devuelve la cantidad de estudiantes en un grupo
create function minimoEstudiantes(@codigo varchar(50), @periodo int, @anho_periodo int, @materia varchar(50), @grado int)
returns int
AS
begin
declare @ret INT
select @ret = count(cedula_estudiante) from Estudiante_grupo as EG where EG.codigo_grupo = @codigo and EG.periodo = @periodo and EG.anho_periodo = @anho_periodo and EG.nombre_materia = @materia and EG.numero_grado = @grado
return @ret
end

--Cambia el estado de un grupo de cerrado
create procedure cambiarEstadoGrupo(@codigo varchar(50), @periodo int, @anho_periodo int, @materia varchar(50), @grado int, @nuevoEstado int)
AS
BEGIN
    update Grupo set estado = @nuevoEstado where Grupo.codigo = @codigo and Grupo.numero_periodo = @periodo and Grupo.anho_periodo = @anho_periodo and Grupo.nombre_materia = @materia and Grupo.numero_grado = @grado
END

--Registra a un profesor en la tabla correspondiente
create procedure registro_profesor(
    @cedula int
    )
    AS
    BEGIN
        declare @existencia INT
        set @existencia = verificarProfesor(@cedula)
        if @existencia = 0
        begin
            insert into Profesor values(@cedula)
        end
    END

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
    set @existencia = verificarPadre(@cedula)
    if @existencia = 0
    begin
        insert into padre values (@nombre_c, @telefono_c, @profesion, @cedula)
    end
END

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


--Registra la informacion de una cobro dentro de la tabla correspondiente
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

--Crea un registro de asistencia asociado a un estudiante de un determinado grupo
create procedure registro_asistencia
(
    @fecha date,
    @codigo_grupo varchar(50),
    @numero_periodo int,
    @anho_periodo int,
    @nombre_materia varchar(50),
    @grado int,
    @cedula_estudiante int
)
AS
BEGIN
    insert into Asistencia values (@fecha, @codigo_grupo, @numero_periodo, @anho_periodo, @nombre_materia, @grado, @cedula_estudiante)
END


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

drop function verificarEvaluaciones
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

--valida todas las condiciones de apertura y en caso de cumplirlas ebre el periodo
create procedure aperturaPeriodo(
    @periodo int,
    @anho_periodo int,
    @estado int output
)
AS
BEGIN
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

create procedure estadoCobro(
    @estudiante int,
    @codigo_grupo varchar(50),
    @numero_periodo int,
    @anho_periodo int,
    @estado varchar(50),
    @materia varchar(50),
    @grado int
)
as 
BEGIN
    update Cobro set estado = @estado where Cobro.estudiante = @estudiante  and obro.Codigo_grupo = @codigo_grupo and Cobro.numero_periodo = @numero_periodo and Cobro.anho_periodo = @anho_periodo and Cobro.materia = @materia and Cobro.grado = @grado
END

--factura el total de los cobros de un estudiante
--Nota: Aun no funciona
create procedure facturacion
(@cedula int, @numero int)
AS
BEGIN
    declare @sumaCobros INT, 
    @estudiante int,
    @codigo_grupo varchar(50),
    @numero_periodo int,
    @anho_periodo int,
    @estado varchar(50),
    @materia varchar(50),
    @grado int
    set @sumaCobros = (select sum(monto) from Cobro where cobro.estudiante = @cedula)
    insert into Factura values(@numero, @sumaCobros)
      declare cursoActual cursor local
        for select estudiante, codigo_grupo, numero_periodo, anho_periodo, materia, grado from Cobro where Cobro.estudiante = @estudiante
        open cursoActual
        FETCH
        next from cursoActual into @estudiante, @codigo_grupo, @numero_periodo, @anho_periodo, @materia, @grado
        while @@fetch_status = 0
        BEGIN
            exec estadoCobro @estudiante, @codigo_grupo, @numero_periodo, @anho_periodo, 1, @materia, @grado
            fetch next from cursoActual into @estudiante, @codigo_grupo, @numero_periodo, @anho_periodo, @materia, @grado
        END
        close cursoActual
        deallocate cursoActual 
    end
END

