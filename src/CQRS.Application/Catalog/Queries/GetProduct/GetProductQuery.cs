using MediatR;

namespace CQRS.Application.Catalog.Queries.GetProduct
{
    public class GetProductQuery : IRequest<ProductResponse>
    {
        public string Code { get; set; }
    }
}
