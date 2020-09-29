using Seamless.Domain.Commands.ActivityLog;
using Seamless.Model.Dtos;
using Seamless.Model.Models;
using Seamless.Domain.Dxos.Common;

namespace Seamless.Domain.Dxos
{
    public interface IActivityLogDxos : IBaseDxos
    {
        ActivityLogDto MapActivityLogDto(SActivityLog activityLog);
        SActivityLog MapCreateRequesttoActivityLog(CreateActivityLogCommand activityLog);
        SActivityLog MapUpdateRequesttoActivityLog(UpdateActivityLogCommand activityLog);
    }
}
