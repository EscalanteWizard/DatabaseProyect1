namespace TodoApi.Models
{
   public class Cobro{
        private int monto;
        private int cedulaEstudiante;
        private string codigoGrupo;
        private int numPeriodo;
        private int anhoPeriodo;
        private DateTime fechaGeneracion;
        private DateTime fechaPago;
        private int grado;
        private int numFactura;
        private string estado;
        private string concepto;
        private string materia;

        //constructor
        Cobro(int monto,int cedulaEstudiante,string codigoGrupo,int numPeriodo,int anhoPeriodo,int grado,int numFactura,string concepto,string materia){
            setMonto(monto);
            setCedulaEstudiante(cedulaEstudiante);
            setCodigoGrupo(codigoGrupo);
            setNumPeriodo(numPeriodo);
            setAnhoPeriodo(anhoPeriodo);                        
            setGrado(grado);
            setNumFactura(numFactura);
            setEstado("Pendiente");
            setConcepto(concepto);
            setMateria(materia);
            setFechaGeneracion();
        }
        //constructor sobrecargado con fecha de generacion y de pago
        Cobro(int monto,int cedulaEstudiante,string codigoGrupo,int numPeriodo,int anhoPeriodo,DateTime fechaGeneracion,DateTime fechaPago,int grado,int numFactura,string concepto,string materia){
            setMonto(monto);
            setCedulaEstudiante(cedulaEstudiante);
            setCodigoGrupo(codigoGrupo);
            setNumPeriodo(numPeriodo);
            setAnhoPeriodo(anhoPeriodo);
            setFechaGeneracion(fechaGeneracion);
            setFechaPago(fechaPago);
            setGrado(grado);
            setNumFactura(numFactura);
            setEstado("Cancelado");
            setConcepto(concepto);
            setMateria(materia);
        }
        //constructor sobrecargado con fecha de generacion
        Cobro(int monto,int cedulaEstudiante,string codigoGrupo,int numPeriodo,int anhoPeriodo,DateTime fechaGeneracion,int grado,int numFactura,string concepto,string materia){
            setMonto(monto);
            setCedulaEstudiante(cedulaEstudiante);
            setCodigoGrupo(codigoGrupo);
            setNumPeriodo(numPeriodo);
            setAnhoPeriodo(anhoPeriodo);
            setFechaGeneracion(fechaGeneracion);
            setGrado(grado);
            setNumFactura(numFactura);
            setEstado("Pendiente");
            setConcepto(concepto);
            setMateria(materia);
        }
        //constructor sobrecargado con fecha de pago
        Cobro(int monto,int cedulaEstudiante,string codigoGrupo,int numPeriodo,int anhoPeriodo,DateTime fechaPago,int grado,int numFactura,string concepto,string materia){
            setMonto(monto);
            setCedulaEstudiante(cedulaEstudiante);
            setCodigoGrupo(codigoGrupo);
            setNumPeriodo(numPeriodo);
            setAnhoPeriodo(anhoPeriodo);            
            setFechaPago(fechaPago);
            setGrado(grado);
            setNumFactura(numFactura);
            setEstado("Cancelado");
            setConcepto(concepto);
            setMateria(materia);
        }
        //setters
        public void setMonto(int monto){
            this.monto=monto;
        }
        public void setCedulaEstudiante(int cedulaEstudiante){
            this.cedulaEstudiante=cedulaEstudiante;
        }
        public void setCodigoGrupo(string codigoGrupo){
            this.codigoGrupo=codigoGrupo;
        }
        public void setNumPeriodo(int numPeriodo){
            this.numPeriodo=numPeriodo;
        }
        public void setAnhoPeriodo(int anhoPeriodo){
            this.anhoPeriodo=anhoPeriodo;
        }
        public void setFechaGeneracion(DateTime fechaGeneracion){
            this.fechaGeneracion=fechaGeneracion;
        }
        //sets que current date
        public void setFechaGeneracion(){
            DateTime fecha=DateTime.Now;
            this.fechaGeneracion=fecha;
        }
        public void setFechaPago(DateTime fechaPago){
            this.fechaPago=fechaPago;
            this.setEstado("Cancelado");
        }
        //sets the current date as payment date
        public void setFechaPago(){
            DateTime fecha=DateTime.Now;
            this.fechaPago=fecha;            
        }
        public void setGrado(int grado){
            this.grado=grado;
        }
        public void setNumFactura(int numFactura){
            this.numFactura=numFactura;
        }
        public void setEstado(string estado){
            this.estado=estado;
        }
        public void setConcepto(string concepto){
            this.concepto=concepto;
        }
        public void setMateria(string materia){
            this.materia=materia;
        }
        //getters
        public int getMonto(){
            return this.monto;
        }
        public int getCedulaEstudiante(){
            return this.cedulaEstudiante;
        }
        public string getCodigoGrupo(){
            return this.codigoGrupo;
        }
        public int getNumPeriodo(){
            return this.numPeriodo;
        }
        public int getAnhoPeriodo(){
            return this.anhoPeriodo;
        }
        public DateTime getFechaGeneracion(){
            return this.fechaGeneracion;
        }
        public DateTime getFechaPago(){
            return this.fechaPago;            
        }
        public int getGrado(){
            return this.grado;
        }
        public int getNumFactura(){
            return this.numFactura;
        }
        public string getEstado(){
            return this.estado;
        }
        public string getConcepto(){
            return this.concepto;
        }
        public string getMateria(){
            return this.materia;
        }
        //funcion para realizar el pago del cobro
        public void pagar(){
            this.setFechaPago();
            this.setEstado("Cancelado");
        }
   } 
}