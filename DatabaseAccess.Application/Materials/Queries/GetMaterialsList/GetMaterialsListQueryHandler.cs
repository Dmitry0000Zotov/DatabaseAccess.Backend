using AutoMapper;
using AutoMapper.QueryableExtensions;
using DatabaseAccess.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DatabaseAccess.Application.Materials.Queries.GetMaterialsList
{
    public class GetMaterialsListQueryHandler : IRequestHandler<GetMaterialsListQuery, MaterialsListVm>
    {
        private readonly IApiDbContext _context;
        private readonly IMapper _mapper;

        public GetMaterialsListQueryHandler(IApiDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<MaterialsListVm> Handle(GetMaterialsListQuery request, CancellationToken cancellationToken)
        {
            var materialsQuery = await _context.Materials
                .ProjectTo<GetMaterialsList>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new MaterialsListVm { Materials = materialsQuery };
        }
    }
}
