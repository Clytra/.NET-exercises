using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HowOldAreYou
{
    public class UserAgeInfo
    {
        public int CheckYourCurrentlyAge(DateTime yourBirthday, DateTime today)
        {
            int currentYear = today.Year;
            int yourYear = yourBirthday.Year;

            int result = currentYear - yourYear;

            if (yourBirthday.DayOfYear > today.DayOfYear)
            {
                result -= 1;
            }

            return result;
        }

        public string ShowUserInfo(int age, string name, string city)
        {
            return $"Także Twoje jestestwo wynosi dokładnie {age} lata, masz na imię {name}, a pojawiłeś się w miłym zakątku o nazwie: {city}.";
        }
    }
}
