using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcAdminTemplate.Models
{
    public class PlansViewModel 
    {
        public string PlanID { get; set; }
        public string PlanName { get; set; }
        public string CompensationManager { get; set; }
        public string CompensationAdvisor { get; set; }
        public string PlanAdmin { get; set; }
        public string PlanStatus { get; set; }

        public static List<PlansViewModel> PlansList = new List<PlansViewModel>(new[]
            {
               new PlansViewModel { PlanID = "1000", PlanName = "Plan1", CompensationManager = "John Doe", CompensationAdvisor = "Joe Schmo", PlanAdmin  = "Mike Jackson", PlanStatus = "Active"},
               new PlansViewModel { PlanID = "2000", PlanName = "Plan2", CompensationManager = "John Doe", CompensationAdvisor = "Joe Schmo", PlanAdmin  = "Mike Jackson", PlanStatus = "Active"},
               new PlansViewModel { PlanID = "3000", PlanName = "Plan3", CompensationManager = "John Doe", CompensationAdvisor = "Joe Schmo", PlanAdmin  = "Mike Jackson", PlanStatus = "Active"}
            });
    }
}
