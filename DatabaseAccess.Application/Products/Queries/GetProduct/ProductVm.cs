using DatabaseAccess.Application.Common.Mappings;
using DatabaseAccess.Domain;
using AutoMapper;

namespace DatabaseAccess.Application.Products.Queries.GetProduct
{
    public class ProductVm : IMapWith<Product>
    {
        public Guid NomenclatureId { get; set; }
        public Guid SpecificationId { get; set; }
        public string ProductName { get; set; }
        public string? Status { get; set; }
        public string? Code { get; set; }
        public decimal? PalletNumber { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Product, ProductVm>()
                .ForMember(productVm => productVm.NomenclatureId, opt => opt.MapFrom(product => product.NomenclatureId))
                .ForMember(productVm => productVm.SpecificationId, opt => opt.MapFrom(product => product.SpecificationId))
                .ForMember(productVm => productVm.ProductName, opt => opt.MapFrom(product => product.ProductName))
                .ForMember(productVm => productVm.Status, opt => opt.MapFrom(product => product.Status))
                .ForMember(productVm => productVm.Code, opt => opt.MapFrom(product => product.Code))
                .ForMember(productVm => productVm.PalletNumber, opt => opt.MapFrom(product => product.PalletNumber))
                .ForMember(productVm => productVm.DateFrom, opt => opt.MapFrom(product => product.DateFrom))
                .ForMember(productVm => productVm.DateTo, opt => opt.MapFrom(product => product.DateTo));
        }
    }
}
