using System;
using Microsoft.Extensions.DependencyInjection;

namespace Swift.BBS.Extension
{
    public static class AutoMapperSetup
    {
        public static void AddAutoMapperSetup(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddAutoMapper(typeof(AutoMapperConfig));
        }
    }
}