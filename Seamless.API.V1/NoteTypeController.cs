using Seamless.Domain.Commands.NoteType;
using Seamless.Model.Dtos;
using Seamless.Domain.Queries.NoteType;
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
    
    public class NoteTypeController : ApiV1ControllerBase
    {
        private readonly ILogger<NoteTypeController> _logger;

        public NoteTypeController(ILogger<NoteTypeController> logger, IMediator mediator) : base(mediator)
        {
            _logger = logger;
        }

        /// <summary>
        /// Get NoteType by id
        /// </summary>
        /// <param name="id">Id of NoteType</param>
        /// <returns>NoteType information</returns>
        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(NoteTypeDto), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<NoteTypeDto>> GetNoteTypeAsync(Int64 id)
        {
            return Single(await QueryAsync(new GetNoteTypeQuery(id)));
        }

        /// <summary>
        /// Get all NoteTypes
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("")]
        [ProducesResponseType(typeof(PagedResults<NoteTypeDto>), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<PagedResults<NoteTypeDto>>> GetNoteTypesAsync([FromQuery] GetNoteTypesQuery query)
        {
            return await QueryAsync<PagedResults<NoteTypeDto>>(query);
        }

        /// <summary>
        /// Create new NoteType
        /// </summary>
        /// <param name="command">Info of NoteType</param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<ActionResult> CreateNoteTypeAsync([FromBody] CreateNoteTypeCommand command)
        {
            return StatusCode(200, await CommandAsync(command));
        }

        /// <summary>
        /// Create new NoteType
        /// </summary>
        /// <param name="command">Info of NoteType</param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult> UpdateNoteTypeAsync([FromBody] UpdateNoteTypeCommand command)
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
        public async Task<ActionResult<NoteTypeDto>> DeleteNoteTypeAsync([FromBody] DeleteNoteTypeCommand command)
        {
            return StatusCode(204, await CommandAsync(command));
        }

    }
}