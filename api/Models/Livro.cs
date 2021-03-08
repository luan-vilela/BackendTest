/*
        Classe modelo para receber a conversão do arquivo Json. Classe tem um
    método shipping, que retorna um valor de frete de 20% do valor do livro.


    #### Corpo Json ####
    {
        "id": 1,
        "name": "Journey to the Center of the Earth",
        "price": 10.00,
        "specifications": {}
    }
*/

namespace api.Models
{
    public class Livro
    {
        public int id { get; set; }
        public string name { get; set; }
        public double price { get; set; }
        public Specifications specifications { get; set; }
        
        //método retorna valor do frete
        public double shipping(){
            return price * 0.2;
        }

    }
}