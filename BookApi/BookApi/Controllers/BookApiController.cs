using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BookApi.Data;
using BookApi.Model;
using System.Linq;

namespace BookApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BookApiController : ControllerBase
    {
        private readonly apiDbContent _apiDbContent;
        public BookApiController(apiDbContent context)
        {
            _apiDbContent = context;
        }
        ///<summary>Create/Edit</summary>
        [HttpPost]
        public JsonResult CreateEdit(Book Books)
        {
            if(Books.id == 0)
            {
                _apiDbContent.Books.Add(Books);
            }
            else
            {
                //var BookId = _apiDbContent.FirstOrDefault(x => x.id == Books.id);
                var BookId = _apiDbContent.Books.Find(Books.id);
                if (BookId== null)
                
                    return new JsonResult(NotFound());
                    BookId = Books;
            }
            _apiDbContent.SaveChanges();
            return new JsonResult(Ok(Books));
        }
        [HttpGet]
        public JsonResult get(int id)
        {
            var result = _apiDbContent.Books.Find(id);
            if (result == null)
                return new JsonResult(NotFound());

             return new JsonResult(Ok(result));
        }
        //delete
        [HttpDelete]
        public JsonResult Delete(int id)
        {
            var result = _apiDbContent.Books.Find(id);
            if (result == null)
                return new JsonResult(NotFound());
            _apiDbContent.Books.Remove(result);
            _apiDbContent.SaveChanges();

            return new JsonResult(NoContent());
                    
        }
        // Get all
        [HttpGet()]
        public JsonResult GetAll()
        {
            var result = _apiDbContent.Books.ToList();

            return new JsonResult(Ok(result));
        }
    }
}
