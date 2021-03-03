using MediatR;
using Microsoft.AspNetCore.Mvc;
using service.manage_vehicle.DTO;
using System;

namespace service.manage_vehicle.Handles
{
    public class PutVendaRequest : IRequest<ObjectResult>
    {
        public VendaDTO VendaDTO { get; set; }
        public Guid Codigo { get; set; }
    }
}
