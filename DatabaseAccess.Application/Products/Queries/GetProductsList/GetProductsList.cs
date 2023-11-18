using AutoMapper;
using DatabaseAccess.Application.Common.Mappings;
using DatabaseAccess.Domain;


namespace DatabaseAccess.Application.Products.Queries.GetProductsList
{
    public class GetProductsList
        : IMapWith<Product>
    {
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
        public string? Status { get; set; }
        public string? Code { get; set; }
        public decimal? PalletNumber { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Product, GetProductsList>()
                .ForMember(productsList => productsList.ProductId, opt => opt.MapFrom(product => product.ProductId))
                .ForMember(productsList => productsList.ProductName, opt => opt.MapFrom(product => product.ProductName))
                .ForMember(productsList => productsList.Status, opt => opt.MapFrom(product => product.Status))
                .ForMember(productsList => productsList.Code, opt => opt.MapFrom(product => product.Code))
                .ForMember(productsList => productsList.PalletNumber, opt => opt.MapFrom(product => product.PalletNumber))
                .ForMember(productsList => productsList.DateFrom, opt => opt.MapFrom(product => product.DateFrom))
                .ForMember(productsList => productsList.DateTo, opt => opt.MapFrom(product => product.DateTo));
        }
    }
}
