namespace TodoApi.Models
{
    public class Estudiante:Usuario{        
        private int numGrado;
        private int cedulaPadre;
        
        //Constructor 
        public Estudiante(string nombre,int cedula,string telefono,string ciudad,string canton,strig sexo,string password,DateTime fechaNac,int numGrado):base(nombre,cedula,telefono,ciudad,canton,sexo,password,fechaNac){
            this.setGrado(numGrado);
        }
        //Constructor sobrecargado con la información de la fecha de creación
        public Estudiante(string nombre,int cedula,string telefono,string ciudad,string canton,strig sexo,string password,DateTime fechaNac,DateTime fechaCreacion,int numGrado):base(nombre,cedula,telefono,ciudad,canton,sexo,password,fechaNac,fechaCreacion){
            this.setGrado(numGrado);            
        }
        //Constructor sobrecargado con la información de la cédula del padre
        public Estudiante(string nombre,int cedula,string telefono,string ciudad,string canton,strig sexo,string password,DateTime fechaNac,int numGrado,int cedulaPadre):base(nombre,cedula,telefono,ciudad,canton,sexo,password,fechaNac){
            this.setGrado(numGrado);
            this.setCedulaPadre(cedulaPadre);
        }
        //Constructor sobrecargado con la información de la fecha de creación y la cedula del padre
        public Estudiante(string nombre,int cedula,string telefono,string ciudad,string canton,strig sexo,string password,DateTime fechaNac,DateTime fechaCreacion,int numGrado,int cedulaPadre):base(nombre,cedula,telefono,ciudad,canton,sexo,password,fechaNac,fechaCreacion){
            this.setGrado(numGrado);
            this.setCedulaPadre(cedulaPadre);
        }
        //setters
        public void setNumGrado(int numGrado){
            this.numGrado=numGrado;
        }
        public void setCedulaPadre(int cedulaPadre){
            this.cedulaPadre=cedulaPadre;
        }
        //getters
        public int getNumGrado(){
            return this.numGrado;
        }
        public int getCedulaPadre(){
            return this.cedulaPadre;
        }
    }
}