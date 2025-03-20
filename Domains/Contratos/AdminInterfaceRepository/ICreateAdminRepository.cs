using Domain.Entities.Admin;

namespace Domain.Contratos.AdminInterface
{
    public interface ICreateAdminRepository
    {
        Task<Admin> CreateAdmin(Admin admin);
        Task<List<Admin>> GetAllAdmin();

        Task<Admin> GetAdmin(Guid Id);

        Task<Admin> EditAdmin(Admin admin);
        Task<Admin> DeleteAdmin(Guid Id);
    }
}
