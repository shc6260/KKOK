using Oracle.ManagedDataAccess.Client;
using System.Data;
using System.Text.Json;
using KKOK_WEB.Models;

namespace KKOK_WEB.CommDB
{
    enum DB_PROJECT_FUNC_NAME
    {
        #region TEST_TABLE
        DB_SELECT_QUERY_PROJECT = 1,
        DB_INSERT_QUERY_PROJECT,
        DB_UPDATE_QUERY_PROJECT,
        DB_DELETE_QUERY_PROJECT,
        #endregion
    }

    public class CommDB_PROJECT
    {
        private const string conString = "User Id=C##TEST; Password=1q2w3e4r;" +
           "Data Source =localhost:1521/orcl";

        public string? result = null;


        #region DB_'TEST_TABLE'_FUNC
        public void db_Select_Query(string input)
        {
            ProjectModel? project_Table = JsonSerializer.Deserialize<ProjectModel>(input);
            string query = "select * from C##TEST.TEST_PROJECT where PJT_CODE = :code";
            using (OracleConnection conn = new OracleConnection(conString))
            {
                using (OracleCommand cmd = conn.CreateCommand())
                {
                    try
                    {
                        conn.Open();
                        cmd.BindByName = true;

                        cmd.CommandText = query;

                        OracleParameter input_base = new OracleParameter("code", project_Table._pjt_code);
                        cmd.Parameters.Add(input_base);

                        OracleDataReader reader = cmd.ExecuteReader();
                        List<ProjectModel> list_test_table = new List<ProjectModel>();
                        while (reader.Read())
                        {
                            list_test_table.Add(new ProjectModel(int.Parse(reader.GetString(0)), reader.GetString(1), DateTime.Parse(reader.GetString(2)), DateTime.Parse(reader.GetString(3))));
                        }
                        result = JsonSerializer.Serialize(list_test_table);
                        reader.Dispose();
                        cmd.Dispose();
                    }
                    catch (Exception ex)
                    {
                        result = ex.Message;
                    }
                }
                conn.Dispose();
            }
        }

        public void db_Insert_Query(string input)
        {
            ProjectModel? project_Table = JsonSerializer.Deserialize<ProjectModel>(input);
            string query = "INSERT INTO C##TEST.TEST_PROJECT VALUES(:code, :name, :startdate, :enddate)";
            using (OracleConnection conn = new OracleConnection(conString))
            {
                try
                {
                    conn.Open();
                    OracleTransaction oracleTransaction;
                    oracleTransaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);
                    using (OracleCommand cmd = conn.CreateCommand())
                    {
                        cmd.Transaction = oracleTransaction;
                        try
                        {
                            cmd.BindByName = true;

                            cmd.CommandText = query;


                            OracleParameter input_code = new OracleParameter("code", db_CountAll_Select_Query());
                            cmd.Parameters.Add(input_code);
                            OracleParameter input_name = new OracleParameter("name", project_Table._pjt_name);
                            cmd.Parameters.Add(input_name);
                            OracleParameter input_startdate = new OracleParameter("startdate", project_Table._pjt_startdate);
                            cmd.Parameters.Add(input_startdate);
                            OracleParameter input_enddate = new OracleParameter("enddate", project_Table._pjt_enddate);
                            cmd.Parameters.Add(input_enddate);

                            cmd.ExecuteNonQuery();
                            oracleTransaction.Commit();

                            oracleTransaction.Dispose();
                            cmd.Dispose ();
                        }
                        catch (Exception ex)
                        {
                            oracleTransaction.Rollback();
                            result = ex.Message;
                        }
                        conn.Dispose ();
                    }
                }
                catch (Exception ex)
                {
                    result = ex.Message;
                }
            }
        }

        public void db_Update_Query(string input)
        {
            ProjectModel? project_Table = JsonSerializer.Deserialize<ProjectModel>(input);
            string query = "UPDATE C##TEST.TEST_PROJECT SET PJT_ENDDATE = :change_enddate WHERE PJT_CODE = :code";
            using (OracleConnection conn = new OracleConnection(conString))
            {
                try
                {
                    conn.Open();
                    OracleTransaction oracleTransaction;
                    oracleTransaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);
                    using (OracleCommand cmd = conn.CreateCommand())
                    {
                        cmd.Transaction = oracleTransaction;
                        try
                        {
                            cmd.BindByName = true;

                            cmd.CommandText = query;


                            OracleParameter input_code = new OracleParameter("code", project_Table._pjt_code);
                            cmd.Parameters.Add(input_code);
                            OracleParameter change_value_enddate = new OracleParameter("change_value", project_Table._pjt_enddate);
                            cmd.Parameters.Add(change_value_enddate);
                            cmd.ExecuteNonQuery();
                            oracleTransaction.Commit();

                            oracleTransaction.Dispose();
                            cmd.Dispose();
                        }
                        catch (Exception ex)
                        {
                            oracleTransaction.Rollback();
                            result = ex.Message;
                        }

                        conn.Dispose();
                    }
                }
                catch (Exception ex)
                {
                    result = ex.Message;
                }
            }
        }

        public void db_Delete_Query(string input)
        {
            ProjectModel? project_Table = JsonSerializer.Deserialize<ProjectModel>(input);
            string query = "DELETE FROM C##TEST.TEST_PROJECT WHERE PJT_CODE = :code";
            using (OracleConnection conn = new OracleConnection(conString))
            {
                try
                {
                    conn.Open();
                    OracleTransaction oracleTransaction;
                    oracleTransaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);
                    using (OracleCommand cmd = conn.CreateCommand())
                    {
                        cmd.Transaction = oracleTransaction;
                        try
                        {
                            cmd.BindByName = true;

                            cmd.CommandText = query;


                            OracleParameter input_code = new OracleParameter("code", project_Table._pjt_code);
                            cmd.Parameters.Add(input_code);
                            cmd.ExecuteNonQuery();
                            oracleTransaction.Commit();

                            oracleTransaction.Dispose();
                            cmd.Dispose();
                        }
                        catch (Exception ex)
                        {
                            oracleTransaction.Rollback();
                            result = ex.Message;
                        }

                        conn.Dispose();
                    }
                }
                catch (Exception ex)
                {
                    result = ex.Message;
                }
            }
        }
        #region DB_inner_select
        public int db_CountAll_Select_Query()
        {
            int query_result = -1;
            string query = "select COUNT(*) from C##TEST.TEST_PROJECT";
            using (OracleConnection conn = new OracleConnection(conString))
            {
                using (OracleCommand cmd = conn.CreateCommand())
                {
                    try
                    {
                        conn.Open();
                        cmd.BindByName = true;

                        cmd.CommandText = query;

                        OracleDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            query_result = int.Parse(reader.GetString(0));
                        }
                        reader.Dispose();
                        cmd.Dispose();
                    }
                    catch (Exception ex)
                    {
                        result = ex.Message;
                        query_result = -1;
                    }
                }
                conn.Dispose();
            }
            return query_result;
        }
        #endregion
        #endregion
    }
}
