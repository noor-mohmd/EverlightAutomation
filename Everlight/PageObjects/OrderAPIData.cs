using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.PageObjects
{
    public class OrderAPIData
    {
        public string? patientMrn { get; set; }
        public string? patientFirstName { get; set; }
        public string? patientLastName { get; set; }
        public string? accessionNumber { get; set; }
        public string? orgCode { get; set; }
        public string? siteId { get; set; }
        public string? modality { get; set; }
        public string? studyDateTime { get; set; }
    }
}
