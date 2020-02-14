using RastreoPaquetes.Entidades.Empresas.Interfaces;
using RastreoPaquetes.Entidades.Pedido.Interfaces;
using RastreoPaquetes.Operaciones.Servicios.Interfaces;
using RastreoPaquetes.Utilerias.Interfaces;
using System;
using System.Linq;

namespace RastreoPaquetes.Operaciones.Servicios
{
    public class FactoryEjecutor : IServicioEjecutor
    {
        private ICreadorEmpresa _creadorEmpresa;
        private readonly IValidadorTransporte _validadorTransporte;
        private readonly IPobladorPedido _pobladorPedido;

        public FactoryEjecutor(IValidadorTransporte validadorTransporte, IPobladorPedido pobladorPedido)
        {
            _validadorTransporte = validadorTransporte;
            _pobladorPedido = pobladorPedido;
        }

        private void ConsolidarEmpresas(string nombreEmpresa)
        {
            switch (nombreEmpresa)
            {
                case "DHL":
                    _creadorEmpresa = new CreadorEmpresaDhl();
                    break;
                case "Estafeta":
                    _creadorEmpresa = new CreadorEmpresaEstafeta();
                    break;
                case "Fedex":
                    _creadorEmpresa = new CreadorEmpresaFedex();
                    break;
            }
        }

        public void RealizarEnvios(IPedido pedido, DateTime fechaActual)
        {
            string nombreEmpresa = pedido.Empresa;

            ConsolidarEmpresas(nombreEmpresa);

            if(_creadorEmpresa != null)
            {
                _creadorEmpresa.NuevaEmpresa();
                IEmpresa empresa = _creadorEmpresa.GetEmpresa();

                if (_validadorTransporte.DisponibilidadTransporte(pedido.TipoTransporte, empresa.Transportes.Keys.ToList()))
                {
                    _pobladorPedido.RePoblarPedido(pedido, fechaActual, empresa.MargenUtilidad, empresa.Transportes[pedido.TipoTransporte]);
                }
            }
        }
    }
}
