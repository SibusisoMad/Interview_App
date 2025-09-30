using InterviewApp.Models;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewApp.Validators
{
    public class GreetingOptionsValidator : IValidateOptions<GreetingOptions>
    {
        public ValidateOptionsResult Validate(string? name, GreetingOptions options)
        {
            var errors = new List<string>();

            if (string.IsNullOrWhiteSpace(options.Language))
                errors.Add("Greeting:Language must not be null or empty.");

            if (options.Messages is null || options.Messages.Count == 0)
                errors.Add("Greeting:Messages must not be empty.");
            else
            {
                if (!options.Messages.ContainsKey("English"))
                    errors.Add("Greeting:Messages must contain an 'English' fallback.");

                errors.AddRange(
                    options.Messages
                           .Where(msg => string.IsNullOrWhiteSpace(msg.Value))
                           .Select(msg => $"Greeting:[{msg.Key}]Messages must not be null or empty.")     

                );
            }

            return errors.Any()
                ? ValidateOptionsResult.Fail(errors)
                : ValidateOptionsResult.Success;
        }
    }
}
