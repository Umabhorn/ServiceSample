using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace WcfBankingService.DataContract
{

    [DataContract]
    public class AccountDTO
    {
        [DataMember] public int ID { get; set; }
        [DataMember] public Nullable<int> User_ID { get; set; }
        [DataMember] public string IBAN { get; set; }
        [DataMember] public Nullable<decimal> TotalBalance { get; set; }
        [DataMember] public Nullable<System.DateTime> UpdateDate { get; set; }
        [DataMember] public Nullable<int> UpdateBy { get; set; }
        [DataMember] public Nullable<bool> IsActive { get; set; }
    }
}
