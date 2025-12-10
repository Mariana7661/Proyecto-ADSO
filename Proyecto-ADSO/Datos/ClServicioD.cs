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
                string userCol;
                using (var cmdCol = new SqlCommand("SELECT CASE WHEN COL_LENGTH('dbo.servicio','idUsuario') IS NOT NULL THEN 'idUsuario' WHEN COL_LENGTH('dbo.servicio','idCliente') IS NOT NULL THEN 'idCliente' ELSE '' END", con))
                {
                    userCol = cmdCol.ExecuteScalar() as string ?? string.Empty;
                }
                string sql = string.IsNullOrEmpty(userCol)
                    ? "INSERT INTO dbo.servicio (servicio, img, precio) VALUES (@servicio, @img, @precio); SELECT CAST(SCOPE_IDENTITY() AS INT);"
                    : $"INSERT INTO dbo.servicio (servicio, img, precio, {userCol}) VALUES (@servicio, @img, @precio, @idUser); SELECT CAST(SCOPE_IDENTITY() AS INT);";
                using (var cmd = new SqlCommand(sql, con))
                {
                    cmd.Parameters.Add("@servicio", SqlDbType.VarChar).Value = servicio.servicio ?? (object)DBNull.Value;
                    cmd.Parameters.Add("@img", SqlDbType.VarChar).Value = servicio.img ?? (object)DBNull.Value;
                    cmd.Parameters.Add("@precio", SqlDbType.Decimal).Value = servicio.precio;
                    if (!string.IsNullOrEmpty(userCol))
                    {
                        var pUser = cmd.Parameters.Add("@idUser", SqlDbType.Int);
                        pUser.Value = servicio.idUsuario > 0 ? (object)servicio.idUsuario : DBNull.Value;
                    }
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
                string userCol;
                using (var cmdCol = new SqlCommand("SELECT CASE WHEN COL_LENGTH('dbo.servicio','idUsuario') IS NOT NULL THEN 'idUsuario' WHEN COL_LENGTH('dbo.servicio','idCliente') IS NOT NULL THEN 'idCliente' ELSE '' END", con))
                {
                    userCol = cmdCol.ExecuteScalar() as string ?? string.Empty;
                }
                string sql = string.IsNullOrEmpty(userCol)
                    ? "SELECT idServicio, servicio, img, precio, NULL AS idUser FROM dbo.servicio"
                    : $"SELECT idServicio, servicio, img, precio, {userCol} AS idUser FROM dbo.servicio";
                using (var cmd = new SqlCommand(sql, con))
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
                            idUsuario = rd.GetInt32(4)
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
                string userCol;
                using (var cmdCol = new SqlCommand("SELECT CASE WHEN COL_LENGTH('dbo.servicio','idUsuario') IS NOT NULL THEN 'idUsuario' WHEN COL_LENGTH('dbo.servicio','idCliente') IS NOT NULL THEN 'idCliente' ELSE '' END", con))
                {
                    userCol = cmdCol.ExecuteScalar() as string ?? string.Empty;
                }
                string sql = string.IsNullOrEmpty(userCol)
                    ? "SELECT idServicio, servicio, img, precio, NULL AS idUser FROM dbo.servicio WHERE idServicio = @idServicio"
                    : $"SELECT idServicio, servicio, img, precio, {userCol} AS idUser FROM dbo.servicio WHERE idServicio = @idServicio";
                using (var cmd = new SqlCommand(sql, con))
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
                                idUsuario = rd.GetInt32(4)
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
                string userCol;
                using (var cmdCol = new SqlCommand("SELECT CASE WHEN COL_LENGTH('dbo.servicio','idUsuario') IS NOT NULL THEN 'idUsuario' WHEN COL_LENGTH('dbo.servicio','idCliente') IS NOT NULL THEN 'idCliente' ELSE '' END", con))
                {
                    userCol = cmdCol.ExecuteScalar() as string ?? string.Empty;
                }
                string sql = string.IsNullOrEmpty(userCol)
                    ? "UPDATE dbo.servicio SET servicio = @servicio, img = @img, precio = @precio WHERE idServicio = @idServicio"
                    : $"UPDATE dbo.servicio SET servicio = @servicio, img = @img, precio = @precio, {userCol} = @idUser WHERE idServicio = @idServicio";
                using (var cmd = new SqlCommand(sql, con))
                {
                    cmd.Parameters.Add("@servicio", SqlDbType.VarChar).Value = servicio.servicio ?? (object)DBNull.Value;
                    cmd.Parameters.Add("@img", SqlDbType.VarChar).Value = servicio.img ?? (object)DBNull.Value;
                    cmd.Parameters.Add("@precio", SqlDbType.Decimal).Value = servicio.precio;
                    if (!string.IsNullOrEmpty(userCol))
                        cmd.Parameters.Add("@idUser", SqlDbType.Int).Value = servicio.idUsuario;
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

        public bool EliminarServicioPorNombre(string nombre)
        {
            var objConexion = new ClConexion();
            var con = objConexion.MtAbrirConexion();
            try
            {
                using (var cmd = new SqlCommand("DELETE FROM Servicio WHERE servicio = @nombre", con))
                {
                    cmd.Parameters.Add("@nombre", SqlDbType.VarChar).Value = nombre;
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
                string userCol;
                using (var cmdCol = new SqlCommand("SELECT CASE WHEN COL_LENGTH('dbo.servicio','idUsuario') IS NOT NULL THEN 'idUsuario' WHEN COL_LENGTH('dbo.servicio','idCliente') IS NOT NULL THEN 'idCliente' ELSE '' END", con))
                {
                    userCol = cmdCol.ExecuteScalar() as string ?? string.Empty;
                }
                string sql = string.IsNullOrEmpty(userCol)
                    ? "SELECT idServicio, servicio, img, precio, NULL AS idUser FROM dbo.servicio WHERE servicio LIKE @q"
                    : $"SELECT idServicio, servicio, img, precio, {userCol} AS idUser FROM dbo.servicio WHERE servicio LIKE @q";
                using (var cmd = new SqlCommand(sql, con))
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
                                idUsuario = rd.GetInt32(4)
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
