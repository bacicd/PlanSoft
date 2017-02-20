using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcAdminTemplate.Models
{
    public class Elements
    {
        public string ElementId { get; set; }
        public string ElementName { get; set; }
        public DateTime DateSet { get; set; }
        public string CreatedBy { get; set; }

        public static List<Elements> ElementsList = new List<Elements>(new[]
            {
                new Elements { ElementId = "10", ElementName = "Plan", DateSet = DateTime.Today, CreatedBy = "Username" },
                new Elements { ElementId = "20", ElementName = "Job Title", DateSet = DateTime.Today, CreatedBy = "Username"},
                new Elements { ElementId = "30", ElementName = "Grade", DateSet = DateTime.Today, CreatedBy = "Username"},
                new Elements { ElementId = "40", ElementName = "Employee", DateSet = DateTime.Today, CreatedBy = "Username"},
                new Elements { ElementId = "50", ElementName = "Organization", DateSet = DateTime.Today, CreatedBy = "Username"},
            });
    }    
}