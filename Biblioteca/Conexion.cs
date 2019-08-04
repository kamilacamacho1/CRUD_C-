using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

namespace Biblioteca
{
    public class Conexion
    {
        public SqlConnection GetConnection()
        {
            try
            {
                string cadena = "Data Source=WINDOWS-PC;Initial Catalog=PruebaMVC;Persist Security Info=True;User ID=sa;Password=123456789";
                SqlConnection con = new SqlConnection(cadena);
                con.Open();
                return con;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
