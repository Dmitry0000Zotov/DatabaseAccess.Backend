using AutoMapper;
using DatabaseAccess.Application.Common.Mappings;
using DatabaseAccess.Application.Products.Commands.CreateProduct;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccess.WebApi.Models
{
    public class CreateProductDto : IMapWith<CreateProductCommand>
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
            profile.CreateMap<CreateProductDto, CreateProductCommand>()
                .ForMember(productCommand => productCommand.NomenclatureId, opt => opt.MapFrom(productDto => productDto.NomenclatureId))
                .ForMember(productCommand => productCommand.SpecificationId, opt => opt.MapFrom(productDto => productDto.SpecificationId))
                .ForMember(productCommand => productCommand.ProductName, opt => opt.MapFrom(productDto => productDto.ProductName))
                .ForMember(productCommand => productCommand.Status, opt => opt.MapFrom(productDto => productDto.Status))
                .ForMember(productCommand => productCommand.Code, opt => opt.MapFrom(productDto => productDto.Code))
                .ForMember(productCommand => productCommand.PalletNumber, opt => opt.MapFrom(productDto => productDto.PalletNumber))
                .ForMember(productCommand => productCommand.DateFrom, opt => opt.MapFrom(productDto => productDto.DateFrom))
                .ForMember(productCommand => productCommand.DateTo, opt => opt.MapFrom(productDto => productDto.DateTo));
        }
    }
}
