using System;

namespace HowOldAreYou
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

                Console.WriteLine("A teraz podaj rok (SWOJEGO!) urodzenia:");
                var year = GetValue();
                if (year > 2020)
                    throw new Exception("Chyba korzystamy z innych kalendarzy...");

                Console.WriteLine("Podaj miesiąc urodzenia:");
                var month = GetValue();
                if (month < 0 || month > 12)
                    throw new Exception("Chyba korzystamy z innych kalendarzy...");

                Console.WriteLine("Podaj dzień urodzenia");
                var day = GetValue();
                if (day < 0 || day > 31)
                    throw new Exception("Chyba korzystamy z innych kalendarzy...");

                Console.WriteLine("A na koniec miasto, w którym się urodziłeś ;)");
                var city = Console.ReadLine();


                var yourBirthday = new DateTime(year, month, day);
                var today = DateTime.Today;

                //var result = CheckYourCurrentlyAge(yourBirthday, today, city);

                //Console.WriteLine(result);
                int age;

                UserAgeInfo userInfo = new UserAgeInfo();
                age = userInfo.CheckYourCurrentlyAge(yourBirthday, today);

                string result;

                result = userInfo.ShowUserInfo(age, name, city);
                Console.WriteLine(result);
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }
            finally
            {
                Console.ReadLine();
            }

        }

        private static string CheckYourCurrentlyAge(DateTime yourBirthday, DateTime today, string city)
        {
            int months = today.Month - yourBirthday.Month;
            int years = today.Year - yourBirthday.Year;

            if (years <= 5)
                return "Nie żebym się czepiała, ale w Twoim wieku wolałam bawić się w piaskownicy niż sprawdzać swój dokładny wiek.";

            if (years >= 100)
                return "Nie żebym się czepiała, ale gratuluję wigoru ;).";

            if (today.Day < yourBirthday.Day)
                months--;


            if (months < 0)
            {
                years--;
                months += 12;
            }

            int days = (today - yourBirthday.AddMonths((years * 12) + months)).Days;

            return $"Także Twoje jestestwo wynosi dokładnie {years} lata, {months} miesięcy oraz {days} dni, a pojawiło się w miłym zakątku o nazwie: {city}.";
        }

        private static int GetValue()
        {
            if (!int.TryParse(Console.ReadLine(), out int value))
                throw new Exception("Złe dane wejściowe. Prawidłowe dla dnia: 1-31, a dla miesiąca: 1-12.");

            return value;
        }
    }
}

