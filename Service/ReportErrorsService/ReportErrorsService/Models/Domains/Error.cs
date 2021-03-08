using System;

namespace ReportErrorsService.Models.Domains
{
    public class Error
    {
        public int ErrorId { get; set; }
        public string ErrorMessage { get; set; }
        public DateTime ErrorDate { get; set; }
    }
}
