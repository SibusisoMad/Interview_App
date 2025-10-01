using InterviewApp.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace InterviewApp.MediatRIntegration
{
    public class GreetUserHandler : IRequestHandler<GreetUserCommand, string>
    {
        private readonly IGreetingService _greetingService;

        public GreetUserHandler(IGreetingService greetingService)
        {
            _greetingService = greetingService;
        }

        public Task<string> Handle(GreetUserCommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_greetingService.GetGreetingMessage());
        }
    }
}