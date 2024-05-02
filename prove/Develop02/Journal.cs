public class Journal
{
    public List<Entry> Entries { get; set; }

    public Journal()
    {
        Entries = new List<Entry>();
    }


     public void DeleteEntry(int index)
    {
        if (index >= 0 && index < Entries.Count)
        {
            Entries.RemoveAt(index);
            Console.WriteLine("Entry deleted successfully.");
        }
        else
        {
            Console.WriteLine("Invalid entry index.");
        }
    }
    public void AddEntry(Entry newEntry)
    {
        Entries.Add(newEntry);
    }

    public void DisplayAll()
    {
        foreach (var entry in Entries)
        {
            entry.Display();
        }
    }

    public void SaveToFile(string file)
    {
        string directoryPath = @"C:\Users\taylo\OneDrive\Documents\CSE210-HW\prove\Develop02\";
        string filePath = Path.Combine(directoryPath, file);
        try
    {
        using (StreamWriter writer = new StreamWriter(filePath, false))
        {
            foreach (var entry in Entries)
            {
                writer.WriteLine($"{entry.Date} - {entry.PromptText}: {entry.EntryText}");
            }
        }
        Console.WriteLine("Journal saved to file successfully.");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error saving journal to file: {ex.Message}");
    }
    }

    public void LoadFromFile(string file)
    {
        string filePath = Path.Combine(@"C:\Users\taylo\OneDrive\Documents\CSE210-HW\prove\Develop02\", file);

    Entries.Clear(); // Clear existing entries before loading from file

    try
    {
        using (StreamReader reader = new StreamReader(filePath))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] parts = line.Split(new char[] { '-' }, 2);
                if (parts.Length == 2)
                {
                    string date = parts[0].Trim();
                    string[] promptAndEntry = parts[1].Trim().Split(new char[] { ':' }, 2);
                    if (promptAndEntry.Length == 2)
                    {
                        string prompt = promptAndEntry[0].Trim();
                        string entryText = promptAndEntry[1].Trim();
                        Entry entry = new Entry(prompt, entryText);
                        entry.Date = date; // Set the date from entery
                        Entries.Add(entry);
                    }
                }
            }
        }
        Console.WriteLine($"Journal loaded from file '{filePath}' successfully.");

        // Display the loaded entries
        foreach (var entry in Entries)
        {
            entry.Display();
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error loading journal from file: {ex.Message}");
    }
    }



}

