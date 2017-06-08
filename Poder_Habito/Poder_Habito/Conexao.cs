using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Poder_Habito
{
    class Conexao
    {
        MySqlConnection conn = null;

        public MySqlConnection ConnectToDataBase()
        {
            try
            {
                conn = new MySqlConnection();
                conn.ConnectionString = "SERVER=localhost;DATABASE=habitobd;user=root;password=";
                conn.Open();
                return conn;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
