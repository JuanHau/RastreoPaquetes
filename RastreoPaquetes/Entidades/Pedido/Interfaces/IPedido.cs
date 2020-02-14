using RastreoPaquetes.Comunes.Enumeradores;
using System;

namespace RastreoPaquetes.Entidades.Pedido.Interfaces
{
    public interface IPedido
    {
        string Origen { get; set; }
        string Destino { get; set; }
        int Distancia { get; set; }
        string Empresa { get; set; }
        TipoTransporte TipoTransporte { get; set; }
        string NombreTransporte { get; set; }
        DateTime FechaHora { get; set; }

        //INICIAL

        EscalaTiempo EscalaTiempo { get; set; }
        TipoEvento Tiempo { get; set; }
        double Duracion { get; set; }
        double Costo { get; set; }
        DateTime FechaEntrega { get; set; }
    }
}
