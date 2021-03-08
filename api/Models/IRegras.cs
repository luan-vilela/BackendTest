/* Interface de regras para requisições */

using api.Models;
using System.Collections.Generic;

namespace api.Models
{
    public interface IRegras
    {
        Livro GetID(int id);
        IEnumerable<Livro> GetName(string name, IEnumerable<Livro> lista = null);
        IEnumerable<Livro> GetAuthor(string author, IEnumerable<Livro> lista = null);
        IEnumerable<Livro> GetIllustrator(string illustrator, IEnumerable<Livro> lista = null);
        IEnumerable<Livro> GetGenres(string genres, IEnumerable<Livro> lista = null);
        IEnumerable<Livro> GetPages(int page, IEnumerable<Livro> lista = null);
        IEnumerable<Livro> ListarLivros();
        IEnumerable<Livro> SortByPriceDesc(IEnumerable<Livro> lista = null);
        IEnumerable<Livro> SortByPriceAsc(IEnumerable<Livro> lista = null);
        IEnumerable<Livro> HigherPrice(double price, IEnumerable<Livro> lista = null);
        IEnumerable<Livro> LowerPrice(double price, IEnumerable<Livro> lista = null);
    }
    
}