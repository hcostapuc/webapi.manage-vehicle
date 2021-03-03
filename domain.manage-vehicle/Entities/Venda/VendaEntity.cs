using domain.manage_vehicle.Entities;
using System;
using System.Collections.Generic;

namespace domain.manage_vehicle.Entity.Venda
{
    public class VendaEntity : BaseEntity
    {
        public StatusVenda Status { get; set; }
        public DateTime Data { get; set; }
        public virtual VendedorEntity Vendedor { get; set; }
        public virtual IEnumerable<VeiculoEntity> Veiculos { get; set; }
    }
}
