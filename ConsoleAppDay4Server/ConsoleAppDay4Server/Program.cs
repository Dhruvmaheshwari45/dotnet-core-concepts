using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLib;


namespace ConsoleAppDay4Server
{
    public class ViewModel
    {
        public string Name { get; set; }
        public int ID { get; set; }
        public int Did { get; set; }
    }
    public interface IData
    {
        List<ViewModel> GetData();
    }
    public class FakeRepo : IData
    {
        public List<ViewModel> GetData()
        {
            List<ViewModel> data = new List<ViewModel>();
            data.Add(new ViewModel { ID = 1111, Name = "Udhay", Did = 110 });
            data.Add(new ViewModel { ID = 1112, Name = "Deepshikha", Did = 120 });
            data.Add(new ViewModel { ID = 1113, Name = "Pawan", Did = 110 });
            data.Add(new ViewModel { ID = 1114, Name = "Chetan", Did = 110 });
            data.Add(new ViewModel { ID = 1115, Name = "Shima", Did = 120 });
            return data;
        }
    }
    public class ActualRepo : IData
    {
        private readonly string connStr = string.Empty;
        public ActualRepo()
        {
            connStr = ConfigurationManager.ConnectionStrings["dacBangCnnStr"].ConnectionString;
        }
        public List<ViewModel> GetData()
        {
            CDataLib cdal = new CDataLib(connStr);
            List<ViewModel> data = new List<ViewModel>();
            foreach (var item in cdal.GetEmployees())
            {
                data.Add(new ViewModel { ID = item.EmpId, Name = item.EmpName, Did = item.DeptId });
            }
            return data;
        }
    }

    public class Business
    {
        IData data;
        public Business(IData data)
        {
            this.data = data;
        }
        public void Display()
        {
            Console.WriteLine("{0, -10} {1, -20} {2, -10}", "ID", "NAME", "DID");
            foreach (var emp in data.GetData())
            {
                Console.WriteLine("{0, -10} {1, -20} {2, -10}", emp.ID, emp.Name, emp.Did);
            }
        }

    }

    internal class Program
    {
        static IData DataFactory()
        {
            //return new FakeRepo();
            return new ActualRepo();
        }
        static void Main1(string[] args)
        {
            Business business = new Business(DataFactory());
            business.Display();
        }

        static void Main(string[] args)
        {
            //IOC Containers (Inversion of Control)
            IKernel kernel = new StandardKernel();
            kernel.Bind<IData>().To<ActualRepo>();
            //kernel.Bind<IData>().To<FakeRepo>();

            Business business = kernel.Get<Business>();
            business.Display();
        }
    }
}