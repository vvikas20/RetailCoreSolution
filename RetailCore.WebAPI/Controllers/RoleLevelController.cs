using Microsoft.AspNetCore.Mvc;
using RetailCore.BusinessObjects.Configurations;
using RetailCore.ServiceContracts;
using RetailCore.WebAPI.RequestParameter;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RetailCore.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleLevelController : ControllerBase
    {

        private readonly ILogger<RoleLevelController> _logger;
        private readonly IRoleLevelService _roleLevelService;
        private readonly AppSettings _appSettings;


        public RoleLevelController(ILogger<RoleLevelController> logger, IRoleLevelService roleLevelService, AppSettings appSettings)
        {
            _logger = logger;
            _roleLevelService = roleLevelService;
            _appSettings = appSettings;
        }

        // GET: api/<RoleLevelController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<RoleLevelController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<RoleLevelController>
        [HttpPost]
        public void Post([FromBody] RoleLevelParameter value)
        {
        }

        // PUT api/<RoleLevelController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<RoleLevelController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
