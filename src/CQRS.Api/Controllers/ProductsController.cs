using System.Threading.Tasks;
using CQRS.Application.Catalog.Commands;
using CQRS.Application.Catalog.Queries.GetProduct;
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

        [HttpGet("{code}")]
        public async Task<ActionResult<ProductResponse>> Get(string code)
        {
            var response = await Mediator.Send(new GetProductQuery { Code = code });

            if (response == null)
                NotFound($"product code: {code} not found");

            return response;
        }
    }
}