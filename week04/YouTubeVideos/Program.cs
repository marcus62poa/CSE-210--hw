// Program.cs

using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
      
        List<Video> videos = new List<Video>();

        // ----------------- Video 1 -
        Video video1 = new Video("C# Abstraction Deep Dive", "Tech Guru", 650);

       
        video1.AddComment(new Comment("Alice", "Great explanation of classes!"));
        video1.AddComment(new Comment("Bob_Codes", "Very helpful for the assignment. Thanks!"));
        video1.AddComment(new Comment("Charlie_Dev", "I liked the use of composition here."));
        video1.AddComment(new Comment("Diana_Programmer", "Concise and clear examples."));

        videos.Add(video1);

        // ----------------- Video 2 ------------
        Video video2 = new Video("Introduction to OOP", "Code Master", 900);

        // Add 3 comments (must be at least 3)
        video2.AddComment(new Comment("Eve", "The best overview of OOP principles I've seen."));
        video2.AddComment(new Comment("Frankie", "Could you do a video on interfaces next?"));
        video2.AddComment(new Comment("Grace", "Perfect for beginners."));

        videos.Add(video2);

        // ----------------- Video 3 ----
        // Must create at least 3 Video objects.
        Video video3 = new Video("Advanced C# Topics", "Pro Dev", 1200);

        video3.AddComment(new Comment("Henry", "The async/await section was really useful."));
        video3.AddComment(new Comment("Ivy", "Top-tier content as always."));
        video3.AddComment(new Comment("Jack", "I re-watched the generics part multiple times."));

        videos.Add(video3);

        Console.WriteLine("--- YouTube Videos and Comments Report ---");
        Console.WriteLine();

        foreach (Video video in videos)
        {
            
            Console.WriteLine($"Title: {video.GetTitle()}");
            Console.WriteLine($"Author: {video.GetAuthor()}");
            Console.WriteLine($"Length (seconds): {video.GetLengthInSeconds()}");
          
            Console.WriteLine($"Number of Comments: {video.GetNumberOfComments()}");
            Console.WriteLine("Comments:");

        
            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($"- {comment.GetCommenterName()}: \"{comment.GetCommentText()}\"");
            }

            Console.WriteLine(); 
        }
    }
}