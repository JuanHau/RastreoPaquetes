using Microsoft.VisualStudio.TestTools.UnitTesting;
using RastreoPaquetes.Comunes.Enumeradores;
using RastreoPaquetes.Utilerias;
using System;

namespace RastreoPaquetesTests.Utilerias
{
    [TestClass]
    public class ObtenedorEscalaTest
    {
        protected ObtenedorEscala _obtenedorEscala;

        [TestInitialize]
        public void TestInitialize()
        {
            _obtenedorEscala = new ObtenedorEscala();
        }

        [TestMethod]
        public void ObtenerEscalaTiempo_FechaTieneMeses_EscalaTiempoMes()
        {
            //Arrange
            DateTime actual = new DateTime(2020, 01, 01);
            DateTime fecha = new DateTime(2020, 03, 31);

            //Act
            EscalaTiempo escala = _obtenedorEscala.ObtenerEscalaTiempo(actual, fecha);

            //Assert
            Assert.AreEqual(EscalaTiempo.Mes, escala);
        }

        [TestMethod]
        public void ObtenerEscalaTiempo_FechaTieneDias_EscalaTiempoDia()
        {
            //Arrange
            DateTime actual = new DateTime(2020, 01, 01);
            DateTime fecha = new DateTime(2020, 01, 03);

            //Act
            EscalaTiempo escala = _obtenedorEscala.ObtenerEscalaTiempo(actual, fecha);

            //Assert
            Assert.AreEqual(EscalaTiempo.Dia, escala);
        }

        [TestMethod]
        public void ObtenerEscalaTiempo_FechaTieneHora_EscalaTiempoHora()
        {
            //Arrange
            DateTime actual = new DateTime(2020, 01, 01);
            DateTime fecha = new DateTime(2020, 01, 01, 03, 00, 00);

            //Act
            EscalaTiempo escala = _obtenedorEscala.ObtenerEscalaTiempo(actual, fecha);

            //Assert
            Assert.AreEqual(EscalaTiempo.Hora, escala);
        }

        [TestMethod]
        public void ObtenerEscalaTiempo_FechaTieneMinuto_EscalaTiempoMinuto()
        {
            //Arrange
            DateTime actual = new DateTime(2020, 01, 01);
            DateTime fecha = new DateTime(2020, 01, 01, 00, 04, 00);

            //Act
            EscalaTiempo escala = _obtenedorEscala.ObtenerEscalaTiempo(actual, fecha);

            //Assert
            Assert.AreEqual(EscalaTiempo.Minuto, escala);
        }

        [TestMethod]
        public void ObtenerEscalaTiempo_FechaNoTieneEscala_EscalaTiempoNinguna()
        {
            //Arrange
            DateTime actual = new DateTime(2020, 01, 01);
            DateTime fecha = new DateTime(2020, 01, 01);

            //Act
            EscalaTiempo escala = _obtenedorEscala.ObtenerEscalaTiempo(actual, fecha);

            //Assert
            Assert.AreEqual(EscalaTiempo.NoEscala, escala);
        }
    }
}
