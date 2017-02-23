using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcAdminTemplate.Models
{
    public class Attributes
    {
        public string ElementCode { get; set; }
        public string ElementName { get; set; }
        public string AttributeCode { get; set; }
        public string AttributeName { get; set; }
        public DateTime DateSet { get; set; }
        public string CreatedBy { get; set; }

        public static List<Attributes> AttributesList = new List<Attributes>(new[]
            {
                new Attributes { ElementCode = "10", ElementName = "Plan", AttributeCode = "10", AttributeName = "Compensation Manager", DateSet = DateTime.Today, CreatedBy = "Username"}
            });
    }
}