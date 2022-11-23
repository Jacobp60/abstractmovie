using AbstractMovie.Models.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractMovie.Data
{
    public interface IRepository<T> where T : Media
    {
        void Add(T media);
        List<T> Get();
        T Search(string searchString);
    }

}
