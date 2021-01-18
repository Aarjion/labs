using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Бипит_лаба_10.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        public ActionResult Index()
        {
            return View();
        }
        Bipit_3Entities BD = new Bipit_3Entities();

        public ActionResult book()
        {
            IEnumerable<Book> book = BD.Book;
            ViewBag.Book = book;
            return View("book");
        }

        public ActionResult fio()
        {
            IEnumerable<FIO> fio = BD.FIO;
            ViewBag.Fio = fio;
            return View("fio");
        }

        public ActionResult book_arenda()
        {
            IEnumerable<Arenda_book> book_arenda = BD.Arenda_book;
            ViewBag.book_arenda = book_arenda;
            return View("book_arenda");
        }

        public ActionResult Delete_fio(int id)
        {
            FIO s = new FIO { Id = id };
            BD.Entry(s).State = EntityState.Deleted;
            BD.SaveChanges();
            return RedirectToAction("fio");
        }

        public ActionResult Delete_book(int id)
        {
            Book s = new Book { Id = id };
            BD.Entry(s).State = EntityState.Deleted;
            BD.SaveChanges();
            return RedirectToAction("book");
        }

        public ActionResult Delete_book_arenda(int id)
        {
            Arenda_book s = new Arenda_book { Id = id };
            BD.Entry(s).State = EntityState.Deleted;
            BD.SaveChanges();
            return RedirectToAction("book_arenda");
        }

        [HttpGet]
        public ActionResult Edit_fio(int? id)
        {
            if (id == null)
                return HttpNotFound();
            FIO s = BD.FIO.Find(id);
            if (s != null)
                return View(s);
            return HttpNotFound();
        }
        [HttpPost]
        public ActionResult Edit_fio(FIO s)
        {
            BD.Entry(s).State = EntityState.Modified;
            BD.SaveChanges();
            return RedirectToAction("fio");
        }
       

        [HttpGet]
        public ActionResult Edit_book(int? id)
        {
            if (id == null)
                return HttpNotFound();
            Book s = BD.Book.Find(id);
            if (s != null)
                return View(s);
            return HttpNotFound();
        }

        [HttpPost]
        public ActionResult Edit_book(Book s)
        {
            BD.Entry(s).State = EntityState.Modified;
            BD.SaveChanges();
            return RedirectToAction("book");
        }

        [HttpGet]
        public ActionResult Edit_book_arenda(int? id)
        {
            if (id == null)
                return HttpNotFound();
            Arenda_book app = BD.Arenda_book.Find(id);
            if (app != null)
            {
                SelectList fio = new SelectList(BD.FIO, "Id", "Fio1");
                ViewBag.FIO = fio;
                SelectList book = new SelectList(BD.Book, "Id", "Name_book");
                ViewBag.Book = book;
                return View(app);
            }

            return HttpNotFound();
        }

        [HttpPost]
        public ActionResult Edit_book_arenda(Arenda_book s)
        {
            BD.Entry(s).State = EntityState.Modified;
            BD.SaveChanges();
            return RedirectToAction("book_arenda");
        }

        [HttpGet]
        public ActionResult Add_fio()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add_fio(FIO s)
        {
            BD.FIO.Add(s);
            BD.SaveChanges();
            return RedirectToAction("fio");
        }

        [HttpGet]
        public ActionResult Add_book()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add_book(Book s)
        {
            BD.Book.Add(s);
            BD.SaveChanges();
            return RedirectToAction("book");
        }

        [HttpGet]
        public ActionResult Add_book_arenda()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add_book_arenda(Arenda_book s)
        {
            SelectList fio = new SelectList(BD.FIO, "Id", "Fio1");
            ViewBag.FIO = fio;
            SelectList book = new SelectList(BD.Book, "Id", "Name_book");
            ViewBag.Book = book;
            return View();
        }
    }
}