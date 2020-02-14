using Microsoft.VisualStudio.TestTools.UnitTesting;
using RastreoPaquetes.Utilerias;
using System;
using System.Collections.Generic;
using System.IO;

namespace RastreoPaquetesTests.Utilerias
{
    [TestClass]
    public class LectorArchivoTest
    {
        [TestMethod]
        [DataRow("")]
        [DataRow(null)]
        public void LeerArchivo_RutaInexistente_DevuelveExcepcion(string ruta)
        {
            //Arrange
            LectorArchivo lector = new LectorArchivo();

            //Act
            ArgumentException error = Assert.ThrowsException<ArgumentException>(() => lector.LeerArchivo(ruta));

            //Assert
            Assert.AreEqual("El archivo en la ruta  no existe", error.Message);
        }

        [TestMethod]
        public void LeerArchivo_RutaExistente_DevuelveListaEventos()
        {
            //Arrange
            LectorArchivo lector = new LectorArchivo();
            string ruta = Path.GetFullPath("paquetes.txt");

            //Act
            List<string> eventos = lector.LeerArchivo(ruta);

            //Assert
            Assert.AreEqual(3, eventos.Count);
        }
    }
}