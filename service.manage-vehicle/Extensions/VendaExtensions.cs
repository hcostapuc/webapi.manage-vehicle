using AutoMapper;
using domain.manage_vehicle.Entity.Venda;
using service.manage_vehicle.DTO;
using System;
using System.Linq;
using System.Text;

namespace service.manage_vehicle.Extensions
{
    public static class VendaExtensions
    {
        public static bool MergeFrom(this VendaEntity vendaEntity, VendaEntity vendaNew, out string msg)
        {
            msg = String.Empty;

            if (vendaEntity != null && TryValidStatus(vendaNew.Status,vendaEntity.Status))
            {
                vendaEntity.Veiculos = null;
                vendaEntity.Data = vendaNew.Data;
                vendaEntity.Vendedor = vendaNew.Vendedor;
                vendaEntity.Status = vendaEntity.Status;
                return true;
            }
            else
            {
                msg = "Venda com status inválida ou nula";
                return false;
            }

        }
        private static bool TryValidStatus(StatusVenda statusVendaNew, StatusVenda statusVendaOld)
        {
            if (statusVendaNew != statusVendaOld)
            {
                return statusVendaOld switch
                {
                    StatusVenda.ConfirmacaoPagamento => statusVendaNew == StatusVenda.PagamentoAprovado || statusVendaNew == StatusVenda.Cancelada,
                    StatusVenda.PagamentoAprovado => statusVendaNew == StatusVenda.EmTransporte || statusVendaNew == StatusVenda.Cancelada,
                    StatusVenda.EmTransporte => statusVendaNew == StatusVenda.Entregue,
                    _ => false,
                };
            }
            else
                return true;
        }
        public static bool TryValid(this VendaEntity vendaEntity, out string msg)
        {
            msg = string.Empty;
            var msgBuilder = new StringBuilder();

            if (vendaEntity.Veiculos == null || !vendaEntity.Veiculos.ToList().Any())
                msgBuilder.AppendLine("Venda deve possuir pelo menos um ou mais veículos");

            if (vendaEntity.Vendedor == null)
                msgBuilder.AppendLine("Vendedor é um campo obrigatório!");

            if (msgBuilder.Length == 0)
                return true;
            else
            {
                msg = msgBuilder.ToString();
                return false;
            }
        }
    }
}
