using System;
					
public class Program
{
	public static void Main()
	{
		// Generate a random number between 1 and 10
		// Ask user to guess the number and save user's input to a variable
		int randomNumber = new Random().Next(1, 11);
		Console.WriteLine("Guess the random number between 1 and 10:");
		
		bool guessedNum = false; // Boolean value "geussedNum"
		
		// While loop that takes users input and outputs message whether the number is too high or too low
		// When the correct number is guessed, a message is outputed to the user and guessedNum is set to true.
		while (guessedNum == false)
		{
			var input = Console.ReadLine();
			int guess = Convert.ToInt32(input);
			
			if (guess > randomNumber)
			{
				Console.WriteLine("Too high.");
			}
			else if (guess < randomNumber){
				Console.WriteLine("Too low.");
			}
			else
			{
				Console.WriteLine("You guessed the correct number. Well done!");
				guessedNum = true;
			}
		}
	}
}