using Asp_WebApi_Crud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace Asp_WebApi_Crud.Controllers
{
    public class CrudApiController : ApiController
    {
        Web_Api_Crud_DBEntities db  = new Web_Api_Crud_DBEntities();
        [System.Web.Http.HttpGet]
        public IHttpActionResult GetEmployee()
        {
            var data = db.Employees.ToList();
            return Ok(data);
        }
        [System.Web.Http.HttpGet]
        public IHttpActionResult GetEmployeeByID(int id)
        {
            var data = db.Employees.Where(model => model.id == id).FirstOrDefault();
            return Ok(data);
        }

        [System.Web.Http.HttpPost]
        public IHttpActionResult EmpInsert(Employee obj)
        {
            db.Employees.Add(obj);
            db.SaveChanges();
            return Ok();
        }
        [System.Web.Http.HttpPut]
        public IHttpActionResult EmpUpdate(Employee obj)
        {
            db.Entry(obj).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return Ok();
        }
        [System.Web.Http.HttpDelete]
        public IHttpActionResult DeleteEmployee(int id)
        {
            var data = db.Employees.Where(model => model.id == id).FirstOrDefault();
            db.Entry(data).State = System.Data.Entity.EntityState.Deleted;
            db.SaveChanges();
            return Ok();
        }

    }
}
