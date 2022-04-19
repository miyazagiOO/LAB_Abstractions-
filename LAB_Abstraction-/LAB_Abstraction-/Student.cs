using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB_Abstraction_
{
    internal class Student : Member
    {
        private string _student_id;
        private string _major;

        public string Student_Id
        {
            get { return _student_id; }
            set { _student_id = value; }
        }
        public string Student_Name
        {
            get { return _major; }
            set { _major = value; }
        }

    }
}
