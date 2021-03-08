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

        public IActionResult Privacy()
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

        [HttpGet("api/v1/filtro")]
        [Produces("application/json")]
        public IActionResult Get_filtro()
        {
            var filtro = new List<string> {"Author", "Desc", "Asc"};
            var livros = Request.Query;
            // _regras.Filter(livros);

            Console.WriteLine(livros["name"]);

            foreach(string key in livros.Keys){
                Console.WriteLine(livros[key]);
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

            Livro livro = _regras.GetName(name);

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

            var livro = _regras.SortBy_price(price);

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

        [HttpGet("api/v1/author/{author}")]
        [Produces("application/json")]
        public IActionResult Get_author(string author)
        {

            var livro = _regras.GetAutor(author);

            if (livro == null)
                return Ok(":( Desculpe, nada para mostrar!");

            return Ok(livro);
            // return NotFound();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }



    }
}
