using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractMovie.Models.Types
{
    public class Video : Media
    {
        public String Format { get; set; }

        public String Length { get; set; }

        public string Region { get; set; }

        public Video()
        {
            
        }

        public override String Display()
        {
            
            return $"Id: {Id}\nTitle: {Title}\nFormat: {Format}\nLength: {Length}\nRegion: {Region}";

        }
    }
}
