using ConvertJSONStringToNetObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ConvertJSONStringToNetObject.Views
{
    /// <summary>
    /// The following code converts List<Employee> objects to a JSON string. 
    /// Serialize() method of JavaScriptSerializer class converts a .NET object to a JSON string.
    /// </summary>
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Employee employee1 = new Employee
            {
                firstName = "Todd",
                lastName = "Grover",
                gender = "Male",
                salary = 50000
            };

            Employee employee2 = new Employee
            {
                firstName = "Sara",
                lastName = "Baker",
                gender = "Female",
                salary = 40000
            };

            List<Employee> listEmployee = new List<Employee>();
            listEmployee.Add(employee1);
            listEmployee.Add(employee2);

            JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
            string JSONString = javaScriptSerializer.Serialize(listEmployee);

            Response.Write(JSONString);

            // The following code  converts a JSON string to List<Employee> objects.
            string jsonString = "[{\"firstName\":\"Todd\",\"lastName\":\"Grover\",\"gender\":\"Male\",\"salary\":50000},{\"firstName\":\"Sara\",\"lastName\":\"Baker\",\"gender\":\"Female\",\"salary\":40000}]";
            List<Employee> employees = (List<Employee>)javaScriptSerializer.Deserialize(jsonString, typeof(List<Employee>));

            foreach (Employee employee in employees)
            {
                Response.Write("First Name = " + employee.firstName + "<br/>");
                Response.Write("Last Name = " + employee.lastName + "<br/>");
                Response.Write("Gender = " + employee.gender + "<br/>");
                Response.Write("Salary = " + employee.salary + "<br/><br/>");
            }
        }
    }
}