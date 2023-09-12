using Lab1;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Program
{
    static void Main()
    {
        List<VideoGame> videoGamesList = new List<VideoGame>(); // List storing all the video games

        string filePath = "C:\\Users\\12766\\source\\repos\\Lab1\\Lab1\\videogames.csv"; // File path to the csv file

        foreach (string line in File.ReadLines(filePath)) // Reading the lines of the csv file
        {
            string[] columns = line.Split(','); // Splitting the columns by the comma

            if (columns.Length >= 4) // If the columns are greater than or equal to 4, then the program will pull the information from the csv file
            {
                try
                {
                    VideoGame videoGame = new VideoGame // Pulling all 4 columns of information needed from lab
                    {
                        Name = columns[0], // Name of the game
                        Platform = columns[1], // Example: Wii
                        Year = (columns[2]), // Release year of game
                        Genre = columns[3], // Genre of game
                        Publisher = columns[4] // Publisher of game I chose (Activision)
                    };

                    videoGamesList.Add(videoGame);
                }
                catch (Exception ex) // If there is an error, the program will display the error
                {
                    Console.WriteLine($"Error parsing line: {line}, Error: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine($"Skipping line: {line}");
            }
        }

        videoGamesList.Sort(); // Sorting the list of video games

        
        while (true) // While loop to display the options for the Lab
        {
            Console.WriteLine("\nLab 1 Video Games:");
            Console.WriteLine("\n1. Search Publisher");
            Console.WriteLine("2. Search Genre");
            Console.WriteLine("3. Exit Application");
            Console.Write("Enter your choice (1, 2, 3): ");

            string choice = Console.ReadLine(); // Reading line of the user's choice

            switch (choice)
            {
                case "1":
                    // Search the publisher
                    Console.Write("Enter Publisher name: "); // My example: Activision (See screeenshots attached)
                    string chosenPublisher = Console.ReadLine();
                    PublisherData(videoGamesList, chosenPublisher); // Calling the PublisherData method
                    break;

                case "2":
                    // Search the genre
                    Console.Write("Enter Genre: "); // My example: Shooter (See screeenshots attached)
                    string chosenGenre = Console.ReadLine();
                    PublisherData(videoGamesList, chosenGenre); // Calling the PublisherData method
                    break;

                case "3":
                    // Exit application
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please enter 1, 2, or 3."); // If the user enters an invalid choice, error will display
                    break;
            }
        }
    }

    static void PublisherData(List<VideoGame> games, string filter) // Step 7 + 8
    {
        var filteredGames = games
            .Where(game => game.Publisher == filter || game.Genre == filter) // Filters the games by publisher or genre depending on what option you want to select
            .OrderBy(game => game.Name)
            .ToList();

        Console.WriteLine($"\nGames from {filter}:"); // Displays the games from the chosen publisher/genre

        foreach (var game in filteredGames)
        {
            Console.WriteLine(game); // For each game, display the game
        }

        // Calculation for the percentage of games that match the filter
        int totalGames = games.Count;
        int filteredGameCount = filteredGames.Count;
        double filteredPercentage = (double)filteredGameCount / totalGames * 100;

        Console.WriteLine($"\nOut of {totalGames} games, {filteredGameCount} match your filter, which is {filteredPercentage:F2}%."); // Displays % of games that match filter
    }
}