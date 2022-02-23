using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ValidationStrings
{
    public class Program
    {
        static void Main(string[] args)
        {
            Program p = new Program();

            Console.WriteLine(args[0]);
            var textNonAlphabetic = p.GetStringConvertedNonAlphabetic(args[0]);
            Console.WriteLine($"Text evaluated Non-alphabetic : {textNonAlphabetic}");
            Console.WriteLine("*******************************************");
            Console.WriteLine("Enter the text with spaces to evaluate:");
            var textToEvaluate = Console.ReadLine();
            var textEvaluated = p.GetStringConvertedWithSpaces(textToEvaluate);
            Console.WriteLine($"Text evaluated with spaces: {textEvaluated}");
            Console.ReadLine();
        }

        /// <summary>
        /// Method to get evaluated string 
        /// with the firs character of each word,
        /// the last character of each word and
        /// the quantity of different characters
        /// without spaces
        /// </summary>
        /// <param name="textToEvaluate"></param>
        /// <returns></returns>
        public string GetStringConvertedWithSpaces(string textToEvaluate)
        {
            var textEvaluated = string.Empty;
            var stringsWithoutSpaces = GetArrayWithoutSpaces(textToEvaluate);
            int index = 0;
            foreach (var item in stringsWithoutSpaces)
            {
                var firstCharacter = ReturnFirstCharacter(item);
                var lastCharacter = ReturnLastCharacter(item);
                var countDifferentCharacters = ReturnStringWithoutFirstAndLast(item).Distinct().Count();
                textEvaluated += (index == stringsWithoutSpaces.Length - 1) ?
                     $"{firstCharacter}{countDifferentCharacters}{lastCharacter}" :
                     $"{firstCharacter}{countDifferentCharacters}{lastCharacter} ";
                index++;
            }
            return textEvaluated;
        }

        /// <summary>
        /// Method to get evaluated string 
        /// with the firs character of each word,
        /// the last character of each word and
        /// the quantity of different characters
        /// without non-alphabetics characters
        /// </summary>
        /// <param name="textToEvaluate"></param>
        /// <returns></returns>
        public string GetStringConvertedNonAlphabetic(string textToEvaluate)
        {
            var textEvaluated = string.Empty;
            var stringNonAlphabetic = GetNonAlphabeticCharacters(textToEvaluate);
            var stringConverted = GetArrayNonAlphabetic(textToEvaluate);
            int index = 0;
            foreach (var item in stringConverted)
            {
                var firstCharacter = ReturnFirstCharacter(item);
                var lastCharacter = ReturnLastCharacter(item);
                var countDifferentCharacters = ReturnStringWithoutFirstAndLast(item).Distinct().Count();
                if (index >= stringNonAlphabetic.Length)
                {
                    textEvaluated += $"{firstCharacter}{countDifferentCharacters}{lastCharacter}";
                }
                else
                {
                    textEvaluated += $"{firstCharacter}{countDifferentCharacters}{lastCharacter}{stringNonAlphabetic[index]}";
                }

                index++;
            }
            return textEvaluated;
        }

        /// <summary>
        /// Method to get the first character of the textToEvaluate
        /// </summary>
        /// <param name="textToEvaluate"></param>
        /// <returns></returns>
        private string ReturnFirstCharacter(string textToEvaluate)
        {
            char[] charArrayParse = textToEvaluate.ToCharArray();
            return charArrayParse[0].ToString();
        }

        /// <summary>
        /// Method to get the last character of the textToEvaluate
        /// </summary>
        /// <param name="textToEvaluate"></param>
        /// <returns></returns>
        private string ReturnLastCharacter(string textToEvaluate)
        {
            char charTextParse = textToEvaluate[textToEvaluate.Length - 1];
            return charTextParse.ToString();
        }

        /// <summary>
        /// Method to extract first and last character of textToEvaluate
        /// </summary>
        /// <param name="textToEvaluate"></param>
        /// <returns></returns>
        private string ReturnStringWithoutFirstAndLast(string textToEvaluate)
        {
            char[] charTextParse = textToEvaluate.ToCharArray();
            charTextParse = charTextParse.Where((source, index) => index != textToEvaluate.Length - 1).ToArray();
            charTextParse = charTextParse.Where((source, index) => index != 0).ToArray();

            var newText = string.Empty;
            for (int i = 0; i < charTextParse.Length; i++)
            {
                newText += charTextParse[i].ToString();
            }
            return newText;
        }

        /// <summary>
        /// Method to get array of textToEvaluate without spaces
        /// </summary>
        /// <param name="textToEvaluate"></param>
        /// <returns></returns>
        private string[] GetArrayWithoutSpaces(string textToEvaluate)
        {
            string[] words = textToEvaluate.Split(' ');
            return words;
        }

        /// <summary>
        /// Method to get array of textToEvaluate without non-alphabetics characters
        /// </summary>
        /// <param name="textToEvaluate"></param>
        /// <returns></returns>
        private string[] GetArrayNonAlphabetic(string textToEvaluate)
        {
            return Regex.Matches(textToEvaluate, "\\w+('(s|d|t|ve|m))?")
            .Cast<Match>().Select(x => x.Value).ToArray();
        }

        /// <summary>
        /// Method to get array of textToEvaluate of non-alphabetics characters
        /// </summary>
        /// <param name="textToEvaluate"></param>
        /// <returns></returns>
        private string[] GetNonAlphabeticCharacters(string textToEvaluate)
        {
            return Regex.Matches(textToEvaluate, @"\W|_")
            .Cast<Match>().Select(x => x.Value).ToArray();

        }
    }
}
