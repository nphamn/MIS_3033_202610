//generate a random integer between 1 and 5
using System;

//Datatype variable = value;
Random rand = new Random();
int randomNumber = rand.Next(1, 6); // generates a number between 1 and 5
int guess;
int numberOfguessed = 0;
do
{
    Console.WriteLine("Please guess a number between 1 and 5: ");
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

Console.WriteLine("Congratulations, you guessed correctly!");

Console.WriteLine($"We generated the random number {randomNumber}");
