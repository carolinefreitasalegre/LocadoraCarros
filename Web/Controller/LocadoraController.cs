using Application.Dtos;
using Domain.Contratos.AdminInterface;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controller
{
    public class LocadoraController : ControllerBase
    {
        private readonly ICreateAdminUseCase _useCase;

        public LocadoraController(ICreateAdminUseCase useCase)
        {
            _useCase = useCase;
        }


        [HttpPost]
        public ActionResult Create(CreateAdminRequest request)
        {
            try
            {
               _useCase.CreateAdmin(request.Name, request.JobDescription, request.Email, request.Password);
               return RedirectToPage("/ListCars/ListCar");
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao cadastrar Administrador.", ex);
            }
        }
    }
}



