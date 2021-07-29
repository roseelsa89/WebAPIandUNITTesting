using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using WebAPI.Helpers;

namespace WebAPI
{
    public class EmployeeHelper
    {
        private readonly APIHelper _apiHelper;
        public EmployeeHelper(APIHelper apiHelper)
        {
            _apiHelper = apiHelper;
        }

        public int GetEmployeeData()
        {
            IServiceCollection services = new ServiceCollection();
            Startup startup = new Startup();
            startup.ConfigureServices(services);
            IServiceProvider serviceProvider = services.BuildServiceProvider();
            var myClass = serviceProvider.GetService<LoggerClass>();

            try
            {   
                string resAPI = _apiHelper.ApiCall();
                Employees Items = JsonConvert.DeserializeObject<Employees>(resAPI);
                int count = 0;

                Console.WriteLine("Page:" + Items.Page);
                Console.WriteLine("PerPage:" + Items.PerPage);
                Console.WriteLine("Total:" + Items.Total);
                Console.WriteLine("TotalPages:" + Items.TotalPages);
                Console.WriteLine("Url:" + Items.Support.Url);
                myClass.SomeMethodMsg("Message(Outside Loop): " + Convert.ToString(count));
                foreach (var item in Items.Data)
                {
                    Console.WriteLine("Id:" + item.Id);
                    Console.WriteLine("Email:" + item.Email);
                    Console.WriteLine("FirstName:" + item.FirstName);
                    Console.WriteLine("LastName:" + item.LastName);
                    Console.WriteLine("Avatar:" + item.Avatar);
                    count++;
                    myClass.SomeMethodMsg("Message(Inside Loop): " + Convert.ToString(count));
                }
                myClass.SomeMethodMsg("Message(Outside Loop): " + Convert.ToString(count));
                return count;
            }
            catch (Exception ex)
            {
                myClass.Error("Error in GetEmployeeData :" + ex);
                return 0;
            }
        }
    }
}
