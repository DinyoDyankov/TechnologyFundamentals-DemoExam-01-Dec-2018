namespace P01.Dictionary
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            List<string> wordsAndDefinitionsInput = Console.ReadLine()
                .Split(new[] { " | " }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            Dictionary<string, List<string>> libaryOfWordsAndTheirDefinitions = new Dictionary<string, List<string>>();

            for (int i = 0; i < wordsAndDefinitionsInput.Count; i++)
            {
                string[] currentWordAndHerDefinitions = wordsAndDefinitionsInput[i].Split(new[] { ": " }, StringSplitOptions.RemoveEmptyEntries).ToArray();

                if (libaryOfWordsAndTheirDefinitions.ContainsKey(currentWordAndHerDefinitions[0]))
                {
                    libaryOfWordsAndTheirDefinitions[currentWordAndHerDefinitions[0]].Add(currentWordAndHerDefinitions[1]);
                }
                else
                {
                    List<string> currentList = new List<string>();
                    currentList.Add(currentWordAndHerDefinitions[1]);

                    libaryOfWordsAndTheirDefinitions.Add(currentWordAndHerDefinitions[0], currentList);
                }
            }

            string [] wordsToCheck = Console.ReadLine()
                .Split(new[] { " | " }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            for (int i = 0; i < wordsToCheck.Length; i++)
            {
                foreach (string word in libaryOfWordsAndTheirDefinitions.Keys)
                {
                    if (word == wordsToCheck[i])
                    {
                        Console.WriteLine(word);
                        foreach (var def in libaryOfWordsAndTheirDefinitions[word].OrderByDescending(d => d.Length))
                        {
                            Console.WriteLine($" -{def}");
                        }
                    }
                }
            }

            string command = Console.ReadLine();

            if (command == "List")
            {
                foreach (var word in libaryOfWordsAndTheirDefinitions.Keys.OrderBy(w => w))
                {
                    Console.Write(word + " ");
                }
            }

            Console.WriteLine();
        }
    }
}
