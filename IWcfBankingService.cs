using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WcfBankingService.DataContract;

namespace WcfBankingService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IWcfBankingService" in both code and config file together.
    [ServiceContract]
    public interface IWcfBankingService
    {
        #region Account
        [OperationContract]
        int AddAccount(AccountDTO data);
       [OperationContract]  int UpDateAccount(AccountDTO data);
       [OperationContract]  List<AccountDTO> DataAccountBYUser(int userid);
        [OperationContract] AccountDTO GetAccountBankRecord(int id);
        [OperationContract] AccountDTO GetRecordByIBAN(string iban);
        #endregion


        #region Statement
        [OperationContract]
        int AddStatement(StatementDTO data);
        [OperationContract] int UpDateStatement(StatementDTO data);
        [OperationContract]
        List<StatementDTO> DataStatementByIBAN(string IBAN);

        [OperationContract] StatementDTO GetStatementBankRecord(int id);
        [OperationContract]
        StatementDTO GetRecordByReq(string req);
        #endregion



        #region Transaction
        [OperationContract]
        int AddTransaction(TransactionDTO data);
        [OperationContract] int UpDateTransaction(TransactionDTO data);
        [OperationContract] List<TransactionDTO> GetAllByIBAN(string iban);
        [OperationContract] TransactionDTO GetTransactionBankRecord(int id);
        #endregion


        #region User
        [OperationContract]
        int AddUser(UserDTO data);
        [OperationContract] int UpDateUser(UserDTO data);
        [OperationContract] List<UserDTO> DataUser();
        [OperationContract] UserDTO GetUserBankRecord(int id);
        #endregion


    }
}
