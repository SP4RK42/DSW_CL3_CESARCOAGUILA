using DSW_CL3_CESARCOAGUILA.Models;

namespace DSW_CL3_CESARCOAGUILA.Repositorio.Interfaces
{
    public interface IProveedor
    {
        IEnumerable<Proveedor> ListarProveedores();
        Proveedor getProveedor(int id);
        string InsertarProveedor(Proveedor reg);
        string ActualizarProveedor(Proveedor reg);
        string EliminarProveedor(int id);
    }
}
