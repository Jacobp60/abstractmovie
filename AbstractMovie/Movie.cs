using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractMovie
{
    public class Movie : Media
    {
        List<int> MovieIds { get; set; }
        public List<string> MovieTitles { get; set; }
        public List<string> MovieGenres { get; set; }
        private string _fileName;
        private List<Movie> _movies;

        public string Genres { get; set; }

        public Movie()
        {
            _movies = new List<Movie>();
            _fileName = $"{Environment.CurrentDirectory}/movies.csv";

            MovieIds = new List<int>();
            MovieTitles = new List<string>();
            MovieGenres = new List<string>();
        }

        public Movie(int ID, string Title, string Genre)
        {
            _movies = new List<Movie>();
        }

        public override void Read()
        {
            StreamReader sr = new StreamReader(_fileName);
            // first line contains column headers
            sr.ReadLine();
            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                // first look for quote(") in string
                // this indicates a comma(,) in movie title
                int idx = line.IndexOf('"');
                if (idx == -1)
                {
                 
                    // no quote = no comma in movie title
                    // movie details are separated with comma(,)
                    string[] movieDetails = line.Split(',');
                    // 1st array element contains movie id
                    MovieIds.Add(int.Parse(movieDetails[0]));
                    // 2nd array element contains movie title
                    MovieTitles.Add(movieDetails[1]);
                    // 3rd array element contains movie genre(s)
                    // replace "|" with ", "
                    MovieGenres.Add(movieDetails[2].Replace("|", ", "));

                    
                }
                else
                {
                    // quote = comma in movie title
                    // extract the movieId
                    MovieIds.Add(int.Parse(line.Substring(0, idx - 1)));
                    // remove movieId and first quote from string
                    line = line.Substring(idx + 1);
                    // find the next quote
                    idx = line.IndexOf('"');
                    // extract the movieTitle
                    MovieTitles.Add(line.Substring(0, idx));
                    // remove title and last comma from the string
                    line = line.Substring(idx + 2);
                    // replace the "|" with ", "
                    MovieGenres.Add(line.Replace("|", ", "));
                }
            }
            // close file when done
            sr.Close();
        }

        public override void Display()
        {

            for (int i = 0; i < MovieIds.Count; i++)
            {
                // display movie details
                Console.WriteLine($"Id: {MovieIds[i]}");
                Console.WriteLine($"Title: {MovieTitles[i]}");
                Console.WriteLine($"Genre(s): {MovieGenres[i]}");
                Console.WriteLine();
            }
        }
    }
}
