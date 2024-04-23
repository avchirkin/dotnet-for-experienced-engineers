namespace DependencyInversionBasics;

public class FitnessTracker : ITraceable
{
    private string _owner;
    private int _steps;
    
    public FitnessTracker(string owner)
    {
        _owner = owner;
    }
    
    public void Trace()
    {
        Console.WriteLine($"{_owner} walked {_steps} steps totally");
    }

    public void IncreaseSteps(int stepsCount)
    {
        _steps += stepsCount;
    }
}