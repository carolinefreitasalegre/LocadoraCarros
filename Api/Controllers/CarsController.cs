using Application.Contratos.CarInterfaceUseCase;
using Application.Dtos.Request.CreateCarRequest;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly ICreateCarUseCase _usecase;
        private readonly IValidator<CreateCarRequest> _validator;

        public CarsController(ICreateCarUseCase useCase, IValidator<CreateCarRequest> validator)
        {
            _usecase = useCase;
            _validator = validator;
        }


        [HttpGet("/lista-carros")]
        public async Task<IActionResult> GetCars()
        {
            var lista = await _usecase.GetCars();

            return Ok(lista);
        }


        [HttpGet("/buscar-carro/{Id}")]
        public async Task<IActionResult> GetCarById(Guid Id)
        {
            var car = await _usecase.GetCarById(Id);

            if (car == null)
            {
                return BadRequest("Vaículo não encontrado");
            }


            return Ok(car);
        }


        [HttpPost("/adicionar-carro")]
        public async Task<IActionResult> CreateCar(CreateCarRequest request)
        {
            var validatorResult = await _validator.ValidateAsync(request);

            if (!validatorResult.IsValid)
            {
                return BadRequest("Erro ao adicioar carro. Verifique os campos.");
            }


            try
            {

                var car = await _usecase.CreateCar(request);
                return Created("", car);
            }
            catch (Exception ex)
            {

                return StatusCode(500, new { Message = "Erro ao cadastrar administrador", Details = ex.Message });
            }

        }


        [HttpPost("/editar-carro/{Id}")]
        public async Task<IActionResult> EditCar(Guid Id, EditCarRequest request)
        {

            var validateResult = await _validator.ValidateAsync(request);

            if (!validateResult.IsValid)
            {
                return BadRequest(validateResult.Errors);
            }


            var car = _usecase.UpdateCar(Id, request);

            if (car == null)
            {
                return NotFound("Carro não encontrado");
            }


            return Created("", car);
        }


        [HttpDelete("/deletar-carro/{Id}")]
        public async Task<IActionResult> DeleteCar(Guid Id)
        {
            var car = await _usecase.DeleteCar(Id);

            if (car == null)
            {
                return NotFound("Veículo não encontrado");
            }


            return NoContent();


        }

    }
}
