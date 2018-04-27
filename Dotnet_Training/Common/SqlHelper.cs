using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.Configuration;
using System.Reflection; 

namespace Common
{

    public abstract class SqlHelper
    {

        // ConnectionString to database
        public static readonly string connectionString = ConfigurationManager.
                                                            ConnectionStrings["Connection"].ConnectionString;

        #region Return rows affected
        /// <summary>
        /// Execute SqlCommand without return value
        /// </summary>
        /// <returns>Rows affected</returns>
        private static int ExecteNonQuery(string connectionString, CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {
            SqlCommand cmd = new SqlCommand();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                // Fill parameters into SqlCommand parameter collection
                PrepareCommand(cmd, conn, null, cmdType, cmdText, commandParameters);
                int val = cmd.ExecuteNonQuery();
                // Clear SqlCommand parameters list
                cmd.Parameters.Clear();
                return val;
            }
        }

        /// <summary>
        /// Execute SqlCommand without return value
        /// </summary>
        /// <param name="cmdType">Procedure || SQL</param>
        /// <param name="cmdText">Name of procedure Or SQL Text</param>
        /// <param name="commandParameters">Parameters array</param>
        /// <returns>Rows affected</returns>
        private static int ExecteNonQuery(CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {
            return ExecteNonQuery(connectionString, cmdType, cmdText, commandParameters);
        }

        #endregion

        /// <summary>
        /// Procedure
        /// </summary>
        /// <param name="cmdText">Name of procedure</param>
        /// <param name="commandParameters">Parameters array</param>
        /// <returns>Rows affected</returns>
        public static int ExecteNonQueryProcedure(string cmdText, params SqlParameter[] commandParameters)
        {
            return ExecteNonQuery(CommandType.StoredProcedure, cmdText, commandParameters);
        }
        
        /// <summary>
        /// SQL
        /// <param name="cmdText">SQL Text</param>
        /// <param name="commandParameters">Parameters array</param>
        /// <returns>Rows affected</returns>
        public static int ExecteNonQueryText(string cmdText, params SqlParameter[] commandParameters)
        {
            return ExecteNonQuery(CommandType.Text, cmdText, commandParameters);
        }

        /// <summary>
        /// Fill parameters into SqlCommand
        /// </summary>
        /// <param name="cmd">SqlCommand</param>
        /// <param name="conn">Connection already exists</param>
        /// <param name="trans">Transaction</param>
        /// <param name="cmdType">Procedure || SQL</param>
        /// <param name="cmdText">Name of procedure Or SQL Text</param>
        /// <param name="cmdParms">Parameters array</param>
        private static void PrepareCommand(SqlCommand cmd, SqlConnection conn, SqlTransaction trans, CommandType cmdType, string cmdText, SqlParameter[] cmdParms)
        {
            // if connection is close
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
            cmd.Connection = conn;
            cmd.CommandText = cmdText;
            // if need transaction support
            if (trans != null)
            {
                cmd.Transaction = trans;
            }
            cmd.CommandType = cmdType;
            if (cmdParms != null)
            {
                foreach (SqlParameter parm in cmdParms)
                {
                    cmd.Parameters.Add(parm);
                }
            }
        }

        #region Return DateSet
        /// <summary>
        /// Execute query return DataSet
        /// </summary>
        /// <param name="cmdType">Procedure || SQL</param>
        /// <param name="cmdText">Name of procedure Or SQL Text</param>
        /// <param name="commandParameters">Parameters array</param>
        /// <returns>DataSet</returns>
        private static DataSet ExecuteDataSet(string connectionString, CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {
            SqlCommand cmd = new SqlCommand();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    PrepareCommand(cmd, conn, null, cmdType, cmdText, commandParameters);
                    SqlDataAdapter da = new SqlDataAdapter();
                    DataSet ds = new DataSet();
                    da.SelectCommand = cmd;
                    da.Fill(ds);
                    return ds;
                }
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Execute query return DataSet
        /// </summary>
        /// <param name="cmdType">Procedure || SQL</param>
        /// <param name="cmdText">Name of procedure Or SQL Text</param>
        /// <param name="commandParameters">Parameters array</param>
        /// <returns>DataSet</returns>
        private static DataSet ExecuteDataSet(CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {
            return ExecuteDataSet(connectionString, cmdType, cmdText, commandParameters);
        }

        #endregion

        /// <summary>
        /// Procedure
        /// </summary>
        /// <param name="cmdText">Name of procedure</param>
        /// <param name="commandParameters">Parameters array</param>
        /// <returns>DataSet</returns>
        public static DataSet ExecuteDataSetProcedure(string cmdText, params SqlParameter[] commandParameters)
        {
            return ExecuteDataSet(connectionString, CommandType.StoredProcedure, cmdText, commandParameters);
        }

        /// <summary>
        /// SQL
        /// </summary>
        /// <param name="cmdText">SQL Text</param>
        /// <param name="commandParameters">Parameters array</param>
        /// <returns>DataSet</returns>
        public static DataSet ExecuteDataSetText(string cmdText, params SqlParameter[] commandParameters)
        {
            return ExecuteDataSet(connectionString, CommandType.Text, cmdText, commandParameters);
        }

        /// <summary>
        /// Procedure
        /// </summary>
        /// <param name="cmdText">Name of procedure</param>
        /// <param name="commandParameters">Parameters array</param>
        /// <returns>Single object</returns>
        public static object ExecuteScalarprocedure(string cmdText, params SqlParameter[] commandParameters)
        {
            return ExecuteScalar(SqlHelper.connectionString, CommandType.StoredProcedure, cmdText, commandParameters);
        }

        /// <summary>
        /// SQL
        /// </summary>
        /// <param name="cmdText">SQL Text</param>
        /// <param name="commandParameters">Parameters array</param>
        /// <returns>Single object</returns>
        public static object ExecuteScalarText(string cmdText, params SqlParameter[] commandParameters)
        {
            return ExecuteScalar(SqlHelper.connectionString, CommandType.Text, cmdText, commandParameters);
        }

        /// <summary>
        /// Execute a SqlCommand that returns the first column of the first record against the database specified in the connection string 
        /// using the provided parameters.
        /// </summary>
        /// <remarks>
        /// e.g.:  
        ///  Object obj = ExecuteScalar(connString, CommandType.StoredProcedure, "PublishOrders", new SqlParameter("@prodid", 24));
        /// </remarks>
        /// <returns>An object that should be converted to the expected type using Convert.To{Type}</returns>
        private static object ExecuteScalar(string connectionString, CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {
            SqlCommand cmd = new SqlCommand();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                PrepareCommand(cmd, connection, null, cmdType, cmdText, commandParameters);
                object val = cmd.ExecuteScalar();
                cmd.Parameters.Clear();
                return val;
            }
        }

        /// <summary>
        /// Check if exist
        /// </summary>
        public static bool Exists(string strSql, params SqlParameter[] cmdParms)
        {
            int cmdresult = Convert.ToInt32(ExecuteScalar(connectionString, CommandType.Text, strSql, cmdParms));
            if (cmdresult == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static List<T> PutAllVal<T>(T entity, DataSet ds) where T : new()
        {
            List<T> lists = new List<T>();
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    lists.Add(PutVal(new T(), row));
                }
            }
            return lists;
        }

        public static T PutVal<T>(T entity, DataRow row) where T : new()
        {
            // Initial if entity is nullable
            if (entity == null)
            {
                entity = new T();
            }
            // Get current type of T
            Type type = typeof(T);
            // Get properties of T
            PropertyInfo[] pi = type.GetProperties();
            foreach (PropertyInfo item in pi)
            {
                for (int i = 0; i < row.Table.Columns.Count; i++ )
                {
                    string columnName = row.Table.Columns[i].ColumnName;
                    if (item.Name.Equals(ApplicationUtil.Convert2Camel(columnName)))
                    {
                        // Attribute assignment
                        if (row[columnName] != null && row[columnName] != DBNull.Value)
                        {
                            if (item.PropertyType == typeof(System.Nullable<System.DateTime>))
                            {
                                item.SetValue(entity, Convert.ToDateTime(row[columnName].ToString()), null);
                            }
                            else
                            {
                                item.SetValue(entity, Convert.ChangeType(row[columnName], item.PropertyType), null);
                            }
                        }
                    }
                }
            }
            return entity;
        }

    }
}