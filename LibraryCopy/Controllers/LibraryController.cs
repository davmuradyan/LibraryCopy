using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LibraryCopy.Core.Services;
using LibraryCopy.Data.Entities;
using LibraryCopy.Data.DAO;


namespace LibraryCopy.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class LibraryController : ControllerBase {
        public ILibraryService LibraryService;
        public MainDBcontext context;

        public LibraryController(ILibraryService libraryService) {
            LibraryService = libraryService;
        }

        [HttpGet("ListLibraries")]
        public IActionResult GetLibraries() {
            return Ok(LibraryService.GetLibraries());
        }

        [HttpGet("GetLibraryById")]
        public IActionResult GetLibraryById(int id) {
            return Ok(LibraryService.GetLibraryById(id));
        }

        [HttpGet("GetLibraryByName")]
        public IActionResult GetLibraryByName(string name) {
            return Ok(LibraryService.GetLibraryByName(name));
        }

        [HttpPost("AddLibrary")]
        public IActionResult AddLibrary(LibraryEntity library) {
            LibraryService.AddLibrary(library);
            return Ok();
        }

        [HttpDelete("RemoveLibrary")]
        public IActionResult DeleteLibrary(int id) {
            LibraryService.RemoveLibrary(id);
            return Ok();
        }

        [HttpPut("UpdateLibrary")]
        public IActionResult UpdateLibrary(LibraryEntity library) {
            LibraryService.UpdateLibrary(library);
            return Ok();
        }

        [HttpDelete("DeleteLibrary")]
        public IActionResult DeleteLibrary(LibraryEntity library) {
            LibraryService.DeleteLibrary(library);
            return Ok();
        }

        [HttpPost("AddBook")]
        public IActionResult AddBook(string title, List<string> authors) {

            BookEntity book = new BookEntity() { isDeleted = false, Title = title};
            List<AuthorEntity> authorList = LibraryService.GetAuthorList();
            List<AuthorEntity> authorsOfBook = new List<AuthorEntity>();

            foreach (var name in authors)
            {
                foreach (AuthorEntity author in authorList) {
                    if (author.Name == name) {
                        authorsOfBook.Add(author);
                    }
                }
            }

            book.Authors = authorsOfBook;
            book.Id = 0;
            LibraryService.AddBook(book);
            return Ok();
        }

        [HttpPost("AddAuthor")]
        public IActionResult AddAuthor(AuthorEntity author) {
            LibraryService.AddAuthor(author);
            return Ok();
        }

        [HttpGet("List of Books")]

        public IActionResult GetBooks() {
            return Ok(LibraryService.ShowBooks());
        }
        [HttpDelete("DeleteBook")]
        public IActionResult DeleteBook(string title) {
            LibraryService.DeleteBook(title);
            return Ok();
        }
        [HttpDelete("DeleteAuthor")]
        public IActionResult DeleteAuthor(int id) {
            LibraryService.DeleteAuthor(id);
            return Ok();
        }
        [HttpDelete("RemoveBook")]
        public IActionResult RemoveBook(string title) {
            LibraryService.RemoveBook(title);
            return Ok();
        }
        [HttpDelete("RemoveAuthor")]
        public IActionResult RemoveAuthor(int id) {
            LibraryService.RemoveAuthor(id);
            return Ok();
        }
    }
}
