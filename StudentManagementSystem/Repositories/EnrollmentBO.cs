using BusinessLib;
using StudentManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace StudentManagementSystem.Repositories
{
    public class EnrollmentBO : IRepository<Enrollment>
    {
        StudentContext ctx = new StudentContext();
        public bool Add(Enrollment item)
        {
            ctx.Enrollments.Add(item);
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

        public bool Delete(Enrollment item)
        {
            Enrollment e = ctx.Enrollments.Find(item.EnrollmentId);
            if (e != null)
            {
                ctx.Enrollments.Remove(e);
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

        public Enrollment Get(object id)
        {
            int enrollmentId = (int)id;
            return ctx.Enrollments.Find(enrollmentId);
        }

        public List<Enrollment> GetAll()
        {
            return ctx.Enrollments.ToList();
        }

        public bool Update(Enrollment item)
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