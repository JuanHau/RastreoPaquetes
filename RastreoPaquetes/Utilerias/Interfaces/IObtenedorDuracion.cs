using RastreoPaquetes.Comunes.Enumeradores;
using System;

namespace RastreoPaquetes.Utilerias.Interfaces
{
    public interface IObtenedorDuracion
    {
        int ObtenerDuracion(DateTime actual, DateTime fecha, EscalaTiempo escala);
    }
}
