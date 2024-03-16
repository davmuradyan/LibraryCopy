using LibraryCopy.Data.Entities;

namespace LibraryCopy.Core.Services {
    public interface ILibraryService {
        void AddLibrary(LibraryEntity library);
        void RemoveLibrary(int libraryId);
        void UpdateLibrary(LibraryEntity library);
        void DeleteLibrary(LibraryEntity library);
        List<LibraryEntity> GetLibraries();
        LibraryEntity GetLibraryById(int id);
        LibraryEntity GetLibraryByName(string name);
        void AddBook(BookEntity book);
        void AddAuthor(AuthorEntity author);
        List<AuthorEntity> GetAuthorList();
        Dictionary<string, int> ShowBooks();
        void RemoveBook(string title);
        void RemoveAuthor(int id);
        void DeleteBook(string title);
        void DeleteAuthor(int id);
    }
}
