using System;

namespace Wirtualnik.Server.Extensions.Hangfire
{
    public interface IJobScheduler
    {
        void Schedule();
    }

    public interface IScheduledJob
    {
        void Execute();
    }

    public interface IJobSettings
    {
        string Expression { get; }
        string QueueName { get; }
        int RetryAttempts { get; }
        bool DeleteOnSucceeded { get; }
        int WithoutOverlapping { get; }
    }

    public class JobSettings : IJobSettings
    {
        public string Expression { get; set; }
        public string QueueName { get; set; }
        public int RetryAttempts { get; set; }
        public bool DeleteOnSucceeded { get; set; }
        public int WithoutOverlapping { get; set; }

        #region JobSettings()
        public JobSettings()
        {
            Expression = "* * * * *";
            QueueName = "scheduler";
            RetryAttempts = 5;
            DeleteOnSucceeded = true;
            WithoutOverlapping = 300;
        }

        public JobSettings(IJobSettings settings) : this()
        {
            Expression = settings.Expression;
            QueueName = settings.QueueName;
            RetryAttempts = settings.RetryAttempts;
            DeleteOnSucceeded = settings.DeleteOnSucceeded;
            WithoutOverlapping = settings.WithoutOverlapping;
        }
        #endregion
    }

    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class ScheduleAttribute : Attribute, IJobSettings
    {
        public string Expression { get; set; }
        public string QueueName { get; set; } = "scheduler";
        public int RetryAttempts { get; set; } = 5;
        public bool DeleteOnSucceeded { get; set; } = true;
        public int WithoutOverlapping { get; set; } = 300;

        /// <summary>
        /// http://abunchofutils.com/u/computing/cron-format-helper/
        /// </summary>
        /// <param name="expression"></param>
        public ScheduleAttribute(string expression)
        {
            Expression = expression;
        }
    }
}