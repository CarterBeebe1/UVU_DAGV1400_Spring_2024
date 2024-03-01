using System;
					
public class Program
{
	public static void Main()
	{
		// Create an array with place holder food items
		string[] foods = {"Food1", "Food2", "Food3"};
		
		// Ask user for their three favorite foods
		Console.WriteLine("Enter your three favorite foods:");
		
		// For loop that runs three times and stores each food item the user inputs in the foods array
		for(var i = 1; i <= 3; i++)
		{
			Console.Write(i + ": ");
			foods[i-1] = Console.ReadLine();
		}
		
		// For loop that runs a number of times equal to the number of items in the array
		// Outputs a message for each item in the array using i to denote the outputed item
		for (int i = 0; i < foods.Length; i++)
		{
    		Console.WriteLine("I love " + foods[i] +"!");
		}
	}
}