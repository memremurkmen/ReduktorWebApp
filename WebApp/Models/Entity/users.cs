//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApp.Models.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class users
    {
        public int userID { get; set; }
        public string username { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public Nullable<int> statusId { get; set; }
        public Nullable<int> timestampId { get; set; }
    
        public virtual status status { get; set; }
        public virtual timestamp timestamp { get; set; }
    }
}
