using RastreoPaquetes.Comunes.Enumeradores;

namespace RastreoPaquetes.Entidades.Transportes.Interfaces
{
    public interface ITransporte
    {
        public double CostoKm { get; }
        public int VelocidadEntrega { get; }
        public TipoTransporte TipoTransporte { get; }
    }
}
