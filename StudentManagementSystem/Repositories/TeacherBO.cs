using BusinessLib;
using StudentManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace StudentManagementSystem.Repositories
{
    public class TeacherBO : IRepository<Teacher>
    {
        StudentContext ctx = new StudentContext();
        public bool Add(Teacher item)
        {
            ctx.Teachers.Add(item);
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

        public bool Delete(Teacher item)
        {
            Teacher t = ctx.Teachers.Find(item.TeacherId);
            ctx.Teachers.Remove(t);
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

        public Teacher Get(object id)
        {
            string teacherId = (string)id;
            return ctx.Teachers.Find(teacherId);
        }

        public List<Teacher> GetAll()
        {
            return ctx.Teachers.ToList();
        }

        public bool Update(Teacher item)
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