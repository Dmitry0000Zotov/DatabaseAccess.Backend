using MediatR;

namespace DatabaseAccess.Application.Materials.Commands.DeleteMaterial
{
    public class DeleteMaterialCommand : IRequest
    {
        public Guid MaterialId { get; set; }
    }
}
