namespace TodoApi.Models
{
    public class EvaluacionGrupo{
        private string nombreMateria;
        private int grado;
        private int numeroPeriodo;
        private int anhoPeriodo;
        private string grupo;
        private double porcentaje;
        private string criterio;

        //constructor
        EvaluacionGrupo(string materia,int grado,int periodo,int anho,string grupo,string criterio){
            setNombreMateria(materia);
            setGrado(grado);
            setNumPeriodo(perido);
            setAnhoPeriodo(anho);
            setGrupo(grupo);            
            setCriterio(criterio);
        }
        //constructor sobrecargado con el porcentaje
        EvaluacionGrupo(string materia,int grado,int periodo,int anho,string grupo,double porcentaje,string criterio){
            setNombreMateria(materia);
            setGrado(grado);
            setNumPeriodo(perido);
            setAnhoPeriodo(anho);
            setGrupo(grupo);
            setPorcentaje(porcentaje);
            setCriterio(criterio);
        }
        //setters
        public void setNombreMateria(string materia){
            this.nombreMateria=materia;
        }
        public void setGrado(int grado) {
            this.grado=grado;
        }
        public void setNumPeriodo(int periodo){
            this.numeroPeriodo=periodo;
        }
        public void setAnhoPeriodo(int anho){
            this.anhoPeriodo=anho;
        }
        public void setGrupo(string grupo){
            this.grupo=grupo;
        }
        public void setPorcentaje(double porcentaje){
            this.porcentaje=porcentaje;
        }
        public void setCriterio(string criterio){
            this.criterio=criterio;
        }
        //getters
        public string getNombreMateria(){
            return this.nombreMateria;
        }
        public int getGrado(){
            return this.grado;
        }
        public int getNumPeriodo(){
            return this.numeroPeriodo;
        }
        public int getAnhoPeriodo(){
            return this.anhoPeriodo;
        }
        public string getGrupo(){
            return this.grupo;
        }
        public double getPorcentaje(){
            return this.porcentaje;
        }
        public string getCriterio(){
            return this.criterio;
        }
    }
}