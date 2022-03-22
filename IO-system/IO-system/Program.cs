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
       
        public static void ChallengeOne()
        {
            Console.WriteLine("Challenge 1");
            Console.WriteLine();

            Console.Write("Please enter 3 numbers (eg. 4 8 15): ");
            string input = Console.ReadLine();
            Console.WriteLine("The product of these 3 numbers is: {0}", GetProduct(input));
            Console.WriteLine();
        }

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

        public static int GetAverage(int[] arr, int count)
        {
            int sum = 0;

            for (int i = 0; i < count; i++)
                sum += arr[i];

            return sum / count;
        }
        #endregion

        #region Challenge 3
        
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
       
        public static void ChallengeFour()
        {
            Console.WriteLine("Challenge 4");
            Console.WriteLine();

            Console.WriteLine("Example: Input: [1, 1, 2, 2, 3, 3, 3, 1, 1, 5, 5, 6, 7, 8, 2, 1, 1]");

            int[] arr = new int[] { 1, 1, 2, 2, 3, 3, 3, 1, 1, 5, 5, 6, 7, 8, 2, 1, 1 };

            Console.WriteLine("The most number from the input: {0}", GetMostFrequent(arr));
            Console.WriteLine();
        }

       
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
       
        public static void ChallengeFive()
        {
            Console.WriteLine("Challenge 5");
            Console.WriteLine();

            Console.WriteLine("Example: Input: [5, 25, 99, 123, 78, 96, 555, 108, 4]");

            int[] arr = new int[] { 5, 25, 99, 123, 78, 96, 555, 108, 4 };

            Console.WriteLine("The maximum number from the input: {0}", GetMaximum(arr));
            Console.WriteLine();
        }

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
       
        public static void ChallengeNine()
        {
            Console.WriteLine("Challenge 9");
            Console.WriteLine();

            Console.Write("Enter a sentence: ");
            string input = Console.ReadLine();

            Console.WriteLine();

            Console.WriteLine("[" + string.Join(", ", SplitASentence(input)) + "]");
        }

       
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