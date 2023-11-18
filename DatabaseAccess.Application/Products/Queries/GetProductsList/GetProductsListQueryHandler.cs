using AutoMapper;
using AutoMapper.QueryableExtensions;
using DatabaseAccess.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccess.Application.Products.Queries.GetProductsList
{
    public class GetProductsListQueryHandler : IRequestHandler<GetProductsListQuery, ProductsListVm>
    {
        private readonly IApiDbContext _context;
        private readonly IMapper _mapper;

        public GetProductsListQueryHandler(IApiDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ProductsListVm> Handle(GetProductsListQuery request, CancellationToken cancellationToken)
        {
            var productsQuery = await _context.Products
                .Where(product => product.NomenclatureId == request.NomenclatureId)
                .ProjectTo<GetProductsList>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new ProductsListVm { Products = productsQuery };
        }
    }
}
