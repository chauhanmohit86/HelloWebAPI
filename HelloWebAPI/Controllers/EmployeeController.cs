using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EmployeeBusiness;
using EmployeeBusiness.ViewModels;
using System.Web.Http.Description;
using System.Threading.Tasks;
using TestDemoData;

namespace HelloWebAPI.Controllers
{
    [RoutePrefix("api/Employee")]
    public class EmployeeController : ApiController
    {
        OrganizationEntities ON = new OrganizationEntities();
        EmployeeProcessor EP = new EmployeeProcessor();

        //[Route("{EmpId:int}")]
        //[System.Web.Http.AcceptVerbs("GET", "POST")]
        //[System.Web.Http.HttpPost]
        //public HttpResponseMessage GetEmployeeById(int EmpId)
        //{
        //    string employee = string.Empty;
        //    try
        //    {
        //        employee = EP.GetEmployeeById(EmpId.ToString());

        //    }
        //    catch (Exception ex)
        //    {
        //        return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
        //    }
        //    return Request.CreateResponse(HttpStatusCode.OK, employee);
        //}

        [Route("{EmpId:int}")]
        [System.Web.Http.AcceptVerbs("GET", "POST")]
        [System.Web.Http.HttpGet]
        [ResponseType(typeof(Employee))]
        public async Task<IHttpActionResult> GetEmployeeById(int EmpId)
        {
            
            EmployeeDetail emp = await ON.EmployeeDetails.FindAsync(EmpId.ToString());

            Employee employee = new Employee()
            {
                EmployeeName = emp.EmployeeName,
                EmployeeID = emp.EmployeeID,
                EmailID = emp.EmailID,
                Phone = emp.Phone,
                Salary = emp.Salary,
                City = emp.City
            };

            //employee = EP.GetEmployeeById(EmpId.ToString());
            if (emp == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }

        [Route("")]
        [System.Web.Http.HttpGet]
        public HttpResponseMessage GetAllEmployee()
        {
            string employees = string.Empty;
            try
            {
                employees = EP.GetAllEmployeeData();
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
            return Request.CreateResponse(HttpStatusCode.OK, employees);
        }

        [Route("{empid}/{phone}")]
        [System.Web.Http.HttpGet]
        public HttpResponseMessage DeleteEmployee(string empid, string phone)
        {
            string employees = string.Empty;
            try
            {
                EP.DeleteEmpliyee(empid, phone);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
            return Request.CreateResponse(HttpStatusCode.OK, "Deleted the employee successfully.");
        }

        [Route("{empid:int}/{empname}/{emailid}/{phone}/{salary:int}/{city}")]
        [System.Web.Http.AcceptVerbs("GET", "POST")]
        [System.Web.Http.HttpPost]
        public HttpResponseMessage UpDateEmployee(int empid, string empname, string emailId, string phone, int salary, string city)
        {
            string employees = string.Empty;
            try
            {
                EP.UpdateEmployee(empid.ToString(), empname, emailId, phone, salary, city);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
            return Request.CreateResponse(HttpStatusCode.OK, "Updated the employee: " + empname + ".");
        }

        [Route("{empid:int}/{empname}/{emailid}/{phone:int}/{salary:int}/{city}")]
        [System.Web.Http.AcceptVerbs("GET", "POST")]
        [System.Web.Http.HttpPost]
        public HttpResponseMessage AddNewEmployee(int empid, string empname, string emailId, int phone, int salary, string city)
        {
            string employees = string.Empty;
            try
            {
                EP.AddNewEmployee(empid, empname, emailId, phone, salary, city);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
            return Request.CreateResponse(HttpStatusCode.OK, "Added the new employee: " + empname + ".");
        }
    }
}
