//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MvcAdminTemplate.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class AttributeVariable
    {
        public int Code { get; set; }
        public int ACode { get; set; }
        public string Name { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedOn { get; set; }
    
        public virtual Attribute Attribute { get; set; }
    }
}
