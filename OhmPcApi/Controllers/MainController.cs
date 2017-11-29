using OhmPcApi.Models;
using OhmPcApi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace OhmPcApi.Controllers
{
    [RoutePrefix("api/main")]
    public class MainController : ApiController
    {
        private OhmService service = new OhmService();

        [HttpGet]
        [Route("")]
        public SystemStatus GetSystemStatus()
        {
            SystemStatus status = service.GetUpdatedSystemStatus();
            return status;
        }
    }
}
