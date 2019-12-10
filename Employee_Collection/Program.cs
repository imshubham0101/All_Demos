using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_Collection
{
    class Program
    {
        static void Main(string[] args)
        {
            Emp e1 = new Emp();
            e1.No = 1;
            e1.Name = "Pradeep";

            Console.WriteLine(e1.getDetails());
            Console.ReadLine(); 
        }
    }

    public class Emp
    {
       
        private string _Name;
        private int _No;

        public int No
        {
            get { return _No; }
            set { _No = value; }
        }

        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        public string getDetails()
        {
            return string.Format("No. {0} Name :Mr/Mrs {1}", No, Name);
        }
    }
}
