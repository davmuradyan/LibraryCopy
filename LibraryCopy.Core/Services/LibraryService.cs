using LibraryCopy.Data.Entities;
using LibraryCopy.Data.DAO;

namespace LibraryCopy.Core.Services {
    public class LibraryService : ILibraryService {
        MainDBcontext context;
        public LibraryService(MainDBcontext _context) {
            context = _context;
        }

        public void AddLibrary(LibraryEntity library) {
            context.Add(library);
            context.SaveChanges();
        }

        public void RemoveLibrary(int libraryId) {
            context.Libraries.FirstOrDefault(x => x.Id == libraryId).isDeleted = true;
            context.SaveChanges();
        }

        public void UpdateLibrary(LibraryEntity library) {
            context.Update(library);
            context.SaveChanges();
        }

        public void DeleteLibrary(LibraryEntity library) {
            context.Remove(library);
            context.SaveChanges();
        }

        public List<LibraryEntity> GetLibraries() {
            return context.Libraries.ToList();
        }

        public LibraryEntity GetLibraryById(int id) {
            return context.Libraries.FirstOrDefault(x => x.Id == id);
        }

        public LibraryEntity GetLibraryByName(string name) {
            return context.Libraries.FirstOrDefault(x => x.Name == name);
        }

        public void AddAuthor(AuthorEntity author) {
            context.Add(author);
            context.SaveChanges();
        }
        public List<AuthorEntity> GetAuthorList() {
            return context.Authors.ToList();
        }
        public void AddBook(BookEntity book) {
            context.Add(book);
            context.SaveChanges();
        }
        public Dictionary<string, int> ShowBooks() {
            Dictionary<string, int> dict = new Dictionary<string, int>();
            List<BookEntity> books = context.Books.ToList();

            foreach (var book in books)
            {
                if (book.isDeleted == false)
                {
                    if (!dict.ContainsKey(book.Title)) {
                        dict.Add(book.Title, 1);
                    } else {
                        dict[book.Title]++;
                    }
                }
            }
            return dict;
        }

        
        public void RemoveBook(string title) {
            context.Books.FirstOrDefault(x => x.Title == title).isDeleted = true;
            context.SaveChanges();
        }
        public void RemoveAuthor(int id) {
            context.Authors.FirstOrDefault(x => x.Id == id).isDeleted = true;
            context.SaveChanges();
        }
        public void DeleteBook(string title) {
            context.Books.Remove(context.Books.FirstOrDefault(x => x.Title == title));
            context.SaveChanges();
        }
        public void DeleteAuthor(int id) {
            context.Authors.Remove(context.Authors.FirstOrDefault(x => x.Id == id));
            context.SaveChanges();
        }
    }
}
