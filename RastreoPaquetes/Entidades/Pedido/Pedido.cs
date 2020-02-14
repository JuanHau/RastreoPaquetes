using System;
using RastreoPaquetes.Comunes.Enumeradores;
using RastreoPaquetes.Entidades.Pedido.Interfaces;

namespace RastreoPaquetes.Entidades.Pedido
{
    public class Pedido : IPedido
    {
        public string Origen { get; set; }
        public string Destino { get; set; }
        public int Distancia { get; set; }
        public DateTime FechaHora { get; set; }
        public string Empresa { get; set; }
        public double Duracion { get; set; }
        public EscalaTiempo EscalaTiempo { get; set; }
        public TipoEvento Tiempo { get; set; }
        public double Costo { get; set; }
        public TipoTransporte TipoTransporte { get; set; }
        public string NombreTransporte { get; set; }
        public DateTime FechaEntrega { get; set; }
    }
}
