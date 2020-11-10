using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MultiThreading
{
    class TPLClass
    {
        public static void TestUri()
        {
            Console.WriteLine("Employee Payroll using Threads");
            string[] words = CreateWordArray(@"http://www.gutenberg.org/files/54700/54700-0.txt");

            Parallel.Invoke(() =>
            {
                Console.WriteLine("Begin first task..");
                Console.WriteLine(GetLongestWords(words));
            },
            () =>
            {
                Console.WriteLine("Begin second task..");
                GetMostCommonWords(words);            
            },
            () =>
            {
                Console.WriteLine("Begin third task..");
                GetCountForword(words,"sleep");
            }
            );//close parallel invoke
        }

        private static void GetCountForword(string[] words, string term)
        {
            var findWord = from word in words
                           where word.ToUpper().Contains(term.ToUpper())
                           select word;
            Console.WriteLine("Task 3 -- the word "+term+ " occurs "+ (findWord.Count())+ " times ");
        }

        private static string GetLongestWords(string[] words)
        {
            var longestWord = (from word in words
                           orderby word.Length descending 
                           select word).First();
            Console.WriteLine("Task 1 -- the longest word is (longestWord),");
            return longestWord;
        }

        private static void GetMostCommonWords(string[] words)
        {
            var frequencyOrder = from word in words
                           where word.Length > 6
                           group word by word into g
                           orderby g.Count() descending
                           select g.Key;
            var commonWords=frequencyOrder.Take(10);
            //StringBuilder sb = new StringBuilder();
            //sb.AppendLine("Task 2 -- the most common words are:");
            foreach(var v in commonWords)
            {
                Console.WriteLine(" "+v);
            }
            //Console.WriteLine(sb.ToString());
        }

        public static string[] CreateWordArray(string uri)
        {            
            Console.WriteLine($"Retriving from {uri}");
            string blog = new WebClient().DownloadString(uri);
            return blog.Split(new char[] {' ','\u000A',',',':','-','/' },StringSplitOptions.RemoveEmptyEntries);            
        }
    }
}
