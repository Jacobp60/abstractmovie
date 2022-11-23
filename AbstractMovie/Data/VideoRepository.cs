using AbstractMovie.Models.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractMovie.Data
{
    public class VideoRepository : IRepository<Video>
    {
        private Context _context;

        public VideoRepository()
        {
            _context = new Context();
        }

        public void Add(Video media)
        {
            _context.Videos.Add(media);
        }

        public List<Video> Get()
        {
            return _context.Videos;
        }

        public Video Search(string searchString)
        {
            return _context.Videos.First(a => a.Title == searchString);
        }
    }
}
