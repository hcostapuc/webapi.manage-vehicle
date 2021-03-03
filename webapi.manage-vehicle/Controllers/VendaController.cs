using MediatR;
using Microsoft.AspNetCore.Mvc;
using service.manage_vehicle.DTO;
using service.manage_vehicle.Handles;
using System;
using System.Threading.Tasks;

namespace webapi.manage_vehicle.Controllers
{
    [Route("api/venda")]
    [ApiController]
    public class VendaController : ControllerBase
    {
        private readonly IMediator mediator;

        public VendaController(IMediator mediator) =>
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(Guid id) =>
            await mediator.Send(new GetVendaByIdRequest { Codigo = id });

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] VendaDTO vendaDTO) =>
            await mediator.Send(new PostVendaRequest { VendaDTO = vendaDTO });

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] VendaDTO vendaDTO) =>
            await mediator.Send(new PutVendaRequest { Codigo = id, VendaDTO = vendaDTO });

    }
}
