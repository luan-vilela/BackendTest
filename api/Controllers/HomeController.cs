using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Text.RegularExpressions;
using api.Models;
using System.Web;
using System.Dynamic;

namespace api.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRegras _regras;

        public HomeController(ILogger<HomeController> logger, IRegras regras)
        {
            _logger = logger;
            _regras = regras;
        }

        public IActionResult Index()
        {


            // Root Livro = JsonConvert.DeserializeObject<Livro>(myJsonResponse); 
            // ViewBag.Pagina = new Pagina().fala();
            return View();
        }

        public IActionResult Doc()
        {
            return View();
        }
        //***************************************************************************************************
        //**************
        [HttpGet("api/v1/")]
        [Produces("application/json")]
        public IActionResult Get()
        {
            var livros = _regras.ListarLivros();
        
            if (livros == null)
                return NotFound();

            return Ok(livros);
        }

        [HttpGet("api/v1/filter")]
        [Produces("application/json")]
        public IActionResult Get_filtro()
        {
            var query = Request.Query;

            var livros = _regras.ListarLivros();

            //** Transformar isso em um dicionário **

            if( !string.IsNullOrEmpty(Request.Query["author"]))
                livros = _regras.GetAuthor(query["author"], livros);

            if( !string.IsNullOrEmpty(Request.Query["desc"]))
                livros = _regras.SortByPriceDesc(livros);

            if( !string.IsNullOrEmpty(Request.Query["asc"]))
                livros = _regras.SortByPriceAsc(livros);

            if( !string.IsNullOrEmpty(Request.Query["high"])){
                double price;
                try{
                    price = Double.Parse(Request.Query["high"]);
                }catch(FormatException e){
                    Console.WriteLine("Erro: na conversao" + e);
                    price = -1;
                }

                livros = _regras.HigherPrice(price, livros);
            }
            if( !string.IsNullOrEmpty(Request.Query["low"])){
                double price;
                try{
                    price = Double.Parse(Request.Query["low"]);
                }catch(FormatException e){
                    Console.WriteLine("Erro: na conversao" + e);
                    price = double.PositiveInfinity;
                }

                livros = _regras.LowerPrice(price, livros);
            }
            // page > n
            if( !string.IsNullOrEmpty(Request.Query["page"])){
                int page;
                try{
                    page = int.Parse(Request.Query["page"]);
                }catch(FormatException e){
                    Console.WriteLine("Erro: na conversao" + e);
                    page = 0;
                }

                livros = _regras.GetPages(page, livros);
            }
                    
            

            if (livros == null)
                return NotFound();

            return Ok(livros);
        }

        [HttpGet("api/v1/id/{id}")]
        [Produces("application/json")]
        public IActionResult Get_id(int id)
        {

            Livro livro = _regras.GetID(id);
            if (livro == null)
                return Ok(":( Desculpe, nada para mostrar!");

            return Ok(livro);
            // return NotFound();
        }
        [HttpGet("api/v1/shipping/{id}")]
        [Produces("application/json")]
        public IActionResult Get_shipping(int id)
        {

            Livro livro = _regras.GetID(id);
            if (livro == null)
                return Ok(":( Desculpe, nada para mostrar!");

            return Ok(livro.shipping());
            // return NotFound();
        }

        [HttpGet("api/v1/name/{name}")]
        [Produces("application/json")]
        public IActionResult Get_name(string name)
        {

            IEnumerable<Livro> livro = _regras.GetName(name);

            if (livro == null)
                return Ok(":( Desculpe, nada para mostrar!");

            return Ok(livro);
            // return NotFound();
        }

        [HttpGet("api/v1/asc/")]
        [Produces("application/json")]
        public IActionResult Order_by()
        {

            var livro = _regras.SortByPriceAsc();

            if (livro == null)
                return Ok(":( Desculpe, nada para mostrar!");

            return Ok(livro);
            // return NotFound();
        }

        [HttpGet("api/v1/asc/{price}")]
        [Produces("application/json")]
        public IActionResult Order_by_price(double price)
        {
            var livro = _regras.HigherPrice(price);

            if (livro == null)
                return Ok(":( Desculpe, nada para mostrar!");

            return Ok(livro);
            // return NotFound();
        }

        [HttpGet("api/v1/desc/")]
        [Produces("application/json")]
        public IActionResult Order_desc()
        {

            var livro = _regras.SortByPriceDesc();

            if (livro == null)
                return Ok(":( Desculpe, nada para mostrar!");

            return Ok(livro);
            // return NotFound();
        }

                [HttpGet("api/v1/desc/{price}")]
        [Produces("application/json")]
        public IActionResult Order_desc_price(double price)
        {
            var livro = _regras.LowerPrice(price);

            if (livro == null)
                return Ok(":( Desculpe, nada para mostrar!");

            return Ok(livro);
            // return NotFound();
        }

        [HttpGet("api/v1/author/{author}")]
        [Produces("application/json")]
        public IActionResult Get_author(string author)
        {

            var livro = _regras.GetAuthor(author);

            if (livro == null)
                return Ok(":( Desculpe, nada para mostrar!");

            return Ok(livro);
            
        }

        [HttpGet("api/v1/genres/{genres}")]
        [Produces("application/json")]
        public IActionResult Get_genres(string genres)
        {

            var livro = _regras.GetGenres(genres);

            if (livro == null)
                return Ok(":( Desculpe, nada para mostrar!");

            return Ok(livro);
            
        }

        [HttpGet("api/v1/page/{page}")]
        [Produces("application/json")]
        public IActionResult Get_genres(int page)
        {

            var livro = _regras.GetPages(page);

            if (livro == null)
                return Ok(":( Desculpe, nada para mostrar!");

            return Ok(livro);
            
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }



    }
}
