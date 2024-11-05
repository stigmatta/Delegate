using System;
using System.Text.RegularExpressions;

public delegate void CardHandler(int sum);

namespace CreditCardClass
{
    public class Printers
    {
        public static void PrintPutMoney(int sum)
        {
            Console.WriteLine($"{sum}$ has been successfully put.");
        }

        public static void PrintWithdrawMoney(int sum)
        {
            Console.WriteLine($"{sum}$ has been successfully withdrawn.");
        }

        public static void PrintChangedPin(int sum)
        {
            Console.WriteLine("PIN has been succesfully changed");
        }
    }

    public class CreditCard
    {
        private int creditLimit;
        private int sum;
        private int pin;

        public event CardHandler PutEvent;
        public event CardHandler WithdrawEvent;
        public event CardHandler OnPinChanged;

        private string Id { get; }
        public string Name { get; }
        public DateOnly Date { get; }


        public int CreditLimit
        {
            get { return creditLimit; }
            set
            {
                try
                {
                    if (value > 1000000 || value < 0)
                        throw new ArgumentException("Credit limit must be between 0 and 1,000,000.");
                    creditLimit = value;
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }

        public int Sum
        {
            get { return sum; }
            set
            {
                try
                {
                    if (value > 1000000 || value < 0)
                        throw new ArgumentException("Sum must be between 0 and 1,000,000.");
                    sum = value;
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }

        public int PIN
        {
            get { return pin; }
            set
            {
                if(value<1000 || value > 9999)
                {
                    throw new ArgumentException("PIN must be a 4-digit number.");
                }
                pin = value;
                OnPinChanged?.Invoke(value);
            }
        }

        public CreditCard(int creditLimit, int sum, string id, string name, DateOnly date, int pin)
        {
            try
            {
                CreditLimit = creditLimit;
                Sum = sum;
                PIN = pin;
                if (!(Regex.IsMatch(id, @"^\d{16}$")))
                    throw new ArgumentException("ID must be exactly 16 digits.");
                Id = id;
                if (!(Regex.IsMatch(name, @"^[a-zA-Z\s]+$")))
                    throw new ArgumentException("Name must contain only letters and spaces.");
                Name = name;
                if (date > (DateOnly.FromDateTime(DateTime.Now).AddYears(4)) || date < DateOnly.FromDateTime(DateTime.Now))
                    throw new ArgumentException("Date must be within the next 4 years.");
                Date = date;

                SubscribeForPut();
                SubscribeForWithdraw();
                SubscribeForPinChanged();
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public void PrintAccountMoney(int sum)
        {
            Console.WriteLine($"Your credit card sum of money: {Sum}$");
        }

        public void SubscribeForPut()
        {
            PutEvent = Printers.PrintPutMoney;
            PutEvent += PrintAccountMoney;
        }

        public void SubscribeForWithdraw()
        {
            WithdrawEvent = Printers.PrintWithdrawMoney;
            WithdrawEvent += PrintAccountMoney;
        }

        public void SubscribeForPinChanged()
        {
            OnPinChanged += Printers.PrintChangedPin;
        }

        public void PutMoney(int amount)
        {
            Sum += amount;
            PutEvent?.Invoke(amount);
        }

        public void WithdrawMoney(int amount)
        {
            Sum -= amount;
            WithdrawEvent?.Invoke(amount);
        }

    }

}
