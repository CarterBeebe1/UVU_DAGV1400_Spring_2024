using System;
					
public class Program
{
	public static void Main()
	{
		// Generate a random number between 1 and 10
		// Ask user to guess the number and save user's input to a variable
		int randomNumber = new Random().Next(1, 11);
		Console.WriteLine("Guese the random number between 1 and 10:");
		var input = Console.ReadLine();
		
		// Try converting user's input to an int. Output "Invalid input" if user did not enter an integer
		int num;
		bool success = int.TryParse(input, out num);

		if (success == false)
		{
		Console.WriteLine("Invalid input");
		}
	}
}