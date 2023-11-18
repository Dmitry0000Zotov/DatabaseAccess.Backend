using DatabaseAccess.Application.Common.Exeptions;
using DatabaseAccess.Application.Interfaces;
using DatabaseAccess.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DatabaseAccess.Application.Products.Commands.UpdateProduct
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand>
    {
        private readonly IApiDbContext _context;

        public UpdateProductCommandHandler(IApiDbContext context) => _context = context;

        public async Task Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Products.FirstOrDefaultAsync(product => product.ProductId == request.ProductId, cancellationToken);
            if(entity == null)
            {
                throw new NotFoundException(nameof(Product), request.ProductId);
            }

            entity.ProductName = request.ProductName;
            entity.Status = request.Status;
            entity.Code = request.Code;
            entity.PalletNumber = request.PalletNumber;
            entity.DateFrom = request.DateFrom;
            entity.DateTo = request.DateTo;

            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
