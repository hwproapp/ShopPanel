﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace newsSite90tv.Models.ViewModels
{
    public class CreatePartPropertyViewModel
    {
        public Property property { get; set; }

        public IEnumerable<Category> category { get; set; }
    }
}
