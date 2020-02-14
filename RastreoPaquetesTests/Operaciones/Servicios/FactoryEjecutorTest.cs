using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RastreoPaquetes.Comunes.Enumeradores;
using RastreoPaquetes.Entidades.Pedido;
using RastreoPaquetes.Entidades.Pedido.Interfaces;
using RastreoPaquetes.Entidades.Transportes.Interfaces;
using RastreoPaquetes.Operaciones.Servicios;
using RastreoPaquetes.Utilerias.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace RastreoPaquetesTests.Operaciones.Servicios
{
    [TestClass]
    public class FactoryEjecutorTest
    {
        //Instancia de la clase
        protected FactoryEjecutor _factoryEjecutor;

        //Mocks de la clase
        protected Mock<IValidadorTransporte> _validadorTransporte;
        protected Mock<IPobladorPedido> _pobladorPedido;

        [TestInitialize]
        public void TestInitialize()
        {
            _validadorTransporte = new Mock<IValidadorTransporte>();
            _pobladorPedido = new Mock<IPobladorPedido>();

            _factoryEjecutor = new FactoryEjecutor(_validadorTransporte.Object, _pobladorPedido.Object);
        }

        [TestMethod]
        public void FactoryEjecutor_ParametrosCorrecto_IniciarInstanciaCorrectamente()
        {
            //Arrange
            //Act
            //Assert
            Assert.IsNotNull(_factoryEjecutor);
        }

        [TestMethod]
        [DataRow("DHL")]
        [DataRow("Estafeta")]
        [DataRow("Fedex")]
        public void RealizarEnvios_LaPaqueteriaExisteYTransporteEstaDisponible_DebeCrearEmpresaRepoblarPedido(string empresa)
        {
            //Arrange
            _validadorTransporte.Setup(x => x.DisponibilidadTransporte(It.IsAny<TipoTransporte>(), It.IsAny<List<TipoTransporte>>())).Returns(true);

            IPedido pedido = new Pedido()
            {
                Empresa = empresa,
                TipoTransporte = TipoTransporte.Barco
            };

            //Act
            _factoryEjecutor.RealizarEnvios(pedido, DateTime.Now);

            //Assert
            _pobladorPedido.Verify(x => x.RePoblarPedido(It.IsAny<IPedido>(), It.IsAny<DateTime>(), It.IsAny<int>(), It.IsAny<ITransporte>()), Times.Once);
        }
    }
}
