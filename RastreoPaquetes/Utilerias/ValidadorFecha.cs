using RastreoPaquetes.Utilerias.Interfaces;
using System;

namespace RastreoPaquetes.Utilerias
{
    public class ValidadorFecha : IValidadorFecha
    {
        public DateTime ValidarFechaString(string fechaString)
        {
            DateTime.TryParse(fechaString, out DateTime fecha);

            if (fecha == DateTime.MinValue)
            {
                throw new ArgumentException(string.Format("La fecha {0} tiene un formato incorrecto", fechaString));
            }

            return fecha;
        }
    }
}
