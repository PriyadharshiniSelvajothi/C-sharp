using System;
namespace ComplexOne
{
    class Program
    {
        public static void Main()
        {
            int size = int.Parse(Console.ReadLine());
            int num = int.Parse(Console.ReadLine());

            string[] arr = Console.ReadLine().Split(",");
            int[] values = new int[arr.Length];
            for (int i = 0; i < size - 1; i++)
            {
                values[i] = int.Parse(arr[i]);
            }

            int j = 0;
            int k = values.Length - 1;
            Console.WriteLine(Find(values, j, k, num));
           

        }
        public static string Find(int[] values, int j, int k, int num)
        {
            if (j > k)
            {
                return "No";
            }
           
                int mid = j + (k - j) / 2;
                if (num == values[mid])
                {
                    return "Yes";
                }
                else if (values[mid] < num)
                {
                    j = mid + 1;
                }
                else
                {
                    k = mid - 1;
                }
            
            return Find(values, j, k, num);
        }
    }
}