using System.Data.SqlClient;
[HttpPost]
[ValidateAntiForgeryToken]
public async Task<IActionResult> Create([Bind("Atributos")] EvaluacionGrupo evaluacionGrupo){
    if(ModelState.IsValid){
        SqlConnection conexion=(SqlConnection)_context.Database.GetDbConnection(); //nombre de la conexion
        SqlCommand comando=conexion.CreateCommand(); //comandos que se van a utilizar a travéz de la conexion
        conexion.Open(); //apertura de la conexión
        comando.CommandType=System.Data.CommandType.StoredProcedure;  //se define que el comando el del tipo procedimiento almacenado
        comando.CommandText="registro_evaluaciones_notas";  //variable del texto del comando que se va a llamar a través de la conexión

        comando.Parameters.Add("@nombre_materia",System.Data.SqlDbType.varchar,50).Value=Evaluacion_estudiante_grupo.nombre_materia;        
        comando.Parameters.Add("@grado",System.Data.SqlDbType.int).Value=Evaluacion_estudiante_grupo.grado;
        comando.Parameters.Add("@numero_periodo",System.Data.SqlDbType.int).Value=Evaluacion_estudiante_grupo.numero_periodo;    
        comando.Parameters.Add("@anho_periodo",System.Data.SqlDbType.int).Value=Evaluacion_estudiante_grupo.anho_periodo;
        comando.Parameters.Add("@grupo",System.Data.SqlDbType.varchar,50).Value=Evaluacion_estudiante_grupo.grupo; 
        comando.Parameters.Add("@criterio",System.Data.SqlDbType.varchar,50).Value=Evaluacion_estudiante_grupo.criterio;        
        comando.Parameters.Add("@cedula_estudiante",System.Data.SqlDbType.int).Value=Evaluacion_estudiante_grupo.cedula_estudiante;        
        comando.Parameters.Add("@nota",System.Data.SqlDbType.int).Value=Evaluacion_estudiante_grupo.nota;
        comando.Parameters.Add("@estado",System.Data.SqlDbType.int).Value=Evaluacion_estudiante_grupo.estado;        

        comando.ExecuteNonQuery();
        
        conexion.Close(); //cierre de la conexión
    }
}