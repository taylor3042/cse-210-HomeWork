using System;
using System.Collections.Generic;
using System.Threading;

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Exit");
            Console.Write("Choose an activity: ");

            if (!int.TryParse(Console.ReadLine(), out int choice) || choice < 1 || choice > 4)
            {
                Console.WriteLine("Invalid choice. Please try again.");
                continue;
            }

            if (choice == 4)
            {
                Console.WriteLine("Exiting program...");
                break;
            }

            Activity activity = null;
            switch (choice)
            {
                case 1:
                    activity = new BreathingActivity();
                    break;
                case 2:
                    activity = new ReflectionActivity();
                    break;
                case 3:
                    activity = new ListingActivity();
                    break;
            }

            activity.Start();
            Console.WriteLine("Activity completed. Press any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }
    }
}

abstract class Activity
{
    protected string name;
    protected string description;
    protected int duration;

    public Activity(string name, string description)
    {
        this.name = name;
        this.description = description;
    }

    public void Start()
    {
        Console.WriteLine($"{name} - {description}");
        SetDuration();
        PrepareToBegin();
        DoActivity();
        Conclude();
    }

    protected void SetDuration()
    {
        Console.Write("Enter duration in seconds: ");
        duration = int.Parse(Console.ReadLine());
    }

    protected void PrepareToBegin()
    {
        Console.WriteLine($"Get ready to begin {name}...");
        Thread.Sleep(3000); // Pause for 3 seconds
    }

    protected abstract void DoActivity();

    protected void Conclude()
    {
        Console.WriteLine($"You've done a good job! You completed {name} for {duration} seconds.");
        Thread.Sleep(3000); // Pause for 3 seconds
    }
}

class BreathingActivity : Activity
{
    public BreathingActivity() : base("Breathing Activity", "Helps you relax by pacing your breathing")
    {
    }

    protected override void DoActivity()
    {
        Console.WriteLine("Starting breathing activity...");
        int cycleDuration = 2; // 1 second for breathing in, 1 second for breathing out

        for (int i = 0; i < duration; i += cycleDuration)
        {
            Console.Write("Breathe in...");
            CountdownAnimation(5); // 5 seconds breathing in
            Console.Write("Breathe out...");
            CountdownAnimation(5); // 5 seconds breathing out
        }
    }

    private void CountdownAnimation(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
        Console.WriteLine();
    }
}

class ReflectionActivity : Activity
{
    private List<string> prompts = new List<string>
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private List<string> questions = new List<string>
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };

    public ReflectionActivity() : base("Reflection Activity", "Reflect on times when you've shown strength and resilience")
    {
    }

    protected override void DoActivity()
    {
        Console.WriteLine("Starting reflection activity...");
        Random random = new Random();
        string prompt = prompts[random.Next(prompts.Count)];
        Console.WriteLine(prompt);
        Thread.Sleep(2000); // Pause for 2 seconds

        foreach (var question in questions)
        {
            Console.WriteLine(question);
            Thread.Sleep(5000); // Pause for 5 seconds
        }
    }
}

class ListingActivity : Activity
{
    private List<string> prompts = new List<string>
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    public ListingActivity() : base("Listing Activity", "List as many things as you can in a certain area of strength or positivity")
    {
    }

    protected override void DoActivity()
    {
        Console.WriteLine("Starting listing activity...");
        Random random = new Random();
        string prompt = prompts[random.Next(prompts.Count)];
        Console.WriteLine(prompt);
        Thread.Sleep(2000); // Pause for 2 seconds

        Console.WriteLine("Start listing items...");
        List<string> items = new List<string>();
        DateTime endTime = DateTime.Now.AddSeconds(duration);
        while (DateTime.Now < endTime)
        {
            string item = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(item))
            {
                items.Add(item);
            }
        }

        Console.WriteLine($"You listed {items.Count} items.");
    }
}

