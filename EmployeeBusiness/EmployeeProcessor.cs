using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDemoData;
using System.Web.Script.Serialization;

namespace EmployeeBusiness
{
    public class EmployeeProcessor
    {
        public JavaScriptSerializer jsonSerialiser = new JavaScriptSerializer();

        public string GetAllEmployeeData()
        {
            using (OrganizationEntities ON = new OrganizationEntities())
            {
                var data = (from e in ON.EmployeeDetails
                            select new
                            {
                                e.EmployeeID,
                                e.EmployeeName,
                                e.EmailID,
                                e.Phone,
                                e.Salary,
                                e.City
                            });

                return jsonSerialiser.Serialize(data);
            }
        }

        //public string GetEmployeeById(string EmployeeId)
        //{
        //    using (OrganizationEntities ON = new OrganizationEntities())
        //    {
        //        var data = (from e in ON.EmployeeDetails
        //                    select new
        //                    {
        //                        e.EmployeeID,
        //                        e.EmployeeName,
        //                        e.EmailID,
        //                        e.Phone,
        //                        e.Salary,
        //                        e.City
        //                    }).Where(x=>x.EmployeeID == EmployeeId);

        //        return jsonSerialiser.Serialize(data);
        //    }
        //}

        public async Task<EmployeeDetail> GetEmployeeById(int EmployeeId)
        {
            OrganizationEntities OE = new OrganizationEntities();
            EmployeeDetail emp = await OE.EmployeeDetails.FindAsync(EmployeeId.ToString());
            return emp;
        }

        public void UpdateEmployee(string empid, string empname, string emailId, string phone, int salary, string city)
        {
            OrganizationEntities OE = new OrganizationEntities();
            var emp = OE.EmployeeDetails.SingleOrDefault(x => x.EmployeeID == empid);
            emp.EmployeeName = empname;
            emp.EmailID = emailId;
            emp.Phone = phone;
            emp.Salary = salary;
            emp.City = city;
            OE.SaveChanges();
        }

        public void DeleteEmpliyee(string empid, string phone)
        {
            OrganizationEntities OE = new OrganizationEntities();
            var employee = OE.EmployeeDetails.SingleOrDefault(x => x.EmployeeID == empid);
            OE.EmployeeDetails.Attach(employee);
            OE.EmployeeDetails.Remove(employee);
            OE.SaveChanges();
        } 

        public void AddNewEmployee(int empid, string empname, string emailId, int phone, int salary, string city)
        {
            OrganizationEntities NewOE = new OrganizationEntities();
            var newEmp = new EmployeeDetail { EmployeeID = empid.ToString(), EmployeeName = empname, EmailID = emailId, Phone = phone.ToString(), Salary = Convert.ToInt32(salary), City = city };
            NewOE.EmployeeDetails.Add(newEmp);
            NewOE.SaveChanges();
        }
    }
}
