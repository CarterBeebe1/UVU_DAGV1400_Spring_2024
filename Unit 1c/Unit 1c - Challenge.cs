using System;
					
public class Program
{
	public static void Main()
	{
		string[] foods = {"Food1", "Food2", "Food3"};
		
		Console.WriteLine("Enter your three favorite foods:");
		
		for(var i = 1; i <= 3; i++)
		{
			Console.Write(i + ": ");
			foods[i-1] = Console.ReadLine();
		}

		Console.WriteLine(foods);
	}
	
	public static void FavoriteFoods()
	{
		string[] foods = {"Food1", "Food2", "Food3"};
		
		Console.WriteLine("Enter your three favorite foods:");
		
		for(var i = 1; i <= 3; i++)
		{
			Console.Write(i + ": ");
			foods[i-1] = Console.ReadLine();
		}

		Console.WriteLine(foods);
	}
}
