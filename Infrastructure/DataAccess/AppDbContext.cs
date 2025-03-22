using Domain.Entities.Admin;
using Domain.Entities.Cars;
using Domain.Entities.RentalClient;
using Domain.Entities.Locacoes;
using Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DataAccess
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Cars> carros {get;set;}
        public DbSet<Users> usuarios {get;set;}
        public DbSet<Admin> admin {get;set;}
        public DbSet<RentalCar> locacao { get;set;}
        public DbSet<RentalClient> cliete { get;set;}
    }
}
