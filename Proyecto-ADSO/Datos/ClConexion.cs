using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace Proyecto_ADSO.Datos
{
    public class ClConexion
    {
        SqlConnection objConexion;

        public ClConexion()
        {

            objConexion = new SqlConnection("Data Source=DESKTOP-JOEFSE7\\SQLEXPRESS;Initial Catalog=dbProyecto-ADSO;Integrated Security=True;");

        }
        public SqlConnection MtAbrirConexion()
        {
            objConexion.Open();
            return objConexion;
        }

        public void MtCerrarConexion()
        {
            objConexion.Close();
        }
    }
}
