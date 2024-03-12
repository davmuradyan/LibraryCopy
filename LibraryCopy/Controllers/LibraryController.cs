using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LibraryCopy.Core.Services;
using LibraryCopy.Data.Entities;


namespace LibraryCopy.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class LibraryController : ControllerBase {
        public ILibraryService LibraryService;

        public LibraryController(ILibraryService libraryService) {
            LibraryService = libraryService;
        }

        [HttpGet("List")]
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
    }
}
