using AutoMapper;
using DatabaseAccess.Application.Common.Mappings;
using DatabaseAccess.Domain;

namespace DatabaseAccess.Application.Materials.Queries.GetMaterial
{
    public class MaterialVm : IMapWith<Material>
    {
        public Guid NomenclatureId { get; set; }
        public decimal Amount { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Material, MaterialVm>()
                .ForMember(materialVm => materialVm.NomenclatureId, opt => opt.MapFrom(material => material.NomenclatureId))
                .ForMember(materialVm => materialVm.Amount, opt => opt.MapFrom(material => material.Amount));
        }
    }
}
