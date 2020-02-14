using RastreoPaquetes.Entidades.Empresas;
using RastreoPaquetes.Entidades.Empresas.Interfaces;
using RastreoPaquetes.Entidades.Transportes;
using RastreoPaquetes.Operaciones.Servicios.Interfaces;

namespace RastreoPaquetes.Operaciones.Servicios
{
    public class CreadorEmpresaFedex : ICreadorEmpresa
    {
        private IEmpresa _empresa;

        private void IncluirTransportes()
        {
            Barco barco = new Barco(1, 46);

            _empresa.AgregarTransporte(barco);
        }

        public void NuevaEmpresa()
        {
            _empresa = new Fedex(50);
            IncluirTransportes();
        }

        public IEmpresa GetEmpresa()
        {
            return _empresa;
        }
    }
}
