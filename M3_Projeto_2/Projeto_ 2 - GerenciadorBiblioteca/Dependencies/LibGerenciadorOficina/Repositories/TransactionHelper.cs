using LibDB;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibGerenciadorOficina.Repositories
{
    public static class TransactionHelper
    {
        public static void Execute(string sql, Dictionary<string, object> param)
        {
            SqlTransaction trans = DALPro.BeginTransaction();
            var result = DALPro.Execute(sql, param, trans);
            DALPro.Commit(trans);
            
        }
        public static int ExecuteScalar(string sql, Dictionary<string, object> param)
        {
            SqlTransaction trans = DALPro.BeginTransaction();
            var result = DALPro.ExecuteScalar(sql, param, trans);
            
                if(result == null) DALPro.Rollback(trans);
                else
                {
                    DALPro.Commit(trans);
                }

                return Convert.ToInt32(result);
        }
    }
}
