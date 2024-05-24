using Business.Services.Abstracts;
using FINAL_EXAM.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FINAL_EXAM.Controllers
{
    public class HomeController : Controller
    {
        private readonly IServicessService _servicessService;

        public HomeController(IServicessService servicessService)
        {
            _servicessService = servicessService;
        }

        public IActionResult Index()
        {
            var servicess = _servicessService.GetAllServicess();
            return View(servicess);
        }

        
    }
}