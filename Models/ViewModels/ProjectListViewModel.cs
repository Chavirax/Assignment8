using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment5.Models.ViewModels
{
    public class ProjectListViewModel
    {
        public IEnumerable<Book> Books { get; set; } // There might be an issue with the data type projects

        public PagingInfo PagingInfo { get; set; }

        public string Type { get; set; }
    }
}
