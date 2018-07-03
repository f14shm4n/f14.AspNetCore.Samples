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
            // Gets records starts from index = 0 and takes ITEMS_PER_PAGE items from source list.
            var records = _userRecordRepository.GetUserRecords()
                .Take(ITEMS_PER_PAGE);
            return View(records); // Pass the records to the View; see /Views/Home/Index.cshtml
        }

        // An improvised endpoint api for getting records. Example url: www.example.com/getUserRecords?offset=10
        [HttpGet("{offset}")]
        public IActionResult GetUserRecords([FromQuery] int offset)
            // Gets records starts from index = OFFSET and takes ITEMS_PER_PAGE items from source list.
            // Then return data as JSON.
            => Json(_userRecordRepository.GetUserRecords().Skip(offset).Take(ITEMS_PER_PAGE));

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(Activity.Current?.Id ?? HttpContext.TraceIdentifier);
        }
    }
}
