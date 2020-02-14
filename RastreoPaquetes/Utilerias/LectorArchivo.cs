using RastreoPaquetes.Utilerias.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;

namespace RastreoPaquetes.Utilerias
{
    public class LectorArchivo : ILectorArchivo
    {
        public List<string> LeerArchivo(string rutaArchivo)
        {
            List<string> lineas = new List<string>();

            if (!File.Exists(rutaArchivo))
            {
                throw new ArgumentException(string.Format("El archivo en la ruta {0} no existe", rutaArchivo));
            }

            using (StreamReader stream = new StreamReader(rutaArchivo))
            {
                while (stream.Peek() > -1)
                {
                    string linea = stream.ReadLine();

                    lineas.Add(linea);

                }
            }

            return lineas;
        }
    }
}
