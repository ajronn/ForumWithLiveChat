using System;
using System.Linq;
using System.Threading.Tasks;
using Forum.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Quartz;

namespace Forum.Scheduling.Jobs
{
    public class ArchiveMessagesJob : IJob
    {
        private readonly IConfiguration _configuration;
        private readonly ForumDbContext _context;

        public ArchiveMessagesJob(IConfiguration configuration, ForumDbContext context)
        {
            _configuration = configuration;
            _context = context;
        }

        public async Task Execute(IJobExecutionContext jobExecutionContext)
        {
            var substractedTime = _configuration.GetValue<int>("ArchiveMessagesTime");

            var messagesToArchive =
                await _context.Messages.Where(x => (DateTime.Now > x.CreatedAt.AddMinutes(substractedTime) && !x.IsArchival)).ToListAsync();

            foreach (var message in messagesToArchive)
            {
                message.IsArchival = true;
            }

            await _context.SaveChangesAsync();
        }
    }
}
