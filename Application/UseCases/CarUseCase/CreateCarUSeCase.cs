using Application.Contratos.CarInterfaceUseCase;
using Application.Dtos.Request.CreateCarRequest;
using Application.Dtos.Response.CreateCarResponse;
using AutoMapper;
using Domain.Contratos.CarInterface;
using Domain.Entities.Cars;

namespace Application.UseCases.CarUseCase
{
    public class CreateCarUSeCase : ICreateCarUseCase
    {
        private readonly ICreateCarRepository _repository;
        private readonly IMapper _mapper;

        public CreateCarUSeCase(ICreateCarRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Cars> CreateCar(CreateCarRequest request)
        {
            var addCar = new Cars(request.Model.ToLower(), request.Year, request.Dors, request.Marca.ToLower(), request.Placa.ToUpper(), request.Cor.ToLower(), request.Quilometragem, request.Cambio.ToLower(), request.Combustivel.ToLower(), request.Capacidade, request.ArCondicionado, request.Disponivel, request.PrecoDiaria, request.Status.ToLower(), request.DataUltimaManutencao)
            {
                Id = Guid.NewGuid(),
                RegisterTime = DateTime.Now,
            };



            await _repository.CreateCar(addCar);
            return addCar;

        }

        public async Task<List<CreateCarResponse>> GetCars()
        {
            var listaCarros = await _repository.GetCars();
            return _mapper.Map<List<CreateCarResponse>>(listaCarros);
        }
        public async Task<Cars> GetCarById(Guid Id)
        {
            var car = await _repository.GetCarById(Id) ?? throw new KeyNotFoundException("Carro não encontrado;");
            var response = _mapper.Map<Cars>(car);

            return response;



        }


        public async Task<Cars> UpdateCar(Guid Id, EditCarRequest request)
        {
            var car = await GetCarById(Id) ?? throw new KeyNotFoundException("Nenhum carro encontrado");

            car.Model = request.Model.ToLower();
            car.Year = request.Year;
            car.Dors = request.Dors;
            car.Marca = request.Marca.ToLower();
            car.Placa = request.Placa.ToUpper();
            car.Cor = request.Cor.ToLower();
            car.Quilometragem = request.Quilometragem;
            car.Cambio = request.Cambio.ToLower();
            car.Combustivel = request.Combustivel.ToLower();
            car.Capacidade = request.Capacidade;
            car.ArCondicionado = request.ArCondicionado;
            car.Disponivel = request.Disponivel;
            car.PrecoDiaria = request.PrecoDiaria;
            car.Status = request.Status.ToLower();
            car.DataUltimaManutencao = request.DataUltimaManutencao;


            return await _repository.UpdateCar(car);

        }



        public Task<Cars> DeleteCar(Guid Id)
        {
            var car = _repository.DeleteCar(Id) ?? throw new KeyNotFoundException("Carro não encontrado");


            return car;
        }

    }
}
