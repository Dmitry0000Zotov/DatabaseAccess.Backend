using DatabaseAccess.Application.Interfaces;
using DatabaseAccess.Application.Products.Commands.CreateProduct;
using DatabaseAccess.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DatabaseAccess.Application.Materials.Commands.CreateMaterial
{
    public class CreateMaterialCommandHandler : IRequestHandler<CreateMaterialCommand, Guid>
    {
        private readonly IApiDbContext _context;

        public CreateMaterialCommandHandler(IApiDbContext context) => _context = context;

        public async Task<Guid> Handle(CreateMaterialCommand request, CancellationToken cancellationToken)
        {
            var material = await _context.Materials.FirstOrDefaultAsync(material => material.NomenclatureId == request.NomenclatureId);

            if (material != null)
            {
                material.Amount += request.Amount;
                await _context.SaveChangesAsync(cancellationToken);
                return material.MaterialId;
            }
            
            material = new Material
            {
                MaterialId = Guid.NewGuid(),
                NomenclatureId = request.NomenclatureId,
                Amount = request.Amount
            };

            await _context.Materials.AddAsync(material, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return material.MaterialId;
        }
    }
}
