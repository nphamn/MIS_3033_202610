//generate a random integer between 1 and 5
using System;

Console.WriteLine("Welcome to our game!");

Console.WriteLine("Please input the the lower bound value (lower values that could be guessed)? <<");
string answer = Console.ReadLine();
int lowerBound = int.Parse(answer);

Console.WriteLine("Please input the the upper bound value (highest values that could be guessed)? <<");
answer = Console.ReadLine();
int upperBound = int.Parse(answer);

for (int i = 0; i < int.MaxValue; i++)
{

    //Datatype variable = value;
    Random rand = new Random();
    int randomNumber = rand.Next(lowerBound, upperBound + 1); // generates a number between 1 and 5
    int guess;

    int numberOfguessed = 0;

    do
    {
        Console.WriteLine($"Please guess a number between {lowerBound} and {upperBound}: ");
        string usersGuests = Console.ReadLine();
        guess = int.Parse(usersGuests);
        //guess = Convert.ToInt32(usersGuests);
        numberOfguessed++;

        Console.WriteLine($"You guessed {usersGuests}");

        // if (randomNumber == guess)
        //{
        //     Console.WriteLine("Congratulations, you guessed correctly!");
        //}
        //else
        // {
        //     Console.WriteLine("Sorry, you guessed wrong.");
        //}
        if (randomNumber != guess)
        {
            if (randomNumber > guess)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Too low, try again.");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Too high, try again.");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

    } while (randomNumber != guess);

    Console.WriteLine($"Congratulations, you guessed correctly in {numberOfguessed} attempts!");

    Console.WriteLine($"We generated the random number {randomNumber}");

    Console.WriteLine("Do you want to play again? (yes/no)");
    answer = Console.ReadLine();

    if (answer != "yes") // answer == "no"
    {
        break;
    }

}