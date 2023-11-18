using AutoMapper;
using DatabaseAccess.Application.Common.Exeptions;
using DatabaseAccess.Application.Interfaces;
using DatabaseAccess.Application.Products.Queries.GetProduct;
using DatabaseAccess.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace DatabaseAccess.Application.Nomenclatures.Queries.GetNomenclature
{
    public class GetNomenclatureQueryHandler : IRequestHandler<GetNomenclatureQuery, NomenclatureVm>
    {
        private readonly IApiDbContext _context;
        private readonly IMapper _mapper;

        public GetNomenclatureQueryHandler(IApiDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<NomenclatureVm> Handle(GetNomenclatureQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.Nomenclatures.FirstOrDefaultAsync(nomenclature => nomenclature.NomenclatureId == request.NomenclatureId, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Nomenclature), request.NomenclatureId);
            }

            return _mapper.Map<NomenclatureVm>(entity);
        }
    }
}
