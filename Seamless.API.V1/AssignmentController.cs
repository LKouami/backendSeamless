using Seamless.Domain.Commands.Assignment;
using Seamless.Model.Dtos;
using Seamless.Domain.Queries.Assignment;
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
    
    public class AssignmentController : ApiV1ControllerBase
    {
        private readonly ILogger<AssignmentController> _logger;

        public AssignmentController(ILogger<AssignmentController> logger, IMediator mediator) : base(mediator)
        {
            _logger = logger;
        }

        /// <summary>
        /// Get Assignment by id
        /// </summary>
        /// <param name="id">Id of Assignment</param>
        /// <returns>Assignment information</returns>
        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(AssignmentDto), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<AssignmentDto>> GetAssignmentAsync(Int64 id)
        {
            return Single(await QueryAsync(new GetAssignmentQuery(id)));
        }

        /// <summary>
        /// Get all Assignments
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("")]
        [ProducesResponseType(typeof(PagedResults<AssignmentDto>), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<PagedResults<AssignmentDto>>> GetAssignmentsAsync([FromQuery] GetAssignmentsQuery query)
        {
            return await QueryAsync<PagedResults<AssignmentDto>>(query);
        }

        /// <summary>
        /// Create new Assignment
        /// </summary>
        /// <param name="command">Info of Assignment</param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<ActionResult> CreateAssignmentAsync([FromBody] CreateAssignmentCommand command)
        {
            return StatusCode(200, await CommandAsync(command));
        }

        /// <summary>
        /// Create new Assignment
        /// </summary>
        /// <param name="command">Info of Assignment</param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult> UpdateAssignmentAsync([FromBody] UpdateAssignmentCommand command)
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
        public async Task<ActionResult<AssignmentDto>> DeleteAssignmentAsync([FromBody] DeleteAssignmentCommand command)
        {
            return StatusCode(204, await CommandAsync(command));
        }

    }
}