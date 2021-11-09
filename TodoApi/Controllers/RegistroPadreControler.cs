using System.Data.SqlClient;
[HttpPost]
[ValidateAntiForgeryToken]
public async Task<IActionResult> Create([Bind("Atributos")]Padre padre){
    if(ModelState.IsValid){
        SqlConnection conexion=(SqlConnection)_context.Database.GetDbConnection(); //nombre de la conexion
        SqlCommand comando=conexion.CreateCommand(); //comandos que se van a utilizar a travéz de la conexion
        conexion.Open(); //apertura de la conexión
        comando.CommandType=System.Data.CommandType.StoredProcedure;  //se define que el comando el del tipo procedimiento almacenado
        comando.CommandText="registro_padre";  //variable del texto del comando que se va a llamar a través de la conexión

        comando.Parameters.Add("@nombre_c",System.Data.SqlDbType.varchar,50).Value=Padre.nombre_conyugue;
        comando.Parameters.Add("@telefono_c",System.Data.SqlDbType.int).Value=Padre.telefono_conyugue;
        comando.Parameters.Add("@profesion",System.Data.SqlDbType.varchar).Value=Padre.profesion;
        comando.Parameters.Add("@cedula",System.Data.SqlDbType.int).Value=Padre.cedula;

        comando.ExecuteNonQuery();
        
        conexion.Close(); //cierre de la conexión
    }
}