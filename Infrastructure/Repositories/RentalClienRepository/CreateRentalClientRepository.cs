using Domain.Contratos.RentalClientInterfaceRepository;
using Domain.Entities.RentalClient;
using Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.RentalClienRepository
{
    public class CreateRentalClientRepository : ICreateRentalClientRepository
    {

        private readonly AppDbContext _context;

        public CreateRentalClientRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<RentalClient> CreateCliente(RentalClient client)
        {
            _context.cliete.Add(client);
            await _context.SaveChangesAsync();

            return client;
        }


        public async Task<List<RentalClient>> GetAllClients()
        {
            return await _context.cliete.ToListAsync();
        }

        public async Task<RentalClient> GetClientsById(Guid Id)
        {
            var cliente = await _context.cliete.FirstOrDefaultAsync(c => c.Id == Id) ?? throw new KeyNotFoundException("Cliente não encontrado.");

            return cliente;
        }

        public async Task<RentalClient> Update(RentalClient client)
        {
            var cliente = await _context.cliete.FirstOrDefaultAsync(c => c.Id == client.Id) ?? throw new KeyNotFoundException("Cliente não encontrado.");

            _context.cliete.Update(client);
            await _context.SaveChangesAsync();

            return client;

        }

        public async Task<RentalClient> Delete(Guid Id)
        {
            var cliente = await _context.cliete.FirstOrDefaultAsync(c => c.Id == Id) ?? throw new KeyNotFoundException("Cliente não encontrado.");

            _context.cliete.Remove(cliente);
            await _context.SaveChangesAsync();

            return cliente;
        }




    }
}
