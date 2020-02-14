using RastreoPaquetes.Utilerias.Interfaces;
using System;

namespace RastreoPaquetes.Utilerias
{
    public class ImprimidorPantalla : IImprimidorPantalla
    {
        public void ImprimirConsola(string resultado)
        {
            Console.WriteLine(resultado);
        }
    }
}
