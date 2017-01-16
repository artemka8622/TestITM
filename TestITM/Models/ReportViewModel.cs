using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestITM.Models
{
    public class ReportViewModel
    {
        public SearchViewModel SearchViewModel { get; set; } = new SearchViewModel();

        public List<StausViewModel> StausViewModels { get; set; } = new List<StausViewModel>();
    }
}