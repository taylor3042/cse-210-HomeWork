using System; 

public class Job
{
    private string _jobTitle; 

    public Job(string jobTitle)
    {
        _jobTitle = jobTitle;
    }

    public string GetJobTitle() 
    {
        return _jobTitle;
    }

    public void SetJobTitle(string jobTitle) 
    {
        _jobTitle = jobTitle;
    }

    public void Display() 
    {
        Console.WriteLine(_jobTitle);
    }
}
