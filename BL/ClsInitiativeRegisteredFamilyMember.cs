using Domains;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BL
{
    public interface InitiativeRegisteredFamilyMemberService
    {
        List<TbInitiativeRegisteredFamilyMember> getAll();
        bool Add(TbInitiativeRegisteredFamilyMember client);
        bool Edit(TbInitiativeRegisteredFamilyMember client);
        bool Delete(TbInitiativeRegisteredFamilyMember client);


    }
    public class ClsInitiativeRegisteredFamilyMember : InitiativeRegisteredFamilyMemberService
    {
        MarriagedDbContext ctx;

        public ClsInitiativeRegisteredFamilyMember(MarriagedDbContext context)
        {
            ctx = context;
        }
        public List<TbInitiativeRegisteredFamilyMember> getAll()
        {
            //_4ZsoftwareCompanyTestTaskContext o_4ZsoftwareCompanyTestTaskContext = new _4ZsoftwareCompanyTestTaskContext();
            List<TbInitiativeRegisteredFamilyMember> lstInitiativeRegisteredFamilyMembers = ctx.TbInitiativeRegisteredFamilyMembers.ToList();

            return lstInitiativeRegisteredFamilyMembers;
        }

        public bool Add(TbInitiativeRegisteredFamilyMember item)
        {
            try
            {
                //_4ZsoftwareCompanyTestTaskContext o_4ZsoftwareCompanyTestTaskContext = new _4ZsoftwareCompanyTestTaskContext();
                item.CurrentState = 1;
                ctx.TbInitiativeRegisteredFamilyMembers.Add(item);
                ctx.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;

            }
        }
        public bool Edit(TbInitiativeRegisteredFamilyMember item)
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

        public bool Delete(TbInitiativeRegisteredFamilyMember item)
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
