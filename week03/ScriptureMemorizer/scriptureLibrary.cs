using System;
using System.Collections.Generic;
using System.IO;

public class ScriptureLibrary
{
    private List<Scripture> _scriptures;
    private Random _random;

    
    public ScriptureLibrary()
    {
        _random = new Random();
        _scriptures = new List<Scripture>();

        // Built-in scriptures (safe defaults)
        AddBuiltInScriptures();

        
        TryLoadFromFile("scriptures.txt");
    }

    private void AddBuiltInScriptures()
    {
        
        _scriptures.Add(new Scripture(
            new Reference("John", 3, 16),
            "For God so loved the world that he gave his one and only Son, that whoever believes in him shall not perish but have eternal life."
        ));

        _scriptures.Add(new Scripture(
            new Reference("Proverbs", 3, 5, 6),
            "Trust in the Lord with all your heart and lean not on your own understanding; in all your ways submit to him, and he will make your paths straight."
        ));

        _scriptures.Add(new Scripture(
            new Reference("Psalm", 23, 1),
            "The Lord is my shepherd; I shall not want."
        ));

        _scriptures.Add(new Scripture(
            new Reference("Philippians", 4, 13),
            "I can do all things through Christ who gives me strength."
        ));
    }

   
    private void TryLoadFromFile(string filename)
    {
        try
        {
            if (!File.Exists(filename)) return;

            string[] lines = File.ReadAllLines(filename);
            foreach (string raw in lines)
            {
                if (string.IsNullOrWhiteSpace(raw)) continue;
                string line = raw.Trim();
                string[] parts = line.Split('|', 5);
                if (parts.Length < 5) continue;

                string book = parts[0].Trim();
                if (!int.TryParse(parts[1], out int chapter)) continue;
                if (!int.TryParse(parts[2], out int startVerse)) continue;

                int endVerse = startVerse;
                if (!string.IsNullOrWhiteSpace(parts[3]) && int.TryParse(parts[3], out int parsedEnd))
                {
                    endVerse = parsedEnd;
                }

                string text = parts[4].Trim();
                Reference reference = new Reference(book, chapter, startVerse, endVerse);
                _scriptures.Add(new Scripture(reference, text));
            }
        }
        catch
        {
           
        }
    }

    public Scripture GetRandomScripture()
    {
        if (_scriptures.Count == 0) throw new InvalidOperationException("No scriptures in library.");
        int idx = _random.Next(_scriptures.Count);
        return _scriptures[idx];
    }
}
