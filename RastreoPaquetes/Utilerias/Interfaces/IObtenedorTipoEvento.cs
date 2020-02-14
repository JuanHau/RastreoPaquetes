using RastreoPaquetes.Comunes.Enumeradores;
using System;

namespace RastreoPaquetes.Utilerias.Interfaces
{
    public interface IObtenedorTipoEvento
    {
        TipoEvento ObtenerTipoEvento(DateTime actual, DateTime fecha);
    }
}
