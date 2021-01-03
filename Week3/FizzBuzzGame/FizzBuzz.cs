using System;

namespace FizzBuzzGame
{
    public class FizzBuzz
    {
        public void CheckNumber(int value)
        {
            var fizzBuzz = "FizzBuzz";
            var fizz = "Fizz";
            var buzz = "Buzz";

            if (value % 3 == 0 && value % 5 == 0)
            {
                Console.WriteLine(fizzBuzz);
            }
            else if (value % 3 == 0)
            {
                Console.WriteLine(fizz);
            }
            else if (value % 5 == 0)
            {
                Console.WriteLine(buzz);
            }
            else
            {
                Console.WriteLine(value.ToString());
                
            }
            Console.ReadLine();
        }
    }
}
