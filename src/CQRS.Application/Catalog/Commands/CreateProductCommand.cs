using MediatR;

namespace CQRS.Application.Catalog.Commands
{
    public class CreateProductCommand : IRequest<string>
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public string Code { get; set; }

        public decimal OldPrice { get; set; }

        public decimal Price { get; set; }

        public string Brand { get; set; }

        public string Category { get; set; }
    }
}
