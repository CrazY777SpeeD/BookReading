using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Runtime.Remoting.Messaging;
using BookReading.Models;

namespace BookReading.Controllers
{
    public class AuthorController : Controller
    {
        //
        // GET: /Author/
        private IBookContext _bookContext;
        public AuthorController() : this(new DbBookContext())
        {
        }
        public AuthorController(IBookContext bookContext)
        {
            if (bookContext == null)
                throw new ArgumentNullException();
            _bookContext = bookContext;
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Details(int id = 0)
        {
            ViewBag.Title = "Подробнее об авторе";
            var book = _bookContext.GetAuthor(id);

            if (book == null)
                return HttpNotFound();

            return View(book);
        }

    }
}
