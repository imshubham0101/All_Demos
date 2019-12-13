using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Features01
{
    public delegate bool Mydelegate(int i);
    class Program
    {

        static void Main(string[] args)
        {

            #region Lambda Expression
            ////Mydelegate pointer = new Mydelegate(checkIn);
            ////bool result = pointer(20);
            ////Console.WriteLine(result);

            //Mydelegate pointer = delegate (int i)
            //{
            //    return (i < 10);
            //};
            //Console.WriteLine(pointer(20));

            //pointer = (i) =>
            //{
            //    return (i > 10);
            //};

            //Console.WriteLine(pointer(20));
            //Console.ReadLine();
            #endregion



        }

        public static bool checkIn(int i)
        {
            return (i > 10);
        }
    }

}
