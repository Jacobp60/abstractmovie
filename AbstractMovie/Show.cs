using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractMovie
{
    public class Show : Media
    {
        public int Season { get; set; }

        public int Episode { get; set; }

        public string[] Writers { get; set; }
        
        public override void Display()
        {
            throw new NotImplementedException();
        }

        public override void Read()
        {
            throw new NotImplementedException();
        }
    }
}
