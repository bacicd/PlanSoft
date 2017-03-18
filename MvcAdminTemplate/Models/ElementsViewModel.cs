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

        public static List<ElementsViewModel> ElementsList = new List<ElementsViewModel>();
    }
}