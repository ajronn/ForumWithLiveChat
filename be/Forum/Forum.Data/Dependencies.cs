using Microsoft.Extensions.DependencyInjection;

namespace Forum.Data
{
    public static class Dependencies
    {
        public static IServiceCollection RegisterMapping(
            this IServiceCollection services)
        {
            return services
                .AddAutoMapper(typeof(Dependencies).Assembly);
        }
    }
}
