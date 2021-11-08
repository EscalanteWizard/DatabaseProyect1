namespace TodoApi.Models{
    public class MateriaGrado{
        private string descripcionMateria;
        private string nombre;
        private int numGrado;
        private int costo;

        //constructor
        public MateriaGrado(string descripcion,string nombre,int num,int costo){
            this.setDescripcion(descripcion);
            this.setNombre(nombre);
            this.setNumero(num);
            this.setCosto(costo);
        }
        //setters
        public void setDescripcion(string descrip){
            this.descripcionMateria=descrip;
        }
        public void setNombre(string name){
            this.nombre=name;
        }
        public void setNumero(int num){
            this.numGrado=num;
        }
        public void setCosto(int cost){
            this.costo=cost;
        }
        //getters
        public string getDescripcion(){
            return this.descripcionMateria;
        }
        public string getNombre(){
            return this.nombre;
        }
        public int getNumero(){
            return this.numGrado;
        }
        public int getCosto(){
            return this.costo;
        }
    }
}