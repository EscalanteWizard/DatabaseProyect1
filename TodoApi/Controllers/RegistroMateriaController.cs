using System.Data.SqlClient;
[HttpPost]
[ValidateAntiForgeryToken]
public async Task<IActionResult> Create([Bind("Atributos")]Materia materia){
    if(ModelState.IsValid){
        SqlConnection conexion=(SqlConnection)_context.Database.GetDbConnection(); //nombre de la conexion
        SqlCommand comando=conexion.CreateCommand(); //comandos que se van a utilizar a travéz de la conexion
        conexion.Open(); //apertura de la conexión
        comando.CommandType=System.Data.CommandType.StoredProcedure;  //se define que el comando el del tipo procedimiento almacenado
        comando.CommandText="registro_materia";  //variable del texto del comando que se va a llamar a través de la conexión

        comando.Parameters.Add("@descripcion",System.Data.SqlDbType.varchar,50).Value=Materia_Grado.descripcion_materia;
        comando.Parameters.Add("@nombre",System.Data.SqlDbType.varchar,50).Value=Materia_Grado.nombre;
        comando.Parameters.Add("@grado",System.Data.SqlDbType.int).Value=Materia_Grado.numero_grado;
        comando.Parameters.Add("@costo",System.Data.SqlDbType.int).Value=Materia_Grado.costo;

        comando.ExecuteNonQuery();
        
        conexion.Close(); //cierre de la conexión
    }
}