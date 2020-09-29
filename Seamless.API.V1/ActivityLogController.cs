using Seamless.Domain.Commands.ActivityLog;
using Seamless.Model.Dtos;
using Seamless.Domain.Queries.ActivityLog;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Seamless.API.V1.Controllers
{
    [AllowAnonymous]

    public class ActivityLogController : ApiV1ControllerBase
    {
        private readonly ILogger<ActivityLogController> _logger;

        public ActivityLogController(ILogger<ActivityLogController> logger, IMediator mediator) : base(mediator)
        {
            _logger = logger;
        }

        /// <summary>
        /// Get ActivityLog by id
        /// </summary>
        /// <param name="id">Id of ActivityLog</param>
        /// <returns>ActivityLog information</returns>
        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(ActivityLogDto), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<ActivityLogDto>> GetActivityLogAsync(Int64 id)
        {
            return Single(await QueryAsync(new GetActivityLogQuery(id)));
        }

        /// <summary>
        /// Get all ActivityLogs
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("")]
        [ProducesResponseType(typeof(PagedResults<ActivityLogDto>), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<PagedResults<ActivityLogDto>>> GetActivityLogsAsync([FromQuery] GetActivityLogsQuery query)
        {
            return await QueryAsync<PagedResults<ActivityLogDto>>(query);
        }

        /// <summary>
        /// Create new ActivityLog
        /// </summary>
        /// <param name="command">Info of ActivityLog</param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<ActionResult> CreateActivityLogAsync([FromBody] CreateActivityLogCommand command)
        {
            return StatusCode(200, await CommandAsync(command));
        }

        /// <summary>
        /// Create new ActivityLog
        /// </summary>
        /// <param name="command">Info of ActivityLog</param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult> UpdateActivityLogAsync([FromBody] UpdateActivityLogCommand command)
        {
            return Ok(await CommandAsync(command));
        }


        /// <summary>
        /// Delete an employee with an id 
        /// </summary>
        /// <param name="command">The delete model</param>
        /// <returns></returns>
        [HttpDelete]
        [ProducesResponseType(typeof(DeleteResult), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<ActivityLogDto>> DeleteActivityLogAsync([FromBody] DeleteActivityLogCommand command)
        {
            return StatusCode(204, await CommandAsync(command));
        }

    }
}