using RastreoPaquetes.Entidades.Pedido.Interfaces;
using RastreoPaquetes.Entidades.Transportes.Interfaces;
using System;

namespace RastreoPaquetes.Utilerias.Interfaces
{
    public interface IPobladorPedido
    {
        IPedido PoblarPedido(string[] campos);
        void RePoblarPedido(IPedido pedido, DateTime fechaActual, int margenUtilidad, ITransporte transporte);
    }
}
