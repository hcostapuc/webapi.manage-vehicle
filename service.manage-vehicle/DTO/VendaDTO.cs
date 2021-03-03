using domain.manage_vehicle.Entity.Venda;
using System;
using System.Collections.Generic;

namespace service.manage_vehicle.DTO
{
    public class VendaDTO
    {
        public Guid Codigo { get; set; }
        public StatusVenda Status { get; set; }
        public DateTime Data { get; set; }
        public virtual IEnumerable<VeiculoDTO> Veiculos { get; set; }
        public virtual VendedorDTO Vendedor { get; set; }
    }
}
