using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment10.Models.ViewModels
{
    public class PageNumbering
    {
        public int NumPerPage { get; set; }

        public int CurrentPage { get; set; }

        public int TotalNumItems { get; set; }

        //Calculate Num Pages
        public int NumPages => (int) (Math.Ceiling((decimal) TotalNumItems / NumPerPage));
    }
}
