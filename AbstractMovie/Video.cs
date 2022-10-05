using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractMovie
{
    public class Video : Media
    {
        public string Format { get; set; }

        public int Length { get; set; }

        public int[] Eegions { get; set; }

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
