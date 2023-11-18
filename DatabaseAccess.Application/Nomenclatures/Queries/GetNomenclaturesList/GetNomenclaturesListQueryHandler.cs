using AutoMapper;
using AutoMapper.QueryableExtensions;
using DatabaseAccess.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace DatabaseAccess.Application.Nomenclatures.Queries.GetNomenclaturesList
{
    public class GetNomenclaturesListQueryHandler : IRequestHandler<GetNomenclaturesListQuery, NomenclaturesListVm>
    {
        private readonly IApiDbContext _context;
        private readonly IMapper _mapper;

        public GetNomenclaturesListQueryHandler(IApiDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<NomenclaturesListVm> Handle(GetNomenclaturesListQuery request, CancellationToken cancellationToken)
        {
            var nomenclaturesQuery = await _context.Nomenclatures
                .ProjectTo<GetNomenclaturesList>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new NomenclaturesListVm { Nomenclatures = nomenclaturesQuery };
        }
    }
}
