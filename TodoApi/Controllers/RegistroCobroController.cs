using System.Data.SqlClient;
[HttpPost]
[ValidateAntiForgeryToken]
public async Task<IActionResult> Create([Bind("Atributos")]Cobro cobro){
    if(ModelState.IsValid){
        SqlConnection conexion=(SqlConnection)_context.Database.GetDbConnection(); //nombre de la conexion
        SqlCommand comando=conexion.CreateCommand(); //comandos que se van a utilizar a travéz de la conexion
        conexion.Open(); //apertura de la conexión
        comando.CommandType=System.Data.CommandType.StoredProcedure;  //se define que el comando el del tipo procedimiento almacenado
        comando.CommandText="registro_cobro";  //variable del texto del comando que se va a llamar a través de la conexión

        comando.Parameters.Add("@estudiante",System.Data.SqlDbType.int).Value=Cobro.estudiante;
        comando.Parameters.Add("@codigo_grupo",System.Data.SqlDbType.varchar,50).Value=Cobro.codigo_grupo;
        comando.Parameters.Add("@numero_periodo",System.Data.SqlDbType.int).Value=Cobro.numero_periodo;
        comando.Parameters.Add("@anho_periodo",System.Data.SqlDbType.int).Value=Cobro.anho_periodo;
        comando.Parameters.Add("@fecha_generacion",System.Data.SqlDbType.datetime2).Value=Cobro.fecha_generacion;
        comando.Parameters.Add("@fecha_pago",System.Data.SqlDbType.datetime2).Value=Cobro.fecha_pago;
        comando.Parameters.Add("@estado",System.Data.SqlDbType.varchar,50).Value=Cobro.estado;
        comando.Parameters.Add("@concepto",System.Data.SqlDbType.varchar.50).Value=Cobro.concepto;
        comando.Parameters.Add("@materia",System.Data.SqlDbType.varchar.50).Value=Cobro.materia;
        comando.Parameters.Add("@grado",System.Data.SqlDbType.int).Value=Cobro.grado;
        

        comando.ExecuteNonQuery();
        
        conexion.Close(); //cierre de la conexión
    }
}