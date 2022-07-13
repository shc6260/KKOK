namespace KKOK_WEB.Models
{
    public class Test_TableModel_Base
    {
        private string test_Name;

        public string _test_name
        {
            get { return test_Name; }
        }

        private string test_Name_change;

        public string _test_name_change
        {
            get { return test_Name_change; }
        }

        public Test_TableModel_Base(string input_test_Name)
        {
            test_Name = input_test_Name;
        }
        public Test_TableModel_Base(string input_test_Name , string input_change_Name)
        {
            test_Name = input_test_Name;
            test_Name_change = input_change_Name;
        }
    }
}
