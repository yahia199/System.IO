using System;
using System.IO;
using System.Linq;

namespace SystemIO
{
    public class Program
    {
        static void Main(string[] args)
        {
            string path = "../../../words.txt";
            GenerateTextFile(path);

            ChallengeOne();
            ChallengeTwo();
            ChallengeThree();
            ChallengeFour();
            ChallengeFive();
            ChallengeSix(path);
            ChallengeSeven(path);
            ChallengeEight(path);
            ChallengeNine();
        }

        /// <summary>
        /// A method that generates words.txt file
        /// </summary>
        /// <param name="path">words.txt file path</param>
        public static void GenerateTextFile(string path)
        {
            if (!File.Exists(path))
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine("Hello");
                    sw.WriteLine("And");
                    sw.WriteLine("Welcome");
                }
        }

        #region Challenge 1
        /// <summary>
        /// A method that asks the user for 3 numbers.
        /// Outputs the product of these 3 numbers multiplied together.
        /// If the user puts in less than 3 numbers, return 0.
        /// If the user puts in more than 3 numbers, only multiply the first 3.
        /// If the number is not a number, default that value to 1.
        /// </summary>
        public static void ChallengeOne()
        {
            Console.WriteLine("Challenge 1");
            Console.WriteLine();

            Console.Write("Please enter 3 numbers (eg. 4 8 15): ");
            string input = Console.ReadLine();
            Console.WriteLine("The product of these 3 numbers is: {0}", GetProduct(input));
            Console.WriteLine();
        }

        /// <summary>
        /// A method that parses a string input by the space and returns the product
        /// </summary>
        /// <param name="input">The 3 numbers entered by the user sepreated by spaces</param>
        /// <returns>The product of the 3 numbers entered</returns>
        public static int GetProduct(string input)
        {
            string[] nums = input.Split(' ');

            if (nums.Length < 3)
                return 0;

            int product = 1;

            for (int i = 0; i < 3; i++)
            {

                if (!int.TryParse(nums[i], out int num))
                    product *= 1;
                else
                    product *= num;
            }

            return product;
        }
        #endregion

        #region Challenge 2
        /// <summary>
        /// A method that asks the user to enter a number between 2-10.
        /// Then, prompt the user that number of times for random numbers.
        /// After the user has inputted all of the numbers, find the average of all the numbers inputted.
        /// </summary>
        public static void ChallengeTwo()
        {
            Console.WriteLine("Challenge 2");
            Console.WriteLine();

            Console.Write("Please enter a number between 2-10: ");
            string input = Console.ReadLine();

            int count;

            while (!int.TryParse(input, out count) || count < 2 || 10 < count)
            {
                Console.Write("Please enter a number between 2-10: ");
                input = Console.ReadLine();
            }

            int[] arr = new int[count];

            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine($"{ i + 1 } of {count} - Enter a number: ");
                input = Console.ReadLine();

                int num;

                while (!int.TryParse(input, out num) || num < 0)
                {
                    Console.WriteLine($"{ i + 1 } of {count} - Enter a number: ");
                    input = Console.ReadLine();
                }

                arr[i] = num;
            }

