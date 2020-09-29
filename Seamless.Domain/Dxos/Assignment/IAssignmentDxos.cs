using Seamless.Domain.Commands.Assignment;
using Seamless.Model.Dtos;
using Seamless.Model.Models;
using Seamless.Domain.Dxos.Common;

namespace Seamless.Domain.Dxos
{
    public interface IAssignmentDxos : IBaseDxos
    {
        AssignmentDto MapAssignmentDto(SAssignment assignment);
        SAssignment MapCreateRequesttoAssignment(CreateAssignmentCommand assignment);
        SAssignment MapUpdateRequesttoAssignment(UpdateAssignmentCommand assignment);
    }
}
