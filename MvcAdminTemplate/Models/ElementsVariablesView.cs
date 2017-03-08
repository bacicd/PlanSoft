using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcAdminTemplate.Models
{
    public class ElementsVariablesView
    {
        public string ElementCode { get; set; }
        public string ElementName { get; set; }
        public string VariableName { get; set; }
        public string VariableCode { get; set; }
        public string VariableCID { get; set; }
        public DateTime DateSet { get; set; }
        public string CreatedBy { get; set; }

        public static List<ElementsVariablesView> ElementsVariablesList = new List<ElementsVariablesView>(new[]
            {
                new ElementsVariablesView { ElementCode = "10", ElementName = "Plan", VariableCode = "1000000", VariableName = "Branch Plan", VariableCID = "B1045", DateSet = DateTime.Today, CreatedBy = "Username" },
                new ElementsVariablesView { ElementCode = "10", ElementName = "Plan", VariableCode = "1001000", VariableName = "Retail Plan", VariableCID = "R3046", DateSet = DateTime.Today, CreatedBy = "Username" },
                new ElementsVariablesView { ElementCode = "10", ElementName = "Plan", VariableCode = "1002000", VariableName = "Wholesale Plan", VariableCID = "B1045", DateSet = DateTime.Today, CreatedBy = "Username" },
                new ElementsVariablesView { ElementCode = "10", ElementName = "Plan", VariableCode = "1002006", VariableName = "Management Plan", VariableCID = "MP", DateSet = DateTime.Today, CreatedBy = "Username" },
                new ElementsVariablesView { ElementCode = "40", ElementName = "Employee", VariableCode = "4000050", VariableName = "Mark Johnson", VariableCID = "465846387", DateSet = DateTime.Today, CreatedBy = "Username" }
            });
    }
}