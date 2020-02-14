using RastreoPaquetes.Entidades.Pedido.Interfaces;

namespace RastreoPaquetes.Operaciones.Servicios.Interfaces
{
    public interface IFormateadorMensaje
    {
        void SiguienteFormateador(IFormateadorMensaje formateadorMensaje);
        string FormatearMensaje(IPedido pedido);
    }
}
