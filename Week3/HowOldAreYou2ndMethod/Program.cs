using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HowOldAreYou2ndMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Cześć! Przed obliczeniem, jak bardzo jesteś stary, podaj " +
                "proszę Twoje imię:");
                var name = Console.ReadLine();


            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
