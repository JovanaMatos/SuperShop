using Microsoft.AspNetCore.Mvc;

namespace SuperShop.Controllers
{
    public class ErrorsController : Controller
    {
        [Route("error/404")]
        public IActionResult Error404()
        {
            return View();
        }
    }
}
