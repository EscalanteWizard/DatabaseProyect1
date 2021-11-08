namespace TodoApi.Models{
    public class Salario{
        private int monto;
        private DateTime inicioPeriodoSalario;
        private DateTime finPeriodoSalario;
        private int cedulaProfesor;
        private string concepto;

        //constructor
        Salario(int monto,DateTime inicioPeriodoSalario,DateTime finPeriodoSalario,int cedulaProfesor,string concepto){
            setMonto(monto);
            setInicioPeriodoSalario(inicioPeriodoSalario);
            setFinPeriodoSalario(finPeriodoSalario);
            setCedulaProfesor(cedulaProfesor);
            setConcepto(concepto);
        }
        //setters
        public void setMonto(int monto){
            this.monto=monto;
        }
        public void setInicioPeriodoSalario(DateTime inicioPeriodoSalario){
            this.inicioPeriodoSalario=inicioPeriodoSalario;
        }
        public void setFinPeriodoSalario(DateTime finPeriodoSalario){
            this.finPeriodoSalario=finPeriodoSalario;
        }
        public void setCedulaProfesor(int cedulaProfesor){
            this.cedulaProfesor=cedulaProfesor;
        }
        public void setConcepto(string concepto){
            this.concepto=concepto;
        }
        //getters
        public int getMonto(){
            return this.monto;
        }
        public DateTime getInicioPeriodoSalario(){
            return this.inicioPeriodoSalario;
        }
        public DateTime getFinPeriodoSalario(){
            return this.finPeriodoSalario;
        }
        public int getCedulaProfesor(){
            return this.cedulaProfesor;
        }
        public string getConcepto(){
            return this.concepto;
        }
    }
}