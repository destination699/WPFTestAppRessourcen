using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFTestAppRessourcen
{
    partial class Person
    {
        override public string ToString()
        {
            string x = string.Empty;

            x = this.Name + " " + this.Vorname;

            return x;
        }
    }
}
