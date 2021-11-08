namespace TodoApi.Models{
    public class Matricula{
        private int estudiante;
        private int numPeriodo;
        private int anhoPeriodo;
        private string codigoGrupo;
        private string materia;
        private string estado;
         
        //constructor
        Matricula(int estudiante,int numPeriodo,int anhoPeriodo,string codigoGrupo,string materia,string estado){
            setEstudiante(estudiante);
            setNumPeriodo(numPeriodo);
            setAnhoPeriodo(anhoPeriodo);
            setCodigoGrupo(codigoGrupo);
            setMateria(materia);
            setEstado(estado);
        }
        //setters
        public void setEstudiante(int estudiante){
            this.estudiante=estudiante;
        }
        public void setNumPeriodo(int numPeriodo){
            this.numPeriodo=numPeriodo;
        }
        public void setAnhoPeriodo(int anhoPeriodo){
            this.anhoPeriodo=anhoPeriodo;
        }
        public void setCodigoGrupo(string codigoGrupo){
            this.codigoGrupo=codigoGrupo;
        }
        public void setMateria(string materia){
            this.materia=materia;
        }
        public void setEstado(string estado){
            this.estado=estado;
        }
        //getters
        public int getEstudiante(){
            return this.estudiante;
        }
        public int getNumPeriodo(){
            return this.numPeriodo;
        }
        public int getAnhoPeriodo(){
            return this.anhoPeriodo;
        }
        public string getCodigoGrupo(){
            return this.codigoGrupo;
        }
        public string getMateria(){
            return this.materia;
        }
        public string getEstado(){
            return this.estado;
        }
    }
}