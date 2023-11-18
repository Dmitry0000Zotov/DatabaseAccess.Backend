using DatabaseAccess.Application.Common.Exeptions;
using DatabaseAccess.Application.Interfaces;
using DatabaseAccess.Application.Products.Commands.DeleteProduct;
using DatabaseAccess.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccess.Application.Materials.Commands.DeleteMaterial
{
    public class DeleteMaterialCommandHandler : IRequestHandler<DeleteMaterialCommand>
    {
        private readonly IApiDbContext _context;

        public DeleteMaterialCommandHandler(IApiDbContext context) => _context = context;

        public async Task Handle(DeleteMaterialCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Materials.FindAsync(new object[] { request.MaterialId }, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Material), request.MaterialId);
            }

            _context.Materials.Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
