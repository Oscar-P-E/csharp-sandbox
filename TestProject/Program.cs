/*
Enter your role name (Administrator, Manager, or User)
Admin
The role name that you entered, "Admin" is not valid. Enter your role name (Administrator, Manager, or User)
   Administrator
Your input value (Administrator) has been accepted.
*/

using static System.Console;

var validInput = false;

WriteLine("Enter your role name (Administrator, Manager, or User)");

do
{
    var trimmedInput = ReadLine()?.Trim();

    if (trimmedInput != null && (trimmedInput.Equals("administrator", StringComparison.OrdinalIgnoreCase) ||
        trimmedInput.Equals("manager", StringComparison.OrdinalIgnoreCase) ||
        trimmedInput.Equals("user", StringComparison.OrdinalIgnoreCase)))
    {
        validInput = true;
        WriteLine($"Your input value ({trimmedInput}) has been accepted.");
    }
    else
        WriteLine($"The role name that you entered, \"{trimmedInput}\" is not valid. Enter your role name (Administrator, Manager, or User)");
} while (validInput == false);