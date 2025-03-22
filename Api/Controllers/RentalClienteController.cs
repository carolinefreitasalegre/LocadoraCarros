using Application.Contratos.CreateRentalClientInterfacceUseCase;
using Application.Dtos.Request.RequestClient;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;



namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentalClienteController : ControllerBase
    {
        private readonly ICreateRentalClientUseCase _usecase;
        private readonly IValidator<CreateRentalClientRequest> _validator;

        public RentalClienteController(ICreateRentalClientUseCase usecase, IValidator<CreateRentalClientRequest> validator)
        {
            _usecase = usecase;
            _validator = validator;
        }

        [HttpPost("/adicionar-cliente")]
        public async Task<IActionResult> CreateClient(CreateRentalClientRequest request)
        {

            var validatorResult = _validator.Validate(request);

            if (!validatorResult.IsValid)
            {
                return BadRequest(validatorResult.Errors);
            }

            try
            {
                var cliente = await _usecase.CreateCliente(request);

                return Created("", cliente);

            }
            catch (Exception ex)
            {

                return StatusCode(500, new { Message = "Erro ao cadastrar cliente", Details = ex.Message });
            }



        }

        [HttpGet("/buscar-cliente/{Id}")]
        public async Task<IActionResult> GetClientById(Guid Id)
        {
            var cliente = await _usecase.GetClientsById(Id);

            if (cliente == null)
            {
                return BadRequest("Erro ao burcar cliente.");
            }

            return Ok(cliente);
        }


        [HttpGet("/clientes")]
        public async Task<IActionResult> GetClients()
        {
            var clientes = await _usecase.GetAllClients();

            return Ok(clientes);
        }

        [HttpPost("/editar-cliente/{Id}")]
        public async Task<IActionResult> EditClient(Guid Id, CreateRentalClientRequest request)
        {

            var client = await _usecase.GetClientsById(Id);

            if (client == null)
            {
                return BadRequest("Cleinte não encontrado");
            }


            var validator = _validator.Validate(request);

            if (!validator.IsValid)
            {
                return BadRequest(validator.Errors);
            }


            try
            {

                await _usecase.Update(Id, request);

                return Created("", client);

            }
            catch (Exception ex)
            {

                return StatusCode(500, new { Message = "Erro ao cadastrar cliente", Details = ex.Message });

            }

        }


        [HttpDelete("deletar-client/{Id}")]
        public async Task<IActionResult> DeleteClient(Guid Id)
        {
            var cliente = await _usecase.Delete(Id);

            if (cliente == null)
            {

                return NotFound("Cliente não encontrado");
            }

            return NoContent();
        }
    }
}
