using Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;

public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
{
    public AppDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
        optionsBuilder.UseSqlServer("Server=CAROL\\MSSQLSERVERONE;Database=LocadoraCarros;Trusted_Connection=True;TrustServerCertificate=True;");

        return new AppDbContext(optionsBuilder.Options);
    }
}
