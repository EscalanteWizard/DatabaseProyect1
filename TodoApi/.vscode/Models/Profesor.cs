namespace TodoApi.Models{
    public class Profesor:Usuario{

        //constructor
         Profesor(string nombre,int cedula,string telefono,string ciudad,string canton,strig sexo,string password,DateTime fechaNac):base(nombre,cedula,telefono,ciudad,canton,sexo,password,fechaNac){
        }
        //Constrcutor sobrecargad con la fecha de creacion
        Profesor(string nombre,int cedula,string telefono,string ciudad,string canton,strig sexo,string password,DateTime fechaNac,DateTime fechaCreacion,int numGrado):base(nombre,cedula,telefono,ciudad,canton,sexo,password,fechaNac,fechaCreacion){
        }
    }
}