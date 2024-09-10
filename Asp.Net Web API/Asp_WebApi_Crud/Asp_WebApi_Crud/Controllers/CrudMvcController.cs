using Asp_WebApi_Crud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace Asp_WebApi_Crud.Controllers
{
    public class CrudMvcController : Controller
    {
        // GET: CrudMvc
        HttpClient client = new HttpClient();
        public ActionResult Index()
        {
            List<Employee> emp_list = new List<Employee>();
            client.BaseAddress = new Uri("https://localhost:44341/api/CrudApi");
            var response = client.GetAsync("CrudApi");
            response.Wait();

            var test = response.Result;
            if(test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<List<Employee>>();
                display.Wait();
                emp_list = display.Result;
            } 
            return View(emp_list);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Employee obj)
        {
            client.BaseAddress = new Uri("https://localhost:44341/api/CrudApi");
            var response = client.PostAsJsonAsync<Employee>("CrudApi",obj);
            response.Wait();

            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View("Create");
            
        }
        public ActionResult Details(int id)
        {
            Employee obj = null;
            client.BaseAddress = new Uri("https://localhost:44341/api/CrudApi");
            var response = client.GetAsync("CrudApi?id="+id.ToString());
            response.Wait();

            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<Employee>();
                display.Wait();
                obj = display.Result;
            }
            return View(obj);          
        }
        public ActionResult Edit(int id)
        {
            Employee obj = null;
            client.BaseAddress = new Uri("https://localhost:44341/api/CrudApi");
            var response = client.GetAsync("CrudApi?id=" + id.ToString());
            response.Wait();

            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<Employee>();
                display.Wait();
                obj = display.Result;
            }
            return View(obj);
        }
        [HttpPost]
        public ActionResult Edit(Employee obj)
        {
            client.BaseAddress = new Uri("https://localhost:44341/api/CrudApi");
            var response = client.PutAsJsonAsync<Employee>("CrudApi", obj);
            response.Wait();

            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View("Edit");
        }
        public ActionResult Delete(int id)
        {
            Employee obj = null;
            client.BaseAddress = new Uri("https://localhost:44341/api/CrudApi");
            var response = client.GetAsync("CrudApi?id=" + id.ToString());
            response.Wait();

            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<Employee>();
                display.Wait();
                obj = display.Result;
            }
            return View(obj);
        }
        [HttpPost,ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            client.BaseAddress = new Uri("https://localhost:44341/api/CrudApi");
            var response = client.DeleteAsync("CrudApi/"+ id.ToString());
            response.Wait();

            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View("Delete");
        }
    }
}