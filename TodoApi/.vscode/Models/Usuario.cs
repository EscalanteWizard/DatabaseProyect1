namespace TodoApi.Models
{
    public class Usuario
    {
        private string nombre;
        private int cedula;
        private string telefono;
        private string ciudad;
        private string canton;
        private string sexo;
        private string password;
        private DateTime fechaNac;
        private DateTime fechaCreacion;

        //Constructor
        public Usuario(string nombre,int cedula,string telefono,string ciudad,string canton,strig sexo,string password,DateTime fechaNac){
            this.setNombre(nombre);
            this.setCedula(cedula);
            this.setTelefono(telefono);
            this.setCiudad(ciudad);
            this.setCanton(canton);
            this.setSexo(sexo);
            this.setPassword(password);
            this.setFechaNac(fechaNac);
            this.setFechaCreacion();
        }
        //Constructor sobrecargado para indicar la fecha de creación
        public Usuario(string nombre,int cedula,string telefono,string ciudad,string canton,strig sexo,string password,DateTime fechaNac,DateTime fechaCreacion){
            this.setNombre(nombre);
            this.setCedula(cedula);
            this.setTelefono(telefono);
            this.setCiudad(ciudad);
            this.setCanton(canton);
            this.setSexo(sexo);
            this.setPassword(password);
            this.setFechaNac(fechaNac);
            this.fechaCreacion(fechaCreacion);
        }
        //setters
        public void setCedula(int cedula){
            this.cedula=cedula;
        }
        public void setNombre(string nombe){
            this.nombre=nombre;
        }
        public void setTelefono(string telefono){
            this.telefono=telefono;
        }
        public void setCiudad(string ciudad){
            this.ciudad=ciudad;
        }
        public void setCanton(string canton){
            this.canton=canton;
        }
        public void setSexo(string sexo){
            this.sexo=sexo;
        }
        public void setPassword(string password){
            this.password=password;
        }
        public void setFechaNac(DateTime fechaNac){
            this.fechaNac=fechaNac;
        }
        //getters
        public int getCedula(){
            return this.cedula;
        }
        public string getNombre(){
            return this.nombre;
        }
        public string getTelefono(){
            return this.telefono;
        }
        public string getCiudad(){
            return this.ciudad;
        }
        public string getCanton(){
            return this.canton;
        }
        public string getSexo(){
            return this.sexo;
        }
        public string getPassword(){
            return this.password;
        }
        public DateTime getFechaNac(){
            return this.fechaNac;
        }
        public DateTime getFechaCrea(){
            return this.fechaCreacion;
        }
        //guarda la fecha actual como la fecha de creación del elemento en la base de datos
        public setFechaCreacion(){
            this.fechaCreacion=DateTime.now();
        }        
    }
}