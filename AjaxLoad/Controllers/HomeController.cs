using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AjaxLoad.Models;
using AjaxLoad.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace AjaxLoad.Controllers
{
    public class HomeController : Controller
    {
        public const int ITEMS_PER_PAGE = 10;

        private readonly IUserRecordRepository _userRecordRepository;

        public HomeController(IUserRecordRepository userRecordRepository)
        {
            _userRecordRepository = userRecordRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(_userRecordRepository.GetUserRecords().Take(ITEMS_PER_PAGE));
        }

        [HttpGet("{offset}")]
        public IActionResult GetUserRecords([FromQuery] int offset) => Json(_userRecordRepository.GetUserRecords().Skip(offset).Take(ITEMS_PER_PAGE));

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(Activity.Current?.Id ?? HttpContext.TraceIdentifier);
        }
    }
}
