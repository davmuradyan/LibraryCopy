using LibraryCopy.Data.Entities;
using LibraryCopy.Data.DAO;

namespace LibraryCopy.Core.Services {
    public class LibraryService : ILibraryService {
        MainDBcontext context;
        public LibraryService(MainDBcontext context) {
            this.context = context;
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
    }
}
