using Domain.Contratos.RentalInterfaceRepository;
using Domain.Entities.Locacoes;
using Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.RentalRepository
{
    public class CreateRentalRepository : ICreateRentalRepository
    {
        private readonly AppDbContext _context;

        public CreateRentalRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<RentalCar> CreateRental(RentalCar rental)
        {
            _context.locacao.Add(rental);
            await _context.SaveChangesAsync();

            return rental;
        }

        public async Task<List<RentalCar>> GetAllRental()
        {

            return await _context.locacao.ToListAsync();

        }

        public async Task<RentalCar> GetRentalById(Guid Id)
        {
            var locacao = await _context.locacao.FirstOrDefaultAsync(x => x.Id == Id) ?? throw new KeyNotFoundException("Contrato de locação não encontrado.");


            return locacao;

        }


        public async Task<RentalCar> EditRental(RentalCar rental)
        {
            var contrato = await _context.locacao.FirstOrDefaultAsync(x => x.Id == rental.Id) ?? throw new KeyNotFoundException("Contrato de locação não encontrado.");

            _context.locacao.Update(contrato);
            await _context.SaveChangesAsync();  

            return rental;
        }


        public async Task<RentalCar> DeleteRental(Guid Id)
        {
            var contrato = await _context.locacao.FirstOrDefaultAsync(x => x.Id == Id) ?? throw new KeyNotFoundException("Contrato de locação não encontrado.");

            _context.locacao.Remove(contrato);
            await _context.SaveChangesAsync();

            return contrato;
        }
    }
}
