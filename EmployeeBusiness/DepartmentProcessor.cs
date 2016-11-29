using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using TestDemoData;

namespace EmployeeBusiness
{
    public class DepartmentProcessor
    {
        public JavaScriptSerializer jsonSerialiser = new JavaScriptSerializer();

        public string GetAllDepartments()
        {
            using (OrganizationEntities ON = new OrganizationEntities())
            {
                var data = (from d in ON.DepartmentDetails
                            select new
                            {
                                d.DepartmentID,
                                d.DepartmentName,
                                d.TotalEmployee,
                                d.EmployeeID
                            });

                return jsonSerialiser.Serialize(data);
            }
        }

        public string GetDepartmentById(string DepartmentId)
        {
            using (OrganizationEntities ON = new OrganizationEntities())
            {
                var data = (from d in ON.DepartmentDetails
                            select new
                            {
                                d.DepartmentID,
                                d.DepartmentName,
                                d.TotalEmployee,
                                d.EmployeeID
                            }).Where(x => x.DepartmentID == DepartmentId);

                return jsonSerialiser.Serialize(data);
            }
        }

        public void UpdateDepartment(string depid, string depname, int totalemployees)
        {
            OrganizationEntities OE = new OrganizationEntities();
            var dept = OE.DepartmentDetails.SingleOrDefault(x => x.DepartmentID == depid);
            dept.DepartmentName = depname;
            dept.TotalEmployee = totalemployees;
            OE.SaveChanges();
        }

        public void DeleteDepartment(string deptid, string empid)
        {
            OrganizationEntities OE = new OrganizationEntities();
            var dept = OE.DepartmentDetails.SingleOrDefault(x => x.DepartmentID == deptid);
            OE.DepartmentDetails.Attach(dept);
            OE.DepartmentDetails.Remove(dept);
            OE.SaveChanges();
        }

        public void AddNewDepartment(string depid, string depname, int totalemployees, string empid)
        {
            OrganizationEntities NewOE = new OrganizationEntities();
            var newDept = new DepartmentDetail { DepartmentID = depid, DepartmentName = depname, TotalEmployee = totalemployees, EmployeeID = empid};
            NewOE.DepartmentDetails.Add(newDept);
            NewOE.SaveChanges();
        }
    }
}
