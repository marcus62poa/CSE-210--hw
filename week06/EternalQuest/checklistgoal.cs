
public class ChecklistGoal : Goal
{
    
    private int _amountCompleted;
    private int _target;
    private int _bonus;


    public ChecklistGoal(string name, string description, int points, int target, int bonus) : base(name, description, points)
    {
        _amountCompleted = 0; 
        _target = target;
        _bonus = bonus;
    }

  
    public ChecklistGoal(string name, string description, int points, int target, int bonus, int amountCompleted) : base(name, description, points)
    {
        _target = target;
        _bonus = bonus;
        _amountCompleted = amountCompleted;
    }


    public override int RecordEvent()
    {
        _amountCompleted++;
        int pointsEarned = _points;

       
        if (IsComplete())
        {
            pointsEarned += _bonus; 
        }

        return pointsEarned;
    }

   
    public override bool IsComplete()
    {
        return _amountCompleted >= _target;
    }

   
    public override string GetDetailsString()
    {
       
        string status = IsComplete() ? "[X]" : "[ ]";

       
        return $"{status} {_shortName} ({_description}) -- Currently completed: {_amountCompleted}/{_target}";
    }

    
    public override string GetStringRepresentation()
    {
        
        return $"ChecklistGoal:{_shortName},{_description},{_points},{_target},{_bonus},{_amountCompleted}";
    }
}