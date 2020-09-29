using Seamless.Domain.Commands.Category;
using Seamless.Model.Dtos;
using Seamless.Domain.Queries.Category;
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
    
    public class CategoryController : ApiV1ControllerBase
    {
        private readonly ILogger<CategoryController> _logger;

        public CategoryController(ILogger<CategoryController> logger, IMediator mediator) : base(mediator)
        {
            _logger = logger;
        }

        /// <summary>
        /// Get Category by id
        /// </summary>
        /// <param name="id">Id of Category</param>
        /// <returns>Category information</returns>
        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(CategoryDto), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<CategoryDto>> GetCategoryAsync(Int64 id)
        {
            return Single(await QueryAsync(new GetCategoryQuery(id)));
        }

        /// <summary>
        /// Get all Categorys
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("")]
        [ProducesResponseType(typeof(PagedResults<CategoryDto>), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<PagedResults<CategoryDto>>> GetCategorysAsync([FromQuery] GetCategoriesQuery query)
        {
            return await QueryAsync<PagedResults<CategoryDto>>(query);
        }

        /// <summary>
        /// Create new Category
        /// </summary>
        /// <param name="command">Info of Category</param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<ActionResult> CreateCategoryAsync([FromBody] CreateCategoryCommand command)
        {
            return StatusCode(200, await CommandAsync(command));
        }

        /// <summary>
        /// Create new Category
        /// </summary>
        /// <param name="command">Info of Category</param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult> UpdateCategoryAsync([FromBody] UpdateCategoryCommand command)
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
        public async Task<ActionResult<CategoryDto>> DeleteCategoryAsync([FromBody] DeleteCategoryCommand command)
        {
            return StatusCode(204, await CommandAsync(command));
        }

    }
}