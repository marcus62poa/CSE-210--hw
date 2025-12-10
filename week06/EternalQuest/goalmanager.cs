using System.IO;
using System.Collections.Generic;


public class GoalManager
{
    
    private List<Goal> _goals;
    private int _score;

    
    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    
    public void Start()
    {
        int choice = 0;

        while (choice != 6)
        {
            DisplayPlayerInfo();
            Console.WriteLine("\nMenu Options:");
            Console.WriteLine("  1. Create New Goal");
            Console.WriteLine("  2. List Goals");
            Console.WriteLine("  3. Save Goals");
            Console.WriteLine("  4. Load Goals");
            Console.WriteLine("  5. Record Event");
            Console.WriteLine("  6. Quit");
            Console.Write("Select a choice from the menu: ");

            if (int.TryParse(Console.ReadLine(), out choice))
            {
                switch (choice)
                {
                    case 1:
                        CreateGoal();
                        break;
                    case 2:
                        ListGoalDetails();
                        break;
                    case 3:
                        SaveGoals();
                        break;
                    case 4:
                        LoadGoals();
                        break;
                    case 5:
                        RecordEvent();
                        break;
                    case 6:
                        Console.WriteLine("Goodbye!");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number.");
            }
        }
    }

    public void DisplayPlayerInfo()
    {
        Console.WriteLine($"\nYou have {_score} points.");
    }

    public void ListGoalNames()
    {
        Console.WriteLine("\nThe goals are:");
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals found. Create a new goal first.");
            return;
        }

        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"  {i + 1}. {_goals[i].GetShortName()}");
        }
    }

    public void ListGoalDetails()
    {
        Console.WriteLine("\nThe goals are:");
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals found. Create a new goal first.");
            return;
        }

        for (int i = 0; i < _goals.Count; i++)
        {
           
            Console.WriteLine($"  {i + 1}. {_goals[i].GetDetailsString()}");
        }
    }

    public void CreateGoal()
    {
        Console.WriteLine("\nThe types of Goals are:");
        Console.WriteLine("  1. Simple Goal");
        Console.WriteLine("  2. Eternal Goal");
        Console.WriteLine("  3. Checklist Goal");
        Console.Write("Which type of goal would you like to create? ");

        if (!int.TryParse(Console.ReadLine(), out int typeChoice))
        {
            Console.WriteLine("Invalid input.");
            return;
        }

        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();
        Console.Write("What is a short description of it? ");
        string description = Console.ReadLine();
        Console.Write("What is the amount of points associated with this goal? ");

        if (!int.TryParse(Console.ReadLine(), out int points))
        {
            Console.WriteLine("Invalid points value.");
            return;
        }

        Goal newGoal = null;

        switch (typeChoice)
        {
            case 1: 
                newGoal = new SimpleGoal(name, description, points);
                break;
            case 2: 
                newGoal = new EternalGoal(name, description, points);
                break;
            case 3: 
                Console.Write("How many times does this goal need to be accomplished for a bonus? ");
                if (!int.TryParse(Console.ReadLine(), out int target))
                {
                    Console.WriteLine("Invalid target value.");
                    return;
                }
                Console.Write("What is the bonus for accomplishing it that many times? ");
                if (!int.TryParse(Console.ReadLine(), out int bonus))
                {
                    Console.WriteLine("Invalid bonus value.");
                    return;
                }
                newGoal = new ChecklistGoal(name, description, points, target, bonus);
                break;
            default:
                Console.WriteLine("Invalid goal type choice.");
                return;
        }

        if (newGoal != null)
        {
            _goals.Add(newGoal);
            Console.WriteLine($"Goal '{newGoal.GetShortName()}' created successfully.");
        }
    }

    public void RecordEvent()
    {
        ListGoalNames();

        if (_goals.Count == 0) return;

        Console.Write("Which goal did you accomplish? ");
        if (!int.TryParse(Console.ReadLine(), out int index) || index <= 0 || index > _goals.Count)
        {
            Console.WriteLine("Invalid goal number.");
            return;
        }

        Goal goal = _goals[index - 1];

        
        int pointsEarned = goal.RecordEvent();
        _score += pointsEarned;

        if (pointsEarned > 0)
        {
            Console.WriteLine($"Congratulations! You have earned {pointsEarned} points.");
            DisplayPlayerInfo();
        }
        else
        {
            Console.WriteLine($"Goal '{goal.GetShortName()}' cannot be completed again, or is already completed.");
        }
    }

   
    public void SaveGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();

        
        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            
            outputFile.WriteLine(_score);

            
            foreach (Goal goal in _goals)
            {
               
                outputFile.WriteLine(goal.GetStringRepresentation());
            }
        }
        Console.WriteLine("Goals saved successfully.");
    }

   
    public void LoadGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();

        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found.");
            return;
        }

        string[] lines = System.IO.File.ReadAllLines(filename);

        
        if (lines.Length > 0 && int.TryParse(lines[0], out int loadedScore))
        {
            _score = loadedScore;
        }
        else
        {
            Console.WriteLine("Could not load score. Starting score at 0.");
            _score = 0;
        }

        _goals.Clear(); 

       
        for (int i = 1; i < lines.Length; i++)
        {
            string line = lines[i];
            string[] parts = line.Split(":"); 
            string goalType = parts[0];
            string goalDetails = parts[1];

            
            string[] details = goalDetails.Split(",");

            
            string name = details[0];
            string description = details[1];
            int points = int.Parse(details[2]);

            
            Goal loadedGoal = null;
            switch (goalType)
            {
                case "SimpleGoal":
                    bool isComplete = bool.Parse(details[3]);
                    loadedGoal = new SimpleGoal(name, description, points, isComplete);
                    break;
                case "EternalGoal":
                    
                    loadedGoal = new EternalGoal(name, description, points);
                    break;
                case "ChecklistGoal":
                    int target = int.Parse(details[3]);
                    int bonus = int.Parse(details[4]);
                    int amountCompleted = int.Parse(details[5]);
                    loadedGoal = new ChecklistGoal(name, description, points, target, bonus, amountCompleted);
                    break;
            }

            if (loadedGoal != null)
            {
                _goals.Add(loadedGoal);
            }
        }
        Console.WriteLine("Goals loaded successfully.");
    }
}