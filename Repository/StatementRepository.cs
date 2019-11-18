using WcfBankingService.DataContract;
using WcfBankingService.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;

namespace WcfBankingService.Repository
{
    public class StatementRepository
    {
        public int Add(StatementDTO data)
        {
            try
            {
                string ReqNo = Guid.NewGuid().ToString();
                var Context = new DB_SYSBANKEntities();
                var oi = new Tbl_Statement();
oi.IBANFrom   = data.IBANFrom;
oi.IBANTo     = data.IBANTo;
oi.FullMoney  = data.FullMoney;
oi.Fee        = data.Fee;
oi.Deposit    = data.Deposit;
oi.Withdraw   = data.Withdraw;

oi.Channel    = data.Channel;
oi.CreateDate = data.CreateDate;
                oi.CreateBy = data.CreateBy;
                oi.Req_No = ReqNo;
                Context.Tbl_Statement.Add(oi);


                var oiAcc = new Tbl_Account();
                var TRST = new Tbl_Transaction();
                var TRS = new Tbl_Transaction();
                var oiAcc2 = new Tbl_Account();
                if (data.IBANFrom != null)
                {
                    TRS.IBAN = data.IBANFrom;
                    TRS.FullMoney = data.FullMoney;
                    TRS.Withdraw = data.FullMoney;
                    TRS.PrevBalance = data.PrevBalanceFrom;
                    TRS.Balance = TRS.PrevBalance - TRS.FullMoney;
                    TRS.CreateDate = DateTime.Now;
                    TRS.CreateBy = data.CreateBy;
                    TRS.Req_No = ReqNo;
                    Context.Tbl_Transaction.Add(TRS);
                    oiAcc2 = Context.Tbl_Account.FirstOrDefault(i => i.IBAN == data.IBANFrom);
                    if (oiAcc2 != null)
                    {
                        if (oiAcc2.TotalBalance != null)
                        {
                            oiAcc2.TotalBalance = oiAcc2.TotalBalance - TRS.FullMoney;
                        }
                        else
                        {
                            oiAcc2.TotalBalance = TRS.FullMoney;
                        }
                        oiAcc2.UpdateBy = data.CreateBy;
                        oiAcc2.UpdateDate = DateTime.Now;
                    }
                    
                }
               
                if (data.IBANTo != null)
                {
                    TRST.IBAN = data.IBANTo;
                    TRST.FullMoney = data.FullMoney;
                    TRST.Fee = data.FullMoney * Convert.ToDecimal(0.01);
                    TRST.Deposit = data.FullMoney - TRST.Fee;
                    TRST.PrevBalance = data.PrevBalanceTo;
                    TRST.Balance = TRST.PrevBalance + TRST.Deposit;
                    TRST.CreateBy = data.CreateBy;
                    TRST.CreateDate = DateTime.Now;
                    TRST.Req_No = ReqNo;
                    Context.Tbl_Transaction.Add(TRST);
                    oiAcc = Context.Tbl_Account.FirstOrDefault(i => i.IBAN == data.IBANTo);
                    if (oiAcc != null)
                    {
                        if (oiAcc.TotalBalance != null)
                        {
 oiAcc.TotalBalance = oiAcc.TotalBalance + TRST.Deposit;
                        }
                        else
                        {
                            oiAcc.TotalBalance =  TRST.Deposit;
                        }
                        oiAcc.UpdateBy = data.CreateBy;
                        oiAcc.UpdateDate = DateTime.Now;
                    }
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
        public int Update(StatementDTO data)
        {
            try
            {
                var Context = new DB_SYSBANKEntities();
                var oi = Context.Tbl_Statement.FirstOrDefault(i => i.ID == data.ID);
                if (oi != null)
                {
                    oi.IBANFrom = data.IBANFrom;
                    oi.IBANTo = data.IBANTo;
                    oi.FullMoney = data.FullMoney;
                    oi.Fee = data.Fee;
                    oi.Deposit = data.Deposit;
                    oi.Withdraw = data.Withdraw;

                    oi.Channel = data.Channel;
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

        public List<StatementDTO> DataStatementByIBAN(string IBAN)
        {
            try
            {
                var Context = new DB_SYSBANKEntities();
                var List = (from P in Context.Tbl_Statement
                           select new StatementDTO
                           {
                               ID = P.ID,
IBANFrom        = P.IBANFrom,
IBANTo          = P.IBANTo,
FullMoney       = P.FullMoney,
Fee             = P.Fee,
Deposit         = P.Deposit,
Withdraw        = P.Withdraw,
Channel         = P.Channel,
CreateDate      = P.CreateDate,
CreateBy        = P.CreateBy,
Req_No =P.Req_No,
                           }).Where(r=>r.IBANFrom == IBAN || r.IBANTo == IBAN).ToList();
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
        public StatementDTO GetRecordByReq(string req)
        {
            try
            {
                var Context = new DB_SYSBANKEntities();
                var List = (from P in Context.Tbl_Statement
                           select new StatementDTO
                           {
                               ID = P.ID,
                               IBANFrom = P.IBANFrom,
                               IBANTo = P.IBANTo,
                               FullMoney = P.FullMoney,
                               Fee = P.Fee,
                               Deposit = P.Deposit,
                               Withdraw = P.Withdraw,
                               Channel = P.Channel,
                               CreateDate = P.CreateDate,
                               CreateBy = P.CreateBy,
                               Req_No = P.Req_No,
                           }).OrderByDescending(r=>r.ID).ToList();
                if (req != null && req != "") List = List.Where(r => r.Req_No == req).ToList(); ;

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
        public StatementDTO GetRecord(int id)
        {
            try
            {
                var Context = new DB_SYSBANKEntities();
                var List = from P in Context.Tbl_Statement
                           where (P.ID == id)
                           select new StatementDTO
                           {
                               ID = P.ID,
                               IBANFrom = P.IBANFrom,
                               IBANTo = P.IBANTo,
                               FullMoney = P.FullMoney,
                               Fee = P.Fee,
                               Deposit = P.Deposit,
                               Withdraw = P.Withdraw,
                               Channel = P.Channel,
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
