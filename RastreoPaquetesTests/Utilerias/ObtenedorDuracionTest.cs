using Microsoft.VisualStudio.TestTools.UnitTesting;
using RastreoPaquetes.Comunes.Enumeradores;
using RastreoPaquetes.Utilerias;
using System;

namespace RastreoPaquetesTests.Utilerias
{
    [TestClass]
    public class ObtenedorDuracionTest
    {
        protected ObtenedorDuracion _obtenedorDuracion;

        [TestInitialize]
        public void TestInitialize()
        {
            _obtenedorDuracion = new ObtenedorDuracion();
        }

        [TestMethod]
        public void ObtenerDuracion_EscalaMes_DuracionMes()
        {
            //Arrange
            DateTime actual = new DateTime(2020, 01, 01, 01, 59, 59);
            DateTime fecha = new DateTime(2020, 04, 01, 01, 59, 59);

            //Act
            int duracionMes = _obtenedorDuracion.ObtenerDuracion(actual, fecha, EscalaTiempo.Mes);

            //Assert
            Assert.AreEqual(2, duracionMes);
        }

        [TestMethod]
        public void ObtenerDuracion_EscalaDia_DuracionDia()
        {
            //Arrange
            DateTime actual = new DateTime(2020, 01, 01, 01, 59, 59);
            DateTime fecha = new DateTime(2020, 01, 02, 01, 59, 59);

            //Act
            int duracionDia = _obtenedorDuracion.ObtenerDuracion(actual, fecha, EscalaTiempo.Dia);

            //Assert
            Assert.AreEqual(1, duracionDia);
        }

        [TestMethod]
        public void ObtenerDuracion_EscalaHora_DuracionHora()
        {
            //Arrange
            DateTime actual = new DateTime(2020, 01, 01, 01, 59, 59);
            DateTime fecha = new DateTime(2020, 01, 01, 03, 59, 59);

            //Act
            int duracionHora = _obtenedorDuracion.ObtenerDuracion(actual, fecha, EscalaTiempo.Hora);

            //Assert
            Assert.AreEqual(2, duracionHora);
        }

        [TestMethod]
        public void ObtenerDuracion_EscalaMinuto_DuracionMinuto()
        {
            //Arrange
            DateTime actual = new DateTime(2020, 01, 01, 01, 00, 00);
            DateTime fecha = new DateTime(2020, 01, 01, 01, 01, 00);

            //Act
            int duracionMinuto = _obtenedorDuracion.ObtenerDuracion(actual, fecha, EscalaTiempo.Minuto);

            //Assert
            Assert.AreEqual(1, duracionMinuto);
        }
    }
}
