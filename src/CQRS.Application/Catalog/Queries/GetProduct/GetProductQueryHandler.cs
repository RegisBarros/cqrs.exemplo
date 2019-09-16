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
        //private Smtp _smtp;

        public GetProductQueryHandler(Repository repository)
        {
            _repository = repository;
            //_smtp = new Smtp();
        }

        public async Task<ProductResponse> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            var product = _repository.Get(request.Code);

            if (product == null)
                throw new NotFoundException(nameof(Product), request.Code);

            //var email = new Email("admin@app.com", "customer@gmail.com", "e-mail body", "customer service", null);
            //await _smtp.Send(email);

            return ProductResponse.Mapper.ToResponse(product);
        }
    }
}
