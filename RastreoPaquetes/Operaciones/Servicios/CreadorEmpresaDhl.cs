using RastreoPaquetes.Entidades.Empresas;
using RastreoPaquetes.Entidades.Empresas.Interfaces;
using RastreoPaquetes.Entidades.Transportes;
using RastreoPaquetes.Operaciones.Servicios.Interfaces;

namespace RastreoPaquetes.Operaciones.Servicios
{
    public class CreadorEmpresaDhl : ICreadorEmpresa
    {
        private IEmpresa _empresa;

        private void IncluirTransportes()
        {
            Barco barco = new Barco(1, 46);
            Avion avion = new Avion(10, 600);

            _empresa.AgregarTransporte(barco);
            _empresa.AgregarTransporte(avion);
        }

        public void NuevaEmpresa()
        {
            _empresa = new Dhl(40);
            IncluirTransportes();
        }

        public IEmpresa GetEmpresa()
        {
            return _empresa;
        }
    }
}
