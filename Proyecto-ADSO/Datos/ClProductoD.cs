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
                using (var cmd = new SqlCommand("INSERT INTO Producto (nombre, img, precio, idCliente) VALUES (@nombre, @img, @precio, @idCliente); SELECT CAST(SCOPE_IDENTITY() AS INT);", con))
                {
                    cmd.Parameters.Add("@nombre", SqlDbType.VarChar).Value = producto.nombre ?? (object)DBNull.Value;
                    cmd.Parameters.Add("@img", SqlDbType.VarChar).Value = producto.img ?? (object)DBNull.Value;
                    cmd.Parameters.Add("@precio", SqlDbType.Decimal).Value = producto.precio;
                    cmd.Parameters.Add("@idCliente", SqlDbType.Int).Value = producto.idCliente;
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
                using (var cmd = new SqlCommand("SELECT idProducto, nombre, img, precio, idCliente FROM Producto", con))
                using (var rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        var p = new ClProducto
                        {
                            idProducto = rd.GetInt32(0),
                            nombre = rd.IsDBNull(1) ? null : rd.GetString(1),
                            img = rd.IsDBNull(2) ? null : rd.GetString(2),
                            precio = rd.GetDecimal(3),
                            idCliente = rd.GetInt32(4)
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
                using (var cmd = new SqlCommand("SELECT idProducto, nombre, img, precio, idCliente FROM Producto WHERE idProducto = @idProducto", con))
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
                                precio = rd.GetDecimal(3),
                                idCliente = rd.GetInt32(4)
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
                using (var cmd = new SqlCommand("UPDATE Producto SET nombre = @nombre, img = @img, precio = @precio, idCliente = @idCliente WHERE idProducto = @idProducto", con))
                {
                    cmd.Parameters.Add("@nombre", SqlDbType.VarChar).Value = producto.nombre ?? (object)DBNull.Value;
                    cmd.Parameters.Add("@img", SqlDbType.VarChar).Value = producto.img ?? (object)DBNull.Value;
                    cmd.Parameters.Add("@precio", SqlDbType.Decimal).Value = producto.precio;
                    cmd.Parameters.Add("@idCliente", SqlDbType.Int).Value = producto.idCliente;
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
                using (var cmd = new SqlCommand("SELECT idProducto, nombre, img, precio, idCliente FROM Producto WHERE nombre LIKE @q", con))
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
                                precio = rd.GetDecimal(3),
                                idCliente = rd.GetInt32(4)
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
