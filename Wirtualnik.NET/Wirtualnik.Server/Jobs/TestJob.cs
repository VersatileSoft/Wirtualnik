﻿using Microsoft.Extensions.Logging;
using Wirtualnik.Server.Extensions.Hangfire;

namespace Wirtualnik.Server.Jobs
{
    [Schedule("0 0 0 1 1 *")]
    public class TestJob : IScheduledJob
    {
        private readonly ILogger<TestJob> _logger;

        public TestJob(ILogger<TestJob> logger)
        {
            _logger = logger;
        }

        public void Execute()
        {
            _logger.LogDebug("Test job execute");
        }
    }
}