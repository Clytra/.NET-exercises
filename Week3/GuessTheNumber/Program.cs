using System;

namespace GuessTheNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var random = new Random();
                var rightValue = random.Next(101);

                Console.WriteLine("Zgadnij liczbę jaką mam na myśli. Możliwa liczba mieści się w przedziale od 0 do 100:");
                

                for (int i = 0;; i++)
                {
                    var number = GetValue();
                    if (number < 0)
                    {
                        Console.WriteLine("W grę wchodzą wartości powyżej zera!");
                        Console.WriteLine("Próbuj dalej!");
                    }
                    else if (number > rightValue)
                    {
                        Console.WriteLine("Prawidłowa liczba jest niższa od podanej.");
                        Console.WriteLine("Próbuj dalej!");
                    }
                    else if (number < rightValue)
                    {
                        Console.WriteLine("Prawidłowa liczba jest wyższa od podanej.");
                        Console.WriteLine("Próbuj dalej!");
                    }
                    else
                    {
                        Console.WriteLine($"Brawo! Chodzi o: {rightValue}. Gratulacje! Łączna ilość prób wynosi: {i}");
                        Console.ReadLine();
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }
        }

        private static int GetValue()
        {
            if (!int.TryParse(Console.ReadLine(), out int value))
                throw new Exception("Złe dane wejściowe. Wprowadź wartość z zakresu od 0 do 100.");

            return value;
        }
    }
}
    
