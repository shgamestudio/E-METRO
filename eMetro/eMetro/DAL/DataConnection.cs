using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eMetro.DAL
{
    class DataConnection
    {
        string conStr;
        public DataConnection()
        {
            //conStr = @"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\SELL_PLANE_TICKET_DATABASE.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True";
            conStr = "Data Source=DESKTOP-16B7G12\\SQLEXPRESS;Initial Catalog=EMETRO;Integrated Security=True";
        }
        public SqlConnection GetConnect()
        {
            return new SqlConnection(conStr);
        }
    }
}
