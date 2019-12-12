using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using table_attr01;
 
namespace _01Reflection
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Path of any .NET Assembly to see the details");
            string path = Console.ReadLine();           //give dll path here 
            Assembly assembly = Assembly.LoadFrom(path); // load assembly file of the given path 
            Type[] types = assembly.GetTypes(); //get the different types present in assembly file

            foreach (Type type in types)
            {
                List<Attribute> allAttributes = type.GetCustomAttributes().ToList();
                // -- get all the attributes present in types and put into List                                                                  

                bool isSerializable = false;

                foreach (Attribute attr in allAttributes) //check the attributes one by one present in type 
                {
                    if(attr is SerializableAttribute)
                    {
                        isSerializable = true;
                        Console.WriteLine(type.Name + " is Serializable");
                    }
                    if(attr is Table)
                    {
                        Table table = (Table) attr;
                        Console.WriteLine("Create table "+ table.Tablename + "( )");
                        object dynamicObjectOfSomeType = null;
                        PropertyInfo[] properties = type.GetProperties();
                        foreach (PropertyInfo  property in properties)
                        {
                            Console.WriteLine("Properties");
                            Console.WriteLine(property.Name);
                            dynamicObjectOfSomeType =
                    assembly.CreateInstance(type.FullName);
                            Console.WriteLine(property.GetValue(dynamicObjectOfSomeType));
                        }
                        
                    }

                }

                if (isSerializable != true)
                {
                    Console.WriteLine(type.Name + " is not marked as Serializable!");
                }
                Console.WriteLine("__________________________________________");
                Console.WriteLine("__________________________________________");
                Console.WriteLine(type.Name);
                MethodInfo[] methods =  //get all methods of a type
                    type.GetMethods(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public);
                Console.WriteLine("   |  ");
                Console.WriteLine();
                foreach (MethodInfo method in methods) //Iterate through each method
                {
                    Console.Write("-------"+method.ReturnType.ToString()+ " "+ method.Name +"  ( " );
                    ParameterInfo[] allparams = method.GetParameters(); //get all parameters of method
                    foreach (ParameterInfo param in allparams) 
                    {
                        Console.Write(param.ParameterType + "   "+param.Name + "    ");
                    }
                    Console.Write(")");
                    Console.WriteLine();

                }


               

            }
            Console.ReadLine();

        }
    }
}
