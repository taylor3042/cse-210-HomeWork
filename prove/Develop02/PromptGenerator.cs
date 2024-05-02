public class PromptGenerator
{
    public List<string> Prompts { get; set; }

    public PromptGenerator()
    {
        Prompts = new List<string>();
    }

    public string GetRandomPrompt()
    {
        Random rand = new Random();
        int index = rand.Next(Prompts.Count);
        return Prompts[index];
    }
}
