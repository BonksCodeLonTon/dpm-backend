using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace DPM.Infrastructure.Database
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder
                .UseNpgsql("Host=13.250.174.234; Database=postgres; Username=postgres; Password=Abc@12345")
                .UseSnakeCaseNamingConvention();
            return new AppDbContext(optionsBuilder.Options);
        }
    }
}