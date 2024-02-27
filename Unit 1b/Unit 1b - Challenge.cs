using System;
					
public class Program
{
	public static void Main(){
		Console.WriteLine("Please enter the current temperature in degrees Celsius:");						// Ask user to enter a temperature.
		string input = Console.ReadLine();																	// Take user input and store it in variable.
		int value = 0;																						// Store an int variable with value 0.
		int.TryParse(input, out value);																		// Convert inputed temperature to int and store in the variable.
		Temperature(value);																					// Execute function to interpret temperature and output feedback to user.
		Console.WriteLine(" ");
		Console.WriteLine("Please enter an exam score percentage between 0 and 100:");						// Ask user to enter an exam score.
		string input2 = Console.ReadLine();																	// Take input for the exam score and store it in a variable.
		int score = 0;																						// Store int variable called score with value 0.
		int.TryParse(input2, out score);																	// Covert input to integer and store in variable score.
		Console.WriteLine("What is your favorite subject: English, Math, or Science? (Captilize choice)");	// Execute function to interpret the exam score and output a grade to the user.
		string subject = Console.ReadLine();																// Take input for subject choice.
		examGrader(score, subject);																			// Execute function to interpret the exam score and subject. Output feedback to user.
	}
	public static void Temperature(int input){
		if (input >= 40){																													// Check if user input a temperature greater than or equal to 40.
			Console.WriteLine("Plan outdoor activities either in the moring or when sun starts to set and stay in air conditioned areas.");	// Output feedback.
		}else if ((input > 30) & (input < 40)){																								// Check if user input a temperature greater than 30 and less than 40.
			Console.WriteLine("Make sure to stay hydrated and avoid staying in the sun for too long.");										// Output feedback.
		}else if ((input <= 30)&(input >= 20)){																								// Check if temperature is 30 or less and 20 or more.
			Console.WriteLine("Enjoy the pleasant weather!");																				// Output feedback.
		}else if ((input < 20)&(input > 10)){																								// Check if temperature is between 10 and 20.
			Console.WriteLine("I recommend carying a light jacket.");																		// Output feedback.
		}else if (input < 10){																												// Check it temperature is less than 10.
			Console.WriteLine("Make sure to wear warm clothing.");																			// Output feedback.
		}
	}
	public static void examGrader(int score, string subject){
		string text = "Grade: ";										// Store string with "Grade: ".
		if ((score <= 100)&(score >= 90)){								// Check if score is between 90 and 100.
			Console.WriteLine(text+"A");								// Output grade letter.
		}else if ((score < 90)&(score >= 80)){							// Check if score is between 80 and 89.
			Console.WriteLine(text+"B");								// Output feedback.
		}else if ((score < 80)&(score >= 70)){							// Check if score is between 70 and 79.
			Console.WriteLine(text+"C");								// Output feedback.
		}else if ((score < 70)&(score >= 60)){							// Check if score is between 60 and 69.
			Console.WriteLine(text+"D");								// Output feedback.
		}else if ((score < 60)&(score >= 0)){							// Check if score is 60 or less.
			Console.WriteLine(text+"E");								// Output feedback.
		}else{															// Tell user their inputed percentage is invalid.
			Console.WriteLine("Invalid grade percentage");
		}
			
		switch (subject)
		{
			case "Math":																																									// Check if user "Math" as subject and output feedback.
				Console.WriteLine("Math can be a benificial subject and is key to better learning and understanding the universe.");
				Console.WriteLine("Keep on practicing the concepts and you will eventually improve and increase your cognitive ability.");
				break;
			case "English":																																									// Check if user "English" as subject and output feedback.
				Console.WriteLine("English is a great subject that can lead to clearer thinking and improved memory function");
				Console.WriteLine("Any type of consistent practice such as reading, writing, language, can have a benifit on your English skills.");
				break;
			case "Science":																																									// Check if user chose "Science" as subject and output feedback.
				Console.WriteLine("Science is a great subject for understanding how nature works. Spacing out your study time can largly improve learning and better memory retention.");
				Console.WriteLine("Make sure to test your knowledge and challenge yourself to recall what you've learned. This will reinfoce what youve learned for long term memory.");
				break;
			default:																																										// Output Invalid choice if none of the cases are used.
				Console.WriteLine("Invalid choice. Make sure to capitilize the first letter.");
				break;
		}
	}
}