using Application.Contratos.CreateRentalClientInterfacceUseCase;
using Application.Dtos.Request.RequestClient;
using Application.Dtos.Response.ResponseClient;
using AutoMapper;
using Domain.Contratos.RentalClientInterfaceRepository;
using Domain.Entities.RentalClient;

namespace Application.UseCases.CreateRentalClientUseCase
{
    public class CreateRentalClientUseCase : ICreateRentalClientUseCase
    {

        private readonly ICreateRentalClientRepository _repository;
        private readonly IMapper _mapper;

        public CreateRentalClientUseCase(ICreateRentalClientRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<RentalClient> CreateCliente(CreateRentalClientRequest request)
        {
            var cliente = new RentalClient(request.Name, request.Email, request.Cpf.Replace("[^0-9a-zA-Z]+", ""))
            {
                Id = Guid.NewGuid(),
                RegisterTime = DateTime.Now,
            };

            await _repository.CreateCliente(cliente);
            return cliente;
        }



        public async Task<List<CreateRentalClientResponse>> GetAllClients()
        {
            var clientes = await _repository.GetAllClients();

            return _mapper.Map<List<CreateRentalClientResponse>>(clientes);

        }

        public async Task<RentalClient> GetClientsById(Guid Id)
        {
            var client = await _repository.GetClientsById(Id) ?? throw new ApplicationException("Cliente não encontrado.");

            return client;
        }

        public async Task<RentalClient> Update(Guid Id, CreateRentalClientRequest request)
        {
            var cliente = await _repository.GetClientsById(Id) ?? throw new ApplicationException("Cliente não encontrado.");

            cliente.Name = request.Name;
            cliente.Email = request.Email;
            cliente.Cpf = request.Cpf;

            return await _repository.Update(cliente);
        }

        public async Task<RentalClient> Delete(Guid Id)
        {
            await (GetClientsById(Id) ?? throw new ApplicationException("Cliente não encontrado."));

            return await _repository.Delete(Id);

        }
    }
}
