using AutoMapper;
using DatabaseAccess.Application.Common.Exeptions;
using DatabaseAccess.Application.Interfaces;
using DatabaseAccess.Application.Products.Queries.GetProduct;
using DatabaseAccess.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccess.Application.Materials.Queries.GetMaterial
{
    public class GetMaterialQueryHandler : IRequestHandler<GetMaterialQuery, MaterialVm>
    {
        private readonly IApiDbContext _context;
        private readonly IMapper _mapper;

        public GetMaterialQueryHandler(IApiDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<MaterialVm> Handle(GetMaterialQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.Materials.FirstOrDefaultAsync(material => material.MaterialId == request.MaterialId, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Material), request.MaterialId);
            }

            return _mapper.Map<MaterialVm>(entity);
        }
    }
}
