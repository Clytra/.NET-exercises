using System;

namespace FizzBuzzGame
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Gra FizzBuzz. Podaj liczbę:");
                var number = GetValue();

                FizzBuzz fizzBuzz = new FizzBuzz();
                fizzBuzz.CheckNumber(number);
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
                throw new Exception("Nieprawidłowe dane wejściowe!");

            return value;
        }
    }
}
