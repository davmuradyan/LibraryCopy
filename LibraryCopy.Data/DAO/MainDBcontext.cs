using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LibraryCopy.Data.Entities;

namespace LibraryCopy.Data.DAO {
    public class MainDBcontext : DbContext {
        public MainDBcontext(DbContextOptions options) : base(options) { }

        public DbSet<LibraryEntity> Libraries { get; set; }
    }
}
