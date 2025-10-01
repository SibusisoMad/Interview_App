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
    public class GetTimeGreetingHandler : IRequestHandler<GetTimeGreetingQuery, string>
    {
        private readonly ITimeGreetingService _timeGreetingService;

        public GetTimeGreetingHandler(ITimeGreetingService timeGreetingService)
        {
            _timeGreetingService = timeGreetingService;
        }

        public Task<string> Handle(GetTimeGreetingQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_timeGreetingService.GetTimeGreeting());
        }
    }
}