namespace TodoApi.Models{
    public class ProfesorGrupo{
        private int numPeriodo;
        private int anhoPeriodo;
        private string nombreMateria;
        private int grado;
        private string grupo;
        private int cedulaProfesor;

        //constructor
        ProfesorGrupo(int numPeriodo,int anhoPeriodo,string nombreMateria,int grado,string grupo,int cedulaProfesor){
            setNumPeriodo(numPeriodo);
            setAnhoPeriodo(anhoPeriodo);
            setNombreMateria(nombreMateria);
            setGrado(grado);
            setGrupo(grupo);
            setCedulaProfesor(cedulaProfesor);
        }
        //setters
        public void setNumPeriodo(int numPeriodo){
            this.numPeriodo=numPeriodo;
        }
        public void setAnhoPeriodo(int anhoPeriodo){
            this.anhoPerido=anhoPeriodo;
        }
        public void setNombreMateria(string nombreMateria){
            this.nombreMateria=nombreMateria;
        }
        public void setGrado(int grado){
            this.grado=grado;
        }
        public void setGrupo(string grupo){
            this.grupo=grupo;
        }
        public void setCedulaProfesor(int cedulaProfesor){
            this.cedulaProfesor=cedulaProfesor;
        }
        //getters
        public int getNumPeriodo(){
            return this.numPeriodo;
        }
        public int getAnhoPeriodo(){
            return this.anhoPerido;
        }
        public string getNombreMateria(){
            return this.nombreMateria;
        }
        public int getGrado(){
            return this.grado;
        }
        public string getGrupo(){
            return this.grupo;
        }
        public int getCedulaProfesor(){
            return this.cedulaProfesor;
        }
    }
}