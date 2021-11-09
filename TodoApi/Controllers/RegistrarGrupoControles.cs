using System.Data.SqlClient;
[HttpPost]
[ValidateAntiForgeryToken]
public async Task<IActionResult> Create([Bind("Atributos")]Usuario usuario){
    if(ModelState.IsValid){
        SqlConnection conexion=(SqlConnection)_context.Database.GetDbConnection(); //nombre de la conexion
        SqlCommand comando=conexion.CreateCommand(); //comandos que se van a utilizar a travéz de la conexion
        conexion.Open(); //apertura de la conexión
        comando.CommandType=System.Data.CommandType.StoredProcedure;  //se define que el comando el del tipo procedimiento almacenado
        comando.CommandText="registrar_grupo";  //variable del texto del comando que se va a llamar a través de la conexión
    
        comando.Parameters.Add("@anho_periodo",System.Data.SqlDbType.int).Value=Grupo.anho_periodo;
        comando.Parameters.Add("@numero_periodo",System.Data.SqlDbType.int).Value=Grupo.numero_periodo;
        comando.Parameters.Add("@codigo",System.Data.SqlDbType.varchar,50).Value=Grupo.codigo;
        comando.Parameters.Add("@materia",System.Data.SqlDbType.varchar,50).Value=Grupo.nombre_materia;
        comando.Parameters.Add("@grado",System.Data.SqlDbType.int).Value=Grupo.numero_grado;
        comando.Parameters.Add("@estado",System.Data.SqlDbType.int).Value=Grupo.estado;
        comando.Parameters.Add("@cupo",System.Data.SqlDbType.int).Value=Grupo.cupo;

        comando.ExecuteNonQuery();
        conexion.Close(); //cierre de la conexión
    }
}