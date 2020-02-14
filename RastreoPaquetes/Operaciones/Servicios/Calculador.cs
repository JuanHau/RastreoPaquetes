using RastreoPaquetes.Comunes.Enumeradores;
using RastreoPaquetes.Operaciones.Servicios.Interfaces;
using System;

namespace RastreoPaquetes.Operaciones.Servicios
{
    public class Calculador : ICalculador
    {
        public double CalcularCosto(double costoKm, int distancia, int margenUtilidad)
        {
            return costoKm * distancia * (1 + margenUtilidad / 100);
        }

        public DateTime CalcularFechaEntrega(DateTime fechaPedido, double tiempoTranslado, EscalaTiempo escalaTiempo)
        {
            DateTime fechaEntrega = new DateTime();
            switch (escalaTiempo)
            {
                case EscalaTiempo.Mes:
                    fechaEntrega = fechaPedido.AddMonths((int)tiempoTranslado);
                    break;
                case EscalaTiempo.Dia:
                    fechaEntrega = fechaPedido.AddDays((int)tiempoTranslado);
                    break;
                case EscalaTiempo.Hora:
                    fechaEntrega = fechaPedido.AddHours((int)tiempoTranslado);
                    break;
                case EscalaTiempo.Minuto:
                    fechaEntrega = fechaPedido.AddMinutes((int)tiempoTranslado);
                    break;
            }

            return fechaEntrega;
        }

        public double CalcularTiempoTraslado(int distancia, int velocidadTransporte)
        {
            return (double)distancia / velocidadTransporte;
        }
    }
}
