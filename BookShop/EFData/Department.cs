//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BookShop.EFData
{
    using System;
    using System.Collections.Generic;
    
    public partial class Department
    {
        public Department()
        {
            this.Projects = new HashSet<Project>();
        }
    
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public int StatusId { get; set; }
    
        public virtual ICollection<Project> Projects { get; set; }
    }
}
