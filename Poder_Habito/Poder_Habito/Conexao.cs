﻿using System;
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
                conn.ConnectionString = "SERVER=aplicativo_db.mysql.dbaas.com.br;DATABASE=aplicativo_db;user=aplicativo_db;password=Sector@22";
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
