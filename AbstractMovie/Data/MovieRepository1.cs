using AbstractMovie.Models.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractMovie.Data
{
    public class MovieRepository1 : IRepository<Movie>
    {
        private Context _context;

        public MovieRepository1()
        {
            _context = new Context();
        }

        public void Add(Movie _newMovie_)
        {
           _context.Movies.Add(_newMovie_);
        }

        public List<Movie> Get()
        {
            return _context.Movies;
        }

        public Movie Search(string searchString)
        {
            return _context.Movies.First(a => a.Title == searchString);
        }
    }
}
