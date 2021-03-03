using System;

namespace service.manage_vehicle.DTO
{
    public class VeiculoDTO
    {
        public Guid Codigo { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int AnoFabricacao { get; set; }
    }
}
