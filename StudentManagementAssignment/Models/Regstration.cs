//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace StudentManagementAssignment.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Regstration
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string nic { get; set; }
        public int Course_ID { get; set; }
        public int Batch_ID { get; set; }
        public Nullable<int> Phone { get; set; }
    
        public virtual Batch Batch { get; set; }
        public virtual Course Course { get; set; }
    }
}