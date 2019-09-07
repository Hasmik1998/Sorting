using System;

namespace Sortings
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] arr1 = {1, 7, -1, 8, 2};
            double m;
            int d, v;

            double[] BubbleSort(double[] arr)
            {
                for (int j = 0; j <= arr.Length - 2; ++j)
                {
                    for (int i = 0; i <= arr.Length - 2; ++i)
                    {
                        if (arr[i] > arr[i + 1])
                        {
                            m = arr[i + 1];
                            arr[i + 1] = arr[i];
                            arr[i] = m;
                        }
                    }
                }

                return arr;
            }

            double[] InsertionSort(double[] arr)
            {
                for (int i = 0; i < arr.Length - 1; i++)
                {
                    for (int j = i + 1; j > 0; j--)
                    {
                        if (arr[j - 1] > arr[j])
                        {
                            m = arr[j - 1];
                            arr[j - 1] = arr[j];
                            arr[j] = m;
                        }
                    }
                }

                return arr;
            }

            double[] Selectionsort(double[] arr)
            {
                for (int i = 0; i < arr.Length - 1; i++)
                {
                    int smallest = i;
                    for (int j = i + 1; j < arr.Length; j++)
                    {
                        if (arr[j] < arr[smallest])
                        {
                            smallest = j;
                        }
                    }

                    double temp = arr[smallest];
                    arr[smallest] = arr[i];
                    arr[i] = temp;
                }

                return arr;

            }

            int partition(double[] arr, int left, int right)
            {
                if (left > right) return -1;

                int end = left;

                double pivot = arr[right];
                for (int i = left; i < right; i++)
                {
                    if (arr[i] < pivot)
                    {
                        swap(arr, i, end);
                        end++;
                    }
                }

                swap(arr, end, right);

                return end;
            }

            void swap(double[] arr, int left, int right)
            {
                double tmp = arr[left];
                arr[left] = arr[right];
                arr[right] = tmp;
            }

            double[] QuickSort(double[] arr, int left, int right)
            {

                int index = partition(arr, left, right);

                if (index != -1)
                {
                    QuickSort(arr, left, index - 1);
                    QuickSort(arr, index + 1, right);
                }

                return arr;
            }

            double[] MergeSort(double[] array, int start, int end)
            {
                if (start < end)
                {
                    int middle = (end + start) / 2;
                    double[] leftArr = MergeSort(array, start, middle);
                    double[] rightArr = MergeSort(array, middle + 1, end);
                    double[] mergedArr = MergeArray(leftArr, rightArr);
                    return mergedArr;
                }

                return new double[] {array[start]};
            }

            double[] MergeArray(double[] leftArr, double[] rightArr)
            {
                double[] Mergearr = new double[leftArr.Length + rightArr.Length];

                int leftIndex = 0;
                int rightIndex = 0;
                int mergeIndex = 0;

                while (leftIndex < leftArr.Length && rightIndex < rightArr.Length)
                {
                    if (leftArr[leftIndex] < rightArr[rightIndex])
                    {
                        Mergearr[mergeIndex++] = leftArr[leftIndex++];
                    }
                    else
                    {
                        Mergearr[mergeIndex++] = rightArr[rightIndex++];
                    }
                }

                while (leftIndex < leftArr.Length)
                {
                    Mergearr[mergeIndex++] = leftArr[leftIndex++];
                }

                while (rightIndex < rightArr.Length)
                {
                    Mergearr[mergeIndex++] = rightArr[rightIndex++];
                }

                return Mergearr;
            }

            void heapsort(int[] arr)
            {
                MinHeap heap=new MinHeap();
                for (int i = 0; i < arr.Length; i++)
                {
                    heap.Add(arr[i]);
                }
            }


            InsertionSort(arr1);
            foreach (var i in arr1)
            {
                Console.WriteLine(i.ToString() + " ");
            }
        }

    }
}