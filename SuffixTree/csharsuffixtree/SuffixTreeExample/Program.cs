/* Program.cs
 * To Do: add comments
 *
 * This is a suffix tree algorithm for .NET written in C#. Feel free to use it as you please!
 * This code was derived from Mark Nelson's article located here: http://marknelson.us/1996/08/01/suffix-trees/
 * Have Fun
 *
 * Zikomo A. Fields 2008
 *
 */

using System;
using System.Collections.Generic;

namespace Algorithms
{
   internal class Program
   {
      private static void Main(string[] args)
      {
         Console.Write("Enter a string: ");
         string something = Console.ReadLine();
         string[] tokens = something.Split();
         int[] numbers = Array.ConvertAll(tokens, int.Parse);
         List<int> numberList = new List<int>(numbers);
         SuffixTree tree = new SuffixTree(numberList);
         tree.BuildTree();

         while (true)
         {
            Console.Write("Search for: ");

            string searchTerm = Console.ReadLine();
            tokens = something.Split();
            numbers = Array.ConvertAll(tokens, int.Parse);
            numberList = new List<int>(numbers);

            if (tree.Search(numberList))
            {
               Console.WriteLine("It's in there!");
            }
            else
            {
               Console.WriteLine("Nope not in there!");
            }
            if (searchTerm.ToLower() == "quit")
            {
               break;
            }
         }
      }
   }
}