using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace VersionQuest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SoftwareController : ControllerBase
    {
        private readonly ILogger<SoftwareController> _logger;

        public SoftwareController(ILogger<SoftwareController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Software> Get()
        {
            return SoftwareManager.GetAllSoftware().ToArray();
        }
    }
}
