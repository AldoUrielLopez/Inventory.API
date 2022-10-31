using AutoMapper;
using Inventory.Application.Commands;
using Inventory.Application.Interfaces;
using Inventory.Application.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Inventory.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : Controller
    {

        private readonly IMediator mediator;
        private readonly IMapper mapper;
        private readonly IProductQueries queries;

        public ProductController(IMediator mediator, IMapper mapper, IProductQueries queries)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            this.queries = queries ?? throw new ArgumentNullException(nameof(queries));
        }

        #region POST
        /// <summary>
        /// Da de alta un producto
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(ProductQuery), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> PostProduct([FromBody] CreateProductCommand command)
        {
            if (command == null) return this.UnprocessableEntity();

            var commandResult = await this.mediator.Send(command);

            return this.Ok(commandResult);
            
        }
        #endregion

        #region PUT
        /// <summary>
        /// Ejecuta la venta de un solo producto poniendo la cantidad a restar del inventario
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> PutChangeStock([FromBody] UpdateQuantityCommand command)
        {
            if (command == null) return this.UnprocessableEntity();

            var commandResult = await this.mediator.Send(command);

            return this.Ok(commandResult);
        }
        #endregion 

        #region GET
        /// <summary>
        /// Obtiene todos los prouctos
        /// </summary>
        /// <returns></returns>
        [HttpGet("")]
        public IActionResult GetAll()
        {
            var result = this.queries.GetAll();

            if (result != null && result.Count() > 0)
                return this.Ok(result);
            else
                return this.NotFound();
        }

        [HttpGet("{name}")]
        public IActionResult GetByName(string name)
        {
            var result = this.queries.GetByName(name);

            if (result != null && result.Count() > 0)
                return this.Ok(result);
            else
                return this.NotFound();
        }
        #endregion
    }
}
