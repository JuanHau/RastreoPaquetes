using RastreoPaquetes.Comunes.Enumeradores;
using RastreoPaquetes.Utilerias.Interfaces;
using System;
using System.Collections.Generic;

namespace RastreoPaquetes.Utilerias
{
    public class ValidadorTransporte : IValidadorTransporte
    {
        public bool DisponibilidadTransporte(TipoTransporte tipoTransporte, List<TipoTransporte> tipoTransportes)
        {
            return tipoTransportes.Contains(tipoTransporte);
        }

        public TipoTransporte EsMedioDeTransporte(string medioTransporte)
        {
            Enum.TryParse(medioTransporte, out TipoTransporte tipo);

            return tipo;
        }
    }
}
