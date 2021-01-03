using System;

namespace EvenOrOddNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Podaj wartość w celu sprawdzenia, czy jest liczbą parzystą.");
                var number = GetValue();

                if (number % 2 == 0)
                {
                    Console.WriteLine("Podana liczba jest liczbą parzystą.");
                }
                else
                {
                    Console.WriteLine("Podana liczba jest liczbą nieparzystą.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.ReadLine();
            }
        }

        private static int GetValue()
        {
            if (!int.TryParse(Console.ReadLine(), out int value))
                throw new Exception("Nieprawidłowe dane wejściowe!");

            return value;
        }
    }
}
