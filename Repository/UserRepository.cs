using WcfBankingService.DataContract;
using WcfBankingService.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;

namespace WcfBankingService.Repository
{
    public class UserRepository
    {
        public int Add(UserDTO data)
        {
            try
            {
                var Context = new DB_SYSBANKEntities();
                var oi = new Tbl_User();
oi.FirstName        = data.FirstName;
oi.LastName         = data.LastName;
oi.CitizenID        = data.CitizenID;
oi.PassportID       = data.PassportID;
oi.MobileNo         = data.MobileNo;
oi.EmailAddress     = data.EmailAddress;
                oi.IsActive = data.IsActive;


                Context.Tbl_User.Add(oi);
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
        public int Update(UserDTO data)
        {
            try
            {
                var Context = new DB_SYSBANKEntities();
                var oi = Context.Tbl_User.FirstOrDefault(i => i.ID == data.ID);
                if (oi != null)
                {
                    oi.FirstName = data.FirstName;
                    oi.LastName = data.LastName;
                    oi.CitizenID = data.CitizenID;
                    oi.PassportID = data.PassportID;
                    oi.MobileNo = data.MobileNo;
                    oi.EmailAddress = data.EmailAddress;
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

        public List<UserDTO> GetAll()
        {
            try
            {
                var Context = new DB_SYSBANKEntities();
                var List = from P in Context.Tbl_User
                           select new UserDTO
                           {
                               ID = P.ID,
FirstName       = P.FirstName,
LastName        = P.LastName,
CitizenID       = P.CitizenID,
PassportID      = P.PassportID,
MobileNo        = P.MobileNo,
EmailAddress    = P.EmailAddress,
IsActive        = P.IsActive,

                           };
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
        public UserDTO GetRecord(int id)
        {
            try
            {
                var Context = new DB_SYSBANKEntities();
                var List = from P in Context.Tbl_User
                           where (P.ID == id)
                           select new UserDTO
                           {
                               ID = P.ID,
                               FirstName = P.FirstName,
                               LastName = P.LastName,
                               CitizenID = P.CitizenID,
                               PassportID = P.PassportID,
                               MobileNo = P.MobileNo,
                               EmailAddress = P.EmailAddress,
                               IsActive = P.IsActive,
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
