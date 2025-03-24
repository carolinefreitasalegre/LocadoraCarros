using Application.Dtos.Request.RequestRental;
using Application.Dtos.Response.ResponseRental;
using Domain.Entities.Locacoes;

namespace Application.Contratos.RentalInterfaceUseCase
{
    public interface ICreateRentalUseCase
    {
        Task<RentalCar> CreateRental(RentalRequest request);

        Task<List<CreateRentalResponse>> GetAllRental();

        Task<RentalCar> GetRentalById(Guid Id);

        Task<RentalCar> EditRental(Guid Id, RentalRequest request);
        Task<RentalCar> DeleteRental(Guid Id);
    }
}
