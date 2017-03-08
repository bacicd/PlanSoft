using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcAdminTemplate.Models
{
    public class ElementsViewModel
    {
        public string ElementId { get; set; }
        public string ElementName { get; set; }
        public DateTime DateSet { get; set; }
        public string CreatedBy { get; set; }

        public static List<ElementsViewModel> ElementsList = new List<ElementsViewModel>(new[]
            {
                new ElementsViewModel { ElementId = "10", ElementName = "Plan", DateSet = DateTime.Today, CreatedBy = "Username" },
                new ElementsViewModel { ElementId = "20", ElementName = "Job Title", DateSet = DateTime.Today, CreatedBy = "Username"},
                new ElementsViewModel { ElementId = "30", ElementName = "Grade", DateSet = DateTime.Today, CreatedBy = "Username"},
                new ElementsViewModel { ElementId = "40", ElementName = "Employee", DateSet = DateTime.Today, CreatedBy = "Username"},
                new ElementsViewModel { ElementId = "50", ElementName = "Organization", DateSet = DateTime.Today, CreatedBy = "Username"},
            });
    }    
}