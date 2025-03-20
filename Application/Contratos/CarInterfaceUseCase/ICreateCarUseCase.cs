using Application.Dtos.Request.CreateCarRequest;
using Application.Dtos.Response.CreateCarResponse;
using Domain.Entities.Cars;

namespace Application.Contratos.CarInterfaceUseCase
{
    public interface ICreateCarUseCase
    {
        Task<Cars> CreateCar(CreateCarRequest request);
        Task<List<CreateCarResponse>> GetCars();
        Task<Cars> GetCarById(Guid Id);
        Task<Cars> UpdateCar(Guid Id, EditCarRequest request);
        Task<Cars> DeleteCar(Guid Id);
    }
}
