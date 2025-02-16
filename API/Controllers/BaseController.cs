using BackendAPI.Model;
using BackendAPI.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;


namespace BackendAPI.Controllers
{
    [Route("API/[Controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        private readonly APIdbContext dbContext;
        public BaseController() 
        {
            dbContext = new APIdbContext();
        }
        [HttpPost("DemoAPI")]
        public ActionResult printData(Demoviewmodel demoviewmodel)
        {
            var data = demoviewmodel.name + " Lives in " + demoviewmodel.location;
            return Ok(data);
        }
        [HttpPost("InsertUpdateEmployeeInfo")]
        public ActionResult insertupdatedata(EmployeeViewModel employee)
        {
            FinalreturnModel finalreturnModel = new FinalreturnModel();
            Employee employee1 = new Employee();
            employee1.Id = Guid.NewGuid();
            employee1.Name = employee.Name;
            employee1.Description = employee.Description;
            employee1.FirstName = employee.FirstName;
            dbContext.employee.Add(employee1);
            finalreturnModel.message = "Inserted SuccessFully";
            finalreturnModel.status = "success";
            //var data = dbContext.employee.Where(x => x.Id == employee.Id).FirstOrDefault();
            //if(data == null)
            //{
            //    Employee employee1 = new Employee();
            //    employee1.Id = Guid.NewGuid();
            //    employee1.Name = employee.Name; 
            //    employee1.Description = employee.Description;
            //    employee1.FirstName = employee.FirstName;
            //    dbContext.employee.Add(employee1);
            //    finalreturnModel.message = "Inserted SuccessFully";
            //    finalreturnModel.status = "success";
            //}
            //else
            //{
            //    data.FirstName = employee.FirstName;
            //    data.Name = employee.Name;
            //    data.Description = employee.Description;
            //    finalreturnModel.message = "Updated SuccessFully";
            //    finalreturnModel.status = "success";
            //}
            dbContext.SaveChanges();
            return Ok(finalreturnModel);
        }
        [HttpGet("GetAllEmployeeData")]
        public ActionResult getdata()
        {
            var data = dbContext.employee.ToList();
            return Ok(data);
        }
    }
    public class Demoviewmodel
    {
        public string? name { get; set; }
        public string? location { get; set; }
    }
    public class FinalreturnModel
    {
        public string? status { get; set;}
        public string? message { get; set;}
    }
}
