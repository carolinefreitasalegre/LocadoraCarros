using Application.Contratos.AdminInterfaceUseCase;
using Application.Dtos.Request.RequestAdmin;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly ICreateAdminUseCase _usecase;
        private readonly IValidator<CreateAdminRequest> _validator;

        public AdminController(ICreateAdminUseCase usecase, IValidator<CreateAdminRequest> validator)
        {
            _usecase = usecase;
            _validator = validator;
        }

        [HttpGet("/lista-administradores")]
        public async Task<IActionResult> GetAllAdmin()
        {
            var lista = await _usecase.GetAllAdmin();

            return Ok(lista);
        }


        [HttpGet("/buscar-administrador/{Id}")]
        public async Task<IActionResult> GetAdmin(Guid Id)
        {
            var admin = await _usecase.GetAdmin(Id);

            if (admin == null)
                return NotFound("Administrador não encontrado");

            return Ok(admin);

        }


        [HttpPost("/criar-administrador")]
        public async Task<IActionResult> CreateAdmin(CreateAdminRequest request)
        {
            var validatorResult = await _validator.ValidateAsync(request);

            if (!validatorResult.IsValid)
            {
                return BadRequest(validatorResult.Errors);
            }

            try
            {
                var admin = await _usecase.CreateAdmin(request);
                return Created("", admin);

            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "Erro ao cadastrar administrador", Details = ex.Message });
            }


        }


        [HttpPost("/editar-administrador/{Id}")]
        public async Task<IActionResult> EditdAdmin(Guid Id, CreateAdminRequest request)
        {
            var validatorResult = await _validator.ValidateAsync(request);

            if (!validatorResult.IsValid)
            {
                return BadRequest(validatorResult.Errors);
            }


            var admin = await _usecase.EditAdmin(Id, request);

            if (admin == null)
                return NotFound("Administrador não encontrado");


            return Created("", admin);
        }


        [HttpDelete("/deletar-administrador/{Id}")]
        public async Task<IActionResult> DeleteAdmin(Guid Id)
        {
            var admin = await _usecase.DeleteAdmin(Id);

            if (admin == null)
                return NotFound("Administrador não encontrado");


            return NoContent();
        }

    }
}
