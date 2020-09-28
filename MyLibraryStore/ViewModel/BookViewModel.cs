using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyLibraryStore.Models;

namespace MyLibraryStore.ViewModel
{
    public class BookViewModel
    {
        public Book Book{ get; set; }

        public List<SelectListItem> Genre{ get; set; }
    }
}
