using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;


namespace BackendAPI.Controllers
{
    [Route("API/[Controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        [HttpPost("DemoAPI")]
        public ActionResult printData(demoviewmodel demoviewmodel)
        {
            var data = demoviewmodel.name + " Lives in " + demoviewmodel.location;
            return Ok(data);
        }
    }
    public class demoviewmodel
    {
        public string? name { get; set; }
        public string? location { get; set; }
    }
}
