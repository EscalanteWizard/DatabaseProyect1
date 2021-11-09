using System.Data.SqlClient;
[HttpPost]
[ValidateAntiForgeryToken]
public async Task<IActionResult> Create([Bind("Atributos")]Salario salario){
    if(ModelState.IsValid){
        SqlConnection conexion=(SqlConnection)_context.Database.GetDbConnection(); //nombre de la conexion
        SqlCommand comando=conexion.CreateCommand(); //comandos que se van a utilizar a travéz de la conexion
        conexion.Open(); //apertura de la conexión
        comando.CommandType=System.Data.CommandType.StoredProcedure;  //se define que el comando el del tipo procedimiento almacenado
        comando.CommandText="registro_salario";  //variable del texto del comando que se va a llamar a través de la conexión

        comando.Parameters.Add("@monto",System.Data.SqlDbType.int).Value=Salario.monto_salario;        
        comando.Parameters.Add("@inicio",System.Data.SqlDbType.datetime2).Value=Salario.inicio_periodo_salario;
        comando.Parameters.Add("@final",System.Data.SqlDbType.datetime2).Value=Salario.final_periodo_salario;                
        comando.Parameters.Add("@cedula_profesor",System.Data.SqlDbType.int).Value=Salario.profesor;
        comando.Parameters.Add("@concepto",System.Data.SqlDbType.varchar.50).Value=Salario.concepto;                

        comando.ExecuteNonQuery();
        
        conexion.Close(); //cierre de la conexión
    }
}