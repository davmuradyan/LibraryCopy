using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryCopy.Data.Entities {
    public record AuthorEntity : BaseEntity {
        required public string Name { get; set; }
    }
}
