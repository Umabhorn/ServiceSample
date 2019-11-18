using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace WcfBankingService.DataContract
{
    [DataContract]
    public class UserDTO
    {
        [DataMember]  public int ID { get; set; }
        [DataMember]  public string FirstName { get; set; }
        [DataMember]  public string LastName { get; set; }
        [DataMember]  public string CitizenID { get; set; }
        [DataMember]  public string PassportID { get; set; }
        [DataMember]  public string MobileNo { get; set; }
        [DataMember]  public string EmailAddress { get; set; }
        [DataMember] public Nullable<bool> IsActive { get; set; }
    }
}
