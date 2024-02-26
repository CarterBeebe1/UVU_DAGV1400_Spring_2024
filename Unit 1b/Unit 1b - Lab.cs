using System;
					
public class Program
{
	public static void Main(){
		Console.WriteLine("Please enter the current temperature in degrees Celsius:");	// Ask user to enter a temperature
		string input = Console.ReadLine();												// Take user input and store it in variable
		int value = 0;																	// Store an int variable with value 0
		int.TryParse(input, out value);													// Convert inputed temperature to int and store in the variable
		Temperature(value);																// Execute function to interpret temperature and output feedback to user
		Console.WriteLine(" ");															// Add a space
		Console.WriteLine("Please enter an exam score percentage between 0 and 100:");	// Ask user to enter an exam score
		string input2 = Console.ReadLine();											// Take input for the exam score and store it in a variable
		int score = 0;																	// Store int variable called score with value 0
		int.TryParse(input2, out score);													// Covert input to integer and store in variable score
		examGrader(score);																// Execute function to interpret the exam score and output a grade to the user.
	}public static void Temperature(int input){
		if (input > 30){																				// Check if user input a temperature greater than 30
			Console.WriteLine("Make sure to stay hydrated and avoid staying in the sun for too long.");	// Output feedback
		}else if (input <= 30){																			// Check if temperature is less than 30
			Console.WriteLine("Enjoy the pleasant weather!");											// Output feedback
		}
	}public static void examGrader(int score){
		string text = "Grade: ";					// Store string with "Grade: "
		if ((score <= 100)&(score >= 90)){			// Check if score is between 90 and 100
			Console.WriteLine(text+"A");			// Output grade letter
		}else if ((score < 90)&(score >= 80)){		// Check if score is between 80 and 89
			Console.WriteLine(text+"B");			// Output feedback
		}else if ((score < 80)&(score >= 70)){		// Check if score is between 70 and 79
			Console.WriteLine(text+"C");			// Output feedback
		}else if ((score < 70)&(score >= 60)){		// Check if score is between 60 and 69
			Console.WriteLine(text+"D");			// Output feedback
		}else										// Check if score is 59 or less
			Console.WriteLine(text+"E");			// Output feedback
	}
}