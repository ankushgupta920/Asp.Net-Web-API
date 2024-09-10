using MyNewAspWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace MyNewAspWebAPI.Controllers
{
    public class NewApiController : ApiController
    {
        DataBaseFirstEFEntities db = new DataBaseFirstEFEntities();
        [System.Web.Http.HttpGet]
        public IHttpActionResult Index()
        {
            var obj = db.students.ToList();
            return Ok(obj);
        }

        [System.Web.Http.HttpGet]
        public IHttpActionResult Index(int id)
        {
            var obj = db.students.Where(model => model.Id == id).FirstOrDefault();
            return Ok(obj);
        }
    }
}
