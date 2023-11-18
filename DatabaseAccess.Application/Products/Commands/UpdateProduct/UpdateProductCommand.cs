using MediatR;

namespace DatabaseAccess.Application.Products.Commands.UpdateProduct
{
    public class UpdateProductCommand : IRequest
    {
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
        public string Status { get; set; }
        public string Code { get; set; }
        public int PalletNumber { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
    }
}
