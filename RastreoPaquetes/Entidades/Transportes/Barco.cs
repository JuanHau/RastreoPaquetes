using RastreoPaquetes.Comunes.Enumeradores;
using RastreoPaquetes.Entidades.Pedido.Interfaces;
using RastreoPaquetes.Entidades.Transportes.Interfaces;
using System;

namespace RastreoPaquetes.Entidades.Transportes
{
    public class Barco : ITransporte
    {

        public double CostoKm { get; }

        public int VelocidadEntrega { get; }

        public Barco(double costoKm, int velocidadEntrega)
        {
            CostoKm = costoKm;
            VelocidadEntrega = velocidadEntrega;
        }

        public TipoTransporte TipoTransporte => TipoTransporte.Barco;

        public void RealizarEntrega(IPedido pedido, int margenUtilidad)
        {
            throw new NotImplementedException();
        }
    }
}
