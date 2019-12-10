using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeraPointer;

namespace StudentLib
{
    public class Student
    {

        public static event Mydelegate Admitted ;

        public static void DoItNow(String name) {

            Admitted(name);
        }


       
    }
}

namespace MeraPointer
{
    public delegate void Mydelegate(String msg);
}
