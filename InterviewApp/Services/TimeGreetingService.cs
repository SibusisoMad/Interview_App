using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewApp.Services
{
    public class TimeGreetingService : ITimeGreetingService
    {
        public string GetTimeGreeting()
        {
            var hour = DateTime.Now.Hour;
            string greeting = hour < 12 ? "Good morning" :
                              hour < 18 ? "Good afternoon" : "Good evening";

            return greeting;
        }
    }
}
