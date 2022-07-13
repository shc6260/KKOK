namespace KKOK_WEB.Models
{
    public class ProjectModel
    {
        private int pjt_code;
        private string pjt_name;
        private DateTime pjt_startdate;
        private DateTime pjt_enddate;

        public int _pjt_code
        {
            get { return pjt_code; }
        }
        public string _pjt_name
        {
            get { return pjt_name; }
        }
        public DateTime _pjt_startdate
        {
            get { return pjt_startdate; }
        }
        public DateTime _pjt_enddate
        {
            get { return pjt_enddate; }
        }

        public ProjectModel(int code, string name, DateTime startdate, DateTime enddate)
        {
            pjt_code = code;
            pjt_name = name;
            pjt_startdate = startdate;
            pjt_enddate = enddate;
        }
    }
}
