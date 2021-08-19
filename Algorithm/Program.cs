using System;
using System.Collections.Generic;

namespace Algorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            if (IsPalendrom("wowowe"))
                Console.WriteLine("IS Palendrom");
            else
                Console.WriteLine("IS Not Palendrom");
        }

        private static bool IsPalendrom(string s)
        {
            char[] temp = s.ToCharArray();
            List<char> chars = new List<char>();
            List<int> counts = new List<int>();
            for(int i=0;i<temp.Length;i++)
            {
                int currentIndex = chars.IndexOf(temp[i]);
                if (currentIndex!=-1)
                {
                    counts[currentIndex]++;
                }
                else
                {
                    chars.Add(temp[i]);
                    counts.Add(1);
                }
            }
            int noOfOddValues = 0;
            for(int i=0;i<counts.Count;i++)
            {
                if (counts[i] % 2 != 0)                
                    noOfOddValues++;                              
                if (noOfOddValues > 1)               
                    return false;         
            }
            return true;
        }
        private static int[] GenerateUnsortedList(int length)
        {
            var unsortedList = new List<int>();
            Random random = new Random();
            for(int i=0;i<length;i++)
            {
                unsortedList.Add(random.Next(length));
            }
            return unsortedList.ToArray();
        }
       
    }
}
