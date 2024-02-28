using System;
					
public class Program
{
	public static void Main()
	{
		// Asks user to enter a positive integer
		Console.WriteLine("Enter a positive integer:");
		var input = Console.ReadLine();
		
		// Try converting user input to int. Output "Invalid input" if user did not enter an integer
		int num;
		bool success = int.TryParse(input, out num);

		if (success == false)
		{
		Console.WriteLine("Invalid input");
		}
		
		// Adds a space
		Console.WriteLine(" ");
		
		// Nested for loop. The outside loop runs until i is greater than or equal to num
		// The inside loop outputs i to the console i number of times
		for (var i = 1; i <= num; i++)
		{
			for (var w = 1; w <= i; w++)
			{
				Console.Write(i);
			}
			Console.WriteLine("");
		}
	}
}