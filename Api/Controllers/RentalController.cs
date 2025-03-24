using Application.Contratos.RentalInterfaceUseCase;
using Application.Dtos.Request.RequestRental;
using Application.Dtos.Response.ResponseRental;
using Domain.Entities.Admin;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentalController : ControllerBase
    {
        private readonly ICreateRentalUseCase _usecase;
        private readonly IValidator<RentalRequest> _validator;

        public RentalController(ICreateRentalUseCase usecase, IValidator<RentalRequest> validator)
        {
            _usecase = usecase;
            _validator = validator;
        }

        [HttpPost("/criar-contrato")]
        public async Task<IActionResult> CreateRental(RentalRequest request)
        {
            var contrato = await _usecase.CreateRental(request);

            var validator = _validator.Validate(request);

            if (!validator.IsValid)
            {
                return BadRequest(validator.Errors);
            }

            return Created("", contrato);
        }

        [HttpGet("/lista-contratos")]
        public async Task<IActionResult> GetAllRental()
        {
            var lista = await _usecase.GetAllRental();

            return Ok(lista);
        }

        [HttpGet("/buscar-contrato/{Id}")]
        public async Task<IActionResult> GetRentalById(Guid Id)
        {
            var contrato = await _usecase.GetRentalById(Id);

            if (contrato == null)
            {
                BadRequest("Contrato não encontrado");
            }

            return Ok(contrato);

        }


        [HttpPost("/editar-contrato/{Id}")]
        public async Task<IActionResult> EditRental(Guid Id, RentalRequest request)
        {

            var validatorResult = await _validator.ValidateAsync(request);

            if (!validatorResult.IsValid)
            {
                return BadRequest(validatorResult.Errors);
            }


            var contrato = await _usecase.EditRental(Id, request);

            if (contrato == null)
                return NotFound("Contrato não encontrado");


            return Created("", contrato);

        }


        [HttpDelete("/deletar-contrato/{Id}")]
        public async Task<IActionResult> DeleteRental(Guid Id)
        {
            var contrato = await _usecase.DeleteRental(Id);

            if (contrato == null)
                return NotFound("Contrato não encontrado");


            return NoContent();
        }
    }
}
