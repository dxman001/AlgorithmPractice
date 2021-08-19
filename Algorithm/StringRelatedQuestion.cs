using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm
{
    public class StringRelatedQuestion
    {

        public static string RemoveDuplicates(string str)
        {
            string result = string.Empty;
            string tempValue = string.Empty;
            char[] strArray = str.ToCharArray();
            for (int i = 0; i < strArray.Length; i++)
            {
                if (!tempValue.Contains(strArray[i].ToString().ToUpper())
                    && !string.IsNullOrEmpty(strArray[i].ToString()))
                {
                    tempValue = $"{tempValue}{strArray[i].ToString().ToUpper()}";
                    result = $"{result}{strArray[i]}";
                }
            }
            return result;
        }
        public static string RemoveDuplicatesSorted(string str)
        {
            string result = string.Empty;
            string tempValue = string.Empty;
            char[] strArray = str.ToCharArray();
            Array.Sort(strArray);
            for (int i = 0; i < strArray.Length; i++)
            {
                if (!tempValue.Contains(strArray[i].ToString().ToUpper())
                    && !string.IsNullOrEmpty(strArray[i].ToString()))
                {
                    tempValue = $"{tempValue}{strArray[i].ToString().ToUpper()}";
                    result = $"{result}{strArray[i]}";
                }
            }
            return result;
        }
        public static int SearchElement(int[] arr, int key)
        {
            int pivot = FindPivot(arr);
            if (pivot == -1)
                return SearchElement(arr, 0, arr.Length - 1, key);
            if (key > arr[pivot])
                return -1;
            if (key > arr[0])
                return SearchElement(arr, 0, pivot, key);
            if (key < arr[0])
                return SearchElement(arr, pivot + 1, arr.Length - 1, key);
            if (key == arr[pivot])
                return pivot;
            return -1;
        }
        private static int SearchElement(int[] arr, int start, int end, int key)
        {
            if (end < start) return -1;
            if (key == arr[start]) return start;
            if (key == arr[end]) return end;
            int mid = (start + end) / 2;
            if (key == arr[mid]) return mid;
            if (key < arr[mid]) return SearchElement(arr, start, mid, key);
            return SearchElement(arr, mid, end, key);

        }
        public static int FindPivot(int[] arr)
        {
            return FindPivot(arr, 0, arr.Length - 1);
        }
        private static int FindPivot(int[] arr, int start, int end)
        {
            if (end < start) return -1;

            if (end == start) return start;

            int mid = (start + end) / 2;

            if (mid < end && arr[mid] > arr[mid + 1])
                return mid;

            if (mid > start && arr[mid] < arr[mid - 1])
                return (mid - 1);
            if (arr[start] >= arr[mid])
                return FindPivot(arr, start, mid - 1);

            return FindPivot(arr, mid + 1, end);

        }
        public static void PrintLastNString(string s, int t)
        {
            string[] subStrings = s.Split('\n');
            if (subStrings.Length == 0 || t<1) Console.WriteLine("Empty Value"); ;
            int startPoint = subStrings.Length - t < 0 ? 0 : subStrings.Length - t;
            for (int i = startPoint; i < subStrings.Length; i++)
            {
                Console.WriteLine(subStrings[i]);
            }
        }
        public static int LengthEncoding(char[] chars)
        {
            int result = 1;
            int count = 1;
            for (int i=1;i< chars.Length;i++)
            {
              
                    if (chars[i] == chars[i - 1])
                    {
                        count++;
                    }
                    else
                    {
                     if (count > 1)
                        {
                          char[] temp = count.ToString().ToCharArray();
                          for (int j=0;j< temp.Length;j++)
                                {
                            chars[result] = temp[j];
                            result++;
                                }
                        }
                        count = 1;
                        chars[result] = chars[i];
                        result++;
                }
                              
            }
            return result;
        }

    }
}
