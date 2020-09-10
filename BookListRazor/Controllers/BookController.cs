using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookListRazor.Model;
using Microsoft.AspNetCore.Mvc;

namespace BookListRazor.Controllers
{
    [Route("api/Book")]
    [ApiController]
    public class BookController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BookController(ApplicationDbContext context)
        {
            this._context = context;
        }
        [HttpGet]
        public IActionResult GetAllBooks()
        {
            return Json(new { data = _context.Books.ToList() });
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var book = _context.Books.Find(id);
            if(book == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }
            _context.Books.Remove(book);
            _context.SaveChanges();
            return Json(new { success = true, message = "Deloeted Successfully" });
        }
    }
}
