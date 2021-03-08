/*
        Classe que implementa interface IRegras. Classe responsável pelas chamadas
    Request da api. Classe possui um construtor que recebe json e retorna uma  Lista 
    de Livros.  
*/

using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Runtime.Serialization.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Linq;

namespace api.Models
{
    public class Regras: IRegras
    {

        private readonly List<Livro> _lista;

        public Regras()
        {
            _lista = JsonToLivro();
        }

        // Cria Lista de livro a partir de um arquivo json
        private List<Livro> JsonToLivro(){
            var path = Directory.GetCurrentDirectory() + @"/../books.json" ;
            
            if(!File.Exists(path))
                return null;
            
            List<Livro> livros = new List<Livro>();
            var json = File.ReadAllText(path);

            // Corrige espaço no parametro
            json = json.Replace(@"Page count", "Pagecount").Replace(@"Originally published", "Originallypublished");
            var ms = new MemoryStream(Encoding.UTF8.GetBytes(json));
            var ser = new DataContractJsonSerializer(livros.GetType());
            var lista = (List<Livro>)ser.ReadObject(ms) as List<Livro>;
            ms.Close();
            return lista;  
        }
        
        public string GeraObjJson<T>(T  lista){
  
            var ms = new MemoryStream();
            var ser = new DataContractJsonSerializer(typeof(T));
            ser.WriteObject(ms, lista);
            byte[] json = ms.ToArray();
            
            ms.Close();
            var jsonString = Encoding.UTF8.GetString(json, 0, json.Length);
            Console.WriteLine(jsonString);
            jsonString = jsonString.Replace(@"Pagecount", "Page count").Replace(@"Originallypublished", "Originally published");
            return jsonString;
        }

        public Livro GetID(int id)
        {
            return _lista.FirstOrDefault(o => o.id.Equals(id));
        }

        public IEnumerable<Livro> ListarLivros()
        {
            return _lista;
        }

        public Livro GetName(string name)
        {
            return _lista.FirstOrDefault(o => o.name.Equals(name));
        }

        public IEnumerable<Livro> GetAutor(string autor, List<Livro> lista = null)
        {
            if(lista != null)
                return lista.Where(o => o.specifications.Author.Equals(autor));   
            return _lista.Where(o => o.specifications.Author.Equals(autor));            
        }

        public IEnumerable<Livro> SortByPriceDesc(List<Livro> lista = null)
        {
            if(lista != null)
                return lista.OrderByDescending(livro => livro.price);
            return _lista.OrderByDescending(livro => livro.price);
        }

        public IEnumerable<Livro> SortByPriceAsc(List<Livro> lista = null)
        {
            if(lista != null)
                return lista.OrderBy(livro => livro.price);
            return _lista.OrderBy(livro => livro.price);
            
        }

        public IEnumerable<Livro> SortBy_price(double price, List<Livro> lista = null)
        {
            if(lista != null)
                return lista.Where(x => x.price >= price);
            return _lista.Where(x => x.price >= price);
            
        }

        // public IEnumerable<Livro> Filter(IEnumerable<<string,string>>  query)
        // {
        //     Console.WriteLine(query["name"]);
        //     return null;
        // }
    }
}