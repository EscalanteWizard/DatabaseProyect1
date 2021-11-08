namespace TodoApi.Models{
    Public class Periodo{
        private DateTime fecha_inicio;
        private DateTime fecha_final;
        private int anho;
        private int numero;
        private int notaMinima;

        //constructor
        public Periodo(DateTime fechaInicio,int anho,int numero,int notaMinima){
            this.setFechaInicio(fechaInicio);            
            this.setAnho(anho);
            this.setNumero(numero);
            this-setNotaMinima(notaMinima);            
        }
        //constructor sobrecargado con fecha final
        public Periodo(DateTime fechaInicio,DateTime fechaFin,int anho,int numero,int notaMinima){
            this.setFechaInicio(fechaInicio);
            this.setFechaFinal(fechaFin);
            this.setAnho(anho);
            this.setNumero(numero);
            this-setNotaMinima(notaMinima);            
        }
        //settters
        public void setFechaInicio(DateTime fechaInicio){
            this.fechaInicio=fechaInicio;
        }
        public void setFechaFin(DateTime fechaFin){
            this.fechaFinal=fechaFin;
        }
        public void setAnho(int anho){
            this.anho=anho;
        }
        public void setNumero(int num){
            this.numero=num;
        }
        public void setNotaMinima(int notaMin){
            this.notaMinima=notaMin;
        }
        //getters
        public DateTime getFechaInicio(){
            return this.fechaInicio;
        }
        public DateTime getFechaFin(){
            return this.fechaFinal;
        }
        public int getAnho(){
            return this.anho;
        }
        public int getNumero(){
            return this.numero;
        }
        public int getNotaMinima(){
            return this.notaMinima;
        }
    }
}