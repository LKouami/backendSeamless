using Seamless.Domain.Commands.TicketStatus;
using Seamless.Model.Dtos;
using Seamless.Domain.Queries.TicketStatus;
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
    
    public class TicketStatusController : ApiV1ControllerBase
    {
        private readonly ILogger<TicketStatusController> _logger;

        public TicketStatusController(ILogger<TicketStatusController> logger, IMediator mediator) : base(mediator)
        {
            _logger = logger;
        }

        /// <summary>
        /// Get TicketStatus by id
        /// </summary>
        /// <param name="id">Id of TicketStatus</param>
        /// <returns>TicketStatus information</returns>
        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(TicketStatusDto), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<TicketStatusDto>> GetTicketStatusAsync(Int64 id)
        {
            return Single(await QueryAsync(new GetTicketStatusQuery(id)));
        }

        /// <summary>
        /// Get all TicketStatuss
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("")]
        [ProducesResponseType(typeof(PagedResults<TicketStatusDto>), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<PagedResults<TicketStatusDto>>> GetTicketStatussAsync([FromQuery] GetTicketStatusesQuery query)
        {
            return await QueryAsync<PagedResults<TicketStatusDto>>(query);
        }

        /// <summary>
        /// Create new TicketStatus
        /// </summary>
        /// <param name="command">Info of TicketStatus</param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<ActionResult> CreateTicketStatusAsync([FromBody] CreateTicketStatusCommand command)
        {
            return StatusCode(200, await CommandAsync(command));
        }

        /// <summary>
        /// Create new TicketStatus
        /// </summary>
        /// <param name="command">Info of TicketStatus</param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult> UpdateTicketStatusAsync([FromBody] UpdateTicketStatusCommand command)
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
        public async Task<ActionResult<TicketStatusDto>> DeleteTicketStatusAsync([FromBody] DeleteTicketStatusCommand command)
        {
            return StatusCode(204, await CommandAsync(command));
        }

    }
}