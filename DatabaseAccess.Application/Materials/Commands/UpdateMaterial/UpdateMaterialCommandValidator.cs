using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccess.Application.Materials.Commands.UpdateMaterial
{
    public class UpdateMaterialCommandValidator : AbstractValidator<UpdateMaterialCommand>
    {
        public UpdateMaterialCommandValidator()
        {
            RuleFor(updateMaterialCommand => updateMaterialCommand.MaterialId).NotEqual(Guid.Empty);
            RuleFor(updateMaterialCommand => updateMaterialCommand.Amount).NotEmpty();
        }
    }
}
