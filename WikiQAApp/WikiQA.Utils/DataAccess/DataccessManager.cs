using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.IO;
using WikiQA.Helper.Logger;

namespace WikiQA.Utils.DataAccess
{
    class DataccessManager : IDisposable
    {
        string connStr;

        DbConnection server;
        public void Dispose()
        {
            server.Close();
        }

        public DataccessManager(string connStr)
        {
            this.connStr = connStr;
            try
            {
                server = new SqlConnection(connStr);
            }
            catch (Exception e)
            {
                EventViewerLogger.LogError(this.ToString(), e);
            }
        }

        DbCommand InitCommand(string sql, Dictionary<string, string> sqlParams)
        {
            DbCommand cmd = new SqlCommand(sql, (SqlConnection)server);
            if (sqlParams != null)
            {
                foreach (var item in sqlParams)
                {
                    DbParameter p = cmd.CreateParameter();
                    p.ParameterName = item.Key;
                    p.Value = item.Value;
                    cmd.Parameters.Add(p);
                }
            }
            return cmd;
        }

        public int ExecuteNonQuery(string sql, Dictionary<string, string> sqlParams = null)
        {
            using (server = new SqlConnection(connStr))
            {
                server.Open();
                DbCommand cmd = InitCommand(sql, sqlParams);
                return cmd.ExecuteNonQuery();
            }
        }

        public async Task<int> ExecuteNonQueryAsync(string sql, Dictionary<string, string> sqlParams = null)
        {
            using (server = new SqlConnection(connStr))
            {
                server.Open();
                DbCommand cmd = InitCommand(sql, sqlParams);
                return await cmd.ExecuteNonQueryAsync();
            }
        }
        public object ExecuteScalar(string sql, Dictionary<string, string> sqlParams = null)
        {
            using (server = new SqlConnection(connStr))
            {
                server.Open();
                DbCommand cmd = InitCommand(sql, sqlParams);
                return cmd.ExecuteScalar();
            }
        }

        public async Task ExecuteScalarAsync(string sql, Dictionary<string, string> sqlParams = null)
        {
            using (server = new SqlConnection(connStr))
            {
                server.Open();
                DbCommand cmd = InitCommand(sql, sqlParams);
                await cmd.ExecuteScalarAsync();
            }
        }

        public DataResult ExecuteSelect(string sql, Dictionary<string, string> sqlParams = null)
        {
            using (server = new SqlConnection(connStr))
            {
                server.Open();
                DbCommand cmd = InitCommand(sql, sqlParams);
                DbDataReader reader = cmd.ExecuteReader();
                DataResult result = new DataResult();
                string[] fields = null;
                object[] values = null;
                while (reader.Read())
                {
                    if (fields == null)
                    {
                        fields = new string[reader.FieldCount];
                        values = new object[reader.FieldCount];

                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            fields[i] = reader.GetName(i).ToUpper();
                        }
                    }

                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        values[i] = reader.GetValue(i);
                    }
                    result.AddRow(fields, values);
                }
                if (reader != null && !reader.IsClosed)
                {
                    reader.Close();
                }
                return result;
            }
        }
        public async Task<DataResult> ExecuteSelectAsync(string sql, Dictionary<string, string> sqlParams = null)
        {
            using (server = new SqlConnection(connStr))
            {
                server.Open();
                DbCommand cmd = InitCommand(sql, sqlParams);
                DbDataReader reader = await cmd.ExecuteReaderAsync();
                DataResult result = new DataResult();
                string[] fields = null;
                object[] values = null;
                while (reader.Read())
                {
                    if (fields == null)
                    {
                        fields = new string[reader.FieldCount];
                        values = new object[reader.FieldCount];

                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            fields[i] = reader.GetName(i).ToUpper();
                        }
                    }

                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        values[i] = reader.GetValue(i);
                    }
                    result.AddRow(fields, values);
                }
                if (reader != null && !reader.IsClosed)
                {
                    reader.Close();
                }
                return result;
            }
        }

    }
}
