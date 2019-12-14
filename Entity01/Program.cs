using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity01
{
    class Program
    {
        static void Main(string[] args)
        {
            EmployeeEntities emp = new EmployeeEntities();
            foreach (var item in emp.Employees.ToList())
            {
                Console.WriteLine(item.Id+" :: "+item.Name+" :: "+item.Address);
            }
            Console.ReadLine();
        }
    }
}
