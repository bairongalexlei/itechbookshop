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
    
    public partial class Account
    {
        public int AccountId { get; set; }
        public int AccountTypeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ChineseName { get; set; }
        public string Title { get; set; }
        public string SpouseFirstName { get; set; }
        public string OrganizationName { get; set; }
        public int AddressId { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public int StatusId { get; set; }
        public Nullable<int> LanguageId { get; set; }
    }
}
