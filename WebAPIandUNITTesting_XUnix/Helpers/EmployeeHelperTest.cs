using System;
using WebAPI;
using WebAPI.Helpers;
using Xunit;

namespace XUnixTesting
{
    public class EmployeeHelperTest 
    {       
        [Fact]
        public void GetEmployeeDataTest()
        {
            try
            {
                var apiHelp = new APIHelper();
                EmployeeHelper empHelper = new EmployeeHelper(apiHelp);
                int cnt = empHelper.GetEmployeeData();
                Assert.True(cnt > 0);
            }
            catch(Exception ex)
            {                
                throw ex;
            }           
        }
    }   
}
