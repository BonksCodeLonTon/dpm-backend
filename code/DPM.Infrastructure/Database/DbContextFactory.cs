using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace DPM.Infrastructure.Database
{
    public class DbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {

            return new AppDbContext(
              new DbContextOptionsBuilder()
                .UseNpgsql("Host=localhost; Database=DPM; Username=postgres; Password=Abc@12345")
                .Options);
        }
    }
}
