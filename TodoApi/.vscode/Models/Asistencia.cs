namespace TodoApi.Models
{
    public class Asistencia{
        private DateTime fecha;
        private string codigoGrupo;
        private int periodo;
        private int anhoPeriodo;
        private string nombreMateria;
        private int grado;
        private int cedulaEstudiante;

        //constructor
        Asistencia(DateTime fecha,string codigoGrupo,int periodo,int anhoPeriodo,string nombreMateria,int grado,int cedulaEstudiante){
            setFecha(fecha);
            setCodigoGrupo(codigoGrupo);
            setPeriodo(periodo);
            setAnhoPeriodo(anhoPeriodo);
            setNombreMateria(nombreMateria);
            setGrado(grado);
            setCedulaEstudiante(cedulaEstudiante);
        }
        //setters
        public void setFecha(DateTime fecha){
            this.fecha=fecha;
        }
        public void setCodigoGrupo(string codigoGrupo){
            this.codigoGrupo=codigoGrupo;
        }
        public void setPeriodo(int periodo){
            this.periodo=periodo;
        }
        public void setAnhoPeriodo(int anhoPeriodo){
            this.anhoPeriodo=anhoPeriodo;
        }
        public void setNombreMateria(int nombreMateria){
            this.nombreMateria=nombreMateria;
        }
        public void setGrado(int grado){
            this.grado=grado;
        }
        public void setCedulaEstudiante(int cedulaEstudiante){
            this.cedulaEstudiante=cedulaEstudiante;
        }
        //getters
        public DateTime getFecha(){
            return this.fecha;
        }
        public string getCodigoGrupo(){
            return this.codigoGrupo;
        }
        public int getPeriodo(){
            return this.periodo;
        }
        public int getAnhoPeriodo(){
            return this.anhoPeriodo;
        }
        public void getNombreMateria(){
            return this.nombreMateria;
        }
        public int getGrado(){
            return this.grado;
        }
        public int getCedulaEstudiante(){
            return this.cedulaEstudiante;
        }
    }
}