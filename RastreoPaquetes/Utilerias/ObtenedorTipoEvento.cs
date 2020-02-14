using RastreoPaquetes.Comunes.Enumeradores;
using RastreoPaquetes.Utilerias.Interfaces;
using System;

namespace RastreoPaquetes.Utilerias
{
    public class ObtenedorTipoEvento : IObtenedorTipoEvento
    {
        public TipoEvento ObtenerTipoEvento(DateTime actual, DateTime fecha)
        {
            if (actual > fecha)
            {
                return TipoEvento.Pasado;
            }
            else
            {
                return TipoEvento.Futuro;

            }
        }
    }
}
