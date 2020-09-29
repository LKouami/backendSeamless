using Seamless.Domain.Commands.Priority;
using Seamless.Model.Dtos;
using Seamless.Domain.Queries.Priority;
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
    
    public class PriorityController : ApiV1ControllerBase
    {
        private readonly ILogger<PriorityController> _logger;

        public PriorityController(ILogger<PriorityController> logger, IMediator mediator) : base(mediator)
        {
            _logger = logger;
        }

        /// <summary>
        /// Get Priority by id
        /// </summary>
        /// <param name="id">Id of Priority</param>
        /// <returns>Priority information</returns>
        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(PriorityDto), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<PriorityDto>> GetPriorityAsync(Int64 id)
        {
            return Single(await QueryAsync(new GetPriorityQuery(id)));
        }

        /// <summary>
        /// Get all Prioritys
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("")]
        [ProducesResponseType(typeof(PagedResults<PriorityDto>), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<PagedResults<PriorityDto>>> GetPrioritysAsync([FromQuery] GetPrioritiesQuery query)
        {
            return await QueryAsync<PagedResults<PriorityDto>>(query);
        }

        /// <summary>
        /// Create new Priority
        /// </summary>
        /// <param name="command">Info of Priority</param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<ActionResult> CreatePriorityAsync([FromBody] CreatePriorityCommand command)
        {
            return StatusCode(200, await CommandAsync(command));
        }

        /// <summary>
        /// Create new Priority
        /// </summary>
        /// <param name="command">Info of Priority</param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult> UpdatePriorityAsync([FromBody] UpdatePriorityCommand command)
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
        public async Task<ActionResult<PriorityDto>> DeletePriorityAsync([FromBody] DeletePriorityCommand command)
        {
            return StatusCode(204, await CommandAsync(command));
        }

    }
}