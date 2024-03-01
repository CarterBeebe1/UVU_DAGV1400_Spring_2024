using System;
					
public class Program
{
	public static void Main()
	{
		// Generate a random number between 1 and 10
		// Ask user to guess the number and save user's input to a variable
		int randomNumber = new Random().Next(1, 11);
		
		// Try converting user's input to an int. Output "Invalid input" if user did not enter an integer
		//bool success = int.TryParse(input, out num);

		//if (success == false)
		//{
		//	Console.WriteLine("Invalid input");
		//}
		
		bool guessedNum = false;
		
		Console.WriteLine("Guess the random number between 1 and 10:");
		
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
			}
		}
	}
}