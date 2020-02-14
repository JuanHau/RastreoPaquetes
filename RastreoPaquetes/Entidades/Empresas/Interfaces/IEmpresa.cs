using RastreoPaquetes.Comunes.Enumeradores;
using RastreoPaquetes.Entidades.Transportes.Interfaces;
using System.Collections.Generic;

namespace RastreoPaquetes.Entidades.Empresas.Interfaces
{
    public interface IEmpresa
    {
        void AgregarTransporte(ITransporte transporte);
        void RemoverTransporte(ITransporte transporte);
        public Dictionary<TipoTransporte, ITransporte> Transportes { get; }
        int MargenUtilidad { get; }
        string Nombre { get; }
        //string RealizarEntrega(IPedido pedido);
    }
}
