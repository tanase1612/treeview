using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TreeViewAD.Models;

namespace TreeViewAD.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            List<AuthorViewModel> model = new List<AuthorViewModel>();

            AuthorViewModel firstAuthor = new AuthorViewModel
            {
                Id = 1,
                Name = "John",
                BookViewModel = new List<BookViewModel>{
                    new BookViewModel{
                        Id=1,
                        Title = "JQuery",
                        IsWritten = false
                    }, new BookViewModel{
                        Id=2,
                        Title = "JavaScript",
                        IsWritten = false
                    }
                }
            };

            AuthorViewModel secondAuthor = new AuthorViewModel
            {
                Id = 2,
                Name = "Deo",
                BookViewModel = new List<BookViewModel>{
                    new BookViewModel{
                        Id=3,
                        Title = "C#",
                        IsWritten = false
                    }, new BookViewModel{
                        Id=4,
                        Title = "Entity Framework",
                        IsWritten = false
                    }
                }
            };
            model.Add(firstAuthor);
            model.Add(secondAuthor);
            return View("Index", model);
        }

        [HttpPost]
        public ActionResult Index(List<AuthorViewModel> model)
        {
            List<AuthorViewModel> selectedAuthors = model.Where(a => a.IsAuthor).ToList();
            List<BookViewModel> selectedBooks = model.Where(a => a.IsAuthor)
                                                .SelectMany(a => a.BookViewModel.Where(b => b.IsWritten)).ToList();
            return View();
        }
    }
}