using RastreoPaquetes.Entidades.Pedido;
using RastreoPaquetes.Entidades.Pedido.Interfaces;
using RastreoPaquetes.Entidades.Transportes.Interfaces;
using RastreoPaquetes.Operaciones.Servicios.Interfaces;
using RastreoPaquetes.Utilerias.Interfaces;
using System;
using System.Linq;

namespace RastreoPaquetes.Utilerias
{
    public class PobladorPedido : IPobladorPedido
    {
        private readonly IValidadorFecha _validadorFecha;
        private readonly IValidadorTransporte _validadorTransporte;
        private readonly ICalculador _calculador;
        private readonly IObtenedorEscala _obtenedorEscala;
        private readonly IObtenedorDuracion _obtenedorDuracion;
        private readonly IObtenedorTipoEvento _obtenedorTipoEvento;

        public PobladorPedido(
            IValidadorFecha validadorFecha,
            IValidadorTransporte validadorTransporte,
            ICalculador calculador,
            IObtenedorEscala obtenedorEscala,
            IObtenedorDuracion obtenedorDuracion,
            IObtenedorTipoEvento obtenedorTipoEvento)
        {
            _validadorFecha = validadorFecha;
            _validadorTransporte = validadorTransporte;
            _calculador = calculador;
            _obtenedorEscala = obtenedorEscala;
            _obtenedorDuracion = obtenedorDuracion;
            _obtenedorTipoEvento = obtenedorTipoEvento;
        }

        public IPedido PoblarPedido(string[] campos)
        {
            IPedido pedido = new Pedido()
            {
                Origen = campos.ElementAt(0),
                Destino = campos.ElementAt(1),
                Distancia = int.Parse(campos.ElementAt(2)),
                Empresa = campos.ElementAt(3),
                NombreTransporte = campos.ElementAt(4),
                TipoTransporte = _validadorTransporte.EsMedioDeTransporte(campos.ElementAt(4)),
                FechaHora = _validadorFecha.ValidarFechaString(campos.ElementAt(5))
            };

            return pedido;
        }

        public void RePoblarPedido(IPedido pedido, DateTime fechaActual, int margenUtilidad, ITransporte transporte)
        {
            pedido.EscalaTiempo = _obtenedorEscala.ObtenerEscalaTiempo(fechaActual, pedido.FechaHora);
            pedido.Tiempo = _obtenedorTipoEvento.ObtenerTipoEvento(fechaActual, pedido.FechaHora);
            pedido.Duracion = _obtenedorDuracion.ObtenerDuracion(fechaActual, pedido.FechaHora, pedido.EscalaTiempo); 
            pedido.Costo = _calculador.CalcularCosto(transporte.CostoKm, pedido.Distancia, margenUtilidad);
            pedido.FechaEntrega = _calculador.CalcularFechaEntrega(pedido.FechaHora, pedido.Duracion, pedido.EscalaTiempo);
        }
    }
}
