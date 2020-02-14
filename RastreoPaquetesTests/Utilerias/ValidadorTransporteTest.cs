using Microsoft.VisualStudio.TestTools.UnitTesting;
using RastreoPaquetes.Comunes.Enumeradores;
using RastreoPaquetes.Utilerias;
using System.Collections.Generic;

namespace RastreoPaquetesTests.Utilerias
{
    [TestClass]
    public class ValidadorTransporteTest
    {
        protected ValidadorTransporte _validadorTransporte;

        [TestMethod]
        public void DisponibilidadTransporte_LaPaqueteriaContieneElMedioTransporte_DevuelveTrue()
        {
            //Arrange
            _validadorTransporte = new ValidadorTransporte();
            List<TipoTransporte> tipoTransportes = new List<TipoTransporte>() { TipoTransporte.Avion, TipoTransporte.Tren };

            //Act
            bool resultado = _validadorTransporte.DisponibilidadTransporte(TipoTransporte.Tren, tipoTransportes);

            //Assert
            Assert.IsTrue(resultado);
        }

        [TestMethod]
        public void DisponibilidadTransporte_LaPaqueteriaNoContieneElMedioTransporte_DevuelveFalse()
        {
            //Arrange
            _validadorTransporte = new ValidadorTransporte();
            List<TipoTransporte> tipoTransportes = new List<TipoTransporte>() { TipoTransporte.Avion, TipoTransporte.Tren };

            //Act
            bool resultado = _validadorTransporte.DisponibilidadTransporte(TipoTransporte.Barco, tipoTransportes);

            //Assert
            Assert.IsFalse(resultado);
        }

        [TestMethod]
        [DataRow("Tren")]
        [DataRow("Barco")]
        [DataRow("Avion")]
        public void EsMedioDeTransporte_ElTransporteCorrespondeAUnTipoRegistrado_DevuelveElTipoCorrecto(string medioTransporte)
        {
            //Arrange
            _validadorTransporte = new ValidadorTransporte();

            //Act
            TipoTransporte transporte = _validadorTransporte.EsMedioDeTransporte(medioTransporte);

            //Assert
            Assert.AreNotEqual(TipoTransporte.NoValido, transporte);
        }

        [TestMethod]
        [DataRow("TrenBala")]
        [DataRow("Ferri")]
        [DataRow("Helicóptero")]
        public void EsMedioDeTransporte_ElTransporteNoCorrespondeAUnTipoRegistrado_DevuelveElTipoNoValido(string medioTransporte)
        {
            //Arrange
            _validadorTransporte = new ValidadorTransporte();

            //Act
            TipoTransporte transporte = _validadorTransporte.EsMedioDeTransporte(medioTransporte);

            //Assert
            Assert.AreEqual(TipoTransporte.NoValido, transporte);
        }
    }
}
