using ReportService.Models.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportService.Repositories
{
    public class ErrorRepository
    {
        public List<Error> GetLasError(int intervalInMinutes)
        {
            //pobieranie z bazy danych
            return new List<Error>
            {
                new Error {Message = "Błąd tekstowy 1", Date = DateTime.Now},
                new Error {Message = "Błąd tekstowy 2", Date = DateTime.Now}
            };
        }
    }
}
