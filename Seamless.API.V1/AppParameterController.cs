using Seamless.Domain.Commands.AppParameter;
using Seamless.Model.Dtos;
using Seamless.Domain.Queries.AppParameter;
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
    
    public class AppParameterController : ApiV1ControllerBase
    {
        private readonly ILogger<AppParameterController> _logger;

        public AppParameterController(ILogger<AppParameterController> logger, IMediator mediator) : base(mediator)
        {
            _logger = logger;
        }

        /// <summary>
        /// Get AppParameter by id
        /// </summary>
        /// <param name="id">Id of AppParameter</param>
        /// <returns>AppParameter information</returns>
        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(AppParameterDto), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<AppParameterDto>> GetAppParameterAsync(Int64 id)
        {
            return Single(await QueryAsync(new GetAppParameterQuery(id)));
        }

        /// <summary>
        /// Get all AppParameters
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("")]
        [ProducesResponseType(typeof(PagedResults<AppParameterDto>), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<PagedResults<AppParameterDto>>> GetAppParametersAsync([FromQuery] GetAppParametersQuery query)
        {
            return await QueryAsync<PagedResults<AppParameterDto>>(query);
        }

        /// <summary>
        /// Create new AppParameter
        /// </summary>
        /// <param name="command">Info of AppParameter</param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<ActionResult> CreateAppParameterAsync([FromBody] CreateAppParameterCommand command)
        {
            return StatusCode(200, await CommandAsync(command));
        }

        /// <summary>
        /// Create new AppParameter
        /// </summary>
        /// <param name="command">Info of AppParameter</param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult> UpdateAppParameterAsync([FromBody] UpdateAppParameterCommand command)
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
        public async Task<ActionResult<AppParameterDto>> DeleteAppParameterAsync([FromBody] DeleteAppParameterCommand command)
        {
            return StatusCode(204, await CommandAsync(command));
        }

    }
}