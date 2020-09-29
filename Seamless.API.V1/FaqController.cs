using Seamless.Domain.Commands.Faq;
using Seamless.Model.Dtos;
using Seamless.Domain.Queries.Faq;
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
    
    public class FaqController : ApiV1ControllerBase
    {
        private readonly ILogger<FaqController> _logger;

        public FaqController(ILogger<FaqController> logger, IMediator mediator) : base(mediator)
        {
            _logger = logger;
        }

        /// <summary>
        /// Get Faq by id
        /// </summary>
        /// <param name="id">Id of Faq</param>
        /// <returns>Faq information</returns>
        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(FaqDto), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<FaqDto>> GetFaqAsync(Int64 id)
        {
            return Single(await QueryAsync(new GetFaqQuery(id)));
        }

        /// <summary>
        /// Get all Faqs
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("")]
        [ProducesResponseType(typeof(PagedResults<FaqDto>), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<PagedResults<FaqDto>>> GetFaqsAsync([FromQuery] GetFaqsQuery query)
        {
            return await QueryAsync<PagedResults<FaqDto>>(query);
        }

        /// <summary>
        /// Create new Faq
        /// </summary>
        /// <param name="command">Info of Faq</param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<ActionResult> CreateFaqAsync([FromBody] CreateFaqCommand command)
        {
            return StatusCode(200, await CommandAsync(command));
        }

        /// <summary>
        /// Create new Faq
        /// </summary>
        /// <param name="command">Info of Faq</param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult> UpdateFaqAsync([FromBody] UpdateFaqCommand command)
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
        public async Task<ActionResult<FaqDto>> DeleteFaqAsync([FromBody] DeleteFaqCommand command)
        {
            return StatusCode(204, await CommandAsync(command));
        }

    }
}