using AutoMapper;
using domain.manage_vehicle.Entities;
using domain.manage_vehicle.Entity.Venda;

namespace domain.manage_vehicle.Entity
{
    public class VendedorEntity : BaseEntity
    {
        public string Nome { get; set; }
        public int Cpf { get; set; }
        public string Email { get; set; }
        [IgnoreMap]
        public virtual VendaEntity Venda { get; set; }
    }
}
