using Domain.Entities.Cars;

namespace Domain.Contratos.CarInterface
{
    public interface ICreateCarRepository
    {

        Task<List<Cars>> GetCars();
        Task<Cars> GetCarById(Guid Id);
        Task<Cars> CreateCar(Cars cars);
        Task<Cars> UpdateCar(Cars cars);
        Task<Cars> DeleteCar(Guid Id);
    }
}
