using Application.Dtos.Request.RequestClient;
using Application.Dtos.Response.ResponseClient;
using Domain.Entities.RentalClient;

namespace Application.Contratos.CreateRentalClientInterfacceUseCase
{
    public interface ICreateRentalClientUseCase
    {
        Task<List<CreateRentalClientResponse>> GetAllClients();
        Task<RentalClient> GetClientsById(Guid Id);

        Task<RentalClient> CreateCliente(CreateRentalClientRequest request);

        Task<RentalClient> Update(Guid Id, CreateRentalClientRequest request);

        Task<RentalClient> Delete(Guid Id);
    }
}
