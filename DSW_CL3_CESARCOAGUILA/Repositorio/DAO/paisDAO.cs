using Microsoft.Data.SqlClient;
using System.Data;
using DSW_CL3_CESARCOAGUILA.Models;
using DSW_CL3_CESARCOAGUILA.Repositorio.Interfaces;

namespace DSW_CL3_CESARCOAGUILA.Repositorio.DAO
{
    public class paisDAO : IPais
    {
        private readonly string cadena;
        public paisDAO()
        {
            cadena = new ConfigurationBuilder().AddJsonFile("appsettings.json").
                Build().GetConnectionString("sql");
        }
        public IEnumerable<Pais> ListarPaises()
        {
            List<Pais> lista = new List<Pais>();
            using (SqlConnection cn = new SqlConnection(cadena)) 
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("ListarPaises", cn);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    lista.Add(new Pais()
                    {
                        idpais = dr.GetString(0),
                        nombrepais = dr.GetString(1),
                    });
                }
                dr.Close();
            }
            return lista;
        }
    }
}
