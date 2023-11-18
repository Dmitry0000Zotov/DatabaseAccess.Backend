using AutoMapper;
using DatabaseAccess.Application.Common.Mappings;
using DatabaseAccess.Domain;

namespace DatabaseAccess.Application.Nomenclatures.Queries.GetNomenclaturesList
{
    public class GetNomenclaturesList : IMapWith<Nomenclature>
    {
        public Guid NomenclatureId { get; set; }
        public string NomenclatureName { get; set; }
        public string CountType { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Nomenclature, GetNomenclaturesList>()
                .ForMember(nomenclatureList => nomenclatureList.NomenclatureId, opt => opt.MapFrom(nomenclature => nomenclature.NomenclatureId))
                .ForMember(nomenclatureList => nomenclatureList.NomenclatureName, opt => opt.MapFrom(nomenclature => nomenclature.NomenclatureName))
                .ForMember(nomenclatureList => nomenclatureList.CountType, opt => opt.MapFrom(nomenclature => nomenclature.CountType));
        }
    }
}
