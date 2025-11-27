using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using Proyecto_ADSO.Modelo;

namespace Proyecto_ADSO.Datos
{
    public class ClServicioD
    {
        public int CrearServicio(ClServicio servicio)
        {
            var objConexion = new ClConexion();
            var con = objConexion.MtAbrirConexion();
            try
            {
                using (var cmd = new SqlCommand("INSERT INTO Servicio (servicio, img, precio, idCliente) VALUES (@servicio, @img, @precio, @idCliente); SELECT CAST(SCOPE_IDENTITY() AS INT);", con))
                {
                    cmd.Parameters.Add("@servicio", SqlDbType.VarChar).Value = servicio.servicio ?? (object)DBNull.Value;
                    cmd.Parameters.Add("@img", SqlDbType.VarChar).Value = servicio.img ?? (object)DBNull.Value;
                    cmd.Parameters.Add("@precio", SqlDbType.Decimal).Value = servicio.precio;
                    cmd.Parameters.Add("@idCliente", SqlDbType.Int).Value = servicio.idCliente;
                    var id = cmd.ExecuteScalar();
                    return id != null ? Convert.ToInt32(id) : 0;
                }
            }
            finally
            {
                objConexion.MtCerrarConexion();
            }
        }

        public List<ClServicio> ListarServicios()
        {
            var lista = new List<ClServicio>();
            var objConexion = new ClConexion();
            var con = objConexion.MtAbrirConexion();
            try
            {
                using (var cmd = new SqlCommand("SELECT idServicio, servicio, img, precio, idCliente FROM Servicio", con))
                using (var rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        var s = new ClServicio
                        {
                            idServicio = rd.GetInt32(0),
                            servicio = rd.IsDBNull(1) ? null : rd.GetString(1),
                            img = rd.IsDBNull(2) ? null : rd.GetString(2),
                            precio = rd.GetDecimal(3),
                            idCliente = rd.GetInt32(4)
                        };
                        lista.Add(s);
                    }
                }
                return lista;
            }
            finally
            {
                objConexion.MtCerrarConexion();
            }
        }

        public ClServicio ObtenerServicioPorId(int idServicio)
        {
            ClServicio s = null;
            var objConexion = new ClConexion();
            var con = objConexion.MtAbrirConexion();
            try
            {
                using (var cmd = new SqlCommand("SELECT idServicio, servicio, img, precio, idCliente FROM Servicio WHERE idServicio = @idServicio", con))
                {
                    cmd.Parameters.Add("@idServicio", SqlDbType.Int).Value = idServicio;
                    using (var rd = cmd.ExecuteReader())
                    {
                        if (rd.Read())
                        {
                            s = new ClServicio
                            {
                                idServicio = rd.GetInt32(0),
                                servicio = rd.IsDBNull(1) ? null : rd.GetString(1),
                                img = rd.IsDBNull(2) ? null : rd.GetString(2),
                                precio = rd.GetDecimal(3),
                                idCliente = rd.GetInt32(4)
                            };
                        }
                    }
                }
                return s;
            }
            finally
            {
                objConexion.MtCerrarConexion();
            }
        }

        public bool ActualizarServicio(ClServicio servicio)
        {
            var objConexion = new ClConexion();
            var con = objConexion.MtAbrirConexion();
            try
            {
                using (var cmd = new SqlCommand("UPDATE Servicio SET servicio = @servicio, img = @img, precio = @precio, idCliente = @idCliente WHERE idServicio = @idServicio", con))
                {
                    cmd.Parameters.Add("@servicio", SqlDbType.VarChar).Value = servicio.servicio ?? (object)DBNull.Value;
                    cmd.Parameters.Add("@img", SqlDbType.VarChar).Value = servicio.img ?? (object)DBNull.Value;
                    cmd.Parameters.Add("@precio", SqlDbType.Decimal).Value = servicio.precio;
                    cmd.Parameters.Add("@idCliente", SqlDbType.Int).Value = servicio.idCliente;
                    cmd.Parameters.Add("@idServicio", SqlDbType.Int).Value = servicio.idServicio;
                    var rows = cmd.ExecuteNonQuery();
                    return rows > 0;
                }
            }
            finally
            {
                objConexion.MtCerrarConexion();
            }
        }

        public bool EliminarServicio(int idServicio)
        {
            var objConexion = new ClConexion();
            var con = objConexion.MtAbrirConexion();
            try
            {
                using (var cmd = new SqlCommand("DELETE FROM Servicio WHERE idServicio = @idServicio", con))
                {
                    cmd.Parameters.Add("@idServicio", SqlDbType.Int).Value = idServicio;
                    var rows = cmd.ExecuteNonQuery();
                    return rows > 0;
                }
            }
            finally
            {
                objConexion.MtCerrarConexion();
            }
        }

        public List<ClServicio> BuscarServiciosPorNombre(string nombre)
        {
            var lista = new List<ClServicio>();
            var objConexion = new ClConexion();
            var con = objConexion.MtAbrirConexion();
            try
            {
                using (var cmd = new SqlCommand("SELECT idServicio, servicio, img, precio, idCliente FROM Servicio WHERE servicio LIKE @q", con))
                {
                    cmd.Parameters.Add("@q", SqlDbType.VarChar).Value = "%" + nombre + "%";
                    using (var rd = cmd.ExecuteReader())
                    {
                        while (rd.Read())
                        {
                            var s = new ClServicio
                            {
                                idServicio = rd.GetInt32(0),
                                servicio = rd.IsDBNull(1) ? null : rd.GetString(1),
                                img = rd.IsDBNull(2) ? null : rd.GetString(2),
                                precio = rd.GetDecimal(3),
                                idCliente = rd.GetInt32(4)
                            };
                            lista.Add(s);
                        }
                    }
                }
                return lista;
            }
            finally
            {
                objConexion.MtCerrarConexion();
            }
        }
    }
}
