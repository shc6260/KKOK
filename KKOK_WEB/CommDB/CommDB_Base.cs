using Oracle.ManagedDataAccess.Client;
using System.Data;
using System.Text.Json;
using KKOK_WEB.Models;

namespace KKOK_WEB.CommDB
{
    enum DB_BASE_FUNC_NAME // 함수이름에 대한 번호
    {
        #region TEST_TABLE
        DB_SELECT_QUERY_BASE = 1,
        DB_INSERT_QUERY_BASE,
        DB_UPDATE_QUERY_BASE,
        DB_DELETE_QUERY_BASE,
        #endregion
    }

    public class CommDB_Base
    {
        private const string conString = "User Id=C##TEST; Password=1q2w3e4r;" +
           "Data Source =localhost:1521/orcl";

        public string? result = null;


        #region DB_'TEST_TABLE'_FUNC
        /// <summary>
        /// 오라클 db에서 값 조회
        /// </summary>
        /// <param name="input">들어오는 Json 형식의 문자열 값</param>
        public void db_Select_Query_Base(string input)
        {
            Test_TableModel_Base? test_Table = JsonSerializer.Deserialize<Test_TableModel_Base>(input); // json 문자열 -> Test_TableModel 역직렬화
            string query = "select * from C##TEST.TEST_TABLE where NAME_TEST = :input";
            using (OracleConnection conn = new OracleConnection(conString))
            {
                using (OracleCommand cmd = conn.CreateCommand())
                {
                    try
                    {
                        conn.Open();
                        cmd.BindByName = true;

                        cmd.CommandText = query;

                        OracleParameter input_base = new OracleParameter("input", test_Table._test_name); // input 파라미터 추가(:input 으로 값 들어감)
                        cmd.Parameters.Add(input_base);

                        OracleDataReader reader = cmd.ExecuteReader();
                        List<Test_TableModel_Base> list_test_table = new List<Test_TableModel_Base>();
                        while (reader.Read())
                        {
                            list_test_table.Add(new Test_TableModel_Base(reader.GetString(0)));
                        }
                        result = JsonSerializer.Serialize(list_test_table);// List<Test_TableModel_Base> 에서 json 형식 문자열로 직렬화
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

        /// <summary>
        /// 오라클 db에 값 insert
        /// </summary>
        /// <param name="input"> 들어오는 Json 형식의 문자열 값 </param>
        public void db_Insert_Query_Base(string input)
        {
            Test_TableModel_Base? test_Table = JsonSerializer.Deserialize<Test_TableModel_Base>(input);
            string query = "INSERT INTO C##TEST.TEST_TABLE(NAME_TEST) VALUES(:input)";
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


                            OracleParameter input_base = new OracleParameter("input", test_Table._test_name);
                            cmd.Parameters.Add(input_base);
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

        /// <summary>
        /// 오라클 db update
        /// </summary>
        /// <param name="input"> 들어오는 Json 형식의 문자열 값</param>
        public void db_Update_Query_Base(string input)
        {
            Test_TableModel_Base? test_Table = JsonSerializer.Deserialize<Test_TableModel_Base>(input);
            string query = "UPDATE C##TEST.TEST_TABLE SET NAME_TEST = :change_value WHERE NAME_TEST = :input";
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


                            OracleParameter input_base = new OracleParameter("input", test_Table._test_name);
                            cmd.Parameters.Add(input_base);
                            OracleParameter change_value_base = new OracleParameter("change_value", test_Table._test_name_change);
                            cmd.Parameters.Add(change_value_base);
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

        /// <summary>
        /// 오라클 db 멤버 delete
        /// </summary>
        /// <param name="input"> 들어오는 Json 형식의 문자열 값 </param>
        public void db_Delete_Query_Base(string input)
        {
            Test_TableModel_Base? test_Table = JsonSerializer.Deserialize<Test_TableModel_Base>(input);
            string query = "DELETE FROM C##TEST.TEST_TABLE WHERE NAME_TEST = :input";
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


                            OracleParameter input_base = new OracleParameter("input", test_Table._test_name);
                            cmd.Parameters.Add(input_base);
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

        // 내부 동작 함수
        #region DB_inner_select
        public Test_TableModel_Base db_Inner_Select_Query_Base(string input)
        {
            string query = "select * from C##TEST.TEST_TABLE where NAME_TEST = :input";
            Test_TableModel_Base? test_table = null;
            using (OracleConnection conn = new OracleConnection(conString))
            {
                using (OracleCommand cmd = conn.CreateCommand())
                {
                    try
                    {
                        conn.Open();
                        cmd.BindByName = true;

                        cmd.CommandText = query;

                        OracleParameter input_base = new OracleParameter("input", input);
                        cmd.Parameters.Add(input_base);

                        OracleDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            test_table =new Test_TableModel_Base(reader.GetString(0));
                        }
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
            return test_table;
        }
        #endregion
        #endregion
    }
}
