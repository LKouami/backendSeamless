using Seamless.Domain.Commands.Message;
using Seamless.Model.Dtos;
using Seamless.Domain.Queries.Message;
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
    
    public class MessageController : ApiV1ControllerBase
    {
        private readonly ILogger<MessageController> _logger;

        public MessageController(ILogger<MessageController> logger, IMediator mediator) : base(mediator)
        {
            _logger = logger;
        }

        /// <summary>
        /// Get Message by id
        /// </summary>
        /// <param name="id">Id of Message</param>
        /// <returns>Message information</returns>
        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(MessageDto), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<MessageDto>> GetMessageAsync(Int64 id)
        {
            return Single(await QueryAsync(new GetMessageQuery(id)));
        }

        /// <summary>
        /// Get all Messages
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("")]
        [ProducesResponseType(typeof(PagedResults<MessageDto>), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<PagedResults<MessageDto>>> GetMessagesAsync([FromQuery] GetMessagesQuery query)
        {
            return await QueryAsync<PagedResults<MessageDto>>(query);
        }

        /// <summary>
        /// Create new Message
        /// </summary>
        /// <param name="command">Info of Message</param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<ActionResult> CreateMessageAsync([FromBody] CreateMessageCommand command)
        {
            return StatusCode(200, await CommandAsync(command));
        }

        /// <summary>
        /// Create new Message
        /// </summary>
        /// <param name="command">Info of Message</param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult> UpdateMessageAsync([FromBody] UpdateMessageCommand command)
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
        public async Task<ActionResult<MessageDto>> DeleteMessageAsync([FromBody] DeleteMessageCommand command)
        {
            return StatusCode(204, await CommandAsync(command));
        }

    }
}