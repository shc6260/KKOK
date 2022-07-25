using OracleEFCore5.Domain.Common;

namespace OracleEFCore5.Domain.Entities.DBTables
{
    public class Member : AuditableBaseEntity
    {
        public int member_code { get; set; }
        public string member_id { get; set; }
        public string member_pwd { get; set; }
        public string member_name { get; set; }
        public string member_email { get; set; }
        public string member_phone { get; set; }
        public int member_permission { get; set; }
    }
}
