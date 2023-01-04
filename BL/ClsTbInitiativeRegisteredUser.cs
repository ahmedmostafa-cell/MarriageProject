using Domains;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BL
{
    public interface InitiativeRegisteredUserService
    {
        List<TbInitiativeRegisteredUser> getAll();
        bool Add(TbInitiativeRegisteredUser client);
        bool Edit(TbInitiativeRegisteredUser client);
        bool Delete(TbInitiativeRegisteredUser client);


    }
    public class ClsTbInitiativeRegisteredUser : InitiativeRegisteredUserService
    {
        MarriagedDbContext ctx;

        public ClsTbInitiativeRegisteredUser(MarriagedDbContext context)
        {
            ctx = context;
        }
        public List<TbInitiativeRegisteredUser> getAll()
        {
            //_4ZsoftwareCompanyTestTaskContext o_4ZsoftwareCompanyTestTaskContext = new _4ZsoftwareCompanyTestTaskContext();
            List<TbInitiativeRegisteredUser> lstInitiativeRegisteredUsers = ctx.TbInitiativeRegisteredUsers.ToList();

            return lstInitiativeRegisteredUsers;
        }

        public bool Add(TbInitiativeRegisteredUser item)
        {
            try
            {
                //_4ZsoftwareCompanyTestTaskContext o_4ZsoftwareCompanyTestTaskContext = new _4ZsoftwareCompanyTestTaskContext();
                item.CurrentState = 1;
                ctx.TbInitiativeRegisteredUsers.Add(item);
                ctx.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;

            }
        }
        public bool Edit(TbInitiativeRegisteredUser item)
        {
            try
            {
                //_4ZsoftwareCompanyTestTaskContext o_4ZsoftwareCompanyTestTaskContext = new _4ZsoftwareCompanyTestTaskContext();

                ctx.Entry(item).State = EntityState.Modified;
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;

            }
        }

        public bool Delete(TbInitiativeRegisteredUser item)
        {
            try
            {
                //_4ZsoftwareCompanyTestTaskContext o_4ZsoftwareCompanyTestTaskContext = new _4ZsoftwareCompanyTestTaskContext();

                ctx.Entry(item).State = EntityState.Deleted;
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;

            }
        }
    }
}
