using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HiMVCDomain
{
    // This project can output the Class library as a NuGet Package.
    // To enable this option, right-click on the project and select the Properties menu item. In the Build tab select "Produce outputs on build".
    public class Lecturer
    {
        public Lecturer() {}

        public string Name { get; set; }

        public int Rating { get; set; }

        public string Address { get; set; }
    }
}
