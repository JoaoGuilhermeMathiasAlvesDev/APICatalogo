using APICatalogo.Data;
using Microsoft.EntityFrameworkCore;

namespace APICatalogo.Configuration
{
    public static class Configuration
    {
        public static IServiceCollection ConexecaoBanco(this IServiceCollection services,IConfiguration configuration)
        {


           var connection= configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<Context>
                (options => options.UseSqlServer(connection));
            return services;
        }


    }
}
