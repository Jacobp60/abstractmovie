using AbstractMovie.Data;
using AbstractMovie.Interface;
using AbstractMovie.Models.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractMovie.FileService
{
    public class MainService : IMainService
    {
        private readonly IRepository<Movie> _movieRepo;

        private readonly IRepository<Show> _showRepo;

        private readonly IRepository<Video> _videoRepo;


        public MainService(IRepository<Show> ShowRepo,IRepository<Movie> MovieRepo,IRepository<Video> VideoRepo)
        {
           _movieRepo = MovieRepo;
           _showRepo = ShowRepo;
           _videoRepo = VideoRepo;
        }
        public void Invoke()
        {
            Boolean trueAnswer = true;
            Console.WriteLine("Welcome to Abstract Media Creator!");

            Media media = null;

            while (trueAnswer)
            {
                Console.WriteLine("1- Display Media 2-Seach Media 3-Exit");
                string userin = Console.ReadLine();
                if (userin == "1")
                {
                    Console.WriteLine("What Meida would you like to display? \n1-Movie\n2-Show\n3-Video");
                    string choice = Console.ReadLine();
                    switch (choice)
                    {
                        case "1":
                            var movies = _movieRepo.Get().ToList();
                            movies.ForEach(x => Console.WriteLine(x.Title));
                            break;
                        case "2":
                            var shows = _showRepo.Get().ToList();
                            shows.ForEach(x => Console.WriteLine(x.Title));
                            break;
                        case "3":
                            var video = _videoRepo.Get().ToList();
                            video.ForEach(x => Console.WriteLine(x.Title));
                            break;
                        default:
                            break;
                        
                    }
                    trueAnswer = false;
                }
                
                else if (userin == "2")
                {
                    Console.WriteLine("What would you like to search?:");
                    var searchLine = Console.ReadLine();

                    var _movie_ = _movieRepo.Search(searchLine);
                    if (_movie_ == null)
                    {
                        Console.WriteLine($"You didn't find a Movie with name containing {searchLine}!");
                    }
                    else
                    {
                        Console.WriteLine($"You found a Movie {_movie_.Title}!");
                    }

                    var _show_ = _showRepo.Search(searchLine);
                    if (_show_ == null)
                    {
                        Console.WriteLine($"You didn't find a Show with name containing {searchLine}!");
                    }
                    else
                    {
                        Console.WriteLine($"You found a Show named {_show_.Title}!");
                    }

                    var _video_ = _showRepo.Search(searchLine);
                    if (_video_ == null)
                    {
                        Console.WriteLine($"You didn't find a Video with name containing {searchLine}!");
                    }
                    else
                    {
                        Console.WriteLine($"You found a Video named {_video_.Title}!");
                    }

                }
                else if (userin == "3")
                {
                    Console.WriteLine("Thank you");
                    trueAnswer = false;
                    break;
                }
                else
                {
                    Console.WriteLine("Please Enter a valid entry");
                }

            }

            
        }
    }
}
