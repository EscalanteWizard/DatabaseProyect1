--Retorna la cantidad de grupos para cada periodo en formato de tabla indicando el periodo y la cantidad de grupos
use Sistema_matricula
go
create function cantidadGruposPorPeriodo()

returns table

as

RETURN

(select count(grupo.codigo) as 'CantGrupos', Periodo.numero, periodo.anho  from Grupo inner join Periodo on Grupo.numero_periodo=Periodo.numero and grupo.anho_periodo = periodo.anho where periodo.numero = 1 group by periodo.numero, periodo.anho)

--Retorna los Cobros vs los Cobros Facturados por grado por periodo
use Sistema_matricula
go
create function CobrosVersusFacturas()

returns table

as

RETURN

(select count(cobro.monto)as 'Cobros por pagar', (select count(Factura.numero) from Factura)as 'Cobros facturados' from Cobro where Cobro.numero_factura is null) --inner join Factura on Cobro.monto=Factura.monto and Cobro.numero_factura=Factura.numero)


--Retorna el top 10 de los padres con más deudas
use Sistema_matricula
create view topPadresDeudas

as

select top 10 Padre.cedula, count(Padre.cedula) as 'Deudores' from 
Padre inner join Estudiante on Estudiante.cedula_padre=Padre.cedula inner join Cobro on Cobro.estudiante = Estudiante.cedula 
group by Padre.cedula order by count(Padre.cedula)

--Retorna el top10 de profesores con mayor aumento salarial
create view topAumentoSalarial
as

*****************
--Retorna el top 15 de grupos con mayor porcentaje de aprobación
use Sistema_matricula
create view topGruposAprobacion
