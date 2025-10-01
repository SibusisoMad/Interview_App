using System.Collections.Generic;

namespace InterviewApp.Models
{
    public class GreetingOptions
    {
        public string Message { get; set; }
        public string Language { get; set; }

        public Dictionary<string, string> Messages { get; set; } = new();
        public Dictionary<string, Dictionary<string, string>> TimeMessages { get; set; } = new ();
    }
}