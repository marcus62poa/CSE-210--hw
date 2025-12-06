using System;

class Program
{
    /*
    Exceeding Requirements:
    1. Added a 5th prompt to the Reflection Activity.
    2. Implemented logic in ReflectionActivity.cs to ensure no random questions are selected until they have all been used at least once in that session.
    3. Added a new activity: Gratitude Activity, which prompts the user to list three things they are grateful for and why, looping until the duration is complete.
    */
    static void Main(string[] args)
    {
        string choice = "";
        while (choice != "4")
        {
            Console.Clear();
            Console.WriteLine("Menu Options");
            Console.WriteLine("  1. Start breathing activity");
            Console.WriteLine("  2. Start reflection activity");
            Console.WriteLine("  3. Start listing activity");
            Console.WriteLine("  4. Quit");
            Console.Write("Select a choice from the menu: ");
            choice = Console.ReadLine();

            Activity activity = null;

            switch (choice)
            {
                case "1":
                    activity = new BreathingActivity();
                    break;
                case "2":
                    activity = new ReflectionActivity();
                    break;
                case "3":
                    activity = new ListingActivity();
                    break;
                case "4":
                    Console.WriteLine("Thank you for using the Mindfulness Program. Goodbye!");
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    activity = null;
                    break;
            }

            if (activity != null)
            {
                activity.Run();
            }
        }
    }
}