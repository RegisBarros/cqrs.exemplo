using System.Threading.Tasks;
using CQRS.Application.Catalog.Commands;
using Microsoft.AspNetCore.Mvc;

namespace CQRS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : BaseController
    {
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CreateProductCommand command)
        {
            var productId = await Mediator.Send(command);

            return Created($"products/{productId}", new { code = productId });
        }
    }
}