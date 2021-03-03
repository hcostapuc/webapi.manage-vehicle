using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;

namespace service.manage_vehicle.Handles
{
    public class GetVendaByIdRequest : IRequest<ObjectResult>
    {
        public Guid Codigo { get; set; }
    }
}
