using System.Data.SqlClient;
[HttpPost]
[ValidateAntiForgeryToken]
public async Task<IActionResult> Create([Bind("Atributos")]Usuario usuario){
    if(ModelState.IsValid){
        SqlConnection conexion=(SqlConnection)_context.Database.GetDbConnection(); //nombre de la conexion
        SqlCommand comando=conexion.CreateCommand(); //comandos que se van a utilizar a travéz de la conexion
        conexion.Open(); //apertura de la conexión
        comando.CommandType=System.Data.CommandType.StoredProcedure;  //se define que el comando el del tipo procedimiento almacenado
        comando.CommandText="registrar_usuario";  //variable del texto del comando que se va a llamar a través de la conexión

        comando.Parameters.Add("@nombre",System.Data.SqlDbType.varchar,50).Value=Usuaio.nombre;
        comando.Parameters.Add("@cedula",System.Data.SqlDbType.int).Value=Usuaio.cedula;
        comando.Parameters.Add("@telefono",System.Data.SqlDbType.int).Value=Usuaio.telefono;
        comando.Parameters.Add("@ciudad",System.Data.SqlDbType.varchar,50).Value=Usuaio.ciudad;
        comando.Parameters.Add("@canton",System.Data.SqlDbType.varchar,50).Value=Usuaio.canton;
        comando.Parameters.Add("@fecha_nacimiento",System.Data.SqlDbType.date).Value=Usuaio.fecha_nacimiento;
        comando.Parameters.Add("@fecha_creacion",System.Data.SqlDbType.date).Value=Usuaio.fecha_creacion;
        comando.Parameters.Add("@sexo",System.Data.SqlDbType.varchar,50).Value=Usuaio.sexo;
        comando.Parameters.Add("@password",System.Data.SqlDbType.varchar,50).Value=Usuaio.password;
        comando.ExecuteNonQuery();
        conexion.Close(); //cierre de la conexión
    }
}