using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

namespace Collection
{
    class Program
    {
          

        static void Main(string[] args)
        {
            int choice;
            MyCollection c = new MyCollection();
            //File_Io file = null;
            while ((choice = Program.menu()) != 0)
            {
                Console.Clear();

                switch (choice)
                {
                    case 1:
                        Program.readSubmenu();
                        break;

                    case 2:
                        Program.writeSubmenu(c);
                        break;

                    case 3:
                        Program.fileType();
                        break;

                    default:
                        break;
                }

            } 
        }

        public static int menu()
        {
            Console.WriteLine("```````````````");
            Console.WriteLine("```````````````");
            Console.WriteLine("Enter Your choice");
            Console.WriteLine("0.EXIT");
            Console.WriteLine("1.Read");
            Console.WriteLine("2.Write");
            Console.WriteLine("3.File_IO");
            Console.WriteLine("```````````````");
            Console.WriteLine("```````````````");
            return (Convert.ToInt32( Console.ReadLine()));
            
        }

        public static void readSubmenu()
        {
            
            string ch = "y";
            do
            {
                Console.WriteLine("```````````````");
                Console.WriteLine("1.Read All Data");
                Console.WriteLine("2.Seach By Email");
                Console.WriteLine("Enter your Choice");
                int choice = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("```````````````");
                
                Console.Clear();

                Hashtable data = MyCollection.getHashTable();

                    switch (choice) { 
                    case 1:
                        Console.WriteLine("All Data");
                        Console.WriteLine();
                        foreach (object key in data.Keys)
                        {
                            object obj = data[key];
                            if (obj is int)
                            {
                                int i = Convert.ToInt32(obj);
                                Console.WriteLine("integer  " + i);

                            }
                            else if (obj is string)
                            {
                                string str = obj.ToString();
                                Console.WriteLine("string   " + str);
                            }
                            else if (obj is Emp)
                            {
                                Emp e = (Emp)obj;
                                Console.WriteLine(e.getDetails());
                            }
                        }
                       
                        

                        break;
                    case 2:
                        Console.WriteLine("Enter Email");
                        Console.WriteLine(  );
                        string email = Console.ReadLine();
                        foreach(object key in data.Keys)
                        {
                            if(key.ToString() == email)
                            {
                                object obj = data[key];
                                Emp e = (Emp)obj;
                                Console.WriteLine(e.getDetails());

                            }
                        }

                        break;
                    default:
                        break;
                }
             
                Console.WriteLine(  );
                Console.WriteLine("Do You Want To Continue");
                Console.WriteLine("y/n");
                ch = Console.ReadLine();
            } while (ch == "Y" || ch == "y");
        }

        public static void writeSubmenu(MyCollection c)
        {

            string ch = "y";
            do
            {
                Console.Clear();
                Console.WriteLine("```````````````");
                Console.WriteLine("1.Enter Integer");
                Console.WriteLine("2.Enter String");
                Console.WriteLine("3.Enter Employee Details");
                Console.WriteLine("Enter your Choice");
                int choice = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("```````````````");
                Console.Clear();

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Enter Integer Data");
                        c.insert(Convert.ToInt32(Console.ReadLine()));
                        break;
                    case 2:
                        Console.WriteLine("Enter String Data");
                        c.insert(Console.ReadLine());
                        break;
                    case 3:
                        Console.WriteLine("Enter Employee Details");
                        Console.WriteLine("```````````````");
                        Emp e = new Emp();
                        Console.WriteLine("No : ");
                        e.No = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Name :   ");
                        e.Name = Console.ReadLine();
                        Console.WriteLine("Address :    ");
                        e.Address = Console.ReadLine();
                        Console.WriteLine("Email :  ");
                        e.Email = Console.ReadLine();
                        c.insert(e);

                        break;
                    default:
                        break;
                }
                Console.WriteLine(  );
                Console.WriteLine("Do You Want To Continue");
                Console.WriteLine("y/n");
                ch = Console.ReadLine();
            } while (ch == "Y" || ch == "y");
        }

        public static void fileType()
        {
            string ch = "y";
            Console.WriteLine("1.Binary File");
            Console.WriteLine("2.XML File ");
            Console.WriteLine("Enter Your Choice");
            int choice = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("```````````````");
            Console.Clear();
            do
            {
                switch (choice)
                {
                    case 1:
                        Program.fileMenu(new Binary_file());
                        break;
                    case 2:
                        Program.fileMenu(new XML_file());
                        break;

                    default:
                        break;
                }
                Console.WriteLine();
                Console.WriteLine("Do You Want To Continue");
                Console.WriteLine("y/n");
                ch = Console.ReadLine();
            } while (ch == "Y" || ch == "y");

        }

