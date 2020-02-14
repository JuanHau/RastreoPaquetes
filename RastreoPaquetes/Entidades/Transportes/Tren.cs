using RastreoPaquetes.Comunes.Enumeradores;
using RastreoPaquetes.Entidades.Transportes.Interfaces;
using System;

namespace RastreoPaquetes.Entidades.Transportes
{
    public class Tren : ITransporte
    {
        public Tren(double costoKm, int velocidadEntrega)
        {
            CostoKm = costoKm;
            VelocidadEntrega = velocidadEntrega;
        }

        public double CostoKm { get; }

        public int VelocidadEntrega { get; }

        public TipoTransporte TipoTransporte => TipoTransporte.Tren;

        public void RealizarEntrega()
        {
            throw new NotImplementedException();
        }
    }
}
