using Domains;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public interface NormalUserService
    {
        List<TbNormalUser> getAll();
        bool Add(TbNormalUser client);
        bool Edit(TbNormalUser client);
        bool Delete(TbNormalUser client);

        Task<bool> AddAsync(TbNormalUser client);


    }
    public class ClsNormalUser : NormalUserService
    {
        MarriagedDbContext ctx;

        public ClsNormalUser(MarriagedDbContext context)
        {
            ctx = context;
        }
        public List<TbNormalUser> getAll()
        {
            //_4ZsoftwareCompanyTestTaskContext o_4ZsoftwareCompanyTestTaskContext = new _4ZsoftwareCompanyTestTaskContext();
            List<TbNormalUser> lstNormalUsers = ctx.TbNormalUsers.ToList();

            return lstNormalUsers;
        }


        public async Task<bool> AddAsync(TbNormalUser client)
        {
            try
            {
                //_4ZsoftwareCompanyTestTaskContext o_4ZsoftwareCompanyTestTaskContext = new _4ZsoftwareCompanyTestTaskContext();
                client.CurrentState = 1;
                await ctx.TbNormalUsers.AddAsync(client);
                await ctx.SaveChangesAsync();

                return  true;
            }
            catch (Exception ex)
            {
              
                return false;
            }
        }

        public bool Add(TbNormalUser item)
        {
            try
            {
                //_4ZsoftwareCompanyTestTaskContext o_4ZsoftwareCompanyTestTaskContext = new _4ZsoftwareCompanyTestTaskContext();
                item.CurrentState = 1;
                ctx.TbNormalUsers.Add(item);
                ctx.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;

            }
        }
        public bool Edit(TbNormalUser item)
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

        public bool Delete(TbNormalUser item)
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
