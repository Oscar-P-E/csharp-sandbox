// Create a looping structure that can be used to iterate through each string value in the array values.
//
// Complete the required code, placing it within the array looping structure code block. It's necessary to implement
// the following business rules in your code logic:
//
// Rule 1: If the value is alphabetical, concatenate it to form a message.
//
// Rule 2: If the value is numeric, add it to the total.
//
// Rule 3: The result should match the following output:
//
// Output
//
// Message: ABCDEF
// Total: 68.3

string[] values = { "12.3", "45", "ABC", "11", "DEF" };

decimal total = 0;
string message = "";

foreach (string s in values)
{
    if (decimal.TryParse(s, out decimal num))
        total += num;
    else
        message += s;
}

Console.WriteLine($"Message: {message}");
Console.WriteLine($"Total: {total}");