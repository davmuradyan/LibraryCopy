﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryCopy.Data.Entities {
    public class LibraryEntity : BaseEntity {
        public string Name { get; set; } = null!;

        public string Address { get; set; } = null!;

        public string Description { get; set; } = null!;
    }
}
