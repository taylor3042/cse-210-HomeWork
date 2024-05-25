using System;
using System.Collections.Generic;
using System.IO;

public abstract class Goal
{
    private string _name;
    private int _points;
    private bool _completed;

    public string Name
    {
        get { return _name; }
        protected set { _name = value; }
    }

    public int Points
    {
        get { return _points; }
        protected set { _points = value; }
    }

    public bool Completed
    {
        get { return _completed; }
        protected set { _completed = value; }
    }

    public Goal(string name, int points)
    {
        _name = name;
        _points = points;
        _completed = false;
    }

    public abstract int RecordEvent();

    public void SetCompleted(bool completed)
    {
        _completed = completed;
    }

    public override string ToString()
    {
        string status = _completed ? "[X]" : "[ ]";
        return $"{status} {_name} ({_points} points)";
    }
}

public class SimpleGoal : Goal
{
    public SimpleGoal(string name, int points) : base(name, points) { }

    public override int RecordEvent()
    {
        if (!Completed)
        {
            SetCompleted(true);
            return Points;
        }
        return 0;
    }
}

public class EternalGoal : Goal
{
    public EternalGoal(string name, int points) : base(name, points) { }

    public override int RecordEvent()
    {
        return Points;
    }

    public override string ToString()
    {
        return $"[∞] {Name} ({Points} points per completion)";
    }
}

public class ChecklistGoal : Goal
{
    private int _current;
    private int _target;

    public int Current
    {
        get { return _current; }
        private set { _current = value; }
    }

    public int Target
    {
        get { return _target; }
        private set { _target = value; }
    }

    public ChecklistGoal(string name, int points, int target) : base(name, points)
    {
        _target = target;
        _current = 0;
    }

    public override int RecordEvent()
    {
        _current++;
        if (_current >= _target)
        {
            SetCompleted(true);
            return Points + 100; // Example bonus points
        }
        return Points;
    }

    public void SetCurrent(int current)
    {
        _current = current;
    }

    public override string ToString()
    {
        string status = Completed ? "[X]" : "[ ]";
        return $"{status} {Name} ({Points} points) - Progress: {Current}/{Target}";
    }
}

public class User
{
    private string _username;
    private int _score;
    private int _level;

    public string Username
    {
        get { return _username; }
    }

    public int Score
    {
        get { return _score; }
        private set
        {
            _score = value;
            UpdateLevel();
        }
    }

    public int Level
    {
        get { return _level; }
    }

    public User(string username)
    {
        _username = username;
        _score = 0;
        _level = 1;
    }

    private void UpdateLevel()
    {
        _level = _score / 1000 + 1; // Example: 1000 points per level
    }

    public void AddPoints(int points)
    {
        Score += points;
    }

    public override string ToString()
    {
        return $"{Username}: Level {Level}, Score {Score}";
    }
}

public class GoalTracker
{
    private List<Goal> _goals;
    private User _user;

    public GoalTracker(string username)
    {
        _goals = new List<Goal>();
        _user = new User(username);
    }

    public void AddGoal(Goal goal)
    {
        _goals.Add(goal);
    }

    public void RecordEvent(string goalName)
    {
        foreach (var goal in _goals)
        {
            if (goal.Name == goalName)
            {
                int points = goal.RecordEvent();
                _user.AddPoints(points);
                break;
            }
        }
    }

    public void DisplayGoals()
    {
        foreach (var goal in _goals)
        {
            Console.WriteLine(goal);
        }
    }

    public void DisplayUser()
    {
        Console.WriteLine(_user);
    }

    public void SaveGoals(string filename)
    {
        using (StreamWriter file = new StreamWriter(filename))
        {
            file.WriteLine(_user.Username);
            file.WriteLine(_user.Score);
            foreach (var goal in _goals)
            {
                if (goal is SimpleGoal)
                    file.WriteLine($"SimpleGoal,{goal.Name},{goal.Points},{goal.Completed}");
                else if (goal is EternalGoal)
                    file.WriteLine($"EternalGoal,{goal.Name},{goal.Points},{goal.Completed}");
                else if (goal is ChecklistGoal checklistGoal)
                    file.WriteLine($"ChecklistGoal,{goal.Name},{goal.Points},{goal.Completed},{checklistGoal.Current},{checklistGoal.Target}");
            }
        }
    }

