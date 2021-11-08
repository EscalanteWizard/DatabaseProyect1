namespace TodoApi.Models{
    public class Grado{
        private int num;
        private string description;

        public Grado(int num,string description){
            this.setNumero(num);
            this.setDescripcion(description);
        }
        //setters
        public void setNumero(int num){
            this.num=num;
        }
        public void setDescripcion(string descripcion){
            this.descripcion=descricion;
        }
        //getters
        public int getNumero(){
            return this.num;
        }
        public string getDescripcion(){
            return this.descripcion;
        }
    }
}