using Microsoft.AspNetCore.Mvc;

namespace Web.Controller
{
    //[Route("listcars")]
    public class HomeController : ControllerBase
    {
        public IActionResult Index()
        {
            return Ok();
        }

        public IActionResult Home()
        {
            return RedirectToPage("/ListCars/ListCar");
        }
    }
}
