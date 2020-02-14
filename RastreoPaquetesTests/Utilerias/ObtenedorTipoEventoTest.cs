using Microsoft.VisualStudio.TestTools.UnitTesting;
using RastreoPaquetes.Comunes.Enumeradores;
using RastreoPaquetes.Utilerias;
using System;

namespace RastreoPaquetesTests.Utilerias
{
    [TestClass]
    public class ObtenedorTipoEventoTest
    {
        protected ObtenedorTipoEvento _obtenedorTipoEvento;

        [TestMethod()]
        public void ObtenerTipoEvento_FechaAnteriorActual_TipoDeEventoPasado()
        {
            //Arrange
            _obtenedorTipoEvento = new ObtenedorTipoEvento();
            DateTime actual = new DateTime(2020, 01, 08);
            DateTime fechaAnterior = new DateTime(2020, 01, 06);

            //Act
            TipoEvento evento = _obtenedorTipoEvento.ObtenerTipoEvento(actual, fechaAnterior);

            //Assert
            Assert.AreEqual(TipoEvento.Pasado, evento);
        }

        [TestMethod()]
        public void ObtenerTipoEvento_FechaPosteriorActual_TipoDeEventoFuturo()
        {
            //Arrange
            _obtenedorTipoEvento = new ObtenedorTipoEvento();
            DateTime actual = new DateTime(2020, 01, 01);
            DateTime fechaPosterior = new DateTime(2020, 02, 15);

            //Act
            TipoEvento evento = _obtenedorTipoEvento.ObtenerTipoEvento(actual, fechaPosterior);

            //Assert
            Assert.AreEqual(TipoEvento.Futuro, evento);
        }
    }
}
