using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Proyecto_ADSO.Modelo;

namespace Proyecto_ADSO.Datos
{
    public class ClFichaD
    {
        void EnsureTable(SqlConnection con)
        {
            using (var cmd = new SqlCommand(@"IF OBJECT_ID('dbo.Ficha','U') IS NULL BEGIN
                CREATE TABLE dbo.Ficha (
                    idFicha INT IDENTITY(1,1) PRIMARY KEY,
                    titulo VARCHAR(200) NULL,
                    descripcion VARCHAR(MAX) NULL,
                    fecha DATE NULL,
                    idUsuario INT NULL
                )
            END", con))
            {
                cmd.ExecuteNonQuery();
            }
        }

        public int CrearFicha(ClFicha f)
        {
            var objConexion = new ClConexion();
            var con = objConexion.MtAbrirConexion();
            try
            {
                EnsureTable(con);
                using (var cmd = new SqlCommand("INSERT INTO dbo.Ficha (titulo, descripcion, fecha, idUsuario) VALUES (@titulo, @descripcion, @fecha, @idUsuario); SELECT CAST(SCOPE_IDENTITY() AS INT);", con))
                {
                    cmd.Parameters.Add("@titulo", SqlDbType.VarChar).Value = (object)f.titulo ?? DBNull.Value;
                    var pDesc = cmd.Parameters.Add("@descripcion", SqlDbType.VarChar, -1);
                    pDesc.Value = (object)f.descripcion ?? DBNull.Value;
                    cmd.Parameters.Add("@fecha", SqlDbType.Date).Value = f.fecha.Date;
                    cmd.Parameters.Add("@idUsuario", SqlDbType.Int).Value = f.idUsuario;
                    var id = cmd.ExecuteScalar();
                    return id != null ? Convert.ToInt32(id) : 0;
                }
            }
            finally
            {
                objConexion.MtCerrarConexion();
            }
        }

        public List<ClFicha> ListarFichas()
        {
            var lista = new List<ClFicha>();
            var objConexion = new ClConexion();
            var con = objConexion.MtAbrirConexion();
            try
            {
                EnsureTable(con);
                using (var cmd = new SqlCommand("SELECT idFicha, titulo, descripcion, fecha, idUsuario FROM dbo.Ficha", con))
                using (var rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        var f = new ClFicha
                        {
                            idFicha = rd.GetInt32(0),
                            titulo = rd.IsDBNull(1) ? null : rd.GetString(1),
                            descripcion = rd.IsDBNull(2) ? null : rd.GetString(2),
                            fecha = rd.IsDBNull(3) ? DateTime.MinValue : rd.GetDateTime(3),
                            idUsuario = rd.IsDBNull(4) ? 0 : rd.GetInt32(4)
                        };
                        lista.Add(f);
                    }
                }
                return lista;
            }
            finally
            {
                objConexion.MtCerrarConexion();
            }
        }

        public ClFicha ObtenerFichaPorId(int idFicha)
        {
            ClFicha f = null;
            var objConexion = new ClConexion();
            var con = objConexion.MtAbrirConexion();
            try
            {
                EnsureTable(con);
                using (var cmd = new SqlCommand("SELECT idFicha, titulo, descripcion, fecha, idUsuario FROM dbo.Ficha WHERE idFicha = @id", con))
                {
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = idFicha;
                    using (var rd = cmd.ExecuteReader())
                    {
                        if (rd.Read())
                        {
                            f = new ClFicha
                            {
                                idFicha = rd.GetInt32(0),
                                titulo = rd.IsDBNull(1) ? null : rd.GetString(1),
                                descripcion = rd.IsDBNull(2) ? null : rd.GetString(2),
                                fecha = rd.IsDBNull(3) ? DateTime.MinValue : rd.GetDateTime(3),
                                idUsuario = rd.IsDBNull(4) ? 0 : rd.GetInt32(4)
                            };
                        }
                    }
                }
                return f;
            }
            finally
            {
                objConexion.MtCerrarConexion();
            }
        }

        public bool ActualizarFicha(ClFicha f)
        {
            var objConexion = new ClConexion();
            var con = objConexion.MtAbrirConexion();
            try
            {
                EnsureTable(con);
                using (var cmd = new SqlCommand("UPDATE dbo.Ficha SET titulo=@titulo, descripcion=@descripcion, fecha=@fecha, idUsuario=@idUsuario WHERE idFicha=@idFicha", con))
                {
                    cmd.Parameters.Add("@titulo", SqlDbType.VarChar).Value = (object)f.titulo ?? DBNull.Value;
                    var pDesc = cmd.Parameters.Add("@descripcion", SqlDbType.VarChar, -1);
                    pDesc.Value = (object)f.descripcion ?? DBNull.Value;
                    cmd.Parameters.Add("@fecha", SqlDbType.Date).Value = f.fecha.Date;
                    cmd.Parameters.Add("@idUsuario", SqlDbType.Int).Value = f.idUsuario;
                    cmd.Parameters.Add("@idFicha", SqlDbType.Int).Value = f.idFicha;
                    var rows = cmd.ExecuteNonQuery();
                    return rows > 0;
                }
            }
            finally
            {
                objConexion.MtCerrarConexion();
            }
        }

        public bool EliminarFicha(int idFicha)
        {
            var objConexion = new ClConexion();
            var con = objConexion.MtAbrirConexion();
            try
            {
                EnsureTable(con);
                using (var cmd = new SqlCommand("DELETE FROM dbo.Ficha WHERE idFicha = @id", con))
                {
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = idFicha;
                    var rows = cmd.ExecuteNonQuery();
                    return rows > 0;
                }
            }
            finally
            {
                objConexion.MtCerrarConexion();
            }
        }
    }
}
