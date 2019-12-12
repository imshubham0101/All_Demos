using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using MeraPointer;

namespace StudentLib
{
    [Serializable]
    public class Student
    {
        [Serializable]
        public delegate void Mydelegate(String msg);
        public static event Mydelegate Admitted ;

        public static void DoItNow(String name) {

            Admitted(name);
        }


       
    }
}

//namespace MeraPointer
//{
//    [Serializable]
//    public delegate void Mydelegate(String msg);
//}
