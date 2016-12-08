using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EmployeeBusiness;

namespace HelloWebAPI.Controllers
{
    //test
    [RoutePrefix("api/Department")]
    public class DepartmentController : ApiController
    {
        DepartmentProcessor DP = new DepartmentProcessor();

        [Route("{DeptId}")]
        [System.Web.Http.AcceptVerbs("GET", "POST")]
        [System.Web.Http.HttpPost]
        public HttpResponseMessage GetDepartmentById(string DeptId)
        {
            string department = string.Empty;
            try
            {
                department = DP.GetDepartmentById(DeptId);

            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
            return Request.CreateResponse(HttpStatusCode.OK, department);
        }

        [Route("")]
        [System.Web.Http.HttpGet]
        public HttpResponseMessage GetAllDepartments()
        {
            string departments = string.Empty;
            try
            {
                departments = DP.GetAllDepartments();
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
            return Request.CreateResponse(HttpStatusCode.OK, departments);
        }

        [Route("{deptid}/{empid}")]
        [System.Web.Http.HttpGet]
        public HttpResponseMessage DeleteDepartment(string deptid, string empid)
        {
            string department = string.Empty;
            try
            {
                DP.DeleteDepartment(deptid, empid);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
            return Request.CreateResponse(HttpStatusCode.OK, "Deleted the department: " + deptid + " successfully.");
        }

        [Route("{depid}/{depname}/{totalemployee:int}")]
        [System.Web.Http.AcceptVerbs("GET", "POST")]
        [System.Web.Http.HttpPost]
        public HttpResponseMessage UpdateDepartment(string depid, string depname, int totalemployee)
        {
            try
            {
                DP.UpdateDepartment(depid, depname, totalemployee);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
            return Request.CreateResponse(HttpStatusCode.OK, "Updated the department: " + depname + ".");
        }

        [Route("{depid}/{depname}/{totalemployees:int}/{empid}")]
        [System.Web.Http.AcceptVerbs("GET", "POST")]
        [System.Web.Http.HttpPost]
        public HttpResponseMessage AddNewDepartment(string depid, string depname, int totalemployees, string empid)
        {
            try
            {
                DP.AddNewDepartment(depid, depname, totalemployees, empid);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
            return Request.CreateResponse(HttpStatusCode.OK, "Added the new department: " + depname + ".");
        }
    }
}
