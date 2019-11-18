using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace WcfBankingService.DataContract
{
    [DataContract]
    public class TransactionDTO
    {
        [DataMember]  public int ID { get; set; }
        [DataMember]  public string IBAN { get; set; }
        [DataMember]  public Nullable<decimal> FullMoney { get; set; }
        [DataMember]  public Nullable<decimal> Fee { get; set; }
        [DataMember]  public Nullable<decimal> Deposit { get; set; }
        [DataMember]  public Nullable<decimal> Withdraw { get; set; }
        [DataMember]  public Nullable<decimal> Balance { get; set; }
        [DataMember]  public Nullable<decimal> PrevBalance { get; set; }
        [DataMember]  public Nullable<System.DateTime> CreateDate { get; set; }
        [DataMember]  public Nullable<int> CreateBy { get; set; }
        [DataMember] public string Req_No { get; set; }
    }
}
