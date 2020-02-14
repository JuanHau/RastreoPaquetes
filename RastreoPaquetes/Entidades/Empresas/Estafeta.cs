using RastreoPaquetes.Comunes.Enumeradores;
using RastreoPaquetes.Entidades.Empresas.Interfaces;
using RastreoPaquetes.Entidades.Transportes.Interfaces;
using System.Collections.Generic;

namespace RastreoPaquetes.Entidades.Empresas
{
    public class Estafeta : IEmpresa
    {
        public Dictionary<TipoTransporte, ITransporte> Transportes { get; } = new Dictionary<TipoTransporte, ITransporte>();

        public int MargenUtilidad { get; }
        public string Nombre => "Estafeta";

        public ITransporte Transporte { get; }

        public Estafeta(int margenUtilidad)
        {
            MargenUtilidad = margenUtilidad;
        }

        public void AgregarTransporte(ITransporte transporte)
        {
            Transportes.TryAdd(transporte.TipoTransporte, transporte);
        }

        public void RemoverTransporte(ITransporte transporte)
        {
            Transportes.Remove(transporte.TipoTransporte);
        }
    }
}
