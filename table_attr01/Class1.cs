using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace table_attr01
{
    public class Table : Attribute
    {
        private string _Tablename;

        public string Tablename
        {
            get { return _Tablename; }
            set { _Tablename = value; }
        }
    }

    public class Column : Attribute
    {
        private string _Colname;

        public string Colname
        {
            get { return _Colname; }
            set { _Colname = value; }
        }

        private string _coltype;

        public string colType
        {
            get { return _coltype; }
            set { _coltype = value; }
        }



    }
}
