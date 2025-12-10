﻿﻿﻿﻿﻿﻿﻿﻿﻿﻿﻿﻿﻿﻿﻿using System;
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
        public int MtRegistrarCliente(ClUsuario cliente)
        {
            var objConexion = new ClConexion();
            var con = objConexion.MtAbrirConexion();
            try
            {
                int? rolCliente = null;
                using (var cmdRol = new SqlCommand("SELECT TOP 1 idRol FROM dbo.Rol WHERE rol = 'Cliente'", con))
                {
                    var r = cmdRol.ExecuteScalar();
                    if (r != null) rolCliente = Convert.ToInt32(r);
                }

                string sql = "INSERT INTO dbo.Usuario (documento, nombre, apellido, celular, email, clave, idRol) VALUES (@documento, @nombre, @apellido, @celular, @email, @clave, @idRol); SELECT CAST(SCOPE_IDENTITY() AS INT);";

                using (var cmd = new SqlCommand(sql, con))
                {
                    cmd.Parameters.Add("@documento", SqlDbType.VarChar).Value = cliente.documento;
                    cmd.Parameters.Add("@nombre", SqlDbType.VarChar).Value = cliente.nombre;
                    cmd.Parameters.Add("@apellido", SqlDbType.VarChar).Value = cliente.apellido;
                    cmd.Parameters.Add("@celular", SqlDbType.VarChar).Value = cliente.celular;
                    cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = cliente.email;
                    cmd.Parameters.Add("@clave", SqlDbType.VarChar).Value = HashClave(cliente.clave);
                    cmd.Parameters.Add("@idRol", SqlDbType.Int).Value = (object)rolCliente ?? DBNull.Value;
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
                using (var cmd = new SqlCommand("SELECT 1 WHERE EXISTS (SELECT 1 FROM dbo.Usuario WHERE documento = @doc)", con))
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
                using (var cmd = new SqlCommand("SELECT idUsuario FROM dbo.Usuario WHERE email = @correo AND (clave = @hash OR clave = @plain)", con))
                {
                    cmd.Parameters.Add("@correo", SqlDbType.VarChar).Value = correo;
                    cmd.Parameters.Add("@hash", SqlDbType.VarChar).Value = HashClave(claveIngresada);
                    cmd.Parameters.Add("@plain", SqlDbType.VarChar).Value = claveIngresada;
                    var r = cmd.ExecuteScalar();
                    if (r != null)
                    {
                        using (var cmdUp = new SqlCommand("UPDATE dbo.Usuario SET clave = @hash WHERE email = @correo AND clave = @plain", con))
                        {
                            cmdUp.Parameters.Add("@hash", SqlDbType.VarChar).Value = HashClave(claveIngresada);
                            cmdUp.Parameters.Add("@correo", SqlDbType.VarChar).Value = correo;
                            cmdUp.Parameters.Add("@plain", SqlDbType.VarChar).Value = claveIngresada;
                            cmdUp.ExecuteNonQuery();
                        }
                        return true;
                    }
                }
                return false;
            }
            finally
            {
                objConexion.MtCerrarConexion();
            }
        }

        public ClUsuario ObtenerPorEmail(string email)
        {
            ClUsuario c = null;
            var objConexion = new ClConexion();
            var con = objConexion.MtAbrirConexion();
            try
            {
                using (var cmd = new SqlCommand("SELECT idUsuario, documento, nombre, apellido, celular, email FROM dbo.Usuario WHERE email = @email", con))
                {
                    cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = email;
                    using (var rd = cmd.ExecuteReader())
                    {
                        if (rd.Read())
                        {
                            c = new ClUsuario
                            {
                                idUsuario = rd.GetInt32(0),
                                documento = rd.IsDBNull(1) ? null : rd.GetString(1),
                                nombre = rd.IsDBNull(2) ? null : rd.GetString(2),
                                apellido = rd.IsDBNull(3) ? null : rd.GetString(3),
                                celular = rd.IsDBNull(4) ? null : rd.GetString(4),
                                email = rd.IsDBNull(5) ? null : rd.GetString(5)
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

        public bool ActualizarDatosPersonales(ClUsuario cliente)
        {
            var objConexion = new ClConexion();
            var con = objConexion.MtAbrirConexion();
            try
            {
                using (var cmd = new SqlCommand("UPDATE dbo.Usuario SET documento=@documento, nombre=@nombre, apellido=@apellido, celular=@celular WHERE idUsuario=@idUsuario", con))
                {
                    cmd.Parameters.Add("@documento", SqlDbType.VarChar).Value = cliente.documento;
                    cmd.Parameters.Add("@nombre", SqlDbType.VarChar).Value = cliente.nombre;
                    cmd.Parameters.Add("@apellido", SqlDbType.VarChar).Value = cliente.apellido;
                    cmd.Parameters.Add("@celular", SqlDbType.VarChar).Value = cliente.celular;
                    cmd.Parameters.Add("@idUsuario", SqlDbType.Int).Value = cliente.idUsuario;
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
