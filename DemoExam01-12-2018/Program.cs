namespace DemoExam01_12_2018
{
    using System;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class Program
    {
        public static void Main()
        {
            string messageToDecrypt = Console.ReadLine();
            string[] replacementString = Console.ReadLine()
                .Split()
                .ToArray();

            string decryptedMessage = string.Empty;

            var regex = @"[d-z{}|#]";

            var matches = Regex.Matches(messageToDecrypt, regex);

            if (matches.Count != messageToDecrypt.Length)
            {
                Console.WriteLine("This is not the book you are looking for.");
            }
            else
            {
                for (int i = 0; i < messageToDecrypt.Length; i++)
                {
                    char currentElementToDecrypt = messageToDecrypt[i];

                    int currentE = currentElementToDecrypt - 3;
                    char decryptedElement = (char)currentE;

                    decryptedMessage += decryptedElement;
                }

                if (decryptedMessage.Contains(replacementString[0]))
                {
                    decryptedMessage = decryptedMessage.Replace(replacementString[0], replacementString[1]);
                }

                Console.WriteLine(decryptedMessage);
            }
        }
    }
}
