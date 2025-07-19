using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Kalorhytm.Infrastructure.Extensions
{
    public static class StartupExtension
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddDbContext<InMemoryDbContext>(opt => opt.UseInMemoryDatabase("KalorhytmDb"));

            return serviceCollection;
        }
    }
}
