using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.PageObjects
{
    public class OrderData
    {
        public string? MRN { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? AccessionNumber { get; set; }
        public string? Organisation { get; set; }
        public string? SiteId { get; set; }
        public string? Modality { get; set; }
        public string? StudyDateTime { get; set; }
    }
}
