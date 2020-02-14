using RastreoPaquetes.Comunes.Enumeradores;
using System.Collections.Generic;

namespace RastreoPaquetes.Utilerias.Interfaces
{
    public interface IValidadorTransporte
    {
        TipoTransporte EsMedioDeTransporte(string medioTransporte);
        bool DisponibilidadTransporte(TipoTransporte tipoTransporte, List<TipoTransporte> tipoTransportes);
    }
}
