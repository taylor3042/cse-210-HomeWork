public class Entry
{
    public string Date { get; set; }
    public string PromptText { get; set; }
    public string EntryText { get; set; }

    public Entry(string promptText, string entryText)
    {
        Date = DateTime.Today.ToShortDateString();
        PromptText = promptText;
        EntryText = entryText;
    }

    public void Display()
    {
        Console.WriteLine($"Date: {Date}");
        Console.WriteLine($"Prompt: {PromptText}");
        Console.WriteLine($"Entry: {EntryText}");
        Console.WriteLine();
    }


}
