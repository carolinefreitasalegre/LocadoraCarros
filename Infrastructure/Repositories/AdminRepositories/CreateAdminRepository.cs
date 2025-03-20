using Domain.Contratos.AdminInterface;
using Domain.Entities.Admin;
using Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.AdminRepositories
{
    public class CreateAdminRepository : ICreateAdminRepository
    {

        private readonly AppDbContext _context;

        public CreateAdminRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Admin>> GetAllAdmin()
        {
            return await _context.admin.ToListAsync();

        }
        
        public async  Task<Admin> GetAdmin(Guid Id)
        {
            var admin = await _context.admin.FirstOrDefaultAsync(x => x.Id == Id);

            if (admin == null)
            {
                throw new KeyNotFoundException("Administrador não encontrado");
            }

            return admin;
        }

        public async Task<Admin> CreateAdmin(Admin admin)
        {
            _context.admin.Add(admin);
            await _context.SaveChangesAsync();

            return admin;


        }


        public async Task<Admin> EditAdmin(Admin admin)
        {
            var adm = _context.admin.FirstOrDefault(a => a.Id == admin.Id);

            if(adm == null)
            {
                throw new KeyNotFoundException("Administrador não encontrado");
            }
            
            _context.admin.Update(admin);
            await _context.SaveChangesAsync();

            return admin;

        }


        public async Task<Admin> DeleteAdmin(Guid Id)
        {
            var admin = _context.admin.FirstOrDefault(x => x.Id == Id);

            if (admin == null)
            {
                throw new KeyNotFoundException("Administrador não encontrado");
            }

            _context.admin.Remove(admin);
            await _context.SaveChangesAsync();

            return admin;


        }
    }
}
