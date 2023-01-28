using Aula7_8_WebServices.Resources;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using System.Net;
using System.Runtime.Intrinsics.Arm;

namespace Aula7_8_WebServices.Controllers
{
    [ApiController]
    [Route("[controller]/")]
    public class DepartmentController : ControllerBase
    {
        private static List<Department> departments = new List<Department> { new Department(1, "Sales", 10),
        new Department(2, "Maintenance", 20), new Department(3, "Admin", 2)};

        private readonly ILogger<DepartmentController> _logger;

        public DepartmentController(ILogger<DepartmentController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="departmentId"></param>
        /// <returns>A department</returns>
        [HttpGet("GetDepartmentById")]
        public JsonResult Get(int departmentId)
        {
            var dep = departments.FirstOrDefault(x => x.id == departmentId);
            dep.SetManager(1, "John", "Lisbon");
            dep.AddEmployee(2, "Anna", "Coimbra");
            dep.AddEmployee(3, "Charles", "Coimbra");
            var jsResult = new JsonResult(dep);
            Response.StatusCode = dep != null ? (int)HttpStatusCode.OK : (int)HttpStatusCode.NotFound;

            return jsResult;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns> A list of departments</returns>
        [HttpGet("GetAllDepartments")]
        public JsonResult List()
        {
            foreach (var dep in departments)
            {
                dep.SetManager(1, "John", "Lisbon");
                dep.AddEmployee(2, "Anna", "Coimbra");
                dep.AddEmployee(3, "Charles", "Coimbra");
            }
            return new JsonResult(departments);
        }
    }
}