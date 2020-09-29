using Seamless.Domain.Commands.Permission;
using Seamless.Model.Dtos;
using Seamless.Domain.Queries.Permission;
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
    
    public class PermissionController : ApiV1ControllerBase
    {
        private readonly ILogger<PermissionController> _logger;

        public PermissionController(ILogger<PermissionController> logger, IMediator mediator) : base(mediator)
        {
            _logger = logger;
        }

        /// <summary>
        /// Get Permission by id
        /// </summary>
        /// <param name="id">Id of Permission</param>
        /// <returns>Permission information</returns>
        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(PermissionDto), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<PermissionDto>> GetPermissionAsync(Int64 id)
        {
            return Single(await QueryAsync(new GetPermissionQuery(id)));
        }

        /// <summary>
        /// Get all Permissions
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("")]
        [ProducesResponseType(typeof(PagedResults<PermissionDto>), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<PagedResults<PermissionDto>>> GetPermissionsAsync([FromQuery] GetPermissionsQuery query)
        {
            return await QueryAsync<PagedResults<PermissionDto>>(query);
        }

        /// <summary>
        /// Create new Permission
        /// </summary>
        /// <param name="command">Info of Permission</param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<ActionResult> CreatePermissionAsync([FromBody] CreatePermissionCommand command)
        {
            return StatusCode(200, await CommandAsync(command));
        }

        /// <summary>
        /// Create new Permission
        /// </summary>
        /// <param name="command">Info of Permission</param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult> UpdatePermissionAsync([FromBody] UpdatePermissionCommand command)
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
        public async Task<ActionResult<PermissionDto>> DeletePermissionAsync([FromBody] DeletePermissionCommand command)
        {
            return StatusCode(204, await CommandAsync(command));
        }

    }
}