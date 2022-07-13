namespace KKOK_WEB.Models
{
    public class MemberModel
    {
        private int member_code;
        private string member_id;
        private string member_pwd;
        private string member_name;
        private string member_email;
        private string member_phone;
        private int member_permission;

        public int _member_code
        {
            get { return member_code; }
        }
        public string _member_id
        {
            get { return member_id; }
        }
        public string _member_pwd
        {
            get { return member_pwd; }
        }
        public string _member_name
        {
            get { return member_name; }
        }
        public string _member_email
        {
            get { return member_email; }
        }
        public string _member_phone
        {
            get { return member_phone; }
        }
        public int _member_permission
        {
            get { return member_permission; }
        }

        public MemberModel(int code, string id, string pwd, string name, string email, string phone, int permission)
        {
            member_code = code;
            member_id = id;
            member_pwd = pwd;
            member_name = name;
            member_email = email;
            member_phone = phone;
            member_permission = permission;
        }
    }
}
