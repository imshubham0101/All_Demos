using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using table_attr01;

namespace Emp_Lib
{
    [Table (Tablename = "Employee")]
    public class Emp
    {
        [Column (Colname = "Emp_No",colType = "int")]
        private int _No = 10;

        public int No 
        {
            get { return _No; }
            set { _No = value; }
        }

        [Column (Colname = "Emp_Name",colType ="varchar(50)")]
        private string _Name = "DOTNET";

        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

    }
}
