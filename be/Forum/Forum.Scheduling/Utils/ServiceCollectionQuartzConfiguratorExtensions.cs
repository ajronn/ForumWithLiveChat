using Microsoft.Extensions.Configuration;
using Quartz;

namespace Forum.Scheduling.Utils
{
    public static class ServiceCollectionQuartzConfiguratorExtensions
    {
        public static void AddJobAndTrigger<T>(
            this IServiceCollectionQuartzConfigurator quartz,
            IConfiguration configuration)
            where T : IJob
        {
            var jobName = typeof(T).Name;

            var configurationKey = $"Quartz:{jobName}";
            var cronSchedule = configuration[configurationKey];

            var jobKey = new JobKey(jobName);
            quartz.AddJob<T>(options => options.WithIdentity(jobKey));

            quartz.AddTrigger(options => options
                .ForJob(jobKey)
                .WithIdentity(jobName)
                .WithCronSchedule(cronSchedule));
        }
    }
}