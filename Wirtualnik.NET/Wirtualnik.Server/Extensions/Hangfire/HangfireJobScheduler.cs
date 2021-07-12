using Hangfire;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;

namespace Wirtualnik.Server.Extensions.Hangfire
{

    public class HangfireJobScheduler : IJobScheduler
    {
        protected IServiceProvider ServiceProvider { get; }

        private readonly IRecurringJobManager _recurringJobManager;
        private readonly ILogger<HangfireJobScheduler> _logger;

        public HangfireJobScheduler(IServiceProvider serviceProvider, IRecurringJobManager recurringJobManager, ILogger<HangfireJobScheduler> logger)
        {
            ServiceProvider = serviceProvider;
            _recurringJobManager = recurringJobManager;
            _logger = logger;
        }

        public void Schedule()
        {
            foreach (var job in ServiceProvider.GetServices<IScheduledJob>())
            {
                var attr = job.GetType().GetCustomAttributes(typeof(ScheduleAttribute), false).Cast<ScheduleAttribute>().FirstOrDefault();
                if (attr is null)
                {
                    _logger.LogError("Job must have attribute [Schedule] with expression");
                    return;
                }
                _recurringJobManager.AddOrUpdate(job.GetType().FullName, () => job.Execute(), attr.Expression);
            }
        }
    }

}