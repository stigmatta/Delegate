using CreditCardClass;
using MyArrayClass;


namespace Main
{
    public class Program
    {
        #region SecondTaskMethods
        static void PrintCurrentTime()
        {
            TimeSpan currentTime = DateTime.Now.TimeOfDay;
            Console.WriteLine($"{currentTime.Hours:D2}:{currentTime.Minutes:D2}:{currentTime.Seconds:D2}");
        }

        static void PrintCurrentDate()
        {
            DateOnly currentDate = DateOnly.FromDateTime(DateTime.Now.Date);

            Console.WriteLine(currentDate.ToString());
        }

        static void PrintCurrentDayOfWeek()
        {
            DayOfWeek currentDayOfWeek = DateTime.Now.DayOfWeek;
            Console.WriteLine(currentDayOfWeek.ToString());

        }
        #endregion

        public static void Main(string[] args)
        {
            //#region ArrayDelegate

            //int[] arr = new int[10] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            //int[] arr2 = new int[10] { 5, 8, 21, 34, 512, 72, 12, 6, 7, 23 };

            //ArrayHandler arrayHandler = ArrayPrinter.Print;
            //arrayHandler += ArrayPrinter.PrintEven;
            //arrayHandler += ArrayPrinter.PrintOdd;
            //arrayHandler += ArrayPrinter.PrintPrime;
            //arrayHandler += ArrayPrinter.PrintFibonacci;

            //Console.WriteLine("Using the first array:");
            //arrayHandler.Invoke(arr);

            //Console.WriteLine("Using the second array:");
            //arrayHandler.Invoke(arr2);

            //Console.WriteLine();
            //Console.WriteLine();
            //Console.WriteLine();

            //#endregion

            //#region StandardDelegate

            //Action dateHandler = PrintCurrentTime;
            //dateHandler += PrintCurrentDate;
            //dateHandler += PrintCurrentDayOfWeek;

            //dateHandler();

            //#endregion

            #region CreditCard
            CreditCard myCard = new CreditCard(
                creditLimit: 5000,
                sum: 500,
                id: "1234567812345678", 
                name: "John Doe",
                date: new DateOnly(2025, 12, 31), 
                pin: 1234 
            );
            myCard.PutMoney(5);
            myCard.WithdrawMoney(5);
            myCard.PIN = 4321;
            #endregion
        }
    }
}