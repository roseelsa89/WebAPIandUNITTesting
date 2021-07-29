using Microsoft.Extensions.DependencyInjection;
using System;

namespace WebAPI
{
    class Program
    {
        private readonly EmployeeHelper _employeeHelper;
        public Program(EmployeeHelper employeeHelper)
        {
            _employeeHelper = employeeHelper;
        }
        static void Main(string[] args)
        {
            IServiceCollection services = new ServiceCollection();
            Startup startup = new Startup();
            startup.ConfigureServices(services);
            IServiceProvider serviceProvider = services.BuildServiceProvider();
            var myClass = serviceProvider.GetService<LoggerClass>();

            try
            {  
                EmployeeHelper empHelper = new EmployeeHelper(new Helpers.APIHelper());
                int count = empHelper.GetEmployeeData();  
                myClass.SomeMethod(count);               
                Console.ReadLine();
            }
            catch(Exception ex)
            {
                myClass.Error("Error in Program Main : " + ex);
                Console.ReadLine();
            }            
        }      
    }   
}
