﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryCopy.Data.Entities {
    public abstract record BaseEntity {
        public int Id { get; set; }

        public required bool isDeleted { get; set; }
    }
}
