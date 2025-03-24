using Domain.Entities.Locacoes;

namespace Domain.Contratos.RentalInterfaceRepository
{
    public interface ICreateRentalRepository
    {
        Task<RentalCar> CreateRental(RentalCar rental);

        Task<List<RentalCar>> GetAllRental();
        Task<RentalCar> GetRentalById(Guid Id);

        Task<RentalCar> EditRental(RentalCar rental);

        Task <RentalCar> DeleteRental(Guid id);

    }
}
