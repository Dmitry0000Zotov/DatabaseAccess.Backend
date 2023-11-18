using DatabaseAccess.Application.Interfaces;
using DatabaseAccess.Domain;
using MediatR;
namespace DatabaseAccess.Application.Products.Commands.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Guid>
    {
        private readonly IApiDbContext _context;

        public CreateProductCommandHandler(IApiDbContext context) => _context = context;

        public async Task<Guid> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = new Product
            {
                ProductId = Guid.NewGuid(),
                NomenclatureId = request.NomenclatureId,
                SpecificationId = request.SpecificationId,
                ProductName = request.ProductName,
                Status = request.Status,
                Code = request.Code,
                PalletNumber = request.PalletNumber,
                DateFrom = request.DateFrom,
                DateTo = request.DateTo
            };

            await _context.Products.AddAsync(product, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return product.ProductId;
        }
    }
}
