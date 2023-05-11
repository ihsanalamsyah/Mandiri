using JIWA.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

using System.Configuration;

namespace Mandiri
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();

            services.AddDbContext<PGDBContext>(options =>
                    options.UseSqlServer("Data Source=LAPTOP-P41DCSGI;Initial Catalog=Mandiri;Integrated Security=True;TrustServerCertificate=true"));

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
        }
    }
}
