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

        public GreetingService(IOptions<GreetingOptions> options, ILogger<GreetingService> logger)
        {
            _options = options.Value;
            _logger = logger;
        }

        public string GetGreetingMessage()
        {
            _logger.LogInformation("GreetingService initialized with Language: {Language}", _options.Language);

            var language = string.IsNullOrEmpty(_options.Language) ? "English" : _options.Language;

            var message = _options.Messages.ContainsKey(language)
                ? _options.Messages[language]
                : _options.Messages.GetValueOrDefault("English", "Welcome to the interview app!");

            return $"{message}"; 
        }
    }
}