namespace AbstractMovie
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Boolean trueAnswer = true;
            Console.WriteLine("Welcome to Abstract Media Creator!");

            Media media = null;

            while (trueAnswer)
            {
                Console.WriteLine("1- Display Media 2-Exit");
                string userin = Console.ReadLine();
                if (userin == "1")
                {
                    Console.WriteLine("What Meida would you like to display? \n1-Movie\n2-Show\n3-Video");
                    string choice = Console.ReadLine();
                    switch (choice)
                    {
                        case "1": 
                            media = new Movie();
                            media.Read();
                            break;
                        case "2":
                            media = new Show();
                            media.Read();
                            break;
                        case "3":
                            media = new Video();
                            media.Read();
                            break;
                        default:
                            Console.WriteLine("This was an invalid Choice");
                            break;
                    }
                    trueAnswer = false;
                }
                else if (userin == "2")
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

            media?.Display();
           
        }
    }
}