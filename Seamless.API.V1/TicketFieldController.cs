using Seamless.Domain.Commands.TicketField;
using Seamless.Model.Dtos;
using Seamless.Domain.Queries.TicketField;
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
    
    public class TicketFieldController : ApiV1ControllerBase
    {
        private readonly ILogger<TicketFieldController> _logger;

        public TicketFieldController(ILogger<TicketFieldController> logger, IMediator mediator) : base(mediator)
        {
            _logger = logger;
        }

        /// <summary>
        /// Get TicketField by id
        /// </summary>
        /// <param name="id">Id of TicketField</param>
        /// <returns>TicketField information</returns>
        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(TicketFieldDto), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<TicketFieldDto>> GetTicketFieldAsync(Int64 id)
        {
            return Single(await QueryAsync(new GetTicketFieldQuery(id)));
        }

        /// <summary>
        /// Get all TicketFields
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("")]
        [ProducesResponseType(typeof(PagedResults<TicketFieldDto>), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<PagedResults<TicketFieldDto>>> GetTicketFieldsAsync([FromQuery] GetTicketFieldsQuery query)
        {
            return await QueryAsync<PagedResults<TicketFieldDto>>(query);
        }

        /// <summary>
        /// Create new TicketField
        /// </summary>
        /// <param name="command">Info of TicketField</param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<ActionResult> CreateTicketFieldAsync([FromBody] CreateTicketFieldCommand command)
        {
            return StatusCode(200, await CommandAsync(command));
        }

        /// <summary>
        /// Create new TicketField
        /// </summary>
        /// <param name="command">Info of TicketField</param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult> UpdateTicketFieldAsync([FromBody] UpdateTicketFieldCommand command)
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
        public async Task<ActionResult<TicketFieldDto>> DeleteTicketFieldAsync([FromBody] DeleteTicketFieldCommand command)
        {
            return StatusCode(204, await CommandAsync(command));
        }

    }
}