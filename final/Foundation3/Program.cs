using System;
using System.Collections.Generic;

class Address
{
    private string street;
    private string city;
    private string state;
    private string country;

    public Address(string street, string city, string state, string country)
    {
        this.street = street;
        this.city = city;
        this.state = state;
        this.country = country;
    }

    public string GetFullAddress()
    {
        return $"{street}, {city}, {state}, {country}";
    }
}

abstract class Event
{
    private string title;
    private string description;
    private string date;
    private string time;
    private Address address;

    public Event(string title, string description, string date, string time, Address address)
    {
        this.title = title;
        this.description = description;
        this.date = date;
        this.time = time;
        this.address = address;
    }

    public string GetStandardDetails()
    {
        return $"Title: {title}\nDescription: {description}\nDate: {date}\nTime: {time}\nAddress: {address.GetFullAddress()}";
    }

    public abstract string GetFullDetails();
    public abstract string GetShortDescription();

    protected string GetCommonDetails()
    {
        return $"Title: {title}\nDate: {date}";
    }
}

class Lecture : Event
{
    private string speaker;
    private int capacity;

    public Lecture(string title, string description, string date, string time, Address address, string speaker, int capacity)
        : base(title, description, date, time, address)
    {
        this.speaker = speaker;
        this.capacity = capacity;
    }

    public override string GetFullDetails()
    {
        return $"{GetStandardDetails()}\nEvent Type: Lecture\nSpeaker: {speaker}\nCapacity: {capacity}";
    }

    public override string GetShortDescription()
    {
        return $"Type: Lecture\n{GetCommonDetails()}";
    }
}

class Reception : Event
{
    private string rsvpEmail;

    public Reception(string title, string description, string date, string time, Address address, string rsvpEmail)
        : base(title, description, date, time, address)
    {
        this.rsvpEmail = rsvpEmail;
    }

    public override string GetFullDetails()
    {
        return $"{GetStandardDetails()}\nEvent Type: Reception\nRSVP Email: {rsvpEmail}";
    }

    public override string GetShortDescription()
    {
        return $"Type: Reception\n{GetCommonDetails()}";
    }
}

class OutdoorGathering : Event
{
    private string weatherForecast;

    public OutdoorGathering(string title, string description, string date, string time, Address address, string weatherForecast)
        : base(title, description, date, time, address)
    {
        this.weatherForecast = weatherForecast;
    }

    public override string GetFullDetails()
    {
        return $"{GetStandardDetails()}\nEvent Type: Outdoor Gathering\nWeather: {weatherForecast}";
    }

    public override string GetShortDescription()
    {
        return $"Type: Outdoor Gathering\n{GetCommonDetails()}";
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Create addresses
        Address address1 = new Address("123 Main St", "New York", "NY", "USA");
        Address address2 = new Address("456 Elm St", "Los Angeles", "CA", "USA");
        Address address3 = new Address("789 Oak St", "Chicago", "IL", "USA");

        // Create events
        Lecture lecture = new Lecture("AI in Healthcare", "A lecture on the impact of AI in healthcare.", "2024-06-01", "10:00 AM", address1, "Dr. John Smith", 100);
        Reception reception = new Reception("Tech Meetup", "A networking event for tech enthusiasts.", "2024-06-15", "6:00 PM", address2, "rsvp@techmeetup.com");
        OutdoorGathering outdoorGathering = new OutdoorGathering("Music Festival", "An outdoor music festival with various artists.", "2024-07-10", "3:00 PM", address3, "Sunny with a chance of clouds");

        // List of events
        List<Event> events = new List<Event> { lecture, reception, outdoorGathering };

        // Display information for each event
        foreach (Event eventItem in events)
        {
            Console.WriteLine("Standard Details:");
            Console.WriteLine(eventItem.GetStandardDetails());
            Console.WriteLine();

            Console.WriteLine("Full Details:");
            Console.WriteLine(eventItem.GetFullDetails());
            Console.WriteLine();

            Console.WriteLine("Short Description:");
            Console.WriteLine(eventItem.GetShortDescription());
            Console.WriteLine();
        }
    }
}
