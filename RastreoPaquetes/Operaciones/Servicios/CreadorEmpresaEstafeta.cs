using RastreoPaquetes.Entidades.Empresas;
using RastreoPaquetes.Entidades.Empresas.Interfaces;
using RastreoPaquetes.Entidades.Transportes;
using RastreoPaquetes.Operaciones.Servicios.Interfaces;

namespace RastreoPaquetes.Operaciones.Servicios
{
    public class CreadorEmpresaEstafeta : ICreadorEmpresa
    {
        private IEmpresa _empresa;

        private void IncluirTransportes()
        {
            Barco barco = new Barco(1, 46);
            Tren tren = new Tren(5, 80);

            _empresa.AgregarTransporte(barco);
            _empresa.AgregarTransporte(tren);
        }

        public void NuevaEmpresa()
        {
            _empresa = new Estafeta(20);
            IncluirTransportes();
        }

        public IEmpresa GetEmpresa()
        {
            return _empresa;
        }
    }
}
