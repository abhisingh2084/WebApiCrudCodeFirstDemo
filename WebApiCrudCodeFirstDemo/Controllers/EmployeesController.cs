using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiCrudCodeFirstDemo.Data;
using WebApiCrudCodeFirstDemo.Models;

namespace WebApiCrudCodeFirstDemo.Controllers
{
    public class EmployeesController : ApiController
    {
        public HttpResponseMessage Get()
        {
            using (ApplicationDbContext dbContext = new ApplicationDbContext()) 
            {
                return Request.CreateResponse(HttpStatusCode.OK, dbContext.Employees.ToList());
            }
        }

        public HttpResponseMessage Get(int id)
        {
            using (ApplicationDbContext dbContext = new ApplicationDbContext())
            {
                var emp = dbContext.Employees.FirstOrDefault(e => e.Id == id);
                if (emp != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, emp);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Employe with Id " + id + "not Found in Database");
                }

            }
        }

        public HttpResponseMessage Post(Employee employee)
        {
            using (ApplicationDbContext dbContext = new ApplicationDbContext()) 
            {
                if(employee != null)
                {
                    dbContext.Employees.Add(employee);
                    dbContext.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.Created, employee);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Please Provoid Proper Input data to craete an Employee");
                }
            }
        }

        public HttpResponseMessage Put(int id , Employee employee)
        {
            using (ApplicationDbContext dbContext = new ApplicationDbContext())
            {
                var emp = dbContext.Employees.FirstOrDefault(e =>  (e.Id == id));
                if ( emp != null)
                {
                    emp.FirstName = employee.FirstName;
                    emp.LastName = employee.LastName;
                    emp.Gender = employee.Gender;
                    emp.City = employee.City;
                    emp.IsActive = employee.IsActive;
                    dbContext.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.OK, emp);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Employee with Id " + id + "Not found in database");
                }
            }
        }

        public HttpResponseMessage Delete(int id)
        {
            using (ApplicationDbContext dbContext = new ApplicationDbContext())
            {
                var emp = dbContext.Employees.FirstOrDefault(e => e.Id == id);
                 if( emp != null)
                {
                    dbContext.Employees.Remove(emp);
                    dbContext.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.OK, emp);
                }
                 else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Employee with Id" + id + "not found in database");
                }
            }
        }
    }
}
