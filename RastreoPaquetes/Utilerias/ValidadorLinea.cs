using RastreoPaquetes.Utilerias.Interfaces;

namespace RastreoPaquetes.Utilerias
{
    public class ValidadorLinea : IValidadorLinea
    {
        public bool ValidarFormato(string[] columnas, int numeroColumnas)
        {
            return columnas.Length == numeroColumnas;
        }
    }
}
