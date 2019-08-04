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
    class Operacion
    {
        public bool InsertPersona (string nombre)
        {
            try
            {
                Conexion con = new Conexion();
                string sql = "Insert into Tb_Provedores values ('Nombre 1')";
                SqlCommand cmd = new SqlCommand(sql,con.GetConnection());
                int n = cmd.ExecuteNonQuery();
                return n > 0;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
