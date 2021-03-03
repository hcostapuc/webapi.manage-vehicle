using System;

namespace service.manage_vehicle.DTO
{
    public class VendedorDTO
    {
        public Guid Codigo { get; set; }
        public string Nome { get; set; }
        public int Cpf { get; set; }
        public string Email { get; set; }
    }
}
