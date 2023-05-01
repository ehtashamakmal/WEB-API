using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using WEBAPIS.Models;

namespace WEBAPIS.Controllers
{
    public class CrudApiController : ApiController
    {

        CRUD_WEB_APIEntities db = new CRUD_WEB_APIEntities();

        [System.Web.Http.HttpGet]
             public IHttpActionResult GetEmployees()
        {
            List<Employee> list = db.Employees.ToList();
            return Ok(list);
        }


        [System.Web.Http.HttpGet]
        public IHttpActionResult GetEmployeesbyId( int id)
        {
            var emp = db.Employees.Where(model => model.Id == id).FirstOrDefault();
            return Ok(emp);
        }

        [System.Web.Http.HttpPost]
        public IHttpActionResult EmpInsert(Employee e)
        {
            db.Employees.Add(e);
            db.SaveChanges();
            return Ok();
        }



        [System.Web.Http.HttpPut]
        public IHttpActionResult EmpUpdate(Employee e)
        {
            var emp = db.Employees.Where(model => model.Id == e.Id).FirstOrDefault();

            if(emp != null)
            {
                emp.Id = e.Id;
                emp.name = e.name;
                emp.gender = e.gender;
                emp.age = e.age;
                emp.designation = e.designation;
                emp.salary = e.salary;
                db.SaveChanges();
            }
            else
            {

                return NotFound();
            }
            return Ok();
        }

        [System.Web.Http.HttpDelete]
        public IHttpActionResult EmpDelete(int id)
        {
            var emp = db.Employees.Where(model => model.Id == id).FirstOrDefault();
            db.Entry(emp).State = System.Data.Entity.EntityState.Deleted;
            db.SaveChanges();
            return Ok();
        }
    }
}
