using BusinessLib;
using StudentManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace StudentManagementSystem.Repositories
{
    public class LoginBO : IRepository<Login>
    {
        StudentContext ctx = new StudentContext();
        public bool Add(Login item)
        {
            ctx.Logins.Add(item);
            int r = ctx.SaveChanges();
            if (r > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Delete(Login item)
        {
            Login l = ctx.Logins.Find(item.LoginId);
            if (l != null)
            {
                ctx.Logins.Remove(l);
                int r = ctx.SaveChanges();
                if (r > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }

        public Login Get(object id)
        {
            string loginId = (string)id;
            return ctx.Logins.Find(loginId);
        }

        public List<Login> GetAll()
        {
                return ctx.Logins.ToList();
        }

        public bool Update(Login item)
        {
                ctx.Entry(item).State = EntityState.Modified;
                int r = ctx.SaveChanges();
                if (r > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
    }
}