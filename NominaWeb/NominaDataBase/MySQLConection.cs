using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace NominaDataBase
{
    public class MySQLConection 
    {
        //String conection = @"Server=localhost; database = nominadatabase; uid=root1; password=admin;";

         String conection = @"Server=mysqlservernominadb.mysql.database.azure.com; Port=3306; Database=nominadatabase; uid=root1@mysqlservernominadb; password=AdminRoot80; SslMode=Preferred;";

        public MySQLConection()
        {
            using (MySqlConnection connection = new MySqlConnection(conection))
            {
                // Create database if not exists
                using (NominaDBEntities contextDB = new NominaDBEntities(connection, false))
                {
                    contextDB.Database.CreateIfNotExists();
                }

                connection.Open();
                MySqlTransaction transaction = connection.BeginTransaction();
                try
                {
                    using (NominaDBEntities context = new NominaDBEntities(connection, false))
                    {
                        context.Database.Log = (string message) => { Console.WriteLine(message); };
                        context.Database.UseTransaction(transaction);

                        context.SaveChanges();
                    }

                    transaction.Commit();
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }
    }
}
