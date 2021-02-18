using AutoMapper;
using domain.manage_vehicle.Entity.Venda;
using infrastructure.manage_vehicle.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using service.manage_vehicle.DTO;
using service.manage_vehicle.Extensions;
using service.manage_vehicle.Handles;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace service.manage_vehicle.Services
{
    public class PostVendaHandler : IRequestHandler<PostVendaRequest, ObjectResult>
    {
        private readonly IVendaRepository vendaRepository;
        private readonly IMapper mapper;
        public PostVendaHandler(IVendaRepository vendaRepository, IMapper mapper)
        {
            this.vendaRepository = vendaRepository ?? throw new ArgumentNullException(nameof(vendaRepository));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<ObjectResult> Handle(PostVendaRequest request, CancellationToken cancellationToken)
        {
            var venda = mapper.Map<VendaDTO, VendaEntity>(request.VendaDTO);


            if (!venda.TryValid(out string erros)) 
                return new BadRequestObjectResult(erros);

            venda.Status = StatusVenda.ConfirmacaoPagamento;

            await vendaRepository.AddAsync(venda);
            return new OkObjectResult(request.VendaDTO);
        }

    }
}
