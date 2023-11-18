using MediatR;

namespace DatabaseAccess.Application.Products.Queries.GetProductsList
{
    public class GetProductsListQuery : IRequest<ProductsListVm>
    {
        public Guid NomenclatureId { get; set; }
    }
}
