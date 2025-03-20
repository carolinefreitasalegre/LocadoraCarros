using Application.Dtos.Request.RequestAdmin;
using Application.Dtos.Response.ResponseAdmin;
using Domain.Entities.Admin;

namespace Application.Contratos.AdminInterfaceUseCase
{
    public interface ICreateAdminUseCase
    {
        Task<List<CreateAdmiResponse>> GetAllAdmin();
        Task<Admin> CreateAdmin(CreateAdminRequest request);


        Task<Admin> GetAdmin(Guid Id);

        Task<Admin> EditAdmin(Guid Id, CreateAdminRequest request);
        Task<Admin> DeleteAdmin(Guid Id);

    }
}
