using RastreoPaquetes.Comunes.Enumeradores;
using System;

namespace RastreoPaquetes.Utilerias.Interfaces
{
    public interface IObtenedorEscala
    {
        EscalaTiempo ObtenerEscalaTiempo(DateTime actual, DateTime fecha);
    }
}
