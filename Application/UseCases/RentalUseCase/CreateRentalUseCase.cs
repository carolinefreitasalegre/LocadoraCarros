using System.Diagnostics.Contracts;
using Application.Contratos.RentalInterfaceUseCase;
using Application.Dtos.Request.RequestRental;
using Application.Dtos.Response.ResponseAdmin;
using Application.Dtos.Response.ResponseRental;
using AutoMapper;
using Domain.Contratos.RentalInterfaceRepository;
using Domain.Entities.Locacoes;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Extensions.Options;

namespace Application.UseCases.RentalUseCase
{
    public class CreateRentalUseCase : ICreateRentalUseCase
    {

        private readonly ICreateRentalRepository _repository;
        private readonly IMapper _mapper;

        public CreateRentalUseCase(ICreateRentalRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<RentalCar> CreateRental(RentalRequest request)
        {

            var total = request.PrecoDiaria * request.DiasAlugados;

            var newRental = new RentalCar(request.CarroId, request.ClienteId, request.DataInicio, request.DataFimPrevista, request.DataFimReal, request.PrecoDiaria, request.DiasAlugados)
            {
                Id = Guid.NewGuid(),
                ValorTotal = total,
                Status = Domain.Enums.StatusLocacao.Ativa,
            };


            await _repository.CreateRental(newRental);
            return newRental;


        }


        public async Task<List<CreateRentalResponse>> GetAllRental()
        {
            var lista = await _repository.GetAllRental();
            return _mapper.Map<List<CreateRentalResponse>>(lista);
        }

        public async Task<RentalCar> GetRentalById(Guid Id)
        {
            var contrato = await _repository.GetRentalById(Id) ?? throw new ApplicationException("Contrato de locação não encontrado.");

            return contrato;


        }
        public async Task<RentalCar> EditRental(Guid Id, RentalRequest request)
        {
            var contrato = await _repository.GetRentalById(Id) ?? throw new ApplicationException("Contrato de locação não encontrado.");
            var total = contrato.PrecoDiaria * contrato.DiasAlugados;


            contrato.CarroId = request.CarroId;
            contrato.ClienteId = request.ClienteId;
            contrato.DataInicio = request.DataInicio;
            contrato.DataFimPrevista = request.DataFimPrevista;
            contrato.DataFimReal = request.DataFimReal;
            contrato.PrecoDiaria = request.PrecoDiaria;
            contrato.DiasAlugados = request.DiasAlugados;
            contrato.ValorTotal = total;


            await _repository.EditRental(contrato);

            return contrato;
        }

        public async Task<RentalCar> DeleteRental(Guid Id)
        {
            var contrato = await _repository.DeleteRental(Id) ?? throw new ApplicationException("Contrato de locação não encontrado.");

            return contrato;
        }



    }
}
