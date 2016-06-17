using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using static System.Console;

namespace HiMVC.Models.Domain
{
    // This project can output the Class library as a NuGet Package.
    // To enable this option, right-click on the project and select the Properties menu item. In the Build tab select "Produce outputs on build".
    public partial class Lecturer : Lector, Ilect, IlectMore
    {

        int @long = 0x2A, @longer = 700;
        
        public Lecturer() {}

        public string Name { get; set; }

        public int Rating { get; set; }

        public string Address { get; set; }

        public void A() => SomethingDone("A");

        public bool B() => SomethingDone("A");

        public bool SomethingDone(string n) { return true; }

        public void HackSomeStuff()
        {
            string someString = default(string);

            SomethingDone(someString);
            int[,] cells =
            {
                {1, 0, 2 },
                {1, 2, 0 },
                {1, 2, 1 }
            };
        }
    }

    public partial class Lecturer
    {
        public long Id { get; set; }
    }


    public abstract class Lector
    {
        private int xcode = 5;

        //protected void Todo() => WriteLine(nameof(xcode));
    }

    interface Ilect
    {
        void A();
    }

    interface IlectMore
    {
        bool B();
    }
}
