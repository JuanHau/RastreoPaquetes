using RastreoPaquetes.Comunes.Enumeradores;
using RastreoPaquetes.Entidades.Pedido.Interfaces;
using RastreoPaquetes.Operaciones.Servicios.Interfaces;
using System;

namespace RastreoPaquetes.Operaciones.Servicios
{
    public class FormateadorPasadoMensajeSingular : FormateadorBase
    {
        private IFormateadorMensaje _formateadorMensaje;

        public override string FormatearMensaje(IPedido pedido)
        {
            string resultado = string.Empty;
            if (ValidarTransporte(pedido.TipoTransporte))
            {
                if (pedido.Tiempo.Equals(TipoEvento.Pasado) && pedido.Duracion == 1)
                {
                    Console.ForegroundColor = ConsoleColor.Green;

                    resultado = string.Format(FormatoMensajeCorrecto, 
                        "salió", pedido.Origen, 
                        "llegó", pedido.Destino, 
                        "hace", pedido.Duracion, pedido.EscalaTiempo.ToString().ToLower(), 
                        "tuvo", pedido.Costo, 
                        pedido.Empresa);
                }
                else if (_formateadorMensaje != null)
                {
                    resultado = _formateadorMensaje.FormatearMensaje(pedido);
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;

                resultado = string.Format(FormatoMensajeInCorrectoTransporte, pedido.Empresa, pedido.NombreTransporte);
            }

            return resultado;
        }

        public override void SiguienteFormateador(IFormateadorMensaje formateadorMensaje)
        {
            _formateadorMensaje = formateadorMensaje;
        }
    }
}
