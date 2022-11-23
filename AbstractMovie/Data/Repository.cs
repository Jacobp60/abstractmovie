using AbstractMovie.Models.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractMovie.Data
{
    public class Repository<T> : IRepository<T> where T : Media
    {
        private Context _context;
        private List<T> medias;

        public Repository()
        {
            _context = new Context();
            medias = _context.Set<T>();
        }

        public void Add(T Media)
        {
            medias.Add(Media);
        }

        public  List<T> Get()
        {
            return medias;
        }

        public T Search(string searchString)
        {
            return medias.FirstOrDefault(a => a.Title.Contains(searchString, StringComparison.CurrentCultureIgnoreCase));
        }
    }
}
