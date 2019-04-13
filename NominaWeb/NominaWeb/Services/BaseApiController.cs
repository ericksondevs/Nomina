using MySql.Data.MySqlClient;
using NominaDataBase;
using System;
using System.Web.Http;

namespace NominaWeb.Services
{
    public class BaseApiController : ApiController
    {
        public String conection = @"Server=mysqlservernominadb.mysql.database.azure.com; Port=3306; Database=nominadatabase; uid=root1@mysqlservernominadb; password=AdminRoot80; SslMode=Preferred;";
        public MySqlConnection connection;
        public NominaDBEntities db;

        public BaseApiController()
        {
            connection = new MySqlConnection(conection);
            db = new NominaDBEntities(connection, false);
        }
    }
}