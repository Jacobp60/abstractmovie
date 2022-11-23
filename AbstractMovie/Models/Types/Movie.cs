using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractMovie.Models.Types
{
    public class Movie : Media
    {
        public string Genre { get; set; }

        public Movie()
        {
            
        }
        public Movie(int ID, string Title, string Genre)
        {
            
        }

        public override string Display()
        {
            return $"Id: {Id}\nTitle: {Title}\nGenres: {string.Join(", ", Genre)}\n";

        }
    }
}
