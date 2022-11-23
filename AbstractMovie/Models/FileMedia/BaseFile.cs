using AbstractMovie.Models.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractMovie.Models.FileMedia
{
    public abstract class BaseFile<T> where T : Media
    {
        public List<T> MediaList { get; set; }


    }
}
