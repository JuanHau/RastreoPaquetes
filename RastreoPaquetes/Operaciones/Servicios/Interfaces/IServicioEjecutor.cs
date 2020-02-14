using RastreoPaquetes.Entidades.Pedido.Interfaces;
using System;

namespace RastreoPaquetes.Operaciones.Servicios.Interfaces
{
    public interface IServicioEjecutor
    {
        public void RealizarEnvios(IPedido pedido, DateTime fechaActual);
    }
}
