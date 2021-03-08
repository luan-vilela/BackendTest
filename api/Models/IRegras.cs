/* Interface de regras para requisições */

using api.Models;
using System.Collections.Generic;

namespace api.Models
{
    public interface IRegras
    {
        Livro GetID(int id);
        Livro GetName(string name);
        IEnumerable<Livro> GetAutor(string autor, List<Livro> lista = null);
        IEnumerable<Livro> ListarLivros();

        IEnumerable<Livro> SortByPriceDesc(List<Livro> lista = null);

        IEnumerable<Livro> SortByPriceAsc(List<Livro> lista = null);

        public IEnumerable<Livro> SortBy_price(double price, List<Livro> lista = null);

        // public IEnumerable<Livro> Filter(IEnumerable<<string,string>>  query);
    }
    
}