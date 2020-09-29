using Seamless.Domain.Commands.Note;
using Seamless.Model.Dtos;
using Seamless.Domain.Queries.Note;
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
    
    public class NoteController : ApiV1ControllerBase
    {
        private readonly ILogger<NoteController> _logger;

        public NoteController(ILogger<NoteController> logger, IMediator mediator) : base(mediator)
        {
            _logger = logger;
        }

        /// <summary>
        /// Get Note by id
        /// </summary>
        /// <param name="id">Id of Note</param>
        /// <returns>Note information</returns>
        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(NoteDto), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<NoteDto>> GetNoteAsync(Int64 id)
        {
            return Single(await QueryAsync(new GetNoteQuery(id)));
        }

        /// <summary>
        /// Get all Notes
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("")]
        [ProducesResponseType(typeof(PagedResults<NoteDto>), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<PagedResults<NoteDto>>> GetNotesAsync([FromQuery] GetNotesQuery query)
        {
            return await QueryAsync<PagedResults<NoteDto>>(query);
        }

        /// <summary>
        /// Create new Note
        /// </summary>
        /// <param name="command">Info of Note</param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<ActionResult> CreateNoteAsync([FromBody] CreateNoteCommand command)
        {
            return StatusCode(200, await CommandAsync(command));
        }

        /// <summary>
        /// Create new Note
        /// </summary>
        /// <param name="command">Info of Note</param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult> UpdateNoteAsync([FromBody] UpdateNoteCommand command)
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
        public async Task<ActionResult<NoteDto>> DeleteNoteAsync([FromBody] DeleteNoteCommand command)
        {
            return StatusCode(204, await CommandAsync(command));
        }

    }
}