using BusinessLib;
using StudentManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace StudentManagementSystem.Repositories
{
    public class GradeBO : IRepository<Grade>
    {
        StudentContext ctx = new StudentContext();
        public bool Add(Grade item)
        {
            ctx.Grades.Add(item);
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

        public bool Delete(Grade item)
        {
            Grade g = ctx.Grades.Find(item.GradeId);
            if (g != null)
            {
                ctx.Grades.Remove(g);
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

        public Grade Get(object id)
        {
            string gradeId = (string)id;
            return ctx.Grades.Find(gradeId);
        }

        public List<Grade> GetAll()
        {
            return ctx.Grades.ToList();
        }

        public bool Update(Grade item)
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