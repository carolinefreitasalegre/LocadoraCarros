using Domain.Contratos.CarInterface;
using Domain.Entities.Cars;
using Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.CarRepositories
{
    public class CreateCarRepository : ICreateCarRepository
    {
        private readonly AppDbContext _context;

        public CreateCarRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Cars> CreateCar(Cars cars)
        {
            _context.carros.Add(cars);
            await _context.SaveChangesAsync();

            return cars;
        }


        public async Task<List<Cars>> GetCars()
        {
            return await _context.carros.ToListAsync();
        }

        public async Task<Cars> GetCarById(Guid Id)
        {
            var car = await _context.carros.FirstOrDefaultAsync(c => c.Id == Id) ?? throw new KeyNotFoundException("Erro ao buscar veículo no banco de dados");

            return car;


        }

        public async Task<Cars> UpdateCar(Cars cars)
        {
            var car =  _context.carros.FirstOrDefault(c => c.Id == cars.Id) ?? throw new KeyNotFoundException("Carro não encontrado no banco de dados.");

            _context.Update(car);
            await _context.SaveChangesAsync();

            return cars;

        }
        public async Task<Cars> DeleteCar(Guid Id)
        {
            var car = await _context.carros.FirstOrDefaultAsync(c => c.Id == Id) ?? throw new KeyNotFoundException("Veículo não encontrado");


            _context.carros.Remove(car);
            await _context.SaveChangesAsync();

            return car;

        }
    }
}
