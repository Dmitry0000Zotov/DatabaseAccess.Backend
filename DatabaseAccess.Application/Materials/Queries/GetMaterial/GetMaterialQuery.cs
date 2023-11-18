using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccess.Application.Materials.Queries.GetMaterial
{
    public class GetMaterialQuery : IRequest<MaterialVm>
    {
        public Guid MaterialId { get; set; }
    }
}
