using MediatR;

namespace DatabaseAccess.Application.Products.Queries.GetProduct
{
    public class GetProductQuery : IRequest<ProductVm>
    {
        public Guid ProductId { get; set; }
    }
}
