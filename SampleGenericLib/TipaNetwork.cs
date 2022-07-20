using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace SampleGenericLib
{
    public class TipaNetwork<T> where T : Enum
    {
        public Array valuesArray;
        public T valuesT;
        public List<T> sent = new List<T>();
        private int sentCount = 0;
        private int genericSentCount = 0;

        //public TipaNetwork() 
        //{
        //    //values = (T)arg;
        //    valuesArray = Enum.GetValues(typeof(T));
        //    //foreach (var item in valuesArray)
        //    //{
        //    //    valuesT = (T)Enum.Parse(typeof(T), item.ToString(), true);
        //    //    Console.WriteLine(valuesT);
        //    //}
        //}

        public void SendNahui(string message)
        {
            message += " отправлено нахуй конкретно";
            Increase(false);
            //values.Add(message);
            Console.WriteLine(message);
        }

        public void SendVpizdu(T element)
        {
            string message = element.ToString() + " послано впизду обобщенно";
            Increase(true);
            sent.Add(element);

            Console.WriteLine(message);
        }
        private void Increase(bool isGeneric)
        {
            if (isGeneric)
                genericSentCount++;
            else
                sentCount++;
        }

        public void ShowInfo(string type)
        {
            Console.WriteLine("\n\nИТОГО по экземпляру {0}:", type);
            Console.WriteLine("Послано конкретных пакетов: {0}", sentCount);
            Console.WriteLine("Послано обобщенных пакетов: {0}; вот их список:", genericSentCount);
            foreach (var item in sent) 
                Console.WriteLine(item);
        }
    }

    class stackfound {
    public void Go()
    {
        // Get the current application domain for the current thread
        AppDomain currentDomain = AppDomain.CurrentDomain;

        // Create a dynamic assembly in the current application domain,
        // and allow it to be executed and saved to disk.
        AssemblyName name = new AssemblyName("MyEnums");
        AssemblyBuilder assemblyBuilder = currentDomain.DefineDynamicAssembly(name,
                                              AssemblyBuilderAccess.RunAndSave);

        // Define a dynamic module in "MyEnums" assembly.
        // For a single-module assembly, the module has the same name as the assembly.
        ModuleBuilder moduleBuilder = assemblyBuilder.DefineDynamicModule(name.Name,
                                          name.Name + ".dll");

        // Define a public enumeration with the name "MyEnum" and an underlying type of Integer.
        EnumBuilder myEnum = moduleBuilder.DefineEnum("EnumeratedTypes.MyEnum",
                                 TypeAttributes.Public, typeof(int));

        // Get data from database
        //MyDataAdapter someAdapter = new MyDataAdapter();
        //MyDataSet.MyDataTable myData = myDataAdapter.GetMyData();

        //foreach (MyDataSet.MyDataRow row in myData.Rows)
        //{
        //    myEnum.DefineLiteral(row.Name, row.Key);
        //}

        // Create the enum
        myEnum.CreateType();

        // Finally, save the assembly
        assemblyBuilder.Save(name.Name + ".dll");
    }

}
}