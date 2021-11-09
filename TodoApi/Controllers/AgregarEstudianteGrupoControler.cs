using System.Data.SqlClient;
[HttpPost]
[ValidateAntiForgeryToken]
public async Task<IActionResult> Create([Bind("Atributos")]Matricula matricula){
    if(ModelState.IsValid){
        SqlConnection conexion=(SqlConnection)_context.Database.GetDbConnection(); //nombre de la conexion
        SqlCommand comando=conexion.CreateCommand(); //comandos que se van a utilizar a travéz de la conexion
        conexion.Open(); //apertura de la conexión
        comando.CommandType=System.Data.CommandType.StoredProcedure;  //se define que el comando el del tipo procedimiento almacenado
        comando.CommandText="registro_estudiante_grupo";  //variable del texto del comando que se va a llamar a través de la conexión

        comando.Parameters.Add("@estudiante",System.Data.SqlDbType.int).Value=Estudiante_grupo.cedula_estudiante;
        comando.Parameters.Add("@grupo",System.Data.SqlDbType.varchar,50).Value=Estudiante_grupo.codigo_grupo;
        comando.Parameters.Add("@anho_periodo",System.Data.SqlDbType.int).Value=Estudiante_grupo.anho_periodo;
        comando.Parameters.Add("@numero_periodo",System.Data.SqlDbType.int).Value=Estudiante_grupo.numero_periodo;
        comando.Parameters.Add("@materia",System.Data.SqlDbType.varchar,50).Value=Estudiante_grupo.nombre_materia;
        comando.Parameters.Add("@grado",System.Data.SqlDbType.int).Value=Estudiante_grupo.numero_grado;        

        comando.ExecuteNonQuery();

        conexion.Close(); //cierre de la conexión
    }
}