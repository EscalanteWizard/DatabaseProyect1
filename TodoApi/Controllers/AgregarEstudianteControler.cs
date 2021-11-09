using System.Data.SqlClient;
[HttpPost]
[ValidateAntiForgeryToken]
public async Task<IActionResult> Create([Bind("Atributos")]Matricula matricula){
    if(ModelState.IsValid){
        SqlConnection conexion=(SqlConnection)_context.Database.GetDbConnection(); //nombre de la conexion
        SqlCommand comando=conexion.CreateCommand(); //comandos que se van a utilizar a travéz de la conexion
        conexion.Open(); //apertura de la conexión
        comando.CommandType=System.Data.CommandType.StoredProcedure;  //se define que el comando el del tipo procedimiento almacenado
        comando.CommandText="registro_estudiante";  //variable del texto del comando que se va a llamar a través de la conexión

        comando.Parameters.Add("@cedula",System.Data.SqlDbType.int).Value=Estudiante.cedula;
        comando.Parameters.Add("@cedula_padre",System.Data.SqlDbType.int).Value=Estudiante.cedula_padre;        
        comando.Parameters.Add("@grado",System.Data.SqlDbType.int).Value=Estudiante.numero_grado;        

        comando.ExecuteNonQuery();

        conexion.Close(); //cierre de la conexión
    }
}