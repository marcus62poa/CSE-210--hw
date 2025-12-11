class Program
{
    static void Main(string[] args)
    {
        List<Activity> activities = new List<Activity>();

        Running running1 = new Running("03 Nov 2022", 30, 4.8);
        Cycling cycling1 = new Cycling("04 Nov 2022", 45, 20.0);
        Swimming swimming1 = new Swimming("05 Nov 2022", 60, 40);

        activities.Add(running1);
        activities.Add(cycling1);
        activities.Add(swimming1);

        foreach (Activity activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}