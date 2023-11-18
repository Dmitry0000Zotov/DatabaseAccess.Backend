using FluentValidation;

namespace DatabaseAccess.Application.Materials.Commands.CreateMaterial
{
    public class CreateMaterialCommandValidator : AbstractValidator<CreateMaterialCommand>
    {
        public CreateMaterialCommandValidator()
        {
            RuleFor(createMaterialCommand => createMaterialCommand.NomenclatureId).NotEqual(Guid.Empty);
        }
    }
}
