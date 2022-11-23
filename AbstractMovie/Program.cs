using AbstractMovie.Data;
using AbstractMovie.FileService;
using AbstractMovie.Interface;
using AbstractMovie.Models;
using AbstractMovie.Models.FileMedia;
using AbstractMovie.Models.Types;
using System.Runtime.CompilerServices;


namespace AbstractMovie
{
    public class Program
    {

        public static MovieRepository1 _movieRepo = new MovieRepository1();

        public static ShowRepository _showRepo = new ShowRepository();

        public static VideoRepository _videoRepo = new VideoRepository();

        public static void Main(String[] args)
        {
            MainService startup = new MainService(_showRepo,_movieRepo,_videoRepo);

            startup.Invoke();
        }
      
    }

    
}