using System;
using System.Data;
using System.Data.SqlClient;
using Proyecto_ADSO.Modelo;

namespace Proyecto_ADSO.Datos
{
    public class ClUsuarioD
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

        public bool VerificarLoginAdmin(string correo, string clave)
        {
            var objConexion = new ClConexion();
            var con = objConexion.MtAbrirConexion();
            try
            {
                using (var cmd = new SqlCommand("SELECT u.idUsuario FROM dbo.Usuario u INNER JOIN dbo.Rol r ON u.idRol = r.idRol WHERE u.email = @correo AND (u.clave = @hash OR u.clave = @plain) AND r.rol = 'Administrador'", con))
                {
                    cmd.Parameters.Add("@correo", SqlDbType.VarChar).Value = correo;
                    cmd.Parameters.Add("@hash", SqlDbType.VarChar).Value = HashClave(clave);
                    cmd.Parameters.Add("@plain", SqlDbType.VarChar).Value = clave;
                    var r = cmd.ExecuteScalar();
                    if (r != null)
                    {
                        using (var cmdUp = new SqlCommand("UPDATE dbo.Usuario SET clave = @hash WHERE email = @correo AND clave = @plain", con))
                        {
                            cmdUp.Parameters.Add("@hash", SqlDbType.VarChar).Value = HashClave(clave);
                            cmdUp.Parameters.Add("@correo", SqlDbType.VarChar).Value = correo;
                            cmdUp.Parameters.Add("@plain", SqlDbType.VarChar).Value = clave;
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

        public ClUsuario ObtenerAdminPrincipal()
        {
            var objConexion = new ClConexion();
            var con = objConexion.MtAbrirConexion();
            try
            {
                using (var cmd = new SqlCommand("SELECT TOP 1 u.idUsuario, u.nombre, u.apellido, u.celular, u.email FROM dbo.Usuario u INNER JOIN dbo.Rol r ON u.idRol = r.idRol WHERE r.rol = 'Administrador' ORDER BY u.idUsuario", con))
                using (var rd = cmd.ExecuteReader())
                {
                    if (rd.Read())
                    {
                        return new ClUsuario
                        {
                            idUsuario = rd.GetInt32(0),
                            nombre = rd.IsDBNull(1) ? null : rd.GetString(1),
                            apellido = rd.IsDBNull(2) ? null : rd.GetString(2),
                            celular = rd.IsDBNull(3) ? null : rd.GetString(3),
                            email = rd.IsDBNull(4) ? null : rd.GetString(4)
                        };
                    }
                }
                return null;
            }
            finally
            {
                objConexion.MtCerrarConexion();
            }
        }

        int ObtenerRolAdministradorId(SqlConnection con)
        {
            int? rolAdmin = null;
            using (var cmdRol = new SqlCommand("SELECT TOP 1 idRol FROM dbo.Rol WHERE rol = 'Administrador'", con))
            {
                var r = cmdRol.ExecuteScalar();
                if (r != null) rolAdmin = Convert.ToInt32(r);
            }
            if (rolAdmin == null)
            {
                using (var cmdNew = new SqlCommand("INSERT INTO dbo.Rol (rol) VALUES ('Administrador'); SELECT CAST(SCOPE_IDENTITY() AS INT);", con))
                {
                    var id = cmdNew.ExecuteScalar();
                    rolAdmin = id != null ? Convert.ToInt32(id) : 0;
                }
            }
            return rolAdmin ?? 0;
        }

        public int CrearAdministrador(ClUsuario admin)
        {
            var objConexion = new ClConexion();
            var con = objConexion.MtAbrirConexion();
            try
            {
                var idRol = ObtenerRolAdministradorId(con);
                using (var cmd = new SqlCommand("INSERT INTO dbo.Usuario (documento, nombre, apellido, celular, email, clave, idRol) VALUES (@documento, @nombre, @apellido, @celular, @email, @clave, @idRol); SELECT CAST(SCOPE_IDENTITY() AS INT);", con))
                {
                    cmd.Parameters.Add("@documento", SqlDbType.VarChar).Value = admin.documento;
                    cmd.Parameters.Add("@nombre", SqlDbType.VarChar).Value = admin.nombre;
                    cmd.Parameters.Add("@apellido", SqlDbType.VarChar).Value = admin.apellido;
                    cmd.Parameters.Add("@celular", SqlDbType.VarChar).Value = admin.celular;
                    cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = admin.email;
                    cmd.Parameters.Add("@clave", SqlDbType.VarChar).Value = HashClave(admin.clave);
                    cmd.Parameters.Add("@idRol", SqlDbType.Int).Value = idRol;
                    var id = cmd.ExecuteScalar();
                    return id != null ? Convert.ToInt32(id) : 0;
                }
            }
            finally
            {
                objConexion.MtCerrarConexion();
            }
        }

        public bool ActualizarAdministrador(ClUsuario admin)
        {
            var objConexion = new ClConexion();
            var con = objConexion.MtAbrirConexion();
            try
            {
                using (var cmd = new SqlCommand("UPDATE dbo.Usuario SET documento=@documento, nombre=@nombre, apellido=@apellido, celular=@celular, email=@email WHERE idUsuario=@idUsuario", con))
                {
                    cmd.Parameters.Add("@documento", SqlDbType.VarChar).Value = admin.documento;
                    cmd.Parameters.Add("@nombre", SqlDbType.VarChar).Value = admin.nombre;
                    cmd.Parameters.Add("@apellido", SqlDbType.VarChar).Value = admin.apellido;
                    cmd.Parameters.Add("@celular", SqlDbType.VarChar).Value = admin.celular;
                    cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = admin.email;
                    cmd.Parameters.Add("@idUsuario", SqlDbType.Int).Value = admin.idUsuario;
                    var rows = cmd.ExecuteNonQuery();
                    return rows > 0;
                }
            }
            finally
            {
                objConexion.MtCerrarConexion();
            }
        }

        public bool EliminarAdministrador(int idUsuario)
        {
            var objConexion = new ClConexion();
            var con = objConexion.MtAbrirConexion();
            try
            {
                using (var cmd = new SqlCommand("DELETE FROM dbo.Usuario WHERE idUsuario = @idUsuario", con))
                {
                    cmd.Parameters.Add("@idUsuario", SqlDbType.Int).Value = idUsuario;
                    var rows = cmd.ExecuteNonQuery();
                    return rows > 0;
                }
            }
            finally
            {
                objConexion.MtCerrarConexion();
            }
        }

        public ClUsuario ObtenerPorId(int idUsuario)
        {
            ClUsuario u = null;
            var objConexion = new ClConexion();
            var con = objConexion.MtAbrirConexion();
            try
            {
                using (var cmd = new SqlCommand("SELECT idUsuario, documento, nombre, apellido, celular, email FROM dbo.Usuario WHERE idUsuario = @id", con))
                {
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = idUsuario;
                    using (var rd = cmd.ExecuteReader())
                    {
                        if (rd.Read())
                        {
                            u = new ClUsuario
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
                return u;
            }
            finally
            {
                objConexion.MtCerrarConexion();
            }
        }

        public System.Collections.Generic.List<ClUsuario> ListarAdministradores()
        {
            var lista = new System.Collections.Generic.List<ClUsuario>();
            var objConexion = new ClConexion();
            var con = objConexion.MtAbrirConexion();
            try
            {
                using (var cmd = new SqlCommand("SELECT u.idUsuario, u.documento, u.nombre, u.apellido, u.celular, u.email FROM dbo.Usuario u INNER JOIN dbo.Rol r ON u.idRol = r.idRol WHERE r.rol = 'Administrador'", con))
                using (var rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        var u = new ClUsuario
                        {
                            idUsuario = rd.GetInt32(0),
                            documento = rd.IsDBNull(1) ? null : rd.GetString(1),
                            nombre = rd.IsDBNull(2) ? null : rd.GetString(2),
                            apellido = rd.IsDBNull(3) ? null : rd.GetString(3),
                            celular = rd.IsDBNull(4) ? null : rd.GetString(4),
                            email = rd.IsDBNull(5) ? null : rd.GetString(5)
                        };
                        lista.Add(u);
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
