namespace TodoApi.Models
{
    public class Padre:Usuario{ 
        private string nombreConyugue;
        private int telefonoConyugue;
        private string profesion;

        //constructor
        public Padre(string nombre,int cedula,string telefono,string ciudad,string canton,strig sexo,string password,DateTime fechaNac,string nombreConyugue,int telefonoConyugue,string profesion):base(nombre,cedula,telefono,ciudad,canton,sexo,password,fechaNac){
            this.setProfesion(profesion);
            this.setTelefonoConyugue(telefonoConyugue);
            this.setNombreConyugue(nombreConyugue);
        }   
        //constructor sobrecargado con la fecha de creación
        public Padre(string nombre,int cedula,string telefono,string ciudad,string canton,strig sexo,string password,DateTime fechaNac,DateTime fechaCreacion,string nombreConyugue,int telefonoConyugue,string profesion):base(nombre,cedula,telefono,ciudad,canton,sexo,password,fechaNac,fechaCreacion){
            this.setProfesion(profesion);
            this.setTelefonoConyugue(telefonoConyugue);
            this.setNombreConyugue(nombreConyugue);
        }  
        //setters         
        public void setProfesion(string profesion){
            this.profesion=profesion;
        }
        public void setTelefonoConyugue(int telefonoConyugue){
            this.telefonoConyugue=telefonoConyugue;
        }
        public void setNombreConyugue(string nombreConyugue){
            this.nombreConyugue=nombreConyugue;
        }
        //getters
        public string getProfesion(){
            return this.profesion;
        }
        public int getTelefonoConyugue(){
            return this.telefonoConyugue;
        }
        public string getNombreConyugue(){
            return this.nombreConyugue;
        }
    }    
}