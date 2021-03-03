using Assignment5.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
//using Assignment5.Models;
using Assignment5.Models.ViewModels;
namespace Assignment5.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private ICharityRepository _repository;
        public int PageSize = 5; // this variable tells how many items to display per page
        public HomeController(ILogger<HomeController> logger, ICharityRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public IActionResult Index(string category, int pageNum =1)
        {
            return View(new ProjectListViewModel
            {
                Books = _repository.Books
                 .Where(p => category == null || p.Category == category)
                 .OrderBy(p => p.BookId)
                 .Skip((pageNum - 1) * PageSize)
                 .Take(PageSize)

                 ,
                PagingInfo = new PagingInfo
                {
                    CurrentPage = pageNum,
                    ItemsPerPage = PageSize,
                    TotalNumItems = category == null ? _repository.Books.Count() :
                        _repository.Books.Where(x => x.Category == category).Count() // this gets rid of the extra pages
                },
                Type = category
            }); ; //This is what tells the view how many items to display 
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
