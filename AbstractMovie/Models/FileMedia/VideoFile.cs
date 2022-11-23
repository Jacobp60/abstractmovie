using AbstractMovie.Models.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractMovie.Models.FileMedia
{
    public class VideoFile
    {
        private string _fileName = $"{Environment.CurrentDirectory}/videos.csv";
        public List<Video> VideoList = new List<Video>();

        public VideoFile()
        {
            StreamReader sr = new StreamReader(_fileName);
            // first line contains column headers
            sr.ReadLine();

            while (!sr.EndOfStream)
            {
                Video video = new Video(); 
                string line = sr.ReadLine();
                // first look for quote(") in string
                // this indicates a comma(,) in movie title
                int idx = line.IndexOf('"');
                if (idx == -1)
                {

                    // no quote = no comma in vidoe title
                    // movie details are separated with comma(,)
                    string[] movieDetails = line.Split(',');
                    // 1st array element contains movie id
                    video.Id = int.Parse(movieDetails[0]);
                    // 2nd array element contains movie title
                    video.Title = movieDetails[1];
                    // 3rd array element contains movie genre(s)
                    // replace "|" with ", "
                    video.Format = (movieDetails[2]);

                    video.Length = (movieDetails[3]);

                    video.Region = movieDetails[4].Replace("|", ", ");


                }
            }
            // close file when done
            sr.Close();
        }
    }
}
