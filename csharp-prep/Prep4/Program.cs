using System;

class Program
{
    static void Main()
    {
        List<int> numbers = new List<int>();
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        while (true)
        {
            Console.Write("Enter number: ");
            int number = Convert.ToInt32(Console.ReadLine());

            if (number == 0)
            {
                break;
            }

            numbers.Add(number);
        }

       
        int sum = numbers.Sum();
        double average = Math.Round(numbers.Average(), 3);
        int max = numbers.Max();

        Console.WriteLine($"The sum is: {sum}");
        Console.WriteLine($"The average is: {average}");
        Console.WriteLine($"The largest number is: {max}");

       
        int smallestPositive = numbers.Where(n => n > 0).DefaultIfEmpty(0).Min();
        List<int> sortedNumbers = numbers.OrderBy(n => n).ToList();

        Console.WriteLine($"The smallest positive number is: {smallestPositive}");
        Console.WriteLine("The sorted list is:");
        sortedNumbers.ForEach(n => Console.WriteLine(n));
    }
}