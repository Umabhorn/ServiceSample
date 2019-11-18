using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WcfBankingService.DataContract;
using WcfBankingService.Repository;

namespace WcfBankingService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "WcfBankingService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select WcfBankingService.svc or WcfBankingService.svc.cs at the Solution Explorer and start debugging.
    public class WcfBankingService : IWcfBankingService
    {
        #region Account
        public int AddAccount(AccountDTO data)
        {
            try
            {
                var A = new AccountRepository();
                return A.Add(data);

            }
            catch (Exception e)
            {
                throw new FaultException<Exception>(e);
            }
        }
        public int UpDateAccount(AccountDTO data)
        {
            try
            {
                var A = new AccountRepository();
                return A.Update(data);

            }
            catch (Exception e)
            {
                throw new FaultException<Exception>(e);
            }
        }
        public List<AccountDTO> DataAccountBYUser(int userid)
        {
            try
            {
                var A = new AccountRepository();
                return A.GetAllByUserID(userid);

            }
            catch (Exception e)
            {
                throw new FaultException<Exception>(e);
            }
        }
        public AccountDTO GetAccountBankRecord(int id)
        {
            try
            {
                var A = new AccountRepository();
                return A.GetRecord(id);

            }
            catch (Exception e)
            {
                throw new FaultException<Exception>(e);
            }
        }
 public AccountDTO GetRecordByIBAN(string iban)
        {
            try
            {
                var A = new AccountRepository();
                return A.GetRecordByIBAN(iban);

            }
            catch (Exception e)
            {
                throw new FaultException<Exception>(e);
            }
        }
        #endregion

        #region Statement
        public int AddStatement(StatementDTO data)
        {
            try
            {
                var A = new StatementRepository();
                return A.Add(data);

            }
            catch (Exception e)
            {
                throw new FaultException<Exception>(e);
            }
        }
        public int UpDateStatement(StatementDTO data)
        {
            try
            {
                var A = new StatementRepository();
                return A.Update(data);

            }
            catch (Exception e)
            {
                throw new FaultException<Exception>(e);
            }
        }
        public List<StatementDTO> DataStatementByIBAN(string IBAN)
        {
            try
            {
                var A = new StatementRepository();
                return A.DataStatementByIBAN(IBAN);

            }
            catch (Exception e)
            {
                throw new FaultException<Exception>(e);
            }
        }
        public StatementDTO GetStatementBankRecord(int id)
        {
            try
            {
                var A = new StatementRepository();
                return A.GetRecord(id);

            }
            catch (Exception e)
            {
                throw new FaultException<Exception>(e);
            }
        }
 public StatementDTO GetRecordByReq(string req)
        {
            try
            {
                var A = new StatementRepository();
                return A.GetRecordByReq(req);

            }
            catch (Exception e)
            {
                throw new FaultException<Exception>(e);
            }
        }

        #endregion

        #region Transaction
        public int AddTransaction(TransactionDTO data)
        {
            try
            {
                var A = new TransactionRepository();
                return A.Add(data);

            }
            catch (Exception e)
            {
                throw new FaultException<Exception>(e);
            }
        }
        public int UpDateTransaction(TransactionDTO data)
        {
            try
            {
                var A = new TransactionRepository();
                return A.Update(data);

            }
            catch (Exception e)
            {
                throw new FaultException<Exception>(e);
            }
        }
        public List<TransactionDTO> GetAllByIBAN(string iban)
        {
            try
            {
                var A = new TransactionRepository();
                return A.GetAllByIBAN(iban);

            }
            catch (Exception e)
            {
                throw new FaultException<Exception>(e);
            }
        }
        public TransactionDTO GetTransactionBankRecord(int id)
        {
            try
            {
                var A = new TransactionRepository();
                return A.GetRecord(id);

            }
            catch (Exception e)
            {
                throw new FaultException<Exception>(e);
            }
        }


        #endregion

        #region User
        public int AddUser(UserDTO data)
        {
            try
            {
                var A = new UserRepository();
                return A.Add(data);

            }
            catch (Exception e)
            {
                throw new FaultException<Exception>(e);
            }
        }
        public int UpDateUser(UserDTO data)
        {
            try
            {
                var A = new UserRepository();
                return A.Update(data);

            }
            catch (Exception e)
            {
                throw new FaultException<Exception>(e);
            }
        }
        public List<UserDTO> DataUser()
        {
            try
            {
                var A = new UserRepository();
                return A.GetAll();

            }
            catch (Exception e)
            {
                throw new FaultException<Exception>(e);
            }
        }
        public UserDTO GetUserBankRecord(int id)
        {
            try
            {
                var A = new UserRepository();
                return A.GetRecord(id);

            }
            catch (Exception e)
            {
                throw new FaultException<Exception>(e);
            }
        }


        #endregion
    }
}
