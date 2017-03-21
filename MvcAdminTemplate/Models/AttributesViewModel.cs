using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcAdminTemplate.Models
{
    public class AttributesViewModel
    {
        public string ElementCode { get; set; }
        public string ElementName { get; set; }
        public string AttributeCode { get; set; }
        public string AttributeName { get; set; }
        public DateTime DateSet { get; set; }
        public string CreatedBy { get; set; }

        //public static List<AttributesViewModel> AttributesList = new List<AttributesViewModel>(new[]
        //    {
        //        new AttributesViewModel { ElementCode = "10", ElementName = "Plan", AttributeCode = "10", AttributeName = "Compensation Manager", DateSet = DateTime.Today, CreatedBy = "Username"},
        //        new AttributesViewModel { ElementCode = "20", ElementName = "Plan", AttributeCode = "10", AttributeName = "Employee", DateSet = DateTime.Today, CreatedBy = "Username"},
        //        new AttributesViewModel { ElementCode = "30", ElementName = "Plan", AttributeCode = "10", AttributeName = "Developer", DateSet = DateTime.Today, CreatedBy = "Username"}
        //    });
    }
}