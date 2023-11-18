using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccess.Application.Nomenclatures.Queries.GetNomenclature
{
    public class GetNomenclatureQuery : IRequest<NomenclatureVm>
    {
        public Guid NomenclatureId { get; set; }
    }
}
