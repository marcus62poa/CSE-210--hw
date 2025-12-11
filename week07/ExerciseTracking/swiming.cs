class Swimming : Activity
{
    private int _laps;
    private const double LapLengthMeters = 50;
    private const double MetersInKm = 1000;

    public Swimming(string date, int lengthMinutes, int laps) : base(date, lengthMinutes)
    {
        _laps = laps;
    }

    public override double GetDistance()
    {
        return (_laps * LapLengthMeters) / MetersInKm;
    }

    public override double GetSpeed()
    {
        return (GetDistance() / GetLengthMinutes()) * 60;
    }

    public override double GetPace()
    {
        return GetLengthMinutes() / GetDistance();
    }
}