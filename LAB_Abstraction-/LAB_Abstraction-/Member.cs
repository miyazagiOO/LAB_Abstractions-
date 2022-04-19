using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB_Abstraction_
{
    internal class Member
    {
        private string _name;
        private string _SSID;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public string SSID
        {
            get { return _SSID; }
            set { _SSID = value; }
        }
    }
}
