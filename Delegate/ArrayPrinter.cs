public delegate void ArrayHandler(int[] arr);

namespace MyArrayClass
{
    public class ArrayPrinter
    {
        public static void Print(int[] arr)
        {
            Console.WriteLine("Printing");

            foreach (int i in arr)
            {
                Console.Write(i+" ");
            }
            Console.WriteLine();
        }

        public static void PrintEven(int[] arr)
        {
            Console.WriteLine("Printing even elements");
            foreach(int item in arr)
            {
                if(item%2==0)
                Console.Write(item+ " ");
            }
            Console.WriteLine();
        }

        public static void PrintOdd(int[] arr)
        {
            Console.WriteLine("Printing odd elements");

            foreach (int item in arr)
            {
                if (item % 2 == 1)
                    Console.Write(item + " ");
            }
            Console.WriteLine();
        }

        public static void PrintPrime(int[] arr)
        {
            Console.WriteLine("Printing prime elements");

            bool flag = false;

            for(int i = 0;i < arr.Length; i++)
            {
                for(int j = 2; j < arr[i]; j++)
                {
                    if (arr[i]%j==0)
                        flag = true;
                }
                if (!flag)
                {
                    Console.Write(arr[i]+" ");
                }

                flag = false;
            }
            Console.WriteLine();
        }

        public static void PrintFibonacci(int[] arr)
        {
            Console.WriteLine("Printing fibonacci elements");

            int max = arr[0];
            for(int i = 0; i < arr.Length; i++)
            {
                if (arr[i]>max)
                    max = arr[i];
            }
            List<int> fibList = new List<int> { 0, 1 };
            while(fibList.Last() < max)
                fibList.Add(fibList[^1] + fibList[^2]);

            foreach(int item in arr)
            {
                if(fibList.Contains(item))
                    Console.Write(item + " ");
            }

            Console.WriteLine();
        }

    }
}
