using System;
using System.Data;
using System.Data.SqlClient;

namespace Proyecto_ADSO.Datos
{
    public class ClAdminD
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

        public bool MtVerificarLogin(string correo, string clave)
        {
            var objConexion = new ClConexion();
            var con = objConexion.MtAbrirConexion();
            try
            {
                using (var cmd = new SqlCommand("SELECT 1 FROM Admin WHERE email = @correo AND clave = @clave", con))
                {
                    cmd.Parameters.Add("@correo", SqlDbType.VarChar).Value = correo;
                    cmd.Parameters.Add("@clave", SqlDbType.VarChar).Value = HashClave(clave);
                    var r = cmd.ExecuteScalar();
                    return r != null;
                }
            }
            finally
            {
                objConexion.MtCerrarConexion();
            }
        }
    }
}
