using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RESTServices.Dominio;
using System.Data.SqlClient;

namespace RESTServices.Persistencia
{
    public class ProveedorDAO
    {
        public Proveedor Crear(Proveedor proveedorACrear)
        {
            Proveedor proveedorCreado = null;
            string sql = "INSERT INTO tbl_Proveedor VALUES (@ruc, @tip, @raz, @tlf, @cor)";
            using (SqlConnection con = new SqlConnection(ConexionUtil.Cadena))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand(sql, con))
                {
                    com.Parameters.Add(new SqlParameter("@ruc", proveedorACrear.Ruc));
                    com.Parameters.Add(new SqlParameter("@tip", proveedorACrear.Tipo));
                    com.Parameters.Add(new SqlParameter("@raz", proveedorACrear.RazonSocial));
                    com.Parameters.Add(new SqlParameter("@tlf", proveedorACrear.Telefono));
                    com.Parameters.Add(new SqlParameter("@cor", proveedorACrear.Email));
                    com.ExecuteNonQuery();
                }
            }
            proveedorCreado = Obtener(proveedorACrear.Ruc);
            return proveedorCreado;
        }
        
        public Proveedor Obtener(string ruc)
        {
            Proveedor proveedorEncontrado = null;
            string sql = "SELECT * FROM tbl_Proveedor WHERE Ruc_Proveedor = @ruc";
            using (SqlConnection con = new SqlConnection(ConexionUtil.Cadena))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand(sql, con))
                {
                    com.Parameters.Add(new SqlParameter("@ruc", ruc));
                    using (SqlDataReader resultado = com.ExecuteReader())
                    {
                        if (resultado.Read())
                        {
                            proveedorEncontrado = new Proveedor()
                            {
                                Ruc = (string)resultado["Ruc_Proveedor"],
                                Tipo = (string)resultado["Tip_Proveedor"],
                                RazonSocial = (string)resultado["Raz_Proveedor"],
                                Telefono = (string)resultado["Tlf_Proveedor"],
                                Email = (string)resultado["Mail_Proveedor"]
                            };
                        }
                    }
                }
            }
            return proveedorEncontrado;
        }

        public Proveedor Modificar(Proveedor proveedorAModificar)
        {
            Proveedor proveedorModificado = null;
            string sql = "UPDATE tbl_Proveedor SET Tip_Proveedor = @tip, Raz_Proveedor = @raz, Tlf_Proveedor = @tlf, Mail_Proveedor = @cor WHERE Ruc_Proveedor = @ruc";
            using (SqlConnection con = new SqlConnection(ConexionUtil.Cadena))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand(sql, con))
                {
                    com.Parameters.Add(new SqlParameter("@ruc", proveedorAModificar.Ruc));
                    com.Parameters.Add(new SqlParameter("@tip", proveedorAModificar.Tipo));
                    com.Parameters.Add(new SqlParameter("@raz", proveedorAModificar.RazonSocial));
                    com.Parameters.Add(new SqlParameter("@tlf", proveedorAModificar.Telefono));
                    com.Parameters.Add(new SqlParameter("@cor", proveedorAModificar.Email));
                    com.ExecuteNonQuery();
                }
            }
            proveedorModificado = Obtener(proveedorAModificar.Ruc);
            return proveedorModificado;
        }
        public void Eliminar(string ruc)
        {
            string sql = "DELETE FROM tbl_Proveedor WHERE Ruc_Proveedor = @ruc";
            using (SqlConnection con = new SqlConnection(ConexionUtil.Cadena))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand(sql, con))
                {
                    com.Parameters.Add(new SqlParameter("@ruc", ruc));
                    com.ExecuteNonQuery();
                }
            }
        }
        public List<Proveedor> ListarTodos()
        {
            List<Proveedor> proveedoresEncontrados = new List<Proveedor>();
            Proveedor proveedorEncontrado = null;
            string sql = "SELECT * FROM tbl_Proveedor";
            using (SqlConnection con = new SqlConnection(ConexionUtil.Cadena))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand(sql, con))
                {
                    using (SqlDataReader resultado = com.ExecuteReader())
                    {
                        if (resultado.Read())
                        {
                            proveedorEncontrado = new Proveedor()
                            {
                                Ruc = (string)resultado["Ruc_Proveedor"],
                                Tipo = (string)resultado["Tip_Proveedor"],
                                RazonSocial = (string)resultado["Raz_Proveedor"],
                                Telefono = (string)resultado["Tlf_Proveedor"],
                                Email = (string)resultado["Mail_Proveedor"]
                            };
                            proveedoresEncontrados.Add(proveedorEncontrado);
                        }
                    }
                }
            }
            return proveedoresEncontrados;
        }
    }
}