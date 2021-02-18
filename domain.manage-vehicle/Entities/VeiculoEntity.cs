using AutoMapper;
using domain.manage_vehicle.Entities;
using domain.manage_vehicle.Entity.Venda;
using System.ComponentModel.DataAnnotations.Schema;

namespace domain.manage_vehicle.Entity
{
    public class VeiculoEntity : BaseEntity
    {
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int AnoFabricacao { get; set; }
        [IgnoreMap]
        public virtual VendaEntity Venda { get; set; }
    }
}
