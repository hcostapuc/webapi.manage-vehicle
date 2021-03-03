using AutoMapper;
using domain.manage_vehicle.Entity.Venda;
using infrastructure.manage_vehicle.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using service.manage_vehicle.DTO;
using service.manage_vehicle.Handles;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace service.manage_vehicle.Services
{
    public class GetVendaByIdHandler : IRequestHandler<GetVendaByIdRequest, ObjectResult>
    {
        private readonly IVendaRepository vendaRepository;
        private readonly IMapper mapper;
        public GetVendaByIdHandler(IVendaRepository vendaRepository, IMapper mapper)
        {
            this.vendaRepository = vendaRepository ?? throw new ArgumentNullException(nameof(vendaRepository));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<ObjectResult> Handle(GetVendaByIdRequest request, CancellationToken cancellationToken)
        {
            var id = request.Codigo;

            var venda = await vendaRepository.GetIncludeAllAsync(id);
            if (venda == null)
                return new NotFoundObjectResult(venda);
            else
            {
                var vendaDTO = mapper.Map<VendaEntity, VendaDTO>(venda);
                return new OkObjectResult(vendaDTO);
            }
        }

    }
}
