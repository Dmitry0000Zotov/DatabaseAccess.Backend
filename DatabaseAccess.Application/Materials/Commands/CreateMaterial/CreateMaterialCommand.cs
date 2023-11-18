using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccess.Application.Materials.Commands.CreateMaterial
{
    public class CreateMaterialCommand : IRequest<Guid>
    {
        public Guid NomenclatureId { get; set; }
        public decimal Amount { get; set; }
    }
}
