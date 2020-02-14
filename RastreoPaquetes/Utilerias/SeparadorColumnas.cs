using RastreoPaquetes.Utilerias.Interfaces;

namespace RastreoPaquetes.Utilerias
{
    public class SeparadorColumnas : ISeparadorColumnas
    {
        public string[] SepararPorCaracter(string linea, char separador)
        {
            return linea.Split(separador);
        }
    }
}
