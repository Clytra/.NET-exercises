using System;

namespace FizzBuzzGame
{
    public class FizzBuzz
    {
        public void CheckNumber(int value)
        {
            if (value % 3 == 0 && value % 5 == 0)
            {
                Console.WriteLine("FizzBuzz");
            }
            else if (value % 3 == 0)
            {
                Console.WriteLine("Fizz");
            }
            else if (value % 5 == 0)
            {
                Console.WriteLine("Buzz");
            }
            else
            {
                Console.WriteLine(value.ToString());
                
            }
            Console.ReadLine();
        }
    }
}
