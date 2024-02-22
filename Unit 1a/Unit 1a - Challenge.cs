using System;
using System.ComponentModel.Design;

public class CastleBuilding
{
	public static void Main()
	{
		int woodAmt = 100; 				// Indicates the amount of wood.
		int stoneAmt = 100; 			// Indicates the amount of stone.

		double woodInc = 75; 			// Amount of wood increase every time a lumber mill is built.
		double stoneInc = 50; 			// Amount of stone increase every time mineshaft is built.

		double materialInc = 1.2f;  	// Increase in amount of material for building lumber mill or mineshaft.
		bool castleIsBuilt = false; 	// Indicates whether a castle is built.
		bool numError = false;			// Indicates if user didn't input a number between 1 and 4

		// Building structure names
		string build1 = "Cottage";		// Variable type string for name "Cottage"
		string build2 = "Lumber mill";	// Variable type string for name "Lumber mill"
		string build3 = "Mineshaft";	// Variable type string for name "Mineshaft"
		string build4 = "Castle";		// Variable type string for name "Castle"

		string border = "------"; 		// Border space

		Console.WriteLine(border); 								 // Add a border space
		Console.WriteLine("Challenge: Build a " + build4 + "."); // Write to console that the challenge is to buld a castle.
		Console.WriteLine(border); 								 // Add a border space

		// List build options
		Console.WriteLine(border);  																											// Add a border space
		Console.WriteLine("1 = " + build1 + "     - Increases stone and wood gained from building a " + build2 + " or " + build3 + " by 20%."); // Write bulid1 and its conditions.
		Console.WriteLine("2 = " + build2 + " - Gain " + woodInc + " wood.");          															// Write bulid2 and its conditions.
		Console.WriteLine("3 = " + build3 + "   - Gain " + stoneInc + " stone.");      															// Write bulid3 and its conditions.
		Console.WriteLine("4 = " + build4 + "      - Cost: 200 wood and 300 stone.");  															// Write bulid4 and its conditions.
		Console.WriteLine(border); 																												// Add a border space	


		//Repeatedly ask for user input and perform operations until a castle is built.
		while (castleIsBuilt == false)
		{
			Console.WriteLine(border + border + border + border + border + border + border + border); // Add a longer border space to indicate start of new input cycle.
			Console.WriteLine("Type coresponding number 1-4 to build:"); 							  // Tell user to enter a number between 1 and 4.
		
			string? input = Console.ReadLine(); 			 										  // Take input from user.
			int choice; 									 										  // Create an integer to hold the users number choice.
			bool validInt = int.TryParse(input, out choice); 										  // Check if the user entered an integer.


			//Check if user entered an interger value between 1 and 4.
			if (validInt & (0 < choice) & (choice < 5))
			{
				Console.WriteLine(border);     														  // Add a border space
				Console.WriteLine("Processing input...");   										  // Processing input
			}
			else
			{
				Console.WriteLine(border);     														  // Add a border space
				Console.WriteLine("Please type a number between 1 and 4."); 						  // Tell user to input a number between 1 and 4
				numError = true;																	  // Set num error to true
			}

			// Check what structure the user chose to build.----------------------------------------------------
			if (choice == 1)
			{
				Console.WriteLine("Built a cottage. 20% extra wood and stone for every mineshaft and lumber mill built.");  // Write line indicating that a cottage is built.
				woodInc = Math.Round(woodInc * materialInc);   																// Multiply wood per lumber mill bulit by increase amount for building cottage.
				stoneInc = Math.Round(stoneInc * materialInc); 																// Multiply stone per mineshaft bulit by increase amount for building cottage.
			}
			if (choice == 2)
			{
				Console.WriteLine("Built lumber mill and gained " + woodInc + " wood.");	// Write line indicating that a lumber mill is built.
				woodAmt += Convert.ToInt32(woodInc); 											// Add wood increase to wood amount.
			}
			if (choice == 3)
			{
				Console.WriteLine("Built mineshaft and gained " + stoneInc + " stone.");    // Write line indicating that a mineshaft is built.
				stoneAmt += Convert.ToInt32(stoneInc); 											// Add stone increase to stone amount.
			}
			if ((choice == 4) & (woodAmt >= 200 ) & (stoneAmt >= 300)) 							// Check if enough wood and stone are available to build a castle.
			{
				castleIsBuilt = true; 															// Set bool value castleIsBulit to true.
				woodAmt -= 200;																	// Subtract 200 from wood amount.
				stoneAmt -= 300;																// Subtract 300 from stone amount.
			}
			else
			{
				if (numError == false)
				{
					Console.WriteLine("Not enough material to build a castle."); 		// Tell user there is not enough material to build a castle.
				}
			}

			// Output amount of stone and wood to console.
			Console.WriteLine(border); 											// Add a border space.
			Console.WriteLine("Wood amount: " + woodAmt);						// Write wood amount to console.
			Console.WriteLine("Stone amount: " + stoneAmt); 					// Write stone amount to console.

			//Write line congraduating user for building a castle.----------------------------------------------------
			if (castleIsBuilt)
			{
				Console.WriteLine(" "); 										// Add empty space
				Console.WriteLine(border); 										// Add a border space
				Console.WriteLine("Congratulations, you've built a castle!");   // Congratulate user on building a castle
				Console.WriteLine(border); 										// Add a border space
				Console.WriteLine(" "); 										// Add empty space
			}
		}

	}
}