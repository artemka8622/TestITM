using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TestITM.Models
{
    public class SearchViewModel
    {
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd.MM.yyyy hh:mm}")]
        public DateTime From { get; set; } = DateTime.Now.AddDays(-1);
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd.MM.yyyy hh:mm}")]
        public DateTime To { get; set; } = DateTime.Now;
        public string Name { get; set; }
        public Guid SwitchId { get; set; }
    }
}