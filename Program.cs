using System;
using System.Text;
using System.Threading;

class PersonalInfoSys
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Personal Information System.");
        Thread.Sleep(1000);
        Console.WriteLine("Here, we check if you are eligible to get an alcoholic drink from our bar.");
        Thread.Sleep(1000);

        Start();
    }

    static void Start()
    {
        String firstName;
        bool containsDigit;

        do
        {
            Console.Write($"Enter your first name: "); //User enters first name
            firstName = Console.ReadLine();
            containsDigit = false; //makes sure that you can only enter letters

            foreach (char c in firstName) //checks if any character is a digit
            {
                if (char.IsDigit(c))
                {
                    containsDigit = true;
                    break;
                }
            }
            if (String.IsNullOrEmpty(firstName)) //checks if there's no input
            {
                Console.WriteLine("This is no input. Try again?");
            }
            else if (containsDigit) //invalidates the statement if a character involves a digit
            {
                Console.WriteLine("Input is invalid. First name must not contain numbers.");
            }
            else
            {
                Console.WriteLine($"Your first name, {firstName}, is confirmed."); //message prompt when input is correct
                Console.WriteLine();
            }
        } while (String.IsNullOrEmpty(firstName) || containsDigit);

        String lastName;
        do
        {
            Console.Write($"Enter your last name: "); //User enters last name
            lastName = Console.ReadLine();
            containsDigit = false;

            foreach (char c in lastName)
            {
                if (char.IsDigit(c))
                {
                    containsDigit = true;
                    break;
                }
            }
            if (String.IsNullOrEmpty(lastName))
            {
                Console.WriteLine("This is no input. Try again?"); //checks if there's no input
            }
            else if (containsDigit)
            {
                Console.WriteLine("Input is invalid. Last name must not contain numbers.");
            }
            else
            {
                Console.WriteLine($"Your last name, {lastName}, is confirmed."); //message prompt when input is correct
                Console.WriteLine();

            }
        } while (String.IsNullOrEmpty(lastName) || containsDigit);

        double height;
        do
        {
            Console.Write($"Enter your height (in meters): "); //User enters their height in meters
            string input = Console.ReadLine();
            if (double.TryParse(input, out height))
            {
                if (height > 0)
                {
                    Console.WriteLine($"Your height is: {height} meters"); //message prompt when input is correct
                    Console.WriteLine("");
                }
                else
                {
                    Console.WriteLine("Height must be a positive number."); //message prompt when negative number is entered 
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please try again."); //message prompt when input is incorrect
            }
            Console.WriteLine();
        } while (height <= 0);

        int LEGAL_DRINKING_AGE = 0;
        bool validInput = false;
        do
        {
            Console.Write($"Enter your age: "); //User enters their age
            string input = Console.ReadLine();
            if (int.TryParse(input, out LEGAL_DRINKING_AGE))
            {
                validInput = true;
            }
            else
            {
                Console.WriteLine("Oops, it seems like you failed to input a number."); //message prompt when input is not a number
                Console.WriteLine("Let's try this again...");
                Thread.Sleep(1000);
            }
        } while (!validInput);


        if (ConfirmInformation(firstName, lastName, height, LEGAL_DRINKING_AGE))
        {
            if (LEGAL_DRINKING_AGE >= 21) //If greater or equal to 21, then eligible for alcohol consumption
            {
                Console.WriteLine("Congratulations! You are eligible for alcohol consumption.");
                Console.WriteLine();
            }
            else if (LEGAL_DRINKING_AGE == 20) //If equal to 20, display that they are close to legal age
            {
                Console.WriteLine("Close, but not quite yet. You are not eligible for alcohol consumption without the guidance of an adult.");
                Console.WriteLine();
            }
            else //If age is less than 18, display how many years are left before user is able to consume alcohol
            {
                Console.WriteLine("Sadly, you are still under the legal age for alcohol consumption.");
                int remainingYears = 21 - LEGAL_DRINKING_AGE;
                Console.WriteLine("You still have " + remainingYears + " years left before you are eligible for legal alcohol consumption.");
                Console.WriteLine();
            }
        }
        else
        {
            Console.WriteLine("Reinitializing questions..."); //repeats the questions
            Thread.Sleep(2000);
            Start();
        }
        bool inputTrue = false;
        do
        {
            Console.WriteLine("Do you want to use the program again? Y/N?"); //Asks the user if they want to continue using the program. if yes, repeat, if no, break.
            String booleanInput = Console.ReadLine();
            Console.WriteLine();
            if (booleanInput.Equals("yes", StringComparison.OrdinalIgnoreCase) || booleanInput.Equals("y", StringComparison.OrdinalIgnoreCase)) //continues the program
            {
                Start();
            }
            else if (booleanInput.Equals("no", StringComparison.OrdinalIgnoreCase) || booleanInput.Equals("n", StringComparison.OrdinalIgnoreCase)) //ends use of the program
            {
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine("Oops! It seems like you made a mistake with your input. Please use y/n to indicate your choice."); //message prompt when input is incorrect
            }
        } while (!inputTrue);
    }


    static bool ConfirmInformation(String firstName, String lastName, double height, int LEGAL_DRINKING_AGE) //displays information entered for the user to check
    {
        Console.WriteLine("***************************************");
        Console.WriteLine("Information Entered:");
        Console.WriteLine("");
        Console.WriteLine("First Name: " + firstName);
        Console.WriteLine("Last Name: " + lastName);
        Console.WriteLine("Height (in meters): " + height + " meter(s)");
        Console.WriteLine("Age: " + LEGAL_DRINKING_AGE);
        Console.WriteLine("");
        Console.WriteLine("Are all those information correct? (Y/N)");
        Console.WriteLine("***************************************");

        bool trueInput = false;
        do
        {
            String booleanInput = Console.ReadLine(); //user checks if the user entered is correct or not. if yes, proceed. if no, repeat.
            if (booleanInput.Equals("yes", StringComparison.OrdinalIgnoreCase) || booleanInput.Equals("y", StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }
            else if (booleanInput.Equals("no", StringComparison.OrdinalIgnoreCase) || booleanInput.Equals("n", StringComparison.OrdinalIgnoreCase))
            {
                return false;
            }
            else
            {
                Console.WriteLine("Oops! It seems like you made a mistake with your input. Please use y/n to indicate your choice.");
                trueInput = false;
            }
        } while (!trueInput);
        return false;
    }

}