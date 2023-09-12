using Lab1;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Lab1
{
    public class VideoGame : IComparable<VideoGame> // Step 1-3 : Implementing the IComparable interface
    {
       // CSV Properties
        public string Name { get; set; }
        public string Platform { get; set; }
        public string Year { get; set; }
        public string Genre { get; set; }
        public string Publisher { get; set; } 
        public double NA_Sales { get; set; }
        public double EU_Sales { get; set; }
        public double JP_Sales { get; set; }
        public double Other_Sales { get; set; }
        public double Global_Sales { get; set; }

        public int CompareTo(VideoGame other) // Comparison of interface by sorting title
        {
            return this.Name.CompareTo(other.Name); // Comparing the name of the game
        }

        public override string ToString() // Stringing the Name, Year, Genre, and Publisher together
        {
            return $"Name: {Name}, Platform: {Platform}, Year: {Year}, Genre: {Genre}, Publisher: {Publisher}"; // Returning the string output of pulled information
        }

    }

}