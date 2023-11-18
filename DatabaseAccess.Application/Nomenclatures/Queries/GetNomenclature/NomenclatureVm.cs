using AutoMapper;
using DatabaseAccess.Application.Common.Mappings;
using DatabaseAccess.Domain;

namespace DatabaseAccess.Application.Nomenclatures.Queries.GetNomenclature
{
    public class NomenclatureVm : IMapWith<Nomenclature>
    {
        public string NomenclatureName { get; set; }

        public string CountType { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Nomenclature, NomenclatureVm>()
                .ForMember(nomenclatureVm => nomenclatureVm.NomenclatureName, opt => opt.MapFrom(nomenclature => nomenclature.NomenclatureName))
                .ForMember(nomenclatureVm => nomenclatureVm.CountType, opt => opt.MapFrom(nomenclature => nomenclature.CountType));
        }
    }
}
