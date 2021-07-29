using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net;

namespace WebAPI.Helpers
{
    public interface IApiCal
    {
        string ApiCall();
    }
    public class APIHelper : IApiCal
    {     
        private const string URL = "https://reqres.in/api/users?page=2";
        public string ApiCall()
        {
            IServiceCollection services = new ServiceCollection();
            IServiceProvider serviceProvider = services.BuildServiceProvider();
            var myClass = serviceProvider.GetService<LoggerClass>();
            var result = "";
            try
            {                
                using (var client = new WebClient())
                {
                    client.Headers.Add("Content-Type:application/json");
                    client.Headers.Add("Accept:application/json");
                    result = Convert.ToString(client.DownloadString(URL));                   
                }               
            }
            catch(Exception ex)
            {
                myClass.Error("Error in ApiCall :" + ex);               
            }
            return result;
        }
    }
}
