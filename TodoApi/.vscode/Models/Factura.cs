namespace TodoApi.Models{    
    
    public class Factura{
        private int numero;
        private int monto;

        //constructor
        Factura(int numero,int monto){
            setNumero(numero);
            setMonto(monto);
        }
        //setters
        public void setNumero(int numero){
            this.numero=numero;
        }
        public void setMonto(int monto){
            this.monto=monto;
        }
        //getters
        public int getNumero(){
            return this.numero;
        }
        public int getMonto(){
            return this.monto;
        }

    }
}