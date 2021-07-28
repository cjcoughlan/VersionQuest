using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using VersionQuest.Helpers;

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
        public IEnumerable<Software> Get(string searchString)
        {
            // Convert search string to number array
            var searchArray = VersionHelper.GetNumericSearchArray(searchString);

            List<Software> greaterVersions = new List<Software>();

            var allSoftware = SoftwareManager.GetAllSoftware().ToArray();

            foreach (var softwareProduct in allSoftware)
            {
                //Get numeric array for software product
                var softwareArray = VersionHelper.GetNumericVersionArray(softwareProduct.Version);

                var versionIsGreater = true;

                for (var i = 0; i < searchArray.Length; i++)
                {
                    if (softwareArray[i] < searchArray[i])
                    {
                        versionIsGreater = false;
                    }
                }

                if (versionIsGreater)
                {
                    greaterVersions.Add(softwareProduct);
                }

            }

            return greaterVersions.ToArray();
        }
    }
}
