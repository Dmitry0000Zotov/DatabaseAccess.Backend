using AutoMapper;
using DatabaseAccess.Application.Common.Exeptions;
using DatabaseAccess.Application.Interfaces;
using DatabaseAccess.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DatabaseAccess.Application.Products.Queries.GetProduct
{
    public class GetProductQueryHandler : IRequestHandler<GetProductQuery, ProductVm>
    {
        private readonly IApiDbContext _context;
        private readonly IMapper _mapper;

        public GetProductQueryHandler(IApiDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ProductVm> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.Products.FirstOrDefaultAsync(product => product.ProductId == request.ProductId, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Product), request.ProductId);
            }

            return _mapper.Map<ProductVm>(entity);
        }
    }
}
