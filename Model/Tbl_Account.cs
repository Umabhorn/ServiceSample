//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WcfBankingService.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Tbl_Account
    {
        public int ID { get; set; }
        public Nullable<int> User_ID { get; set; }
        public string IBAN { get; set; }
        public Nullable<decimal> TotalBalance { get; set; }
        public Nullable<System.DateTime> UpdateDate { get; set; }
        public Nullable<int> UpdateBy { get; set; }
        public Nullable<bool> IsActive { get; set; }
    
        public virtual Tbl_User Tbl_User { get; set; }
    }
}
