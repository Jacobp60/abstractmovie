using AbstractMovie.Models.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractMovie.Models.FileMedia
{
    public class ShowFile
    {
        private string _fileName = $"{Environment.CurrentDirectory}/shows.csv";
        public List<Show> ShowList = new List<Show>();

        public ShowFile()
        {
            StreamReader sr = new StreamReader(_fileName);
            // first line contains column headers
            sr.ReadLine();
            while (!sr.EndOfStream)
            {
                Show show = new Show();
                string line = sr.ReadLine();
                // first look for quote(") in string
                // this indicates a comma(,) in movie title
                int idx = line.IndexOf('"');
                if (idx == -1)
                {

                    // no quote = no comma in movie title
                    // movie details are separated with comma(,)
                    string[] showDetails = line.Split(',');
                    // 1st array element contains movie id
                    show.Id = int.Parse(showDetails[0]);
                    // 2nd array element contains movie title
                    show.Title = showDetails[1];
                    // 3rd array element contains movie genre(s)
                    // replace "|" with ", "
                    show.Season = (showDetails[2]);

                    show.Episode = (showDetails[3]);

                    show.Writers = showDetails[4].Replace("|", ", ");
                    
                }
                else
                {
                    Console.Write("Fix Commas");
                }
                ShowList.Add(show);
            }
            // close file when done
            sr.Close();
        }
    }
}
