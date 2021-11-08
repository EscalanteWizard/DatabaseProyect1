namespace TodoApi.Models{
    public class Grupo{
        private string nombreMateria;
        private string codigo;
        private int cupo;
        private int numGrado;
        private int numPeriodo;
        private int anhoPeriodo;
        private string estado;

        //constructor
        Grupo(string nombreMateria,string codigo,int cupo,int grado,int periodo,int anho){
            setNombreMateria(nombreMateria);
            setCodigo(codigo);
            setCupo(cupo);
            setGrado(grado);
            setPeriodo(periodo);
            setAnhoPeriodo(anho);
            setEstado("Inactivo");
        }
        //constructor sobrecargado con estado
        Grupo(string nombreMateria,string codigo,int cupo,int grado,int periodo,int anho,string estado){
            setNombreMateria(nombreMateria);
            setCodigo(codigo);
            setCupo(cupo);
            setGrado(grado);
            setPeriodo(periodo);
            setAnhoPeriodo(anho);
            setEstado(estado);
        }
        //setters
        public void setNombreMateria(string nombreMateria){
            this.nombreMateria=nombreMateria;
        }
        public void setCodigo(string codigo){
            this.codigo=codigo;
        }
        public void setCupo(int cupo){
            this.cupo=cupo;
        }
        public void setGrado(int grado){
            this.numGrado=grado;
        }
        public void setPeriodo(int periodo){
            this.numPerido=periodo;
        }
        public void setAnhoPeriodo(int anho){
            this.anhoPeriodo=anho;
        }
        public void setEstado(string estado){
            this.estado=estado;
        }
        //getters
        public string getNombreMateria(){
            return this.nombreMateria;
        }
        public string getCodigo(){
            return this.codigo;
        }
        public int getCupo(){
            return this.cupo;
        }
        public int getGrado(){
            return this.numGrado;
        }
        public int getPeriodo(){
            return this.numPerido;
        }
        public int getAnhoPeriodo(){
            return this.anhoPeriodo;
        }
        public string getEstado(){
            return this.estado;
        }
    }
}