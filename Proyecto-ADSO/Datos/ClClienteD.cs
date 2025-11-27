using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using Proyecto_ADSO.Modelo;

namespace Proyecto_ADSO.Datos
{
    public class ClClienteD
    {
        static string HashClave(string texto)
        {
            using (var sha = System.Security.Cryptography.SHA256.Create())
            {
                var bytes = System.Text.Encoding.UTF8.GetBytes(texto);
                var hash = sha.ComputeHash(bytes);
                var sb = new System.Text.StringBuilder();
                foreach (var b in hash) sb.Append(b.ToString("x2"));
                return sb.ToString();
            }
        }
        public int MtRegistrarCliente(ClCliente cliente)
        {
            var objConexion = new ClConexion();
            var con = objConexion.MtAbrirConexion();
            try
            {
                using (var cmd = new SqlCommand("INSERT INTO Cliente (documento, nombre, apellido, celular, email, clave, direccion) VALUES (@documento, @nombre, @apellido, @celular, @email, @clave, @direccion); SELECT CAST(SCOPE_IDENTITY() AS INT);", con))
                {
                    cmd.Parameters.Add("@documento", SqlDbType.VarChar).Value = cliente.documento;
                    cmd.Parameters.Add("@nombre", SqlDbType.VarChar).Value = cliente.nombre;
                    cmd.Parameters.Add("@apellido", SqlDbType.VarChar).Value = cliente.apellido;
                    cmd.Parameters.Add("@celular", SqlDbType.VarChar).Value = cliente.celular;
                    cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = cliente.email;
                    cmd.Parameters.Add("@clave", SqlDbType.VarChar).Value = HashClave(cliente.clave);
                    cmd.Parameters.Add("@direccion", SqlDbType.VarChar).Value = cliente.direccion;
                    var id = cmd.ExecuteScalar();
                    return id != null ? Convert.ToInt32(id) : 0;
                }
            }
            finally
            {
                objConexion.MtCerrarConexion();
            }
        }
        public bool MtVerificarDocumentoExistente(string documento)
        {
            var objConexion = new ClConexion();
            var con = objConexion.MtAbrirConexion();
            try
            {
                using (var cmd = new SqlCommand("SELECT 1 WHERE EXISTS (SELECT 1 FROM Cliente WHERE documento = @doc)", con))
                {
                    cmd.Parameters.Add("@doc", SqlDbType.VarChar).Value = documento;
                    var r = cmd.ExecuteScalar();
                    return r != null;
                }
            }
            finally
            {
                objConexion.MtCerrarConexion();
            }
        }

        public bool MtVerificarLogin(string correo, string claveIngresada)
        {
            var objConexion = new ClConexion();
            var con = objConexion.MtAbrirConexion();
            try
            {
                using (var cmd = new SqlCommand("SELECT 1 FROM Cliente WHERE email = @correo AND clave = @clave", con))
                {
                    cmd.Parameters.Add("@correo", SqlDbType.VarChar).Value = correo;
                    cmd.Parameters.Add("@clave", SqlDbType.VarChar).Value = HashClave(claveIngresada);
                    var r = cmd.ExecuteScalar();
                    return r != null;
                }
            }
            finally
            {
                objConexion.MtCerrarConexion();
            }
        }

        public ClCliente ObtenerPorEmail(string email)
        {
            ClCliente c = null;
            var objConexion = new ClConexion();
            var con = objConexion.MtAbrirConexion();
            try
            {
                using (var cmd = new SqlCommand("SELECT idCliente, documento, nombre, apellido, celular, email, direccion FROM Cliente WHERE email = @email", con))
                {
                    cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = email;
                    using (var rd = cmd.ExecuteReader())
                    {
                        if (rd.Read())
                        {
                            c = new ClCliente
                            {
                                idCliente = rd.GetInt32(0),
                                documento = rd.IsDBNull(1) ? null : rd.GetString(1),
                                nombre = rd.IsDBNull(2) ? null : rd.GetString(2),
                                apellido = rd.IsDBNull(3) ? null : rd.GetString(3),
                                celular = rd.IsDBNull(4) ? null : rd.GetString(4),
                                email = rd.IsDBNull(5) ? null : rd.GetString(5),
                                direccion = rd.IsDBNull(6) ? null : rd.GetString(6)
                            };
                        }
                    }
                }
                return c;
            }
            finally
            {
                objConexion.MtCerrarConexion();
            }
        }

        public bool ActualizarDatosPersonales(ClCliente cliente)
        {
            var objConexion = new ClConexion();
            var con = objConexion.MtAbrirConexion();
            try
            {
                using (var cmd = new SqlCommand("UPDATE Cliente SET documento=@documento, nombre=@nombre, apellido=@apellido, celular=@celular, direccion=@direccion WHERE idCliente=@idCliente", con))
                {
                    cmd.Parameters.Add("@documento", SqlDbType.VarChar).Value = cliente.documento;
                    cmd.Parameters.Add("@nombre", SqlDbType.VarChar).Value = cliente.nombre;
                    cmd.Parameters.Add("@apellido", SqlDbType.VarChar).Value = cliente.apellido;
                    cmd.Parameters.Add("@celular", SqlDbType.VarChar).Value = cliente.celular;
                    cmd.Parameters.Add("@direccion", SqlDbType.VarChar).Value = cliente.direccion;
                    cmd.Parameters.Add("@idCliente", SqlDbType.Int).Value = cliente.idCliente;
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