            Console.WriteLine($"The average of these {count} numbers is: {GetAverage(arr, count)}");
            Console.WriteLine();
        }

        /// <summary>
        /// A method that iterates through an int array and return the average of the numbers in the index
        /// </summary>
        /// <param name="arr">An int array containing the list of random numbers entered by the user</param>
        /// <param name="count">A number chosen by the user</param>
        /// <returns>The average of all the numbers from the int array</returns>
        public static int GetAverage(int[] arr, int count)
        {
            int sum = 0;

            for (int i = 0; i < count; i++)
                sum += arr[i];

            return sum / count;
        }
        #endregion

        #region Challenge 3
        // source: https://www.w3resource.com/csharp-exercises/for-loop/csharp-for-loop-exercise-31.php
        /// <summary>
        /// A method that outputs a diamond like pattern to the console
        /// </summary>
        public static void ChallengeThree()
        {
            Console.WriteLine("Challenge 3");
            Console.WriteLine();

            int rows = 5;

            for (int i = 0; i <= rows; i++)
            {
                for (int j = 1; j <= rows - i; j++)
                    Console.Write(" ");

                for (int j = 1; j <= 2 * i - 1; j++)
                    Console.Write("*");

                Console.WriteLine();
            }

            for (int i = rows - 1; i >= 1; i--)
            {
                for (int j = 1; j <= rows - i; j++)
                    Console.Write(" ");

                for (int j = 1; j <= 2 * i - 1; j++)
                    Console.Write("*");

                Console.WriteLine();
            }

            Console.WriteLine();
        }
        #endregion

        #region Challenge 4
        /// <summary>
        /// A method that brings in an integer array and returns the number that appears the most times.
        /// If there are no duplicates, return the first number in the array.
        /// If more than one number show up the same amount of time, return the first found.
        /// </summary>
        public static void ChallengeFour()
        {
            Console.WriteLine("Challenge 4");
            Console.WriteLine();

            Console.WriteLine("Example: Input: [1, 1, 2, 2, 3, 3, 3, 1, 1, 5, 5, 6, 7, 8, 2, 1, 1]");

            int[] arr = new int[] { 1, 1, 2, 2, 3, 3, 3, 1, 1, 5, 5, 6, 7, 8, 2, 1, 1 };

            Console.WriteLine("The most number from the input: {0}", GetMostFrequent(arr));
            Console.WriteLine();
        }

        /// <summary>
        /// A method that iterates through an int array and return the most common number in the array
        /// </summary>
        /// <param name="arr">An int array containing the list of random numbers</param>
        /// <returns>Most common number in the array</returns>
        public static int GetMostFrequent(int[] arr)
        {
            int count = 0;
            int most = 0;
            int num = arr[0];

            for (int i = 0; i < arr.Length; i++)
            {
                int current = arr[i];

                for (int j = 0; j < arr.Length; j++)
                    if (current == arr[j])
                        count++;

                if (count > most)
                {
                    num = current;
                    most = count;
                }

                count = 0;
            }

            return num;
        }
        #endregion

        #region Challenge 5
        /// <summary>
        /// A method in that finds the maximum value in the array.
        /// The array is not sorted.
        /// Do not use .Sort()
        /// </summary>
        public static void ChallengeFive()
        {
            Console.WriteLine("Challenge 5");
            Console.WriteLine();

            Console.WriteLine("Example: Input: [5, 25, 99, 123, 78, 96, 555, 108, 4]");

            int[] arr = new int[] { 5, 25, 99, 123, 78, 96, 555, 108, 4 };

            Console.WriteLine("The maximum number from the input: {0}", GetMaximum(arr));
            Console.WriteLine();
        }

        /// <summary>
        /// A method that iterates through an int array and return the maximum number in the array
        /// </summary>
        /// <param name="arr">An int array containing the list of random numbers</param>
        /// <returns>Maximum number in the array</returns>
        public static int GetMaximum(int[] arr)
        {
            int max = arr[0];

            for (int i = 1; i < arr.Length; i++)
                if (arr[i] > max)
                    max = arr[i];

            return max;
        }
        #endregion

        #region Challenge 6
        // source: https://docs.microsoft.com/en-us/dotnet/api/system.io.file.appendtext?view=netcore-3.1
        /// <summary>
        /// A method that asks the user to input a word, and then saves that word into an external file named words.txt
        /// </summary>
        /// <param name="path">words.txt file path</param>
        public static void ChallengeSix(string path)
        {
            Console.WriteLine("Challenge 6");
            Console.WriteLine();

            Console.Write("Enter a word: ");
            string input = Console.ReadLine();

            using (StreamWriter sw = File.AppendText(path))
                sw.WriteLine(input);

            Console.WriteLine("Entered word has been saved!");
            Console.WriteLine();
        }
        #endregion

        #region Challenge 7
        /// <summary>
        /// A method that reads the file in from Challenge 6, and outputs the contents to the console.
        /// </summary>
        /// <param name="path">words.txt file path</param>
        public static void ChallengeSeven(string path)
        {
            Console.WriteLine("Challenge 7");
            Console.WriteLine();

            Console.WriteLine("words.txt file contains the following words:");

            using (StreamReader sr = new StreamReader(path))
            {
                string word = "";
                while ((word = sr.ReadLine()) != null)
                    Console.WriteLine(word);
            }
            Console.WriteLine();
        }
        #endregion

        #region Challenge 8
        // source: https://docs.microsoft.com/en-us/dotnet/api/system.io.file.readalllines?view=netcore-3.1
        // soruce: https://stackoverflow.com/questions/3975290/produce-a-random-number-in-a-range-using-c-sharp
        /// <summary>
        /// A method that reads in the file from Challenge 6 and removes one of the words, and rewrites it back to the file.
        /// </summary>
        /// <param name="path">words.txt file path</param>
        public static void ChallengeEight(string path)
        {
            Console.WriteLine("Challenge 8");
            Console.WriteLine();

            string[] words = File.ReadAllLines(path);

            if (words.Length == 0)
            {
                Console.WriteLine("words.txt file is empty");
                return;
            }

            Random rnd = new Random();
            int random = rnd.Next(words.Length);

            string word = "";

            using (StreamWriter sw = new StreamWriter(path))
            {
                for (int i = 0; i < words.Length; i++)
                {
                    if (i == random)
                        word = words[i];
                    else
                        sw.WriteLine(words[i]);
                }
            }

            Console.WriteLine("\"{0}\" has been removed from words.txt file", word);
            Console.WriteLine();

            ChallengeSeven(path);
        }
        #endregion

        #region Challenge 9
        /// <summary>
        ///  A method that asks the user to input a sentence.
        ///  Outputs the word and the number of characters each word has.
        /// </summary>
        public static void ChallengeNine()
        {
            Console.WriteLine("Challenge 9");
            Console.WriteLine();

            Console.Write("Enter a sentence: ");
            string input = Console.ReadLine();

            Console.WriteLine();

            Console.WriteLine("[" + string.Join(", ", SplitASentence(input)) + "]");
        }

        /// <summary>
        /// A method that parses user input and returns a string array with the word and the number of characters each word has
        /// </summary>
        /// <param name="input">A setence entered by the user</param>
        /// <returns>A string array containing the processed words</returns>
        public static string[] SplitASentence(string input)
        {
            string[] words = input.Split(' ');

            for (int i = 0; i < words.Length; i++)
                words[i] = words[i].ToLower() + ": " + words[i].Count();

            return words;
        }
        #endregion
    }
}