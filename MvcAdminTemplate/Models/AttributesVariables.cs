using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcAdminTemplate.Models
{
    public class AttributesVariables
    {
        public string AttributeCode { get; set; }
        public string AttributeName { get; set; }
        public string VariableName { get; set; }
        public string VariableCode { get; set; }
        public DateTime DateSet { get; set; }
        public string CreatedBy { get; set; }

        public static List<AttributesVariables> AttributesVariablesList = new List<AttributesVariables>(new[]
            {
                new AttributesVariables { AttributeCode = "1008", AttributeName = "Plan Ownership Type", VariableCode = "100", VariableName = "Corporate-Wide", DateSet = DateTime.Today, CreatedBy = "Username" },
                new AttributesVariables { AttributeCode = "1008", AttributeName = "Plan Ownership Type", VariableCode = "101", VariableName = "LOB Specific", DateSet = DateTime.Today, CreatedBy = "Username" },
            });
    }
}