using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApplication1.Controllers
{
    public class EmployeeDataController : ApiController
    {
        string[] myEmployee = { "Ankush", "Rajat", "Sunil" };
        [HttpGet]
        public string[] GetEmployees()
        {
            return myEmployee;
        }
        public string GetEmployeesByID(int id)
        {
            return myEmployee[id];
        }
    }
}
