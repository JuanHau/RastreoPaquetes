using RastreoPaquetes.Comunes.Enumeradores;
using RastreoPaquetes.Entidades.Transportes.Interfaces;
using System;

namespace RastreoPaquetes.Entidades.Transportes
{
    public class Avion : ITransporte
    {
        public double CostoKm { get; }

        public int VelocidadEntrega { get; }

        public TipoTransporte TipoTransporte => TipoTransporte.Avion;

        public Avion(
            double costoKm,
            int velocidadEntrega)
        {
            CostoKm = costoKm;
            VelocidadEntrega = velocidadEntrega;
        }

        public void RealizarEntrega()
        {
            throw new NotImplementedException();
        }
    }
}