    public void LoadGoals(string filename)
    {
        if (!File.Exists(filename))
        {
            Console.WriteLine($"File '{filename}' not found.");
            return;
        }

        _goals.Clear();
        using (StreamReader file = new StreamReader(filename))
        {
            string username = file.ReadLine();
            int score = int.Parse(file.ReadLine());
            _user = new User(username);
            _user.AddPoints(score);
            string line;
            while ((line = file.ReadLine()) != null)
            {
                string[] parts = line.Split(',');
                string goalType = parts[0];
                string name = parts[1];
                int points = int.Parse(parts[2]);
                bool completed = bool.Parse(parts[3]);

                if (goalType == "SimpleGoal")
                {
                    var goal = new SimpleGoal(name, points);
                    goal.SetCompleted(completed);
                    _goals.Add(goal);
                }
                else if (goalType == "EternalGoal")
                {
                    var goal = new EternalGoal(name, points);
                    goal.SetCompleted(completed);
                    _goals.Add(goal);
                }
                else if (goalType == "ChecklistGoal")
                {
                    int current = int.Parse(parts[4]);
                    int target = int.Parse(parts[5]);
                    var goal = new ChecklistGoal(name, points, target);
                    goal.SetCurrent(current);
                    goal.SetCompleted(completed);
                    _goals.Add(goal);
                }
            }
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Enter your username: ");
        string username = Console.ReadLine();
        GoalTracker tracker = new GoalTracker(username);

        while (true)
        {
            Console.WriteLine("\nEternal Quest Program");
            Console.WriteLine("1. Add a Simple Goal");
            Console.WriteLine("2. Add an Eternal Goal");
            Console.WriteLine("3. Add a Checklist Goal");
            Console.WriteLine("4. Record Event");
            Console.WriteLine("5. Display Goals");
            Console.WriteLine("6. Display User Info");
            Console.WriteLine("7. Save Goals");
            Console.WriteLine("8. Load Goals");
            Console.WriteLine("9. Exit");

            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                Console.Write("Enter goal name: ");
                string name = Console.ReadLine();
                Console.Write("Enter points: ");
                int points = int.Parse(Console.ReadLine());
                tracker.AddGoal(new SimpleGoal(name, points));
            }
            else if (choice == "2")
            {
                Console.Write("Enter goal name: ");
                string name = Console.ReadLine();
                Console.Write("Enter points: ");
                int points = int.Parse(Console.ReadLine());
                tracker.AddGoal(new EternalGoal(name, points));
            }
            else if (choice == "3")
            {
                Console.Write("Enter goal name: ");
                string name = Console.ReadLine();
                Console.Write("Enter points: ");
                int points = int.Parse(Console.ReadLine());
                Console.Write("Enter target count: ");
                int target = int.Parse(Console.ReadLine());
                tracker.AddGoal(new ChecklistGoal(name, points, target));
            }
            else if (choice == "4")
            {
                Console.Write("Enter goal name to record: ");
                string name = Console.ReadLine();
                tracker.RecordEvent(name);
            }
            else if (choice == "5")
            {
                tracker.DisplayGoals();
            }
            else if (choice == "6")
            {
                tracker.DisplayUser();
            }
            else if (choice == "7")
            {
                Console.Write("Enter filename to save: ");
                string filename = Console.ReadLine();
                tracker.SaveGoals(filename);
            }
            else if (choice == "8")
            {
                Console.Write("Enter filename to load: ");
                string filename = Console.ReadLine();
                tracker.LoadGoals(filename);
            }
            else if (choice == "9")
            {
                break;
            }
            else
            {
                Console.WriteLine("Invalid choice. Please try again.");
            }
        }
    }
}




