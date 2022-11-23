using AbstractMovie.Models.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractMovie.Data
{
    public class ShowRepository : IRepository<Show>
    {
        private Context _context;

        public ShowRepository()
        {
            _context = new Context();
        }

        public void Add(Show _newshow)
        {
            _context.Shows.Add(_newshow);
        }

        public List<Show> Get()
        {
            return _context.Shows;
        }

        public Show Search(string searchString)
        {
            return _context.Shows.First(a => a.Title == searchString);
        }
    }
}
