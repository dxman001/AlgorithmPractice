using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithm
{
    public static class Sorting
    {
        /// <summary>
        /// Quick Sort
        /// </summary>
        /// <param name="numbers"></param>
        /// <returns></returns>
        public static int[] QuickSort(this int[] numbers)
        {
             return QuickSort(numbers, 0,numbers.Length-1);           
        }
        private static int[] QuickSort(int[] numbers, int left, int right)
        {
            int i = left;
            int j = right;
            int pivot = numbers[(left + right) / 2];
            while (i <= j)
            {
                while (numbers[i] < pivot)
                    i++;

                while (numbers[j] > pivot)
                    j--;

                if (i <= j)
                {
                    int temp = numbers[i];
                    numbers[i] = numbers[j];
                    numbers[j] = temp;
                    i++;
                    j--;
                }
            }
            if (left < j)
                QuickSort(numbers, left, j);

            if (i < right)
                QuickSort(numbers, i, right);
            return numbers;
        }

        /// <summary>
        /// Merge Array with Array
        /// </summary>
        /// <param name="numbers"></param>
        public static void MergeSort(this int[] numbers)
        {
            MergeSort(numbers, 0, numbers.Length - 1,"initial");
        }
        private static void MergeSort(int[] numbers, int leftBoudary, int rightBoundary,string side)
        {
            if(leftBoudary< rightBoundary)
            {
                int middle = leftBoudary + (rightBoundary - leftBoudary) / 2 + 1;
                MergeSort(numbers, leftBoudary, middle - 1,"left");
                MergeSort(numbers, middle, rightBoundary,"right");
                Merge(numbers, leftBoudary, middle, rightBoundary);
            }
        }
        private static void Merge(int[] numbers,int leftBoudary,int middle,int rightBoundary)
        {
            int i, j, k;
            int leftArrayLength = middle - leftBoudary;
            int rightArrayLength = rightBoundary - middle + 1;
            int[] left = new int[leftArrayLength];
            int[] right = new int[rightArrayLength];
            for(i=0;i< leftArrayLength;i++)
            {
                left[i] = numbers[leftBoudary + i];
            }
            for (i = 0; i < rightArrayLength; i++)
            {
                right[i] = numbers[middle + i];
            }
            i = 0;j = 0;k = leftBoudary;
            while(i<leftArrayLength&& j<rightArrayLength)
            {
                if (left[i] <= right[j])
                {
                    numbers[k++] = left[i++];
                }
                else
                {
                    numbers[k++] = right[j++];
                }
            }
            if(leftArrayLength==i)
            {
                for(int z=j;z< rightArrayLength;z++)
                {
                    numbers[k++] = right[z];
                }
            }
            if (rightArrayLength == j)
            {
                for (int q = i; q < leftArrayLength; q++)
                {
                    numbers[k++] = left[q];
                }
            }


        }

        /// <summary>
        /// Bubble sort
        /// </summary>
        /// <param name="numbers"></param>
        public static void BubbleSort(this int[] numbers)
        {
            bool swiped=true;

           while(swiped)
            {
                swiped = false;
                for(int i=0;i< numbers.Length-1;i++)
                {
                    if(numbers[i]> numbers[i+1])
                    {
                        int temp = numbers[i];
                        numbers[i] = numbers[i + 1];
                        numbers[i + 1] = temp;
                        swiped = true;
                    }
                }
            }

        }
        public static void InsertSort(this int[] numbers)
        {
            for(int i=0;i<numbers.Length-1;i++)
            {
                if(numbers[i]>numbers[i+1])
                {
                    int temp = numbers[i];
                    numbers[i] = numbers[i + 1];
                    numbers[i + 1] = temp;
                    
                    InsertSort(numbers);
                }
               
            }
        }
    }
}
