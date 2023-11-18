using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccess.Application.Materials.Queries.GetMaterial
{
    public class GetMaterialQueryValidator : AbstractValidator<GetMaterialQuery>
    {
        public GetMaterialQueryValidator()
        {
            RuleFor(getMaterialQuery => getMaterialQuery.MaterialId).NotEqual(Guid.Empty);
        }
    }
}
