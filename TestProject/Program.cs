string pangram = "The quick brown fox jumps over the lazy dog";

string[] wordArr = pangram.Split(" ");

foreach (string s in wordArr)
{
    char[] sArr = s.ToCharArray();
    Array.Reverse(sArr);
    string result = new String(sArr);
    Console.Write(result + " ");
}