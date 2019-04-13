using CQRS.Application.Exceptions;
using CQRS.Core.Catalog;
using CQRS.Persistence;
using System.Threading;
using System.Threading.Tasks;

namespace CQRS.Application.Catalog.Queries.GetProduct
{
    public class GetProductQueryHandler : MediatR.IRequestHandler<GetProductQuery, ProductResponse>
    {
        private readonly Repository _repository;

        public GetProductQueryHandler(Repository repository)
        {
            _repository = repository;
        }

        public async Task<ProductResponse> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            var product = _repository.Get(request.Code);

            if (product == null)
                throw new NotFoundException(nameof(Product), request.Code);

            return ProductResponse.Mapper.ToResponse(product);
        }
    }
}
