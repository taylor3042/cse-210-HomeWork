using System;

class MagicNumberGame
{
    static void Main()
    {
        Random random = new Random();
        int magicNumber, guess, numberOfGuesses;
        string playAgain;

        do
        {
            magicNumber = random.Next(1, 101); 
            numberOfGuesses = 0;
            guess = 0;

            Console.WriteLine("A magic number between 1 and 100 has been chosen.");

            while (guess != magicNumber)
            {
                Console.Write("What is your guess? ");
                guess = Convert.ToInt32(Console.ReadLine());
                numberOfGuesses++;

                if (guess < magicNumber)
                {
                    Console.WriteLine("Higher");
                }
                else if (guess > magicNumber)
                {
                    Console.WriteLine("Lower");
                }
            }

            Console.WriteLine($"You guessed it in {numberOfGuesses} guesses!");

            Console.Write("Do you want to play again? (yes/no): ");
            playAgain = Console.ReadLine().ToLower();
        } while (playAgain == "yes");

        Console.WriteLine("Thank you for playing!");
    }
}
