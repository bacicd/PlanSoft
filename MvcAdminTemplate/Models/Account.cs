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
    
    public partial class Account
    {
        public string Username { get; set; }
        public int OrgID { get; set; }
        public string First { get; set; }
        public string Last { get; set; }
        public string Role { get; set; }
        public string Password { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public string PasswordSalt { get; set; }
    
        public virtual Organization Organization { get; set; }
        public virtual UserRole UserRole { get; set; }
    }
}
