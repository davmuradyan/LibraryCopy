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
    }
}
