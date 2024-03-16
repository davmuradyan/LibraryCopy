using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryCopy.Data.Entities {
    public record BookEntity : BaseEntity {
        public string Title { get; set; }

        public List<AuthorEntity> Authors { get; set; }
    }
}
