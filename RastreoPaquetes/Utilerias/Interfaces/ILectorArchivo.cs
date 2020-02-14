using System.Collections.Generic;

namespace RastreoPaquetes.Utilerias.Interfaces
{
    public interface ILectorArchivo
    {
        List<string> LeerArchivo(string rutaArchivo);
    }
}
