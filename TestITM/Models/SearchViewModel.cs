using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestITM.Models
{
    public class SearchViewModel
    {
        public DateTime From { get; set; } = DateTime.Now.AddDays(-1);
        public DateTime To { get; set; } = DateTime.Now;
    }
}