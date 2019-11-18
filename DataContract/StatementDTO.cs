using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace WcfBankingService.DataContract
{
    [DataContract]
    public class StatementDTO
    {
       [DataMember]   public int ID { get; set; }
       [DataMember]   public string IBANFrom { get; set; }
       [DataMember]   public string IBANTo { get; set; }
       [DataMember]   public Nullable<decimal> FullMoney { get; set; }
       [DataMember]   public Nullable<decimal> Fee { get; set; }
       [DataMember]   public Nullable<decimal> Deposit { get; set; }
       [DataMember]   public Nullable<decimal> Withdraw { get; set; }
       [DataMember]   public Nullable<decimal> Balance { get; set; }
       [DataMember]   public string Channel { get; set; }
       [DataMember]   public Nullable<System.DateTime> CreateDate { get; set; }
        [DataMember] public Nullable<int> CreateBy { get; set; }
  [DataMember]   public string Req_No { get; set; }

        [DataMember] public Nullable<decimal> PrevBalanceFrom { get; set; }

        [DataMember] public Nullable<decimal> PrevBalanceTo { get; set; }

    }
}
