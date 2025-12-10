using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using Proyecto_ADSO.Modelo;

namespace Proyecto_ADSO.Datos
{
    public class ClProductoD
    {
        public int CrearProducto(ClProducto producto)
        {
            var objConexion = new ClConexion();
            var con = objConexion.MtAbrirConexion();
            try
            {
                string userCol;
                using (var cmdCol = new SqlCommand("SELECT CASE WHEN COL_LENGTH('dbo.producto','idUsuario') IS NOT NULL THEN 'idUsuario' WHEN COL_LENGTH('dbo.producto','idCliente') IS NOT NULL THEN 'idCliente' ELSE '' END", con))
                {
                    userCol = cmdCol.ExecuteScalar() as string ?? string.Empty;
                }
                bool hasDesc;
                using (var cmdDesc = new SqlCommand("SELECT COL_LENGTH('dbo.producto','descripcion')", con))
                {
                    var v = cmdDesc.ExecuteScalar();
                    hasDesc = v != null && v != DBNull.Value;
                }
                string sql = string.IsNullOrEmpty(userCol)
                    ? (hasDesc ? "INSERT INTO dbo.producto (nombre, img, descripcion, precio) VALUES (@nombre, @img, @descripcion, @precio); SELECT CAST(SCOPE_IDENTITY() AS INT);" : "INSERT INTO dbo.producto (nombre, img, precio) VALUES (@nombre, @img, @precio); SELECT CAST(SCOPE_IDENTITY() AS INT);")
                    : (hasDesc ? $"INSERT INTO dbo.producto (nombre, img, descripcion, precio, {userCol}) VALUES (@nombre, @img, @descripcion, @precio, @idUser); SELECT CAST(SCOPE_IDENTITY() AS INT);" : $"INSERT INTO dbo.producto (nombre, img, precio, {userCol}) VALUES (@nombre, @img, @precio, @idUser); SELECT CAST(SCOPE_IDENTITY() AS INT);");
                using (var cmd = new SqlCommand(sql, con))
                {
                    cmd.Parameters.Add("@nombre", SqlDbType.VarChar).Value = producto.nombre ?? (object)DBNull.Value;
                    cmd.Parameters.Add("@img", SqlDbType.VarChar).Value = producto.img ?? (object)DBNull.Value;
                    if (hasDesc)
                    {
                        var pDesc = cmd.Parameters.Add("@descripcion", SqlDbType.VarChar, -1);
                        pDesc.Value = producto.descripcion ?? (object)DBNull.Value;
                    }
                    cmd.Parameters.Add("@precio", SqlDbType.Decimal).Value = producto.precio;
                    if (!string.IsNullOrEmpty(userCol))
                    {
                        var pUser = cmd.Parameters.Add("@idUser", SqlDbType.Int);
                        pUser.Value = producto.idUsuario > 0 ? (object)producto.idUsuario : DBNull.Value;
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

        public List<ClProducto> ListarProductos()
        {
            var lista = new List<ClProducto>();
            var objConexion = new ClConexion();
            var con = objConexion.MtAbrirConexion();
            try
            {
                string userCol;
                using (var cmdCol = new SqlCommand("SELECT CASE WHEN COL_LENGTH('dbo.producto','idUsuario') IS NOT NULL THEN 'idUsuario' WHEN COL_LENGTH('dbo.producto','idCliente') IS NOT NULL THEN 'idCliente' ELSE '' END", con))
                {
                    userCol = cmdCol.ExecuteScalar() as string ?? string.Empty;
                }
                bool hasDesc;
                using (var cmdDesc = new SqlCommand("SELECT COL_LENGTH('dbo.producto','descripcion')", con))
                {
                    var v = cmdDesc.ExecuteScalar();
                    hasDesc = v != null && v != DBNull.Value;
                }
                string sql = string.IsNullOrEmpty(userCol)
                    ? (hasDesc ? "SELECT idProducto, nombre, img, descripcion, precio, NULL AS idUser FROM dbo.producto" : "SELECT idProducto, nombre, img, precio, NULL AS idUser FROM dbo.producto")
                    : (hasDesc ? $"SELECT idProducto, nombre, img, descripcion, precio, {userCol} AS idUser FROM dbo.producto" : $"SELECT idProducto, nombre, img, precio, {userCol} AS idUser FROM dbo.producto");
                using (var cmd = new SqlCommand(sql, con))
                using (var rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        var p = new ClProducto
                        {
                            idProducto = rd.GetInt32(0),
                            nombre = rd.IsDBNull(1) ? null : rd.GetString(1),
                            img = rd.IsDBNull(2) ? null : rd.GetString(2),
                            descripcion = hasDesc ? (rd.IsDBNull(3) ? null : rd.GetString(3)) : null,
                            precio = rd.GetDecimal(hasDesc ? 4 : 3),
                            idUsuario = rd.IsDBNull(hasDesc ? 5 : 4) ? 0 : rd.GetInt32(hasDesc ? 5 : 4)
                        };
                        lista.Add(p);
                    }
                }
                return lista;
            }
            finally
            {
                objConexion.MtCerrarConexion();
            }
        }

        public ClProducto ObtenerProductoPorId(int idProducto)
        {
            ClProducto p = null;
            var objConexion = new ClConexion();
            var con = objConexion.MtAbrirConexion();
            try
            {
                string userCol;
                using (var cmdCol = new SqlCommand("SELECT CASE WHEN COL_LENGTH('dbo.producto','idUsuario') IS NOT NULL THEN 'idUsuario' WHEN COL_LENGTH('dbo.producto','idCliente') IS NOT NULL THEN 'idCliente' ELSE '' END", con))
                {
                    userCol = cmdCol.ExecuteScalar() as string ?? string.Empty;
                }
                bool hasDesc;
                using (var cmdDesc = new SqlCommand("SELECT COL_LENGTH('dbo.producto','descripcion')", con))
                {
                    var v = cmdDesc.ExecuteScalar();
                    hasDesc = v != null && v != DBNull.Value;
                }
                string sql = string.IsNullOrEmpty(userCol)
                    ? (hasDesc ? "SELECT idProducto, nombre, img, descripcion, precio, NULL AS idUser FROM dbo.producto WHERE idProducto = @idProducto" : "SELECT idProducto, nombre, img, precio, NULL AS idUser FROM dbo.producto WHERE idProducto = @idProducto")
                    : (hasDesc ? $"SELECT idProducto, nombre, img, descripcion, precio, {userCol} AS idUser FROM dbo.producto WHERE idProducto = @idProducto" : $"SELECT idProducto, nombre, img, precio, {userCol} AS idUser FROM dbo.producto WHERE idProducto = @idProducto");
                using (var cmd = new SqlCommand(sql, con))
                {
                    cmd.Parameters.Add("@idProducto", SqlDbType.Int).Value = idProducto;
                    using (var rd = cmd.ExecuteReader())
                    {
                        if (rd.Read())
                        {
                            p = new ClProducto
                            {
                                idProducto = rd.GetInt32(0),
                                nombre = rd.IsDBNull(1) ? null : rd.GetString(1),
                                img = rd.IsDBNull(2) ? null : rd.GetString(2),
                                descripcion = hasDesc ? (rd.IsDBNull(3) ? null : rd.GetString(3)) : null,
                                precio = rd.GetDecimal(hasDesc ? 4 : 3),
                                idUsuario = rd.IsDBNull(hasDesc ? 5 : 4) ? 0 : rd.GetInt32(hasDesc ? 5 : 4)
                            };
                        }
                    }
                }
                return p;
            }
            finally
            {
                objConexion.MtCerrarConexion();
            }
        }

        public bool ActualizarProducto(ClProducto producto)
        {
            var objConexion = new ClConexion();
            var con = objConexion.MtAbrirConexion();
            try
            {
                string userCol;
                using (var cmdCol = new SqlCommand("SELECT CASE WHEN COL_LENGTH('dbo.producto','idUsuario') IS NOT NULL THEN 'idUsuario' WHEN COL_LENGTH('dbo.producto','idCliente') IS NOT NULL THEN 'idCliente' ELSE '' END", con))
                {
                    userCol = cmdCol.ExecuteScalar() as string ?? string.Empty;
                }
                bool hasDesc;
                using (var cmdDesc = new SqlCommand("SELECT COL_LENGTH('dbo.producto','descripcion')", con))
                {
                    var v = cmdDesc.ExecuteScalar();
                    hasDesc = v != null && v != DBNull.Value && Convert.ToInt32(v) > 0;
                }
                string sql = string.IsNullOrEmpty(userCol)
                    ? (hasDesc ? "UPDATE dbo.producto SET nombre = @nombre, img = @img, descripcion = @descripcion, precio = @precio WHERE idProducto = @idProducto" : "UPDATE dbo.producto SET nombre = @nombre, img = @img, precio = @precio WHERE idProducto = @idProducto")
                    : (hasDesc ? $"UPDATE dbo.producto SET nombre = @nombre, img = @img, descripcion = @descripcion, precio = @precio, {userCol} = @idUser WHERE idProducto = @idProducto" : $"UPDATE dbo.producto SET nombre = @nombre, img = @img, precio = @precio, {userCol} = @idUser WHERE idProducto = @idProducto");
                using (var cmd = new SqlCommand(sql, con))
                {
                    cmd.Parameters.Add("@nombre", SqlDbType.VarChar).Value = producto.nombre ?? (object)DBNull.Value;
                    cmd.Parameters.Add("@img", SqlDbType.VarChar).Value = producto.img ?? (object)DBNull.Value;
                    if (hasDesc)
                    {
                        var pDesc = cmd.Parameters.Add("@descripcion", SqlDbType.VarChar, -1);
                        pDesc.Value = producto.descripcion ?? (object)DBNull.Value;
                    }
                    cmd.Parameters.Add("@precio", SqlDbType.Decimal).Value = producto.precio;
                    if (!string.IsNullOrEmpty(userCol))
                    {
                        var pUser = cmd.Parameters.Add("@idUser", SqlDbType.Int);
                        pUser.Value = producto.idUsuario > 0 ? (object)producto.idUsuario : DBNull.Value;
                    }
                    cmd.Parameters.Add("@idProducto", SqlDbType.Int).Value = producto.idProducto;
                    var rows = cmd.ExecuteNonQuery();
                    return rows > 0;
                }
            }
            finally
            {
                objConexion.MtCerrarConexion();
            }
        }

        public bool EliminarProducto(int idProducto)
        {
            var objConexion = new ClConexion();
            var con = objConexion.MtAbrirConexion();
            try
            {
                using (var cmd = new SqlCommand("DELETE FROM Producto WHERE idProducto = @idProducto", con))
                {
                    cmd.Parameters.Add("@idProducto", SqlDbType.Int).Value = idProducto;
                    var rows = cmd.ExecuteNonQuery();
                    return rows > 0;
                }
            }
            finally
            {
                objConexion.MtCerrarConexion();
            }
        }

        public List<ClProducto> BuscarProductosPorNombre(string nombre)
        {
            var lista = new List<ClProducto>();
            var objConexion = new ClConexion();
            var con = objConexion.MtAbrirConexion();
            try
            {
                string userCol;
                using (var cmdCol = new SqlCommand("SELECT CASE WHEN COL_LENGTH('dbo.producto','idUsuario') IS NOT NULL THEN 'idUsuario' WHEN COL_LENGTH('dbo.producto','idCliente') IS NOT NULL THEN 'idCliente' ELSE '' END", con))
                {
                    userCol = cmdCol.ExecuteScalar() as string ?? string.Empty;
                }
                bool hasDesc;
                using (var cmdDesc = new SqlCommand("SELECT COL_LENGTH('dbo.producto','descripcion')", con))
                {
                    var v = cmdDesc.ExecuteScalar();
                    hasDesc = v != null && v != DBNull.Value;
                }
                string sql = string.IsNullOrEmpty(userCol)
                    ? (hasDesc ? "SELECT idProducto, nombre, img, descripcion, precio, NULL AS idUser FROM dbo.producto WHERE nombre LIKE @q" : "SELECT idProducto, nombre, img, precio, NULL AS idUser FROM dbo.producto WHERE nombre LIKE @q")
                    : (hasDesc ? $"SELECT idProducto, nombre, img, descripcion, precio, {userCol} AS idUser FROM dbo.producto WHERE nombre LIKE @q" : $"SELECT idProducto, nombre, img, precio, {userCol} AS idUser FROM dbo.producto WHERE nombre LIKE @q");
                using (var cmd = new SqlCommand(sql, con))
                {
                    cmd.Parameters.Add("@q", SqlDbType.VarChar).Value = "%" + nombre + "%";
                    using (var rd = cmd.ExecuteReader())
                    {
                        while (rd.Read())
                        {
                            var p = new ClProducto
                            {
                                idProducto = rd.GetInt32(0),
                                nombre = rd.IsDBNull(1) ? null : rd.GetString(1),
                                img = rd.IsDBNull(2) ? null : rd.GetString(2),
                                descripcion = hasDesc ? (rd.IsDBNull(3) ? null : rd.GetString(3)) : null,
                                precio = rd.GetDecimal(hasDesc ? 4 : 3),
                                idUsuario = rd.IsDBNull(hasDesc ? 5 : 4) ? 0 : rd.GetInt32(hasDesc ? 5 : 4)
                            };
                            lista.Add(p);
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
