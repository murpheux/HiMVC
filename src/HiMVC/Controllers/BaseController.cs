using HiMVC.Models.Interfaces;
using Microsoft.AspNet.Mvc;
using Microsoft.Extensions.Logging;

namespace HiMVC.Controllers
{
    //[ElmahHandleError]
    public partial class BaseController : Controller 
    {
        protected readonly IRepository _repository;
        //protected readonly ILogger _logger;

        public BaseController(IRepository repository, ILoggerFactory loggerFactory)
        {
            _repository = repository;
            //_logger = loggerFactory.CreateLogger<HomeController>();
        }

        protected const int PageSize = 20;

    }
}
