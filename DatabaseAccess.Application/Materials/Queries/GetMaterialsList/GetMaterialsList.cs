using AutoMapper;
using DatabaseAccess.Application.Common.Mappings;
using DatabaseAccess.Domain;

namespace DatabaseAccess.Application.Materials.Queries.GetMaterialsList
{
    public class GetMaterialsList : IMapWith<Material>
    {
        public Guid MaterialId { get; set; }

        public Guid NomenclatureId { get; set; }

        public decimal Amount { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Material, GetMaterialsList>()
                .ForMember(materialsList => materialsList.MaterialId, opt => opt.MapFrom(material => material.MaterialId))
                .ForMember(materialsList => materialsList.NomenclatureId, opt => opt.MapFrom(material => material.NomenclatureId))
                .ForMember(materialsList => materialsList.Amount, opt => opt.MapFrom(material => material.Amount));
        }
    }
}
