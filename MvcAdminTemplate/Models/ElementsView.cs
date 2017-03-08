using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcAdminTemplate.Models
{
    public class ElementsView
    {
        public string ElementId { get; set; }
        public string ElementName { get; set; }
        public DateTime DateSet { get; set; }
        public string CreatedBy { get; set; }

        public static List<ElementsView> ElementsList = new List<ElementsView>(new[]
            {
                new ElementsView { ElementId = "10", ElementName = "Plan", DateSet = DateTime.Today, CreatedBy = "Username" },
                new ElementsView { ElementId = "20", ElementName = "Job Title", DateSet = DateTime.Today, CreatedBy = "Username"},
                new ElementsView { ElementId = "30", ElementName = "Grade", DateSet = DateTime.Today, CreatedBy = "Username"},
                new ElementsView { ElementId = "40", ElementName = "Employee", DateSet = DateTime.Today, CreatedBy = "Username"},
                new ElementsView { ElementId = "50", ElementName = "Organization", DateSet = DateTime.Today, CreatedBy = "Username"},
            });
    }    
}