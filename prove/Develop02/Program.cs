public class Program
{
    public static void Main(string[] args)
    {
        Journal journal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();
        // Might add more prompts to promptGenerator later.
        promptGenerator.Prompts.Add("Who was the most interesting person I interacted with today?");
        promptGenerator.Prompts.Add("What are you most grateful today?");
        promptGenerator.Prompts.Add("Where was your favorite place to be?");
        promptGenerator.Prompts.Add("Why was today a good or a bad day?");

        while (true)
        {
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load the journal from a file");
            Console.WriteLine("5. Delete an entry");
            Console.WriteLine("6. Exit");

            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    string prompt = promptGenerator.GetRandomPrompt();
                    Console.WriteLine($"Prompt: {prompt}");
                    Console.Write("Entry: ");
                    string entryText = Console.ReadLine();
                    Entry newEntry = new Entry(prompt, entryText);
                    journal.AddEntry(newEntry);
                    break;
                case 2:
                    journal.DisplayAll();
                    break;
                case 3:
                    Console.Write("Enter the file name to save the journal to: ");
                    string saveFile = Console.ReadLine();
                    journal.SaveToFile(saveFile);
                    break;
                case 4:
                    Console.Write("Enter the file name to load the journal from: ");
                    string loadFile = Console.ReadLine();
                    journal.LoadFromFile(loadFile);
                    break;
                case 5:
                    //adds option to remove entry since the index is 1 higher then expected, I subtracted by one.
                    Console.Write("Enter index of the entry you wish to delete: ");
                    int index = Convert.ToInt32(Console.ReadLine());
                    journal.DeleteEntry(index - 1);
                    break;
                case 6:
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please select a number from 1 - 5.");
                    break;
            }
        }
    }
}