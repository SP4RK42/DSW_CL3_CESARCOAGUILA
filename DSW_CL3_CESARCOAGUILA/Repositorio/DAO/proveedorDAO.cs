using Microsoft.Data.SqlClient;
using System.Data;
using DSW_CL3_CESARCOAGUILA.Models;
using DSW_CL3_CESARCOAGUILA.Repositorio.Interfaces;

namespace DSW_CL3_CESARCOAGUILA.Repositorio.DAO
{
    public class proveedorDAO : IProveedor
    {
        private readonly string cadena;
        public proveedorDAO()
        {
            cadena = new ConfigurationBuilder().AddJsonFile("appsettings.json").
                Build().GetConnectionString("sql");
        }

        public Proveedor getProveedor(int id)
        {
            Proveedor oProveedor = new Proveedor();
            using (SqlConnection cn = new SqlConnection(cadena)) 
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("SeleccionarProveedor", cn);
                cmd.Parameters.AddWithValue("@IdProveedor", id);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read()) 
                {
                    oProveedor.idproveedor = dr.GetInt32(0);
                    oProveedor.nombrecia = dr.GetString(1);
                    oProveedor.nombrecontacto = dr.GetString(2);
                    oProveedor.cargocontacto = dr.GetString(3);
                    oProveedor.direccion = dr.GetString(4);
                    oProveedor.idpais = dr.GetString(5);
                    oProveedor.telefono = dr.GetString(6);
                    oProveedor.fax = dr.GetString(7);
                }
                cn.Close();
            }
            return oProveedor;
        }

        public IEnumerable<Proveedor> ListarProveedores()
        {
            List<Proveedor> listaProveedores = new List<Proveedor>();
            using(SqlConnection cn = new SqlConnection(cadena)) 
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("ListarProveedores", cn);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    listaProveedores.Add(new Proveedor()
                    {
                        idproveedor = dr.GetInt32(0),
                        nombrecia = dr.GetString(1),
                        nombrecontacto = dr.GetString(2),
                        cargocontacto = dr.GetString(3),
                        direccion = dr.GetString(4),
                        idpais = dr.GetString(5),
                        telefono = dr.GetString(6),
                        fax = dr.GetString(7),
                    });
                }
                dr.Close();
            }
            return listaProveedores;
        }

        public string InsertarProveedor(Proveedor reg)
        {
            string mensaje = string.Empty;
            using (SqlConnection cn = new SqlConnection(cadena)) 
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("InsertarProveedor", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdProveedor", reg.idproveedor);
                    cmd.Parameters.AddWithValue("@NombreCia", reg.nombrecia);
                    cmd.Parameters.AddWithValue("@NombreContacto", reg.nombrecontacto);
                    cmd.Parameters.AddWithValue("@CargoContacto", reg.cargocontacto);
                    cmd.Parameters.AddWithValue("@Direccion", reg.direccion);
                    cmd.Parameters.AddWithValue("@IdPais", reg.idpais);
                    cmd.Parameters.AddWithValue("@Telefono", reg.telefono);
                    cmd.Parameters.AddWithValue("@Fax", reg.fax);
                    cn.Open();
                    int i = cmd.ExecuteNonQuery();
                    mensaje = $"Se ha agregado {i} proveedores";
                }
                catch (Exception ex) { mensaje = ex.Message; }
                finally { cn.Close(); }
            }
            return mensaje;
        }

        public string ActualizarProveedor(Proveedor reg)
        {
            string mensaje = string.Empty;
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("ActualizarProveedor", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdProveedor", reg.idproveedor);
                    cmd.Parameters.AddWithValue("@NombreCia", reg.nombrecia);
                    cmd.Parameters.AddWithValue("@NombreContacto", reg.nombrecontacto);
                    cmd.Parameters.AddWithValue("@CargoContacto", reg.cargocontacto);
                    cmd.Parameters.AddWithValue("@Direccion", reg.direccion);
                    cmd.Parameters.AddWithValue("@IdPais", reg.idpais);
                    cmd.Parameters.AddWithValue("@Telefono", reg.telefono);
                    cmd.Parameters.AddWithValue("@Fax", reg.fax);
                    cn.Open();
                    int i = cmd.ExecuteNonQuery();
                    mensaje = $"Se ha actualizado {i} proveedores";
                }
                catch (Exception ex) { mensaje = ex.Message; }
                finally { cn.Close(); }
            }
            return mensaje;
        }

        public string EliminarProveedor(int id)
        {
            string mensaje = string.Empty;
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("EliminarProveedor", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdProveedor", id);
                    cn.Open();
                    int i = cmd.ExecuteNonQuery();
                    mensaje = $"Se ha eliminado {i} proveedor(es)";
                }
                catch (Exception ex)
                {
                    mensaje = ex.Message;
                }
                finally
                {
                    cn.Close();
                }
            }
            return mensaje;
        }

    }
}
