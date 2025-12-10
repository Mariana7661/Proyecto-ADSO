using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using Proyecto_ADSO.Modelo;

namespace Proyecto_ADSO.Datos
{
    public class ClCitaD
    {
        public int CrearCita(ClCita cita)
        {
            if (cita == null || cita.idUsuario <= 0)
                throw new ArgumentException("Cita inválida: requiere cliente asociado");

            var objConexion = new ClConexion();
            var con = objConexion.MtAbrirConexion();
            try
            {
                bool hasServicio;
                using (var cmdCol = new SqlCommand("SELECT COL_LENGTH('dbo.Cita','idServicio')", con))
                {
                    var v = cmdCol.ExecuteScalar();
                    hasServicio = v != null && v != DBNull.Value;
                }
                var sql = hasServicio
                    ? "INSERT INTO Cita (fecha, hora, idUsuario, idServicio) VALUES (@fecha, @hora, @idUsuario, @idServicio); SELECT CAST(SCOPE_IDENTITY() AS INT);"
                    : "INSERT INTO Cita (fecha, hora, idUsuario) VALUES (@fecha, @hora, @idUsuario); SELECT CAST(SCOPE_IDENTITY() AS INT);";
                using (var cmd = new SqlCommand(sql, con))
                {
                    cmd.Parameters.Add("@fecha", SqlDbType.Date).Value = cita.fecha.Date;
                    cmd.Parameters.Add("@hora", SqlDbType.Time).Value = cita.hora;
                    cmd.Parameters.Add("@idUsuario", SqlDbType.Int).Value = cita.idUsuario;
                    if (hasServicio)
                        cmd.Parameters.Add("@idServicio", SqlDbType.Int).Value = cita.idServicio;
                    var id = cmd.ExecuteScalar();
                    return id != null ? Convert.ToInt32(id) : 0;
                }
            }
            finally
            {
                objConexion.MtCerrarConexion();
            }
        }

        public List<ClCita> ListarCitasCliente(int idCliente)
        {
            var lista = new List<ClCita>();
            var objConexion = new ClConexion();
            var con = objConexion.MtAbrirConexion();
            try
            {
                bool hasServicio;
                using (var cmdCol = new SqlCommand("SELECT COL_LENGTH('dbo.Cita','idServicio')", con))
                {
                    var v = cmdCol.ExecuteScalar();
                    hasServicio = v != null && v != DBNull.Value;
                }
                var sql = hasServicio
                    ? "SELECT idCita, fecha, hora, idUsuario, idServicio FROM Cita WHERE idUsuario = @idCliente"
                    : "SELECT idCita, fecha, hora, idUsuario FROM Cita WHERE idUsuario = @idCliente";
                using (var cmd = new SqlCommand(sql, con))
                {
                    cmd.Parameters.Add("@idCliente", SqlDbType.Int).Value = idCliente;
                    using (var rd = cmd.ExecuteReader())
                    {
                        while (rd.Read())
                        {
                            var c = new ClCita
                            {
                                idCita = rd.GetInt32(0),
                                fecha = rd.GetDateTime(1),
                                hora = (TimeSpan)rd[2],
                                idUsuario = rd.GetInt32(3),
                                idServicio = hasServicio ? rd.GetInt32(4) : 0
                            };
                            lista.Add(c);
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

        public List<ClCita> ListarTodasCitas()
        {
            var lista = new List<ClCita>();
            var objConexion = new ClConexion();
            var con = objConexion.MtAbrirConexion();
            try
            {
                bool hasServicio;
                using (var cmdCol = new SqlCommand("SELECT COL_LENGTH('dbo.Cita','idServicio')", con))
                {
                    var v = cmdCol.ExecuteScalar();
                    hasServicio = v != null && v != DBNull.Value;
                }
                var sql = hasServicio
                    ? "SELECT idCita, fecha, hora, idUsuario, idServicio FROM Cita"
                    : "SELECT idCita, fecha, hora, idUsuario FROM Cita";
                using (var cmd = new SqlCommand(sql, con))
                using (var rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        var c = new ClCita
                        {
                            idCita = rd.GetInt32(0),
                            fecha = rd.GetDateTime(1),
                            hora = (TimeSpan)rd[2],
                            idUsuario = rd.GetInt32(3),
                            idServicio = hasServicio ? rd.GetInt32(4) : 0
                        };
                        lista.Add(c);
                    }
                }
                return lista;
            }
            finally
            {
                objConexion.MtCerrarConexion();
            }
        }

        public bool CancelarCita(int idCita, int idCliente)
        {
            var objConexion = new ClConexion();
            var con = objConexion.MtAbrirConexion();
            try
            {
                using (var cmd = new SqlCommand("DELETE FROM Cita WHERE idCita = @idCita AND idUsuario = @idCliente", con))
                {
                    cmd.Parameters.Add("@idCita", SqlDbType.Int).Value = idCita;
                    cmd.Parameters.Add("@idCliente", SqlDbType.Int).Value = idCliente;
                    var rows = cmd.ExecuteNonQuery();
                    return rows > 0;
                }
            }
            finally
            {
                objConexion.MtCerrarConexion();
            }
        }

        public bool CancelarCitaAdmin(int idCita)
        {
            var objConexion = new ClConexion();
            var con = objConexion.MtAbrirConexion();
            try
            {
                using (var cmd = new SqlCommand("DELETE FROM Cita WHERE idCita = @idCita", con))
                {
                    cmd.Parameters.Add("@idCita", SqlDbType.Int).Value = idCita;
                    var rows = cmd.ExecuteNonQuery();
                    return rows > 0;
                }
            }
            finally
            {
                objConexion.MtCerrarConexion();
            }
        }

        public bool ActualizarCita(ClCita cita)
        {
            var objConexion = new ClConexion();
            var con = objConexion.MtAbrirConexion();
            try
            {
                bool hasServicio;
                using (var cmdCol = new SqlCommand("SELECT COL_LENGTH('dbo.Cita','idServicio')", con))
                {
                    var v = cmdCol.ExecuteScalar();
                    hasServicio = v != null && v != DBNull.Value;
                }
                var sql = hasServicio
                    ? "UPDATE Cita SET fecha=@fecha, hora=@hora, idUsuario=@idUsuario, idServicio=@idServicio WHERE idCita=@idCita"
                    : "UPDATE Cita SET fecha=@fecha, hora=@hora, idUsuario=@idUsuario WHERE idCita=@idCita";
                using (var cmd = new SqlCommand(sql, con))
                {
                    cmd.Parameters.Add("@fecha", SqlDbType.Date).Value = cita.fecha.Date;
                    cmd.Parameters.Add("@hora", SqlDbType.Time).Value = cita.hora;
                    cmd.Parameters.Add("@idUsuario", SqlDbType.Int).Value = cita.idUsuario;
                    if (hasServicio)
                        cmd.Parameters.Add("@idServicio", SqlDbType.Int).Value = cita.idServicio;
                    cmd.Parameters.Add("@idCita", SqlDbType.Int).Value = cita.idCita;
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
