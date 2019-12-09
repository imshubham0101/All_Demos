using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basic01
{

    public delegate void Mydelegate(String msg);

    class Program
    {
        static void Main(string[] args)
        {
            Mydelegate pointer = new Mydelegate(SayHello);

            Student s1 = new Student();

            s1.Admitted += pointer;

            s1.DoAdmit("Shubham");

            Console.ReadLine();


        }

      

        private static void SayHello(string name)
        {
            Console.WriteLine("Welcome Mr/Mrs "+name);
        }
    }

    public class Student
    {
        public event Mydelegate Admitted ; 

        public void DoAdmit(String name)
        {
            Admitted(name);
        }
    }
}
