/*
Enter an integer value between 5 and 10
two
Sorry, you entered an invalid number, please try again
2
You entered 2. Please enter a number between 5 and 10.
7
Your input value (7) has been accepted.
*/

using static System.Console;

string? userInput;
bool validNumber = false;
bool validInput = false;
int userInputNumber = 0;

WriteLine("Enter an integer value between 5 and 10");

do
{
    userInput = ReadLine()?.Trim();

    validNumber = int.TryParse(userInput, out userInputNumber);

    if (!validNumber || userInputNumber is < 5 or > 10)
    {
        WriteLine("Sorry, you entered an invalid number, please try again");
    }
    else
    {
        validInput = true;
        WriteLine($"Your input value ({userInputNumber}) has been accepted.");
    }
} while (validInput == false);