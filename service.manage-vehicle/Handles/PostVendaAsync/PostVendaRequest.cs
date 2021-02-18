using MediatR;
using Microsoft.AspNetCore.Mvc;
using service.manage_vehicle.DTO;

namespace service.manage_vehicle.Handles
{
    public class PostVendaRequest : IRequest<ObjectResult>
    {
        public VendaDTO VendaDTO { get; set; }
    }
}
