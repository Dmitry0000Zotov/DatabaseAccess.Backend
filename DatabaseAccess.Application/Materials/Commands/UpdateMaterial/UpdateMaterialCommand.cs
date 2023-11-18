using MediatR;

namespace DatabaseAccess.Application.Materials.Commands.UpdateMaterial
{
    public class UpdateMaterialCommand : IRequest
    {
        public Guid MaterialId { get; set; }
        public decimal Amount { get; set; }
    }
}
