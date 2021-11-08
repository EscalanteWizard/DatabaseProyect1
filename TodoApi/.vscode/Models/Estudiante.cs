namespace TodoApi.Models
{
    public class Estudiante:Usuario{        
        private int numGrado;
        private string cedulaPadre;
        
        //Constructor 
        public Estudiante(string nombre,string cedula,string telefono,string ciudad,string canton,strig sexo,string password,DateTime fechaNac,int numGrado):base(string nombre,string cedula,string telefono,string ciudad,string canton,strig sexo,string password,DateTime fechaNac){
            this.setGrado(numGrado);
        }
        //Constructor sobrecargado con la información de la fecha de creación
        public Estudiante(string nombre,string cedula,string telefono,string ciudad,string canton,strig sexo,string password,DateTime fechaNac,DateTime fechaCreacion,int numGrado):base(string nombre,string cedula,string telefono,string ciudad,string canton,strig sexo,string password,DateTime fechaNac,DateTime fechaCreacion){
            this.setGrado(numGrado);            
        }
        //Constructor sobrecargado con la información de la cédula del padre
        public Estudiante(string nombre,string cedula,string telefono,string ciudad,string canton,strig sexo,string password,DateTime fechaNac,int numGrado,string cedulaPadre):base(string nombre,string cedula,string telefono,string ciudad,string canton,strig sexo,string password,DateTime fechaNac){
            this.setGrado(numGrado);
            this.setCedulaPadre(cedulaPadre);
        }
        //Constructor sobrecargado con la información de la fecha de creación y la cedula del padre
        public Estudiante(string nombre,string cedula,string telefono,string ciudad,string canton,strig sexo,string password,DateTime fechaNac,DateTime fechaCreacion,int numGrado,string cedulaPadre):base(string nombre,string cedula,string telefono,string ciudad,string canton,strig sexo,string password,DateTime fechaNac,DateTime fechaCreacion){
            this.setGrado(numGrado);
            this.setCedulaPadre(cedulaPadre);
        }
        //setters
        public void setNumGrado(int numGrado){
            this.numGrado=numGrado;
        }
        public void setCedulaPadre(string cedulaPadre){
            this.cedulaPadre=cedulaPadre;
        }
        //getters
        public int getNumGrado(){
            return this.numGrado;
        }
        public string getCedulaPadre(){
            return this.cedulaPadre;
        }
    }
}