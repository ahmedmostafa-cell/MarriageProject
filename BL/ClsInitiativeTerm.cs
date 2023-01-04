using Domains;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BL
{
    public interface InitiativeTermService
    {
        List<TbInitiativeTerm> getAll();
        bool Add(TbInitiativeTerm client);
        bool Edit(TbInitiativeTerm client);
        bool Delete(TbInitiativeTerm client);


    }
    public class ClsInitiativeTerm : InitiativeTermService
    {
        MarriagedDbContext ctx;

        public ClsInitiativeTerm(MarriagedDbContext context)
        {
            ctx = context;
        }
        public List<TbInitiativeTerm> getAll()
        {
            //_4ZsoftwareCompanyTestTaskContext o_4ZsoftwareCompanyTestTaskContext = new _4ZsoftwareCompanyTestTaskContext();
            List<TbInitiativeTerm> lstTbInitiativeTerms = ctx.TbInitiativeTerms.ToList();

            return lstTbInitiativeTerms;
        }

        public bool Add(TbInitiativeTerm item)
        {
            try
            {
                //_4ZsoftwareCompanyTestTaskContext o_4ZsoftwareCompanyTestTaskContext = new _4ZsoftwareCompanyTestTaskContext();
                item.CurrentState = 1;
                ctx.TbInitiativeTerms.Add(item);
                ctx.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;

            }
        }
        public bool Edit(TbInitiativeTerm item)
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

        public bool Delete(TbInitiativeTerm item)
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
