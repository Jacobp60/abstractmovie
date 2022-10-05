using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractMovie
{
    public class Video : Media
    {
        private string _fileName;
        List<int> videoIds { get; set; }
        public List<string> videoTitles { get; set; }
        public List<string> videoFormat { get; set; }
        public List<int> videoLength { get; set; }
        public List<string> videoRegions { get; set; }

        public Video() 
        {
            _fileName = $"{Environment.CurrentDirectory}/videos.csv";

            videoIds = new List<int>();
            videoTitles = new List<string>();
            videoFormat = new List<string>();
            videoLength = new List<int>();
            videoRegions = new List<string>();
        }

        public override void Display()
        {
            for (int i = 0; i < videoIds.Count; i++)
            {
                Console.WriteLine($"Id: {videoIds[i]}");
                Console.WriteLine($"Title: {videoTitles[i]}");
                Console.WriteLine($"Format: {videoFormat[i]}");
                Console.WriteLine($"Length: {videoLength[i]}");
                Console.WriteLine($"Regions(s): {videoRegions[i]}");
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

                    // no quote = no comma in vidoe title
                    // movie details are separated with comma(,)
                    string[] movieDetails = line.Split(',');
                    // 1st array element contains movie id
                    videoIds.Add(int.Parse(movieDetails[0]));
                    // 2nd array element contains movie title
                    videoTitles.Add(movieDetails[1]);
                    // 3rd array element contains movie genre(s)
                    // replace "|" with ", "
                    videoFormat.Add(movieDetails[2]);

                    videoLength.Add(int.Parse(movieDetails[3]));

                    videoRegions.Add(movieDetails[4].Replace("|", ", "));


                }
                else
                {
                    // quote = comma in movie title
                    // extract the movieId
                    videoIds.Add(int.Parse(line.Substring(0, idx - 1)));
                    // remove movieId and first quote from string
                    line = line.Substring(idx + 1);
                    // find the next quote
                    idx = line.IndexOf('"');
                    // extract the movieTitle
                    videoTitles.Add(line.Substring(0, idx));
                    // remove title and last comma from the string
                    line = line.Substring(idx + 2);
                    // replace the "|" with ", "
                    videoRegions.Add(line.Replace("|", ", "));
                }
            }
            // close file when done
            sr.Close();
        }
    }
}
