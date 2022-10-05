using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractMovie
{
    public class Show : Media
    {
        private string _fileName;
        List<int> showIds { get; set; }
        public List<string> showTitles { get; set; }
        public List<int> showEpisode { get; set; }
        public List<int> showSeason { get; set; }
        public List<string> showWriters { get; set; }

        public int Season { get; set; }

        public int Episode { get; set; }

        public string[] Writers { get; set; }

        public Show()
        {
            _fileName = $"{Environment.CurrentDirectory}/shows.csv";

            showIds = new List<int>();
            showTitles = new List<string>();
            showEpisode = new List<int>();
            showSeason = new List<int>();
            showWriters = new List<string>();


        }

        public override void Display()
        {
            for (int i = 0; i < showIds.Count; i++)
            {
                // display movie details
                Console.WriteLine($"Id: {showIds[i]}");
                Console.WriteLine($"Title: {showTitles[i]}");
                Console.WriteLine($"Season(s): {showSeason[i]}");
                Console.WriteLine($"Episode(s): {showEpisode[i]}");
                Console.WriteLine($"Writer(s): {showWriters[i]}");
                Console.WriteLine();
            }
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
                    showIds.Add(int.Parse(movieDetails[0]));
                    // 2nd array element contains movie title
                    showTitles.Add(movieDetails[1]);
                    // 3rd array element contains movie genre(s)
                    // replace "|" with ", "
                    showSeason.Add(int.Parse(movieDetails[2]));

                    showEpisode.Add(int.Parse(movieDetails[3]));

                    showWriters.Add(movieDetails[4].Replace("|", ", "));


                }
                else
                {
                    // quote = comma in movie title
                    // extract the movieId
                    showIds.Add(int.Parse(line.Substring(0, idx - 1)));
                    // remove movieId and first quote from string
                    line = line.Substring(idx + 1);
                    // find the next quote
                    idx = line.IndexOf('"');
                    // extract the movieTitle
                    showTitles.Add(line.Substring(0, idx));
                    // remove title and last comma from the string
                    line = line.Substring(idx + 2);
                    // replace the "|" with ", "
                    showWriters.Add(line.Replace("|", ", "));
                }
            }
            // close file when done
            sr.Close();
        }
    }
}
