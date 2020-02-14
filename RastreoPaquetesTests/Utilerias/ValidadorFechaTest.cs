using Microsoft.VisualStudio.TestTools.UnitTesting;
using RastreoPaquetes.Utilerias;
using System;

namespace RastreoPaquetesTests.Utilerias
{
    [TestClass]
    public class ValidadorFechaTest
    {
        [TestMethod]
        [DataRow("01/01/2020 00:01:00")]
        [DataRow("21/03/2020")]
        public void ConvertirFecha_FechaCorrecta_Fecha(string fecha)
        {
            //Arrange
            ValidadorFecha convertidorFecha = new ValidadorFecha();

            //Act
            DateTime fechaEvento = convertidorFecha.ValidarFechaString(fecha);

            //Assert
            Assert.IsNotNull(fechaEvento);
        }

        [TestMethod]
        [DataRow("")]
        [DataRow(null)]
        public void ConvertirFecha_FechaInCorrecta_Excepcion(string fecha)
        {
            //Arrange
            ValidadorFecha convertidorFecha = new ValidadorFecha();

            //Act
            ArgumentException error = Assert.ThrowsException<ArgumentException>(() => convertidorFecha.ValidarFechaString(fecha));

            //Assert
            Assert.AreEqual("La fecha  tiene un formato incorrecto", error.Message);
        }
    }
}
