using AbstractMovie.Models.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AbstractMovie.Models.FileMedia
{
    public class MovieFile
    {
        private string _fileName = $"{Environment.CurrentDirectory}/movies.csv";
        public List<Movie> MovieList = new List<Movie>();

        public MovieFile()
        {
            StreamReader sr = new StreamReader(_fileName);
            // first line contains column headers
            sr.ReadLine();
            while (!sr.EndOfStream)
            {
                Movie movie = new Movie();
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
                    //MovieIds.Add(int.Parse(movieDetails[0]));
                    movie.Id = int.Parse(movieDetails[0]);
                    // 2nd array element contains movie title
                    movie.Title= movieDetails[1];
                    // 3rd array element contains movie genre(s)
                    // replace "|" with ", "
                    movie.Genre = movieDetails[2].Replace("|", ", ");


                }
                else
                {
                    // quote = comma in movie title
                    // extract the movieId
                    movie.Id = int.Parse(line.Substring(0, idx - 1));
                    // remove movieId and first quote from string
                    line = line.Substring(idx + 1);
                    // find the next quote
                    idx = line.IndexOf('"');
                    // extract the movieTitle
                    movie.Title = line.Substring(0, idx);
                    // remove title and last comma from the string
                    line = line.Substring(idx + 2);
                    // replace the "|" with ", "
                    movie.Genre = line.Replace("|", ", ");
                }
                MovieList.Add(movie);
            }
            // close file when done
            sr.Close();

        }
    }
}
