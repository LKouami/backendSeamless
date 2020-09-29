using Seamless.Model.Dtos;

namespace Seamless.Domain.Queries.ActivityLog
{
    public class GetActivityLogsQuery : QueryListBase<PagedResults<ActivityLogDto>>
    {
        public GetActivityLogsQuery() : base()
        {

        }
        public GetActivityLogsQuery(string search, string sort, string direction, int pageIndex, int pageSize) :
            base(search, sort, direction, pageIndex, pageSize)
        {

        }
    }
}