using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AbstractMovie.Models;
using AbstractMovie.Models.FileMedia;
using AbstractMovie.Models.Types;

namespace AbstractMovie
{

    public class Context
    {
        public List<Movie> Movies { get; set; }

        public List<Video> Videos{ get; set; }  

        public List<Show> Shows { get; set; }


        public Context()
        {
            MovieFile moviefile = new MovieFile();

            Movies = moviefile.MovieList;

            ShowFile showFile = new ShowFile();

            Shows = showFile.ShowList;

            VideoFile videoFile = new VideoFile();

            Videos = videoFile.VideoList;

            
        }



        public List<T> Set<T>()
        {
            var type = typeof(T);
            var contextTables = this.GetType().GetProperties();

            foreach (var property in contextTables)
            {
                if (property.Name.Contains(type.Name))
                {
                    var value = property.GetValue(this, null);
                    return (List<T>)value;
                }
            }

            return null;
        }

    }
}
