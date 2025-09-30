using InterviewApp.Models;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;

namespace InterviewApp.Services
{
    public class GreetingService : IGreetingService
    {
        private readonly GreetingOptions _options;
        private readonly ILogger<GreetingService> _logger;
        private readonly ITimeGreetingService _timeGreetingService;

        public GreetingService(IOptions<GreetingOptions> options, ILogger<GreetingService> logger, ITimeGreetingService timeGreetingService)
        {
            _options = options.Value;
            _logger = logger;
            _timeGreetingService = timeGreetingService;
        }

        public string GetGreetingMessage()
        {
            _logger.LogInformation("GreetingService initialized with Language: {Language}", _options.Language);

            var language = string.IsNullOrEmpty(_options.Language) ? "English" : _options.Language;

            var greeting = _options.Translations.ContainsKey(language)
                ? _options.Translations[language]
                : _options.Translations.GetValueOrDefault("English", "Hello");

            if (greeting == "Hello" && language != "English")
            {
                _logger.LogWarning("Unsupported language {Language}, falling back to English.", language);
            }

            var message = _options.Messages.ContainsKey(language)
                ? _options.Messages[language]
                : _options.Messages.GetValueOrDefault("English", "Welcome to the interview app!");

            var timeGreetingMsg = _timeGreetingService.GetTimeGreeting();

            return $"{timeGreetingMsg}! {message}"; 
        }
    }
}