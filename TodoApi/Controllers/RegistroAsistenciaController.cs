using System.Data.SqlClient;
[HttpPost]
[ValidateAntiForgeryToken]
public async Task<IActionResult> Create([Bind("Atributos")]Asistencia asistencia){
    if(ModelState.IsValid){
        SqlConnection conexion=(SqlConnection)_context.Database.GetDbConnection(); //nombre de la conexion
        SqlCommand comando=conexion.CreateCommand(); //comandos que se van a utilizar a travéz de la conexion
        conexion.Open(); //apertura de la conexión
        comando.CommandType=System.Data.CommandType.StoredProcedure;  //se define que el comando el del tipo procedimiento almacenado
        comando.CommandText="registro_asistencia";  //variable del texto del comando que se va a llamar a través de la conexión

        comando.Parameters.Add("@fecha",System.Data.SqlDbType.datetime2).Value=Asistencia.fecha;        
        comando.Parameters.Add("@codigo_grupo",System.Data.SqlDbType.datetime2).Value=Asistencia.codigo_grupo;
        comando.Parameters.Add("@numero_periodo",System.Data.SqlDbType.datetime2).Value=Asistencia.numero_periodo;    
        comando.Parameters.Add("@anho_periodo",System.Data.SqlDbType.int).Value=Asistencia.anho_periodo;
        comando.Parameters.Add("@nombre_materia",System.Data.SqlDbType.varchar.50).Value=Asistencia.nombre_materia; 
        comando.Parameters.Add("@grado",System.Data.SqlDbType.int).Value=Asistencia.grado;        
        comando.Parameters.Add("@cedula_estudiante",System.Data.SqlDbType.int).Value=Asistencia.cedula_estudiante;        

        comando.ExecuteNonQuery();
        
        conexion.Close(); //cierre de la conexión
    }
}