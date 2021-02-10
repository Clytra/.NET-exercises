using ReportService.Models.Domains;
using System;
using System.Collections.Generic;

namespace ReportService.Repositories
{
    public class ReportRepository
    {
        public Report GetLastNotSentReport()
        {
            //pobieranie z bazy danych ostatniego raportu

            return new Report
            {
                Id = 1,
                Title = "R/1/2021",
                Date = new DateTime(2021, 2, 10, 12, 57, 0),
                Positions = new List<ReportPosition> 
                {
                    new ReportPosition
                    {
                        Id = 1,
                        ReportId = 1,
                        Title = "Position 1",
                        Description = "Description 1",
                        Value = 23.44M
                    },
                    new ReportPosition
                    {
                        Id = 2,
                        ReportId = 1,
                        Title = "Position 2",
                        Description = "Description 2",
                        Value = 66M
                    },
                    new ReportPosition
                    {
                        Id = 3,
                        ReportId = 1,
                        Title = "Position 3",
                        Description = "Description 3",
                        Value = 1.99M
                    }
                }
            };
        }

        public void ReportSend(Report report)
        {
            report.IsSend = true;
            // zapis w bazie danych
        }
    }
}
