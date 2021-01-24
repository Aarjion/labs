using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Бипит_лаба11.Controllers
{
    [Route("api/[ValuesController]")]
    public class ValuesController : ApiController
    {

        Bipit_3Entities context = new Bipit_3Entities();


        ValuesController()
        {
            context.Configuration.ProxyCreationEnabled = false;
        }

        [Route("~/api/GetFIO")]
        [HttpGet]
        public IEnumerable<FIO> GetFIO()
        {
            return context.FIO;
        }

        [Route("~/api/FIO/{id?}")]
        [HttpGet]
        public string FIO(int id)
        {
            FIO e = context.FIO.Find(id);
            return e.FIO1;
        }

        [Route("~/api/AddFIO")]
        [HttpPost]
        public void AddFIO([FromBody] FIO e)
        {
            context.FIO.Add(e);
            context.SaveChanges();
        }

        [Route("~/api/DeleteFIO/{id?}")]
        [HttpDelete]
        public void DeleteFIO(int id)
        {
            FIO e = context.FIO.Find(id);
            context.FIO.Remove(e);
            context.SaveChanges();
        }

        [Route("~/api/GetBook")]
        [HttpGet]
        public IEnumerable<Book> GetBook()
        {
            return context.Book;
        }

        [Route("~/api/Book/{id?}")]
        [HttpGet]
        public string Book(int id)
        {
            Book h = context.Book.Find(id);
            return h.Name_book;
        }

        [Route("~/api/AddBook")]
        [HttpPost]
        public void AddBook([FromBody] Book h)
        {
            context.Book.Add(h);
            context.SaveChanges();
        }

        [Route("~/api/DeleteBook/{id?}")]
        [HttpDelete]
        public void DeleteBook(int id)
        {
            Book Book = context.Book.Find(id);
            context.Book.Remove(Book);
            context.SaveChanges();
        }

        [Route("~/api/GetArenda_book")]
        [HttpGet]
        public IEnumerable<Arenda_book> GetArenda_book()
        {
            return context.Arenda_book;
        }

        [Route("~/api/AddArenda_book")]
        [HttpPost]
        public void AddArenda_book([FromBody] Arenda_book t)
        {
            context.Arenda_book.Add(t);
            context.SaveChanges();
        }

        [Route("~/api/DeleteArenda_book/{id?}")]
        [HttpDelete]
        public void DeleteArenda_book(int id)
        {
            Arenda_book Arenda_book = context.Arenda_book.Find(id);
            context.Arenda_book.Remove(Arenda_book);
            context.SaveChanges();
        }
    }
}    
