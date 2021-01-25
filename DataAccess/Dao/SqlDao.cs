using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess.Dao
{
    public class SqlDao
    {
        private string CONNECTION_STRING = "";

        private static SqlDao instance;



        private SqlDao()
        {
            CONNECTION_STRING = ConfigurationManager.ConnectionStrings["CONN_STRING"].ConnectionString;
        }

        //IMPLEMENTA EL PATRON LLAMADO SINGLETON
        //INVESTIGAR EL PATRON
        public static SqlDao GetInstance()
        {
            if (instance == null)
                instance = new SqlDao();

            return instance;
        }


        public void ExecuteProcedure(SqlOperation sqlOperation)
        {
            try
            {
                using (var conn = new SqlConnection(CONNECTION_STRING))
                using (var command = new SqlCommand(sqlOperation.ProcedureName, conn)
                {
                    CommandType = CommandType.StoredProcedure
                })
                {
                    foreach (var param in sqlOperation.Parameters)
                    {
                        command.Parameters.Add(param);
                    }

                    conn.Open();
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                // TODO: No hay conexión entre esta excepción y BussinessException.
                var errorMessage = ex.Message;
            }
        }

        public List<Dictionary<string, object>> ExecuteQueryProcedure(SqlOperation sqlOperation)
        {
            var lstResult = new List<Dictionary<string, object>>();
            try
            {
                using (var conn = new SqlConnection(CONNECTION_STRING))
                using (var command = new SqlCommand(sqlOperation.ProcedureName, conn)
                {
                    CommandType = CommandType.StoredProcedure
                })
                {
                    foreach (var param in sqlOperation.Parameters)
                    {
                        command.Parameters.Add(param);
                    }

                    conn.Open();
                    var reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            var dict = new Dictionary<string, object>();
                            for (var lp = 0; lp < reader.FieldCount; lp++)
                            {
                                var nombreColumna = reader.GetName(lp);

                                if (nombreColumna.Length == 0)
                                {
                                    throw new Exception("Error en " + sqlOperation.ProcedureName + ". La columna " + lp + " no tiene nombre");
                                }

                                dict.Add(nombreColumna, reader.GetValue(lp));
                            }
                            lstResult.Add(dict);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // TODO: No hay conexión entre esta excepción y BussinessException.
                var errorMessage = ex.Message;
            }

            return lstResult;
        }
    }
}
