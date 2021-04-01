using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WorkflowTest;

namespace WebApplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {
        private readonly ProcessFactory _factory;

        public TestController(ProcessFactory factory)
        {
            _factory = factory;
        }
        // GET
        [HttpGet("test")]
        public async Task<IActionResult> Index()
        {
            var process = _factory.BuildNewProcess("qwe");
            for (int i = 0; i < 5; i++)
            {
                await  process.RunAsync();    
            }
            return Ok();
        }

        [HttpPut("update")]
        public IActionResult UpdateWorkflow()
        {
            // here we should increment version of a template
            return Ok();
        }
        
        /*
         The workflow management should be implemented. 
         Adding, terminating, updating and so on.
         */
    }
}