using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB_Abstraction_
{
    internal class Teacher : Member
    {
        private string _major;

        public string Major
        {
            get { return _major; }
            set { _major = value; }
        }
    }
}
