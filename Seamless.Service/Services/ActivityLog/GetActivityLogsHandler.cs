using Seamless.Data.IRepositories;
using Seamless.Model.Dtos;
using Seamless.Domain.Queries.ActivityLog;
using Seamless.Domain.Dxos;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Seamless.Service.Services
{
    public class GetActivityLogsHandler : IRequestHandler<GetActivityLogsQuery, PagedResults<ActivityLogDto>>
    {
        private readonly IActivityLogRepository _bankRepository;
        private readonly ILogger _logger;

        public GetActivityLogsHandler(IActivityLogRepository bankRepository, IActivityLogDxos bankDxos,
            ILogger<GetActivityLogsHandler> logger)
        {
            _bankRepository = bankRepository ?? throw new ArgumentNullException(nameof(bankRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<PagedResults<ActivityLogDto>> Handle(GetActivityLogsQuery request, CancellationToken cancellationToken)
        {
            if (String.IsNullOrWhiteSpace(request.Search))
            {
                return await _bankRepository.GetListPageAsync(request, null);
            }
            else
            {
                return await _bankRepository.GetListPageAsync(request,
               p =>
                   p.Action.ToLower().StartsWith(request.Search) ||
                   p.Libelle.ToLower().StartsWith(request.Search));
            }

        }
    }
}