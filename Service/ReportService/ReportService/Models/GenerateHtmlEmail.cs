﻿using ReportService.Models.Domains;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ReportService.Models
{
    public class GenerateHtmlEmail
    {
        public string GenerateErrors(List<Error> errors, int interval)
        {
            if (errors == null)
                throw new ArgumentNullException(nameof(errors));

            if (!errors.Any())
                return string.Empty;

            var html = $"Błędy z ostatnich {interval} minut.<br /><br />";

            html +=
                @"
                    <table border=1 cellpadding=5 cellspacing=1>
                        <tr>
                            <td allign=center bgcolor=lightgrey>Wiadomość</td>
                            <td allign=center bgcolor=lightgrey>Data</td>
                        </tr>
                ";

            foreach (var error in errors)
            {
                html +=
                    $@"<tr>
                        <td allign=center>{error.Message}</td>
                        <td allign=center>{error.Date.ToString("dd-MM-yyyy HH:mm")}</td>
                       </tr>
                    ";
            }

            html += @"</table><br /><br/ ><i>Automatyczna wiadomość wysłana w aplikacji ReportService.</i>";

            return html;
        }

        public string GenerateReport(Report report)
        {
            if (report == null)
                throw new ArgumentNullException(nameof(report));

            var html = $"Raport {report.Title} z dnia {report.Date.ToString("dd-MM-yyyy")}.<br /><br />";

            if (report.Positions != null && report.Positions.Any())
            {
                html +=
                @"
                    <table border=1 cellpadding=5 cellspacing=1>
                        <tr>
                            <td allign=center bgcolor=lightgrey>Tytuł</td>
                            <td allign=center bgcolor=lightgrey>Opis</td>
                            <td allign=center bgcolor=lightgrey>Wartość</td>
                        </tr>
                ";

                foreach (var position in report.Positions)
                {
                    html +=
                        $@"<tr>
                        <td allign=center>{position.Title}</td>
                        <td allign=center>{position.Description}</td>
                        <td allign=center>{position.Value.ToString("0.00")} zł</td>
                       </tr>
                    ";
                }

                html += "</table>";
            }
            else
            {
                html += "-- Brak danych do wyświetlenia --";
            }

            html += @"<br /><br/ ><i>Automatyczna wiadomość wysłana w aplikacji ReportService.</i>";

            return html;
        }
    }
}
