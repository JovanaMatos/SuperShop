using Microsoft.AspNetCore.Mvc;
using SuperShop.Data;
using System.Linq;

namespace SuperShop.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _repository;

        public ProductsController(IProductRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult GetProducts()
        {
            return Ok(_repository.GetAll());
        }
    }
}