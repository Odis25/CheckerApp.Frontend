using System;

namespace CheckerApp.Blazor.Models.Checks
{
    public class CheckParameterDto
    {
        public string Description { get; set; }
        public string Method { get; set; }
        public bool Result { get; set; }
        public DateTime Date { get; set; }
        public string Comment { get; set; }
    }
}
