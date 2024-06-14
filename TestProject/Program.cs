string[] myStrings = new string[2]
{
    "I like pizza. I like roast chicken. I like salad", "I like all three of the menu choices"
};



foreach (string s in myStrings)
{
    string[] split = s.Split(',', '.');

    foreach (string s1 in split)
    {
       Console.WriteLine(s1.Trim());
    }
}