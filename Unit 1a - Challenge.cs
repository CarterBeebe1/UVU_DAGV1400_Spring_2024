// See https://aka.ms/new-console-template for more information
using System;

public class Building
{
	public static void Main()
	{
		int woodAmt = 100; // Indicates the amount of wood.
		int stoneAmt = 100; // Indicates the amount of stone.

		double buildSpeed = 1.0f;  // Build speed in days.
		bool castleIsBuilt = false; // Indicates whether a castle is built.
		
		// Building structure names
		string build1 = "Cottage";
		string build2 = "Lumber mill";
		string build3 = "Mineshaft";
		string build4 = "Castle";
		
		// Add a border space
		string border = "------";

		// Indicate that the challenge is to build a castle.
		Console.WriteLine("Challenge: Build a " + build4 + ".");
		Console.WriteLine(border);
		
		// List build options
		Console.WriteLine(border);
		Console.WriteLine("1 = " + build1 + "     - Increases stone and wood gained from building a lumber mill or mineshaft by 20.");
		Console.WriteLine("2 = " + build2 + " - Gain 50 wood.");
		Console.WriteLine("3 = " + build3 + "   - Gain 50 stone.");
		Console.WriteLine("4 = " + build4 + "      - Cost: 200 wood and 300 stone.");
		Console.WriteLine(border);
		Console.WriteLine("Type coresponding number to build:");
			//take input from user and write to console
		// Take input from user and build.
		int choice = Console.ReadLine();
		Console.WriteLine("Building " + choice + "...");
		
		if (choice == 1)
		{
			Console.WriteLine("Built a cottage.");
			woodAmt += 50;
			stoneAmt += 50;
		}

		// Finsished.
		Console.WriteLine("congratulations, all the components for the village are built!");

		// Output amount of stone and wood to console.
		Console.WriteLine("Wood amount: " + woodAmt);
		Console.WriteLine("Stone amount: " + stoneAmt);

	}
}