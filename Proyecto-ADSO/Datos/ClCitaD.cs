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
            if (cita == null || cita.idCliente <= 0)
                throw new ArgumentException("Cita inválida: requiere cliente asociado");

            var objConexion = new ClConexion();
            var con = objConexion.MtAbrirConexion();
            try
            {
                using (var cmd = new SqlCommand("INSERT INTO Cita (fecha, hora, idCliente) VALUES (@fecha, @hora, @idCliente); SELECT CAST(SCOPE_IDENTITY() AS INT);", con))
                {
                    cmd.Parameters.Add("@fecha", SqlDbType.Date).Value = cita.fecha.Date;
                    cmd.Parameters.Add("@hora", SqlDbType.Time).Value = cita.hora;
                    cmd.Parameters.Add("@idCliente", SqlDbType.Int).Value = cita.idCliente;
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
                using (var cmd = new SqlCommand("SELECT idCita, fecha, hora, idCliente FROM Cita WHERE idCliente = @idCliente", con))
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
                                idCliente = rd.GetInt32(3)
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
                using (var cmd = new SqlCommand("SELECT idCita, fecha, hora, idCliente FROM Cita", con))
                using (var rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        var c = new ClCita
                        {
                            idCita = rd.GetInt32(0),
                            fecha = rd.GetDateTime(1),
                            hora = (TimeSpan)rd[2],
                            idCliente = rd.GetInt32(3)
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
                using (var cmd = new SqlCommand("DELETE FROM Cita WHERE idCita = @idCita AND idCliente = @idCliente", con))
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
    }
}
