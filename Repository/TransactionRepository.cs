using WcfBankingService.DataContract;
using WcfBankingService.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;

namespace WcfBankingService.Repository
{
    public class TransactionRepository
    {
        public int Add(TransactionDTO data)
        {
            try
            {
                var Context = new DB_SYSBANKEntities();
                var oi = new Tbl_Transaction();

                oi.IBAN = data.IBAN;
 oi.FullMoney       = data.FullMoney;
 oi.Fee             = data.Fee;
 oi.Deposit         = data.Deposit;
 oi.Withdraw        = data.Withdraw;
 oi.Balance         = data.Balance;
 oi.PrevBalance     = data.PrevBalance;
 oi.CreateDate      = data.CreateDate;
 oi.CreateBy        = data.CreateBy;
                oi.Req_No = data.Req_No;


                Context.Tbl_Transaction.Add(oi);
                int result = Context.SaveChanges();
                return result;
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    var _Name = eve.Entry.Entity.GetType().Name;
                    var State = eve.Entry.State;
                    foreach (var ve in eve.ValidationErrors)
                    {
                        var pName = ve.PropertyName;
                        var Msg = ve.ErrorMessage;
                    }
                }
                throw;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public int Update(TransactionDTO data)
        {
            try
            {
                var Context = new DB_SYSBANKEntities();
                var oi = Context.Tbl_Transaction.FirstOrDefault(i => i.ID == data.ID);
                if (oi != null)
                {
                    oi.IBAN = data.IBAN;
                    oi.FullMoney = data.FullMoney;
                    oi.Fee = data.Fee;
                    oi.Deposit = data.Deposit;
                    oi.Withdraw = data.Withdraw;
                    oi.Balance = data.Balance;
                    oi.PrevBalance = data.PrevBalance;
                    oi.CreateDate = data.CreateDate;
                    oi.CreateBy = data.CreateBy;
                    oi.Req_No = data.Req_No;
                }
                return Context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    var _Name = eve.Entry.Entity.GetType().Name;
                    var State = eve.Entry.State;
                    foreach (var ve in eve.ValidationErrors)
                    {
                        var pName = ve.PropertyName;
                        var Msg = ve.ErrorMessage;
                    }
                }
                throw;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<TransactionDTO> GetAllByIBAN(string iban)
        {
            try
            {
                var Context = new DB_SYSBANKEntities();
                var List = (from P in Context.Tbl_Transaction
                           select new TransactionDTO
                           {
                               ID = P.ID,
IBAN            = P.IBAN,
FullMoney       = P.FullMoney,
Fee             = P.Fee,
Deposit         = P.Deposit,
Withdraw        = P.Withdraw,
Balance         = P.Balance,
PrevBalance     = P.PrevBalance,
CreateDate      = P.CreateDate,
CreateBy        = P.CreateBy,
Req_No = P.Req_No,

                           }).Where(r=>r.IBAN==iban).ToList();
                return List.ToList();
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    var _Name = eve.Entry.Entity.GetType().Name;
                    var State = eve.Entry.State;
                    foreach (var ve in eve.ValidationErrors)
                    {
                        var pName = ve.PropertyName;
                        var Msg = ve.ErrorMessage;
                    }
                }
                throw;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public TransactionDTO GetRecord(int id)
        {
            try
            {
                var Context = new DB_SYSBANKEntities();
                var List = from P in Context.Tbl_Transaction
                           where (P.ID == id)
                           select new TransactionDTO
                           {
                               ID = P.ID,
                               IBAN = P.IBAN,
                               FullMoney = P.FullMoney,
                               Fee = P.Fee,
                               Deposit = P.Deposit,
                               Withdraw = P.Withdraw,
                               Balance = P.Balance,
                               PrevBalance = P.PrevBalance,
                               CreateDate = P.CreateDate,
                               CreateBy = P.CreateBy,
                               Req_No = P.Req_No,
                           };
                return List.FirstOrDefault();
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    var _Name = eve.Entry.Entity.GetType().Name;
                    var State = eve.Entry.State;
                    foreach (var ve in eve.ValidationErrors)
                    {
                        var pName = ve.PropertyName;
                        var Msg = ve.ErrorMessage;
                    }
                }
                throw;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
