using RastreoPaquetes.Comunes.Enumeradores;
using RastreoPaquetes.Entidades.Pedido.Interfaces;
using RastreoPaquetes.Operaciones.Servicios.Interfaces;

namespace RastreoPaquetes.Operaciones.Servicios
{
    public abstract class FormateadorBase : IFormateadorMensaje
    {
        public abstract string FormatearMensaje(IPedido pedido);

        public abstract void SiguienteFormateador(IFormateadorMensaje formateadorMensaje);

        protected const string FormatoMensajeCorrecto = "Tu paquete {0} de {1} y {2} a {3} {4} {5} {6} y {7} un costo de ${8} (cualquier reclamación con {9})";
        protected const string FormatoMensajeInCorrectoTransporte = "La paquetería {0} no ofrece el servicio de transporte {1}, te recomendamos cotizar en otra empresa";
        protected const string FormatoMensajeInCorrectoEmpresa = "La paquetería {0} no se encuentra registrada en nuestra red de distribución";

        protected bool ValidarTransporte(TipoTransporte tipoTransporte)
        {
            return tipoTransporte != TipoTransporte.NoValido;
        }
    }
}
