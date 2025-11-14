
using System;
using System.Collections.Generic;


// Creative Feature: Scripture Library
// I added a ScriptureLibrary class containing multiple scriptures.
// This allows the program to randomly select a verse each time,
// adding variety and extending functionality beyond the instructions.
class Program
{
    static void Main(string[] args)
    {
        Console.Title = "Scripture Memorizer";

       
        ScriptureLibrary library = new ScriptureLibrary();
        Scripture scripture = library.GetRandomScripture();

        
        while (true)
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            if (scripture.IsCompletelyHidden())
            {
                
                Console.WriteLine();
                Console.WriteLine("All words are hidden. Press Enter to exit.");
                Console.ReadLine();
                break;
            }

            Console.WriteLine();
            Console.WriteLine("Press Enter to hide a few words or type 'quit' to exit.");
            string input = Console.ReadLine().Trim();

            if (input.Equals("quit", StringComparison.OrdinalIgnoreCase))
            {
                break;
            }

            
            scripture.HideRandomWords(3);
        }
    }
}
