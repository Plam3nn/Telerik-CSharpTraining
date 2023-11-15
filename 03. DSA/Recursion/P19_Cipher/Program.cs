using System;
using System.Collections.Generic;

namespace P19_Cipher
{
    internal class Program
    {
        //not solved
        static void Main(string[] args)
        {
            var secretMessage = Console.ReadLine();
            var cipher = Console.ReadLine();
            var messages = new List<string>();

            Decipher(secretMessage, cipher, string.Empty, messages);
            Console.WriteLine(string.Join(Environment.NewLine, messages));
        }

        private static void Decipher(string secretMessage, string cipher, string currentMessage, List<string> messages)
        {
            if (secretMessage == string.Empty)
            {
                messages.Add(currentMessage);
            }

            for (int i = 0; i < secretMessage.Length; i++)
            {
                var currentNumber = secretMessage.Substring(0, i + 1);

                if (cipher.Contains(currentNumber))
                {
                    var letterIndex = cipher.IndexOf(currentNumber) - 1;

                    Decipher(secretMessage.Substring(i + 1), cipher, currentMessage + cipher[letterIndex], messages);
                }
            }
        }
    }
}
