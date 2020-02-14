using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RastreoPaquetes.Comunes.Enumeradores;
using RastreoPaquetes.Entidades.Pedido;
using RastreoPaquetes.Entidades.Pedido.Interfaces;
using RastreoPaquetes.Entidades.Transportes;
using RastreoPaquetes.Operaciones.Servicios.Interfaces;
using RastreoPaquetes.Utilerias;
using RastreoPaquetes.Utilerias.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace RastreoPaquetesTests.Utilerias
{
    [TestClass]
    public class PobladorPedidoTest
    {
        //Instancia de la clase
        protected PobladorPedido _pobladorPedido;

        //Mocks de la clase
        protected Mock<IValidadorFecha> _validadorFecha;
        protected Mock<IValidadorTransporte> _validadorTransporte;
        protected Mock<ICalculador> _calculador;
        protected Mock<IObtenedorEscala> _obtenedorEscala;
        protected Mock<IObtenedorDuracion> _obtenedorDuracion;
        protected Mock<IObtenedorTipoEvento> _obtenedorTipoEvento;

        [TestInitialize]
        public void TestInitialize()
        {
            _validadorFecha = new Mock<IValidadorFecha>();
            _validadorTransporte = new Mock<IValidadorTransporte>();
            _calculador = new Mock<ICalculador>();
            _obtenedorEscala = new Mock<IObtenedorEscala>();
            _obtenedorDuracion = new Mock<IObtenedorDuracion>();
            _obtenedorTipoEvento = new Mock<IObtenedorTipoEvento>();

            _pobladorPedido = new PobladorPedido(
                _validadorFecha.Object,
                _validadorTransporte.Object,
                _calculador.Object,
                _obtenedorEscala.Object,
                _obtenedorDuracion.Object,
                _obtenedorTipoEvento.Object);
        }

        [TestMethod]
        public void PobladorPedido_ParametrosCorrectos_IniciarInstancia()
        {
            //Arrange
            //Act
            //Assert
            Assert.IsNotNull(_pobladorPedido);
        }

        [TestMethod]
        public void PoblarPedido_ColumnasCompletas_DevolverEntidadPedido()
        {
            //Arrange
            _validadorTransporte.Setup(x => x.EsMedioDeTransporte(It.IsAny<string>())).Returns(TipoTransporte.Tren);
            _validadorFecha.Setup(x => x.ValidarFechaString(It.IsAny<string>())).Returns(new DateTime(2020, 1, 1, 0, 1, 0));
            string[] campos = new string[6];
            campos[0] = "Tizimín";
            campos[1] = "Mérida";
            campos[2] = "147";
            campos[3] = "DHL";
            campos[4] = "Tren";
            campos[5] = "01/01/2020 00:01:00";

            //Act
            IPedido pedido = _pobladorPedido.PoblarPedido(campos);

            //Assert
            Assert.AreEqual("Tizimín", pedido.Origen);
            Assert.AreEqual("Mérida", pedido.Destino);
            Assert.AreEqual(147, pedido.Distancia);
            Assert.AreEqual("DHL", pedido.Empresa);
            Assert.AreEqual(TipoTransporte.Tren, pedido.TipoTransporte);
            Assert.AreEqual(new DateTime(2020,01,01,0, 1, 0), pedido.FechaHora);
        }

        [TestMethod]
        public void RePoblarPedido_PedidoSeHaPobladoAnteriormente_CompletarCamposExtra()
        {
            //Arrange
            DateTime fechaActual = new DateTime(2020, 02, 14);
            Tren tren = new Tren(5, 80);
            _obtenedorEscala.Setup(x => x.ObtenerEscalaTiempo(It.IsAny<DateTime>(), It.IsAny<DateTime>())).Returns(EscalaTiempo.Hora);
            _obtenedorTipoEvento.Setup(x => x.ObtenerTipoEvento(It.IsAny<DateTime>(), It.IsAny<DateTime>())).Returns(TipoEvento.Futuro);
            _obtenedorDuracion.Setup(x => x.ObtenerDuracion(It.IsAny<DateTime>(), It.IsAny<DateTime>(), It.IsAny<EscalaTiempo>())).Returns(21);
            _calculador.Setup(x => x.CalcularCosto(It.IsAny<double>(), It.IsAny<int>(), It.IsAny<int>())).Returns(122.23);
            _calculador.Setup(x => x.CalcularFechaEntrega(It.IsAny<DateTime>(), It.IsAny<double>(), It.IsAny<EscalaTiempo>())).Returns(new DateTime(2020, 07, 21));

            IPedido pedido = new Pedido()
            {
                Origen = "Tizimín",
                Destino = "Mérida",
                Distancia = 147,
                Empresa = "DHL",
                NombreTransporte = "Tren",
                TipoTransporte = TipoTransporte.Tren,
                FechaHora = new DateTime(2020, 01, 01, 0, 1, 0)
            };

            //Act
            _pobladorPedido.RePoblarPedido(pedido, fechaActual, 2, tren);

            //Assert
            Assert.AreEqual(EscalaTiempo.Hora, pedido.EscalaTiempo);
            Assert.AreEqual(TipoEvento.Futuro, pedido.Tiempo);
            Assert.AreEqual(21, pedido.Duracion);
            Assert.AreEqual(122.23, pedido.Costo);
            Assert.AreEqual(new DateTime(2020, 07, 21), pedido.FechaEntrega);
        }
    }
}
