using Oracle.ManagedDataAccess.Client;
using System.Data;
using System.Text.Json;
using KKOK_WEB.Models;

namespace KKOK_WEB.CommDB
{
    enum DB_MEMBER_FUNC_NAME
    {
        #region TEST_TABLE
        DB_SELECT_QUERY_MEMBER = 1,
        DB_INSERT_QUERY_MEMBER,
        DB_UPDATE_QUERY_MEMBER,
        DB_DELETE_QUERY_MEMBER,
        #endregion
    }

    public class CommDB_Member
    {
        private const string conString = "User Id=C##TEST; Password=1q2w3e4r;" +
           "Data Source =localhost:1521/orcl";

        public string? result = null;


        #region DB_'TEST_TABLE'_FUNC
        public void db_Select_Query(string input)
        {
            MemberModel? Member_Table = JsonSerializer.Deserialize<MemberModel>(input);
            string query = "select * from C##TEST.TEST_MEMBER where MEMBER_CODE = :input";
            using (OracleConnection conn = new OracleConnection(conString))
            {
                using (OracleCommand cmd = conn.CreateCommand())
                {
                    try
                    {
                        conn.Open();
                        cmd.BindByName = true;

                        cmd.CommandText = query;

                        OracleParameter input_base = new OracleParameter("input", Member_Table._member_code);
                        cmd.Parameters.Add(input_base);

                        OracleDataReader reader = cmd.ExecuteReader();
                        List<MemberModel> list_test_table = new List<MemberModel>();
                        while (reader.Read())
                        {
                            list_test_table.Add(new MemberModel(int.Parse(reader.GetString(0)), reader.GetString(1), reader.GetString(2), 
                                reader.GetString(3), reader.GetString(4), reader.GetString(5),int.Parse(reader.GetString(6))));
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
            MemberModel? Member_Table = JsonSerializer.Deserialize<MemberModel>(input);
            string query = "INSERT INTO C##TEST.TEST_MEMBER VALUES(:code, :id, :pwd, :name, :email, :phone, :permission)";
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


                            OracleParameter input_code = new OracleParameter("code", 1111 + db_CountAll_Select_Query());
                            cmd.Parameters.Add(input_code);
                            OracleParameter input_id = new OracleParameter("id", Member_Table._member_id);
                            cmd.Parameters.Add(input_id);
                            OracleParameter input_pwd = new OracleParameter("pwd", Member_Table._member_pwd);
                            cmd.Parameters.Add(input_pwd);
                            OracleParameter input_name = new OracleParameter("name", Member_Table._member_name);
                            cmd.Parameters.Add(input_name);
                            OracleParameter input_email = new OracleParameter("email", Member_Table._member_email);
                            cmd.Parameters.Add(input_email);
                            OracleParameter input_phone = new OracleParameter("phone", Member_Table._member_phone);
                            cmd.Parameters.Add(input_phone);
                            OracleParameter input_permission = new OracleParameter("permission", Member_Table._member_permission);
                            cmd.Parameters.Add(input_permission);

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
            MemberModel? Member_Table = JsonSerializer.Deserialize<MemberModel>(input);
            string query = "UPDATE C##TEST.TEST_MEMBER SET MEMBER_PWD = :change_pwd, MEMBER_EMAIL = :change_email, MEMBER_PHONE = :change_phone WHERE MEMBER_CODE = :code";
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


                            OracleParameter input_code = new OracleParameter("code", Member_Table._member_code);
                            cmd.Parameters.Add(input_code);

                            OracleParameter change_value_pwd = new OracleParameter("change_pwd", Member_Table._member_pwd);
                            cmd.Parameters.Add(change_value_pwd);
                            OracleParameter change_value_email = new OracleParameter("change_emial", Member_Table._member_email);
                            cmd.Parameters.Add(change_value_email);
                            OracleParameter change_value_phone = new OracleParameter("change_phone", Member_Table._member_phone);
                            cmd.Parameters.Add(change_value_phone);
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
            MemberModel? Member_Table = JsonSerializer.Deserialize<MemberModel>(input);
            string query = "DELETE FROM C##TEST.TEST_MEMBER WHERE MEMBER_CODE = :code";
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


                            OracleParameter input_code = new OracleParameter("code", Member_Table._member_code);
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
            int query_result = 0;
            string query = "select COUNT(*) from C##TEST.TEST_TABLE";
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
