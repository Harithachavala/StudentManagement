using BusinessLib;
using StudentManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace StudentManagementSystem.Repositories
{
    public class PaymentBO : IRepository<Payment>
    {
        StudentContext ctx = new StudentContext();
        public bool Add(Payment item)
        {
            ctx.Payments.Add(item);
            int result = ctx.SaveChanges();
            return result > 0;
        }

        public bool Delete(Payment item)
        {
            ctx.Payments.Remove(item);
            int result = ctx.SaveChanges();
            return result > 0;
        }
        public Payment Get(object id)
        {
            int pid = (int)id;
            return ctx.Payments.Find(pid);
        }
        public List<Payment> GetAll()
        {
            return ctx.Payments.ToList();
        }
        public bool Update(Payment item)
        {
            ctx.Entry(item).State = EntityState.Modified;
            int result = ctx.SaveChanges();
            return result > 0;
        }
    }
}