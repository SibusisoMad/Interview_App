using InterviewApp.Models;
using Microsoft.Extensions.Options;
using System;

namespace InterviewApp.Services
{
    public class TimeGreetingService : ITimeGreetingService
    {
        private readonly GreetingOptions _options;

        public TimeGreetingService(IOptions<GreetingOptions> options)
        {
            _options = options.Value;
        }

        public string GetTimeGreeting()
        {
            var language = string.IsNullOrEmpty(_options.Language) ? "English" : _options.Language;

            var hour = DateTime.Now.Hour;
            string period = hour < 12 ? "Morning" :
                            hour < 18 ? "Afternoon" : "Evening";

            string timeMessage = _options.TimeMessages.ContainsKey(language) &&
                              _options.TimeMessages[language].ContainsKey(period)
                              ? _options.TimeMessages[language][period]
                              : _options.TimeMessages["English"][period];

            return timeMessage;
        }
    }
}