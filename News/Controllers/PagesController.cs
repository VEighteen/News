using Microsoft.AspNetCore.Mvc;
using News.Db;

namespace News.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PagesController : ControllerBase
    {
        private readonly ILogger<PagesController> _logger;
        private readonly DataActions _dataActions;

        public PagesController(ILogger<PagesController> logger)
        {
            _logger = logger;
            _dataActions = new DataActions(new Connection());
        }
    }

}
