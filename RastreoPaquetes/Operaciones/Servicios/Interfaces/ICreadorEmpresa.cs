using RastreoPaquetes.Entidades.Empresas.Interfaces;

namespace RastreoPaquetes.Operaciones.Servicios.Interfaces
{
    public interface ICreadorEmpresa
    {
        void NuevaEmpresa();
        IEmpresa GetEmpresa();
    }
}
