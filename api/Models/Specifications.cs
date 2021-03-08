/*
    "specifications": {
            "Originally published":"November 25, 1864",
            "Author":"Jules Verne",
            "Page count": 183,
            "Illustrator": [],
            "Genres": []
  
        }
*/
using System.Collections.Generic;
using System.Text.Json;

namespace api.Models
{
    public class Specifications
    {   
        public string Originallypublished { get; set; }
        public string Author { get; set; }
        public int Pagecount { get; set; }
        public object Illustrator { get; set; }
        public object Genres { get; set; }



    }
}