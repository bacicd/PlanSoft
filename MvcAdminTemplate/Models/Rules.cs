using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcAdminTemplate.Models
{
    public class Rules
    {
        public string RuleCode { get; set; }
        public string RuleName { get; set; }
        public string MarkedField { get; set; }
        public string RuleStatus { get; set; }
        public string CreatedBy { get; set; }
        public DateTime DateAdded { get; set; }

        public static List<Rules> RulesList = new List<Rules>(new[]
            {
                new Rules { RuleCode = "100", RuleName = "Meaningful Measures", MarkedField = "Measure Meaningfulness", RuleStatus = "Active", CreatedBy = "Username" , DateAdded = DateTime.Today},
                new Rules { RuleCode = "101", RuleName = "Plan Ownership Type", MarkedField = "101", RuleStatus = "", CreatedBy = "Username", DateAdded = DateTime.Today },
            });
    }
}