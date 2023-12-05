using System.Text;
using SHA3.Net;

public class PassManager
{
    public static string ComputeSha3_256(string input)
    {
        using (var shaAlg = Sha3.Sha3256())
        {
            var hash = shaAlg.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Convert the hash bytes to a hexadecimal string
            string hashedString = BitConverter.ToString(hash).Replace("-", "").ToLower();

            return hashedString;
        }
    }

    public static void Main()
    {
        string inputString = "Hello, World!";
        string hashedString = ComputeSha3_256(inputString);

        Console.WriteLine($"Original String: {inputString}");
        Console.WriteLine($"SHA3-256 Hash: {hashedString}");
    }
}
