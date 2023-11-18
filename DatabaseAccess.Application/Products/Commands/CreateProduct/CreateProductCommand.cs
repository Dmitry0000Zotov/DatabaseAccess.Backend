using MediatR;
using System.ComponentModel.DataAnnotations.Schema;

namespace DatabaseAccess.Application.Products.Commands.CreateProduct
{
    public class CreateProductCommand : IRequest<Guid>
    {
        public Guid NomenclatureId { get; set; }
        public Guid SpecificationId { get; set; }
        public string ProductName { get; set; }
        public string? Status { get; set; }
        public string? Code { get; set; }
        public decimal? PalletNumber { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
    }
}
