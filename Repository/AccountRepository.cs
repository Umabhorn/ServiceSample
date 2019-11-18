using WcfBankingService.DataContract;
using WcfBankingService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity.Validation;

namespace WcfBankingService.Repository
{
    public class AccountRepository
    {
        public int Add(AccountDTO data)
        {
            try
            {
                var Context = new DB_SYSBANKEntities();
                var STM = new Tbl_Statement();
                var TRS = new Tbl_Transaction();
                var oi = new Tbl_Account();
                oi.User_ID = data.User_ID;
                oi.IBAN = data.IBAN;
                oi.TotalBalance = data.TotalBalance;
                oi.UpdateDate = data.UpdateDate;
                oi.UpdateBy = data.UpdateBy;
                oi.IsActive = data.IsActive;
                if (data.TotalBalance != 0 && data.TotalBalance != null)
                {
                    STM.IBANTo = data.IBAN;
                    STM.FullMoney = data.TotalBalance;
                    STM.Fee = data.TotalBalance * Convert.ToDecimal(0.01);
                    STM.Deposit = data.TotalBalance - STM.Fee;
                    STM.Channel = "Website";
                    STM.CreateDate = DateTime.Now;
                    string ReqNo=Guid.NewGuid().ToString();
                    STM.Req_No = ReqNo;
                   
                    TRS.IBAN = data.IBAN;
                    TRS.FullMoney = data.TotalBalance;
                    TRS.Fee = data.TotalBalance * Convert.ToDecimal(0.01);
                    TRS.Deposit = data.TotalBalance - STM.Fee;
                    TRS.Balance = STM.Deposit;
                    TRS.PrevBalance = 0;
                    TRS.CreateDate = DateTime.Now;
                    TRS.Req_No = ReqNo;

                    oi.TotalBalance = data.TotalBalance - STM.Fee;
                }

                Context.Tbl_Account.Add(oi);
                if (data.TotalBalance != 0 && data.TotalBalance != null)
                {
                  Context.Tbl_Statement.Add(STM);
                    Context.Tbl_Transaction.Add(TRS);
                }
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
        public int Update(AccountDTO data)
        {
            try
            {
                var Context = new DB_SYSBANKEntities();
                var oi = Context.Tbl_Account.FirstOrDefault(i => i.ID == data.ID);
                if (oi != null)
                {

                    oi.User_ID = data.User_ID;
                    oi.IBAN = data.IBAN;
                    oi.TotalBalance = data.TotalBalance;
                    oi.UpdateDate = data.UpdateDate;
                    oi.UpdateBy = data.UpdateBy;
                    oi.IsActive = data.IsActive;
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
        
        public List<AccountDTO> GetAllByUserID(int userid)
        {
            try
            {
                var Context = new DB_SYSBANKEntities();
                var List = (from P in Context.Tbl_Account
                           select new AccountDTO
                           {
                               ID = P.ID,
                               User_ID = P.User_ID,
              IBAN = P.IBAN,
                TotalBalance = P.TotalBalance,
                IsActive = P.IsActive,
                UpdateDate = P.UpdateDate,
                               UpdateBy = P.UpdateBy,
               
                           }).ToList();
                if (userid != 0)
                    List = List.Where(r => r.User_ID == userid).ToList();


                return List;
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
        public AccountDTO GetRecord(int id)
        {
            try
            {
                var Context = new DB_SYSBANKEntities();
                var List = from P in Context.Tbl_Account
                           where (P.ID == id)
                           select new AccountDTO
                           {
                               ID = P.ID,
                               User_ID = P.User_ID,
                               IBAN = P.IBAN,
                               TotalBalance = P.TotalBalance,
                               IsActive = P.IsActive,
                               UpdateDate = P.UpdateDate,
                               UpdateBy = P.UpdateBy,
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

        public AccountDTO GetRecordByIBAN(string iban)
        {
            try
            {
                var Context = new DB_SYSBANKEntities();
                var List = from P in Context.Tbl_Account
                           where (P.IBAN == iban)
                           select new AccountDTO
                           {
                               ID = P.ID,
                               User_ID = P.User_ID,
                               IBAN = P.IBAN,
                               TotalBalance = P.TotalBalance,
                               IsActive = P.IsActive,
                               UpdateDate = P.UpdateDate,
                               UpdateBy = P.UpdateBy,
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
