using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractMovie.Models.Types
{
    public class Show : Media
    {
        public string Season { get; set; }

        public string Episode { get; set; }

        public string Writers { get; set; }

        public Show()
        {

        }
        public Show(int ID, string Title, string season, int episode, string writer)
        {

        }



        public override String Display()
        {
            return $"Id: {Id}\nTitle: {Title}\nSeason(s): {Season}";
        }

    }
}
