using DatabaseAccess.Application.Common.Exeptions;
using DatabaseAccess.Application.Interfaces;
using DatabaseAccess.Application.Products.Commands.UpdateProduct;
using DatabaseAccess.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccess.Application.Materials.Commands.UpdateMaterial
{
    public class UpdateMaterialCommandHandler : IRequestHandler<UpdateMaterialCommand>
    {
        private readonly IApiDbContext _context;

        public UpdateMaterialCommandHandler(IApiDbContext context) => _context = context;

        public async Task Handle(UpdateMaterialCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Materials.FirstOrDefaultAsync(material => material.MaterialId == request.MaterialId, cancellationToken);
            if (entity == null)
            {
                throw new NotFoundException(nameof(Material), request.MaterialId);
            }

            entity.Amount = request.Amount;

            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
