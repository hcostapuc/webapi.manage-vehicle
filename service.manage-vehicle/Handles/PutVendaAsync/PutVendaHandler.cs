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
    public class PutVendaHandler : IRequestHandler<PutVendaRequest, ObjectResult>
    {
        private readonly IVendaRepository vendaRepository;
        private readonly IMapper mapper;
        public PutVendaHandler(IVendaRepository vendaRepository, IMapper mapper)
        {
            this.vendaRepository = vendaRepository ?? throw new ArgumentNullException(nameof(vendaRepository));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        public async Task<ObjectResult> Handle(PutVendaRequest request, CancellationToken cancellationToken)
        {
            var vendaNew = mapper.Map<VendaDTO, VendaEntity>(request.VendaDTO);

            if (!vendaNew.TryValid(out string erros))
                return new BadRequestObjectResult(erros);

            vendaNew.Codigo = request.Codigo;

            var vendaOld = await vendaRepository.GetIncludeAllAsync(vendaNew.Codigo);

            if (vendaOld == null)
                return new NotFoundObjectResult($"Venda de codigo: {vendaNew.Codigo} não encontrada");

            if (!vendaOld.MergeFrom(vendaNew, out string error))
                return new BadRequestObjectResult(error);

            await vendaRepository.UpdateAsync(vendaOld);

            return new OkObjectResult(mapper.Map<VendaEntity, VendaDTO>(vendaOld));
        }
    }
}
