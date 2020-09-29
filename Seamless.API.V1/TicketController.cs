using Seamless.Domain.Commands.Ticket;
using Seamless.Model.Dtos;
using Seamless.Domain.Queries.Ticket;
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
    
    public class TicketController : ApiV1ControllerBase
    {
        private readonly ILogger<TicketController> _logger;

        public TicketController(ILogger<TicketController> logger, IMediator mediator) : base(mediator)
        {
            _logger = logger;
        }

        /// <summary>
        /// Get Ticket by id
        /// </summary>
        /// <param name="id">Id of Ticket</param>
        /// <returns>Ticket information</returns>
        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(TicketDto), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<TicketDto>> GetTicketAsync(Int64 id)
        {
            return Single(await QueryAsync(new GetTicketQuery(id)));
        }

        /// <summary>
        /// Get all Tickets
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("")]
        [ProducesResponseType(typeof(PagedResults<TicketDto>), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<PagedResults<TicketDto>>> GetTicketsAsync([FromQuery] GetTicketsQuery query)
        {
            return await QueryAsync<PagedResults<TicketDto>>(query);
        }

        /// <summary>
        /// Create new Ticket
        /// </summary>
        /// <param name="command">Info of Ticket</param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<ActionResult> CreateTicketAsync([FromBody] CreateTicketCommand command)
        {
            return StatusCode(200, await CommandAsync(command));
        }

        /// <summary>
        /// Create new Ticket
        /// </summary>
        /// <param name="command">Info of Ticket</param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult> UpdateTicketAsync([FromBody] UpdateTicketCommand command)
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
        public async Task<ActionResult<TicketDto>> DeleteTicketAsync([FromBody] DeleteTicketCommand command)
        {
            return StatusCode(204, await CommandAsync(command));
        }

    }
}