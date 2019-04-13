﻿using CQRS.Core.Catalog;
using CQRS.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CQRS.Application.Catalog.Commands
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, string>
    {
        private readonly Repository _repository;

        public CreateProductCommandHandler(Repository repository)
        {
            _repository = repository;
        }

        public async Task<string> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var category = _repository.GetCategory(request.Category);
            var brand = _repository.GetBrand(request.Brand);

            var price = new Price(request.OldPrice, request.Price);

            var product = new Product(request.Title, request.Description, request.Code, price, brand, category);

            _repository.Add(product);

            return product.Code;
        }
    }
}