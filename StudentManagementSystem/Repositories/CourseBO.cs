using BusinessLib;
using StudentManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace StudentManagementSystem.Repositories
{
    public class CourseBO : IRepository<Course>
    {
        StudentContext ctx = new StudentContext();
        public bool Add(Course item)
        {
            ctx.Courses.Add(item);
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

        public bool Delete(Course item)
        {
            Course c = ctx.Courses.Find(item.CourseId);
            if (c != null)
            {
                ctx.Courses.Remove(c);
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

        public Course Get(object id)
        {
            int courseId = (int)id;
            return ctx.Courses.Find(courseId);
        }

        public List<Course> GetAll()
        {
            return ctx.Courses.ToList();
        }

        public bool Update(Course item)
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