using Microsoft.AspNet.Mvc;

namespace HiMVC.Controllers
{
    //[ElmahHandleError]
    public partial class BaseController : Controller 
    {
        protected readonly IRepository _repository;
        //protected readonly Services.Logging.ILogger _logger;

        public BaseController() 
        {

            _repository = new Repository(); ;// container.Resolve<IRepository>();
            //_logger = new NLogLogger(); // container.Resolve<NLogLogger>();
        }

        public BaseController(IRepository repository)
        {
            _repository = repository;
        }

        protected const int PageSize = 20;

        #region BaseServices

        

        #endregion

        

    }
}
