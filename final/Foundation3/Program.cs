public class Address
{
    private string street;
    private string city;
    private string state;
    private string zipCode;

    public Address(string street, string city, string state, string zipCode)
    {
        this.street = street;
        this.city = city;
        this.state = state;
        this.zipCode = zipCode;
    }

    public string GetFullAddress()
    {
        return $"{street}, {city}, {state} {zipCode}";
    }
}

public class Event
{
    private string title;
    private string description;
    private DateTime dateTime;
    private Address address;

    public Event(string title, string description, DateTime dateTime, Address address)
    {
        this.title = title;
        this.description = description;
        this.dateTime = dateTime;
        this.address = address;
    }

    public virtual string GetStandardDetails()
    {
        return $"**Event:** {title}\n**Description:** {description}\n**Date & Time:** {dateTime.ToString("MMMM d, yyyy h:mm tt")}\n**Location:** {address.GetFullAddress()}";
    }

    public virtual string GetFullDetails()
    {
        return GetStandardDetails();
    }

    public virtual string GetShortDescription()
    {
        return $"{this.GetType().Name}: {title} - {dateTime.ToString("MMMM d")}";
    }
}

public class Lecture : Event
{
    private string speaker;
    private int capacity;

    public Lecture(string title, string description, DateTime dateTime, Address address, string speaker, int capacity) : base(title, description, dateTime, address)
    {
        this.speaker = speaker;
        this.capacity = capacity;
    }

    public override string GetFullDetails()
    {
        return base.GetFullDetails() + $"\n**Speaker:** {speaker}\n**Capacity:** {capacity}";
    }
}

public class Reception : Event
{
    private string rsvpEmail;

    public Reception(string title, string description, DateTime dateTime, Address address, string rsvpEmail) : base(title, description, dateTime, address)
    {
        this.rsvpEmail = rsvpEmail;
    }

    public override string GetFullDetails()
    {
        return base.GetFullDetails() + $"\n**RSVP Email:** {rsvpEmail}";
    }
}

public class OutdoorGathering : Event
{
    private string weatherForecast; // Placeholder for future weather integration

    public OutdoorGathering(string title, string description, DateTime dateTime, Address address, string weatherForecast) : base(title, description, dateTime, address)
    {
        this.weatherForecast = weatherForecast; // Replace with actual weather data retrieval
    }

    public override string GetFullDetails()
    {
        return base.GetFullDetails() + $"\n**Weather Forecast:** {weatherForecast}";
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        // Create events of each type
        Event lecture = new Lecture("Coding for Everyone", "Learn the basics of Coding", new DateTime(2024, 10, 26, 18, 0, 0), new Address("123 Main St", "Anytown", "CA", "12345"), "expert@ai.com", 50);
        Event reception = new Reception("Company Holiday Party", "Celebrate the holidays with colleagues!", new DateTime(2024, 12, 15, 19, 0, 0), new Address("567 Elm St", "Big City", "NY", "98765"), "party@company.com");
        Event gathering = new OutdoorGathering("Community Picnic", "Bring a dish to share and enjoy the outdoors!", new DateTime(2024, 08, 10, 12, 0, 0), new Address("City Park", "Anytown", "CA", "12345"), "Sunny and warm!");

        // Print marketing messages for each event
        Console.WriteLine("**Lecture Details**\n" + lecture.GetStandardDetails() + "\n");
        Console.WriteLine("**Lecture Full Details**\n" + lecture.GetFullDetails() + "\n");
        Console.WriteLine("**Lecture Short Description**\n" + lecture.

