// This program calculates the total number of packages of flour from an
// initial amount of wheat grown in yards. It also indicates whether
// there are enough packages for shipment based on the value packageAmt.

using System;

public class WheatMill
{
	public static void Main()
	{
		int yardsOfWheat = 3486;		// Number of yards of wheat farmed.
		double poundsPerYard = 0.137D;		// Pounds of wheat per yard.
		int poundsPerPack = 4;			// Number of pounds in a package of wheat.
		bool shipment = false;			// Indicates whether there are enough packages for shipment.
		
		double yeild = yardsOfWheat * poundsPerYard;			// Calculate total yeild of wheat in pounds by multiplying yards of wheat by the amount of pounds each yard yeilds.
		double packageAmt = Math.Round(yeild / poundsPerPack);		// Find total possible packages of wheat by dividing the total pounds
										// of grain by the amount of pounds in each package and discardsthe  decimal value.
		string text = "Total number of packages: ";


		// Output the total number of packages.

		Console.WriteLine(text + packageAmt);

		
		// Tests whether there are enough packages for shipment and output text indicating whether packages are ready to be shipped.
		
		if (packageAmt >= 100) 
      	{
        	shipment = true;
      	}
		
		if (shipment)
		{
			Console.WriteLine("There are enough packages for shipment");
		}
		else
		{
			Console.WriteLine("There are not enough packages for shipment");
		}
	}
}
