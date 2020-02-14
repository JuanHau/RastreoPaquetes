using RastreoPaquetes.Comunes.Enumeradores;
using System;

namespace RastreoPaquetes.Operaciones.Servicios.Interfaces
{
    public interface ICalculador
    {
        double CalcularCosto(double costoKm, int distancia, int margenUtilidad);
        double CalcularTiempoTraslado(int distancia, int velocidadTransporte);
        DateTime CalcularFechaEntrega(DateTime fechaPedido, double tiempoTranslado, EscalaTiempo escalaTiempo);
    }
}
