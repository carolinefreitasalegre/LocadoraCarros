using Domain.Entities.RentalClient;

namespace Domain.Contratos.RentalClientInterfaceRepository
{
    public interface ICreateRentalClientRepository
    {
        Task<List<RentalClient>> GetAllClients();
        Task<RentalClient> GetClientsById(Guid Id);

        Task<RentalClient> CreateCliente(RentalClient client);

        Task<RentalClient> Update(RentalClient client);

        Task<RentalClient> Delete(Guid Id);
    }
}
