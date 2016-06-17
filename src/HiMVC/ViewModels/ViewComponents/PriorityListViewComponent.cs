using HiMVC.Models.Interfaces;
using Microsoft.AspNet.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HiMVC.ViewModels
{
    [ViewComponent(Name = "PriorityList")]
    public class PriorityListViewComponent : ViewComponent
    {
        private readonly IRepository _repository;

        public PriorityListViewComponent(IRepository repository)
        {
            _repository = repository;
        }

        public IViewComponentResult Invoke(int count)
        {


            return View();
        }

    }
}