        public static void fileMenu(File_Io f)
        {
            string ch = "y";
            Console.WriteLine("1.Write In File");
            Console.WriteLine("2.Read From File");
            Console.WriteLine("Enter the Choice");
            int choice = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("```````````````");
            Console.Clear();
            do
            {
                switch (choice)
                {
                    case 1:
                        f.writeFile();
                        break;
                    case 2:
                        f.readFile();
                        break;

                    default:
                        break;
                }
                Console.WriteLine();
                Console.WriteLine("Do You Want To Continue");
                Console.WriteLine("y/n");
                ch = Console.ReadLine();
            } while (ch == "Y" || ch == "y");
        }

        


    }

    public class MyCollection
    {

       private static Hashtable data = new Hashtable();
        public static Hashtable getHashTable()
        {
            return data;
        }

        public void insert(int value)
        {
           // Hashtable data = getHashTable();
            data.Add(value.GetHashCode(),value);
        } 

        public void insert(string value)
        {
           // Hashtable data = getHashTable();
            data.Add(value.GetHashCode(), value);

        }

        public void insert(Emp e)
        {
            //Hashtable data = getHashTable();
            data.Add(e.Email,e);
        }
        
    }

    [Serializable]
    public class Emp
    {

       
        private int _No;
        private string _Name;
        private string _Address;
        private string _Email;

        public string Email
        {
            get { return _Email; }
            set { _Email = value; }
        }


        public string Address
        {
            get { return _Address; }
            set { _Address = value; }
        }


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
            return string.Format("No. {0} Name :Mr/Mrs {1} Address : {2} Email : {3}", No, Name,Address,Email);
        }
    }

    public abstract class File_Io
    {

       
        protected Hashtable data = MyCollection.getHashTable();
        public abstract void  writeFile();
        public abstract void   readFile();


    }

    public class Binary_file : File_Io
    {
        public override void writeFile()
        {

            FileStream fs =
                new FileStream(@"D:\my_dotnet\Binary_Test.txt",
                                FileMode.OpenOrCreate,
                                FileAccess.Write);

            BinaryFormatter writer = new BinaryFormatter();


            writer.Serialize(fs, data);
            writer = null;
            fs.Close();
        }

        public override void readFile()
        {
            FileStream fs =
                new FileStream(@"D:\my_dotnet\Binary_Test.txt",
                                FileMode.Open,
                                FileAccess.Read);

            BinaryFormatter reader = new BinaryFormatter();

            Hashtable sdata = (Hashtable)reader.Deserialize(fs);

            foreach (object key in sdata.Keys)
            {
                object obj = sdata[key];
                if (obj is int)
                {
                    int i = Convert.ToInt32(obj);
                    Console.WriteLine("integer  " + i);

                }
                else if (obj is string)
                {
                    string str = obj.ToString();
                    Console.WriteLine("string   " + str);
                }
                else if (obj is Emp)
                {
                    Emp e = (Emp)obj;
                    Console.WriteLine(e.getDetails());
                }
            }


            reader = null;
            fs.Close();
        }

      
    }

    public class XML_file : File_Io
    {
        public override void readFile()
        {
            FileStream fs = new FileStream(@"D:\my_dotnet\XML_Test.txt",
                                               FileMode.Open,
                                               FileAccess.Read);
            XmlSerializer reader = new XmlSerializer(typeof(Hashtable));

            Hashtable sdata = (Hashtable)reader.Deserialize(fs);

            foreach(object key in sdata.Keys)
            {
               
                object obj = sdata[key];
                if (obj is int)
                {
                    int i = Convert.ToInt32(obj);
                    Console.WriteLine("integer  " + i);

                }
                else if (obj is string)
                {
                    string str = obj.ToString();
                    Console.WriteLine("string   " + str);
                }
                else if (obj is Emp)
                {
                    Emp e = (Emp)obj;
                    Console.WriteLine(e.getDetails());
                }
            }
        }

        public override void writeFile()
        {
            FileStream fs = new FileStream(@"D:\my_dotnet\XML_Test.txt",
                                                FileMode.OpenOrCreate,
                                                FileAccess.Write);
            XmlSerializer writer = new XmlSerializer(typeof(Hashtable));

            writer.Serialize(fs, data);
            writer = null;
            fs.Close();
            
        }
    }


}
