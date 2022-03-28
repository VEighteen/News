using Microsoft.AspNetCore.Mvc;
using News.Db;
using News.Model;

namespace News.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PagesController : ControllerBase
    {
        private readonly ILogger<PagesController> _logger;
        private readonly DataActions _dataActions;
        private readonly PagesActions _pagesActions;

        public PagesController(ILogger<PagesController> logger)
        {
            _logger = logger;
            _dataActions = new DataActions(new Connection());
            _pagesActions = new PagesActions(_dataActions.SelectAll().ToList());
        }

        [HttpGet("GetAllPages")]
        public IEnumerable<Page> GetAllPages()
        {
            return _dataActions.SelectAll();
        }

        [HttpPost]
        public void Post(string url)
        {
            _dataActions.Insert(url);;
        }

        [HttpGet("FintByEntity")]
        public IEnumerable<Page> FintByEntity(string name)
        {
            return _pagesActions.FintByEntity(name);
        }

        [HttpGet("FintByWord")]
        public IEnumerable<Page> FintByWord(string text)
        {
            return _pagesActions.FindbyWord(text);
        }

        [HttpDelete("DeletById")]
        public void DeleteById(int id)
        {
            _dataActions.DeleteById(id);
        }

        [HttpDelete("DeleteAll")]
        public void DeleteAll(int id)
        {
            _dataActions.Delete();
        }

        [HttpPut]
        public void Update(Page page)
        {
            _dataActions.Update(page);
        }





    }

}
